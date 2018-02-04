namespace HooksNet.Console.Tests
{
    public class GitHooksFixture : IPreCommitHook
    {
        public int OnPreCommitCalled { get; set; }

        public void OnPreCommit()
        {
            GitHookCalls.OnPreCommitCalled++;
        }
    }
}