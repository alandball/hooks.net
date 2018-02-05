namespace HooksNet.Hooks
{
    public interface IPreCommitHook : IGitHook
    {
        void OnPreCommit();
    }
}