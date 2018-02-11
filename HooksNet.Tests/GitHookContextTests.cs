using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HooksNet.Tests
{
    [TestClass]
    public class GitHookContextTests
    {
        private GitHookContext _target;
        private string _tempFile;

        [TestInitialize]
        public void Initialize()
        {
            _target = new GitHookContext();
            _tempFile = Path.GetTempFileName();
        }

        [TestMethod]
        public void Run()
        {
          
        }

        [TestCleanup]
        public void Cleanup()
        {
            File.Delete(_tempFile);
        }
    }
}
