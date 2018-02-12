using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace HooksNet.Utils
{
    static class ProcessRunner
    {
        internal static ProcessResult Run(string name, string arguments)
        {
            var result = new ProcessResult();
            var procStartInfo =
                new ProcessStartInfo(name, arguments)
                {
                    WorkingDirectory = new FileInfo(Assembly.GetCallingAssembly().Location).DirectoryName,
                    RedirectStandardOutput = true
                };

            var process = Process.Start(procStartInfo);
            process.WaitForExit();
            result.ExitCode = process.ExitCode;
            result.Output = process.StandardOutput.ReadToEnd();

            return result;
        }
    }
}