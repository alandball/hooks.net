namespace HooksNet.Hooks
{
    public interface IPrepareCommitMessageHook : IGitHook
    {
        void OnPrepareCommitMessage(string message, CommitMessageSource source);
    }
}