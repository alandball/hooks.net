using System.Collections.Generic;

namespace HooksNet
{

    public interface IRebaseHook : IGitHook
    {
        void OnRebase();
    }
}