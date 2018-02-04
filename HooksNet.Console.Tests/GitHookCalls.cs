namespace HooksNet.Console.Tests
{
    public static class GitHookCalls
    {
        public static void Reset()
        {
            OnPreCommitCalled = 0;
        }

        public static int OnPreCommitCalled { get; set; }

    }
}