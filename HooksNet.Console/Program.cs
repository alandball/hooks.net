using System;
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

            try
            {
                HandleHooks(fileParseResult);
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e);
                Environment.ExitCode = 1;
            }
           
        }

        private static void HandleHooks(GitHookContext fileParseResult)
        {
            var assembly = Assembly.LoadFrom(fileParseResult.AssemblyPath);
            var types = assembly.GetTypes().Where(o => !o.IsInterface && typeof(IGitHook).IsAssignableFrom(o));

            foreach (var type in types)
            {
                HandleHook(fileParseResult, type);
            }
        }

        static string GetArg(string key, string[] args)
        {
            var argKey = "--" + key + "=";
            return args.FirstOrDefault(o => o.StartsWith(argKey, StringComparison.CurrentCultureIgnoreCase))
                ?.Substring(argKey.Length);
        }

        static void HandleHook(GitHookContext context, Type type)
        {
            var handler = GetHandler(context);
            handler.Handle(type);
        }

        static BaseHookHandler GetHandler(GitHookContext context)
        {
            switch (context.Type)
            {
                case HookType.PreCommit:
                    return new PreCommitHookHandler(context);
                default:
                    throw new NotSupportedException();
            }
        }
    }
}
