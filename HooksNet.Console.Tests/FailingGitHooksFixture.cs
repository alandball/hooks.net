using HooksNet.Hooks;

namespace HooksNet.Console.Tests
{
    public class FailingGitHooksFixture : IPreCommitHook
    {
        public void OnPreCommit(PreCommitHookContext context)
        {
           
        }
    }
}