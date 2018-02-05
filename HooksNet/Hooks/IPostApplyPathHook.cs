using System.Collections.Generic;

namespace HooksNet
{

    public interface IPostApplyPathHook : IGitHook
    {
        void OnPostApplyPatch();
    }


}