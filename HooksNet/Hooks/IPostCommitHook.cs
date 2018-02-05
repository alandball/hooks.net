namespace HooksNet.Hooks
{
    public interface IPostCommitHook : IGitHook
    {
        void OnPostCommit();
    }
}