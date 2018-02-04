using System.Collections.Generic;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HooksNet.Console.Tests
{
    [TestClass]
    public class MainTests
    {
        [TestMethod]
        public void Run_PreCommit_Called()
        {
            var path = Assembly.GetExecutingAssembly().Location;
            var args = new List<string>();
            args.Add($"--assembly={path}");
            args.Add("--type=pre-commit");
            GitHookCalls.Reset();

            Program.Main(args.ToArray());
            Assert.AreEqual(1, GitHookCalls.OnPreCommitCalled);
        }
    }
}
