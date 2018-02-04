using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace HooksNet
{
    public static class Initialization
    {
        public static void InitHooksNet(Assembly assembly = null)
        {
            if (assembly == null)
                assembly = Assembly.GetCallingAssembly();

            string root = new FileInfo(assembly.Location).FullName;
            string originalPath = root;

            while (!Directory.Exists(Path.Combine(root, ".git")))
            {
                var info = new DirectoryInfo(root);
                if(info.Parent == null)
                    throw new NoGitRepositoryFoundException(originalPath);

                root = new DirectoryInfo(root).Parent.FullName;
            }
          
            var util = new GitUtil(root, assembly);
            util.CreateHooks();
        }
    }
}
