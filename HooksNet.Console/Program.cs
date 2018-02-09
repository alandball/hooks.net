using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using HooksNet.Hooks;

namespace HooksNet.Console
{
    class Program
    {
        internal static void Main(string[] args)
        {
            var file = GetArg("file", args);
            var fileContent = File.ReadAllText(file);
            var fileParseResult = FileParser.ProcessFileContent(fileContent);

            var assembly = Assembly.LoadFrom(fileParseResult.AssemblyPath);
            var types = assembly.GetTypes().Where(o => !o.IsInterface && typeof(IGitHook).IsAssignableFrom(o));

            foreach (var type in types)
            {
               HandleHook(fileParseResult, type);
            }
        }

        public static string GetArg(string key, string[] args)
        {
            var argKey = "--" + key + "=";
            return args.FirstOrDefault(o => o.StartsWith(argKey, StringComparison.CurrentCultureIgnoreCase))
                ?.Substring(argKey.Length);
        }

        private static void HandleHook(GitHookContext context, Type type)
        {
            if (context.Type == HookType.PreCommit)
            {
                var hasPreCommitHook = type.GetInterfaces().Any(o => o == typeof(IPreCommitHook));
                if (hasPreCommitHook)
                {
                    var preCommitHook = (IPreCommitHook)Activator.CreateInstance(type);
                    preCommitHook.OnPreCommit(new PreCommitHookContext(context.Files));
                }
            }
        }
    }
}
