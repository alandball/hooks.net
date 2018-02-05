using HooksNet.Hooks;

namespace HooksNet
{
    public interface ICommitMessageHook : IGitHook
    {
        void OnCommitMessage();
    }
}