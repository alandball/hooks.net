namespace HooksNet.Hooks
{
    public interface IApplyPatchMessageHook : IGitHook
    {
        void OnApplyPathMessage();
    }
}