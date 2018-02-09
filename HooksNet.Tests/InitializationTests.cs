using System;
using System.IO;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HooksNet.Tests
{
    [TestClass]
    public class InitializationTests
    {
        [TestMethod]
        public void Init_CreatesPerCommitHook()
        {
            Initialization.InitHooksNet(Assembly.GetExecutingAssembly());

            var hookPath = TestsUtils.GetHookPath("pre-commit");
            Assert.IsTrue(File.Exists(hookPath));

            var content = File.ReadAllText(hookPath);
            Console.Write(content);
            File.Delete(hookPath);
        }
    }
}
