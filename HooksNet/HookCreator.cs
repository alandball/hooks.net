using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace HooksNet
{
    internal class HookCreator
    {
        private readonly Assembly _assembly;
        private readonly string _rootPath;

        public HookCreator(string rootPath, Assembly assembly)
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

        private string ConvertToBashPath(string path)
        {
            return path.Replace("\\", "/");
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

            var hooksDirectory = GetHooksDirectory();
            foreach (var type in types) CreateHook(hooksDirectory, type, consoleLocation);
        }

        private void CreateHook(string hooksDirectory, string type, string consoleLocation)
        {
            var hookPath = Path.Combine(hooksDirectory, type);

            if (File.Exists(hookPath))
                File.Delete(hookPath);

            using (var writer = File.CreateText(hookPath))
            {
                var template = TemplateUtil.ReadTemplate(type);

                template = template.Replace("{console}", ConvertToBashPath(consoleLocation));
                template = template.Replace("{type}", type);
                template = template.Replace("{assembly}", ConvertToBashPath(_assembly.Location));

                writer.Write(template);
            }
        }
    }
}