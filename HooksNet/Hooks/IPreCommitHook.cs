using System.Collections.Generic;

namespace HooksNet
{
    public interface IPreCommitHook : IGitHook
    {
        void OnPreCommit();
    }
}