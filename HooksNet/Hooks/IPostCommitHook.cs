using System.Collections.Generic;

namespace HooksNet
{

    public interface IPostCommitHook : IGitHook
    {
        void OnPostCommit();
    }
}