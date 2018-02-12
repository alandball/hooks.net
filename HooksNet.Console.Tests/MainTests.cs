using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HooksNet.Console.Tests
{
    [TestClass]
    public class MainTests
    {
        private string _tempFile;

        [TestInitialize]
        public void Initialize()
        {
            GitHookCalls.FailCall = false;
        }

        [TestCleanup]
        public void Cleanup()
        {
            Environment.ExitCode = 0;
            if (File.Exists(_tempFile))
                File.Delete(_tempFile);
        }

        [TestMethod]

        public void Run_PreCommit_Called_Failed()
        {
            GitHookCalls.FailCall = true;
            CreateTempFile();

            Program.Main(new[] { $"--file={_tempFile}" });

            Assert.AreEqual(1, Environment.ExitCode);

        }

        [TestMethod]
        public void Run_PreCommit_Called()
        {
            CreateTempFile();

            Program.Main(new[] { $"--file={_tempFile}" });

            Assert.AreEqual(1, GitHookCalls.PreCommitCalls.Count);
            var call = GitHookCalls.PreCommitCalls[0];
            Assert.AreEqual(4, call.StagedFiles.Count);
            Assert.IsTrue(call.StagedFiles.Any(o => o.ChangeType == ChangeType.Add && o.Path == "HooksNet.Console/Added.cs"));
            Assert.IsTrue(call.StagedFiles.Any(o => o.ChangeType == ChangeType.Modify && o.Path == "HooksNet.Console/Modified.cs"));
            Assert.IsTrue(call.StagedFiles.Any(o => o.ChangeType == ChangeType.Delete && o.Path == "HooksNet.Tests/Deleted.txt"));
            Assert.IsTrue(call.StagedFiles.Any(o => o.ChangeType == ChangeType.Rename && o.Path == "HooksNet/Renamed.js"));
            Assert.AreEqual(0, Environment.ExitCode);
        }

        private void CreateTempFile()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var stream = assembly.GetManifestResourceStream("HooksNet.Console.Tests.TestFiles.PreCommitTestFile.txt");
            using (var reader = new StreamReader(stream))
            {
                _tempFile = Path.GetTempFileName();
                var fileContent = reader.ReadToEnd();
                fileContent = fileContent.Replace("{assembly}", assembly.Location);

                File.WriteAllText(_tempFile, fileContent);
            }
        }
    }
}
