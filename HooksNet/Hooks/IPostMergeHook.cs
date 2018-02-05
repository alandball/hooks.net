namespace HooksNet.Hooks
{
    public interface IPostMergeHook : IGitHook
    {
        void OnPostMerge();
    }
}