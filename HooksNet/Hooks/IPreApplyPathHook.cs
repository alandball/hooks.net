using HooksNet.Hooks;

namespace HooksNet
{
    public interface IPreApplyPathHook : IGitHook
    {
        void OnPreApplyPatch();
    }
}