using System.Collections.Generic;

namespace HooksNet.Console.Tests
{
    public static class GitHookCalls
    {
        public static List<PreCommitHookContext> PreCommitCalls { get; set; }

        static GitHookCalls()
        {
            PreCommitCalls = new List<PreCommitHookContext>();
        }

        public static void Reset()
        {
            PreCommitCalls = new List<PreCommitHookContext>();
        }

    }
}