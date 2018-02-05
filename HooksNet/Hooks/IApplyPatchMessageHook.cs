using System.Collections.Generic;

namespace HooksNet
{

    public interface IApplyPatchMessageHook : IGitHook
    {
        void OnApplyPathMessage();
    }


}