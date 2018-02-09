using System.Collections.Generic;
using HooksNet.Hooks;

namespace HooksNet.Console.Tests
{
    using System.Collections.Generic;

    public class GitHooksFixture : IPreCommitHook
    {

        public void OnPreCommit(PreCommitHookContext context)
        {
            GitHookCalls.PreCommitCalls.Add(context);
        }
    }
}