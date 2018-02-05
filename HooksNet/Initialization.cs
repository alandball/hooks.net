using System.IO;
using System.Reflection;

namespace HooksNet
{
    public static class Initialization
    {
        public static void InitHooksNet(Assembly assembly = null)
        {
            if (assembly == null)
                assembly = Assembly.GetCallingAssembly();

            var root = new FileInfo(assembly.Location).FullName;
            var originalPath = root;

            while (!Directory.Exists(Path.Combine(root, ".git")))
            {
                var info = new DirectoryInfo(root);
                if (info.Parent == null)
                    throw new NoGitRepositoryFoundException(originalPath);

                root = new DirectoryInfo(root).Parent.FullName;
            }

            var util = new GitUtil(root, assembly);
            util.CreateHooks();
        }
    }
}