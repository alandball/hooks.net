using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace HooksNet
{
    internal class GitUtil
    {
        private readonly string _rootPath;
        private readonly Assembly _assembly;

        public GitUtil(string rootPath, Assembly assembly)
        {
            _rootPath = rootPath;
            _assembly = assembly;
        }

        public bool IsGitRepository()
        {
            return Directory.Exists(Path.Combine(_rootPath, ".git"));
        }

        private string GetHooksDirectory()
        {
            return Path.Combine(_rootPath, ".git", "hooks");
        }

        public void CreateHooks()
        {
            if (!IsGitRepository())
                throw new NoGitRepositoryFoundException(_rootPath);

            var executingAssembly = Assembly.GetExecutingAssembly();

            var assemblyLocation = new FileInfo(executingAssembly.Location);
            var consoleLocation = Path.Combine(assemblyLocation.DirectoryName, "HooksNet.Console.dll");

            var types = new List<string>
            {
                "pre-commit"
            };

            foreach (var type in types)
            {
                var hooksDirectory = GetHooksDirectory();
                var hookPath = Path.Combine(hooksDirectory, type);

                if(File.Exists(hookPath))
                    File.Delete(hookPath);

                using (var writer = File.CreateText(hookPath))
                {
                    writer.Write($"dotnet {consoleLocation} --type=\"{type}\" --assembly=\"{_assembly.Location}\"");
                }
            }
        }
    }
}