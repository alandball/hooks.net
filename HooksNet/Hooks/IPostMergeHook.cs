namespace HooksNet
{
    public interface IPostMergeHook : IGitHook
    {
        void OnPostMerge();
    }
}