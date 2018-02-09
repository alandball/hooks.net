using System.IO;
using System.Reflection;

namespace HooksNet.Tests
{
    public class TestsUtils
    {
        internal static string GetHookPath(string hookName)
        {
            var gitPath = GetGitPath();
            return Path.Combine(gitPath, "hooks", hookName);
        }

        internal static string GetGitPath()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var root = new FileInfo(assembly.Location).FullName;

            while (!Directory.Exists(Path.Combine(root, ".git")))
            {
                var info = new DirectoryInfo(root);
                if (info.Parent == null)
                    return null;

                root = new DirectoryInfo(root).Parent.FullName;
            }

            return Path.Combine(root, ".git");
        }
    }
}