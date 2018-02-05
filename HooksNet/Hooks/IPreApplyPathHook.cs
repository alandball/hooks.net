using System.Collections.Generic;

namespace HooksNet
{

    public interface IPreApplyPathHook : IGitHook
    {
        void OnPreApplyPatch();
    }


}