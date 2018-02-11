using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace HooksNet
{
    public class GitHookContext
    {
        public string RunProcess(string name, string arguments)
        {
            ProcessStartInfo procStartInfo =
                new ProcessStartInfo(name, arguments);
            procStartInfo.WorkingDirectory = new FileInfo(Assembly.GetCallingAssembly().Location).DirectoryName;

            var process = Process.Start(procStartInfo);
            var result = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            return result;
        }
    }
}