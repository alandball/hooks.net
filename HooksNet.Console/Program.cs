using System;
using System.Linq;
using System.Reflection;
using HooksNet.Hooks;

namespace HooksNet.Console
{
    class Program
    {
        internal static void Main(string[] args)
        {
            var assemblyFile = GetArg("assembly", args);
            var hookType = GetArg("type", args);
            if (String.IsNullOrWhiteSpace(assemblyFile))
                throw new ApplicationException("Assembly not defined");

            System.Console.WriteLine(assemblyFile);
            var assembly = Assembly.LoadFrom(assemblyFile);
            var types = assembly.GetTypes().Where(o => !o.IsInterface && typeof(IGitHook).IsAssignableFrom(o));

            foreach (var type in types)
            {
                HandlePreCommit(hookType, type);
            }
        }

        public static string GetArg(string key, string[] args)
        {
            var argKey = "--" + key + "=";
            return args.FirstOrDefault(o => o.StartsWith(argKey, StringComparison.CurrentCultureIgnoreCase))
                ?.Substring(argKey.Length);
        }

        private static void HandlePreCommit(string hookType, Type type)
        {
            if (hookType == "pre-commit")
            {
                var hasPreCommitHook = type.GetInterfaces().Any(o => o == typeof(IPreCommitHook));
                if (hasPreCommitHook)
                {
                    var preCommitHook = (IPreCommitHook) Activator.CreateInstance(type);
                    preCommitHook.OnPreCommit();
                }
            }
        }
    }
}
