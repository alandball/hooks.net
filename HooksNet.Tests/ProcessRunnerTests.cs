using System;
using System.IO;
using HooksNet.HookContext;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HooksNet.Tests
{
    [TestClass]
    public class ProcessRunnerTests
    {
        private string _tempFile;

        [TestInitialize]
        public void Initialize()
        {
            _tempFile = Path.ChangeExtension(Path.GetTempFileName(), "bat");
            File.CreateText(_tempFile).Close();
        }

        [TestMethod]
        public void Run_ExitCode_0()
        {
            string command = "echo \"hello\"" + Environment.NewLine + "exit 0";
            File.AppendAllText(_tempFile, command);
            var result = ProcessRunner.Run("cmd", GetArguments());
            Assert.AreEqual(0, result.ExitCode);
            Console.WriteLine(result.Output);
        }

        [TestMethod]
        public void Run_ExitCode_1()
        {
            string command = "echo \"hello\"" + Environment.NewLine + "exit 1";
            File.AppendAllText(_tempFile, command);
            var result = ProcessRunner.Run("cmd", GetArguments());
            Assert.AreEqual(1, result.ExitCode);
        }

        private string GetArguments()
        {
            return $"/c {_tempFile}";
        }

        [TestCleanup]
        public void Cleanup()
        {
            File.Delete(_tempFile);
            File.Delete(Path.ChangeExtension(_tempFile, "tmp"));
        }
    }
}