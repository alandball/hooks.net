namespace HooksNet.Hooks
{
    public interface IPostApplyPathHook : IGitHook
    {
        void OnPostApplyPatch();
    }
}