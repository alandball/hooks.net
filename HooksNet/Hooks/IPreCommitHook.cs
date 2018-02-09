namespace HooksNet.Hooks
{
    using System.Collections.Generic;

    public interface IPreCommitHook : IGitHook
    {
        void OnPreCommit(PreCommitHookContext context);
    }
}