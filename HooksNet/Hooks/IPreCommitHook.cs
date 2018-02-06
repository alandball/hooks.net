namespace HooksNet.Hooks
{
    using System.Collections.Generic;

    public interface IPreCommitHook : IGitHook
    {
        void OnPreCommit(List<StagedChange> stagedFiles);
    }
}