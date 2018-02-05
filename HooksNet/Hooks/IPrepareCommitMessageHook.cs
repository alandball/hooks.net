namespace HooksNet
{
    public interface IPrepareCommitMessageHook : IGitHook
    {
        void OnPrepareCommitMessage();
    }
}