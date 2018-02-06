namespace HooksNet.Hooks
{
    public interface ICommitMessageHook : IGitHook
    {
        void OnCommitMessage();
    }
}