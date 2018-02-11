namespace HooksNet.Hooks
{
    public interface ICommitMessageHook : IGitHook
    {
        /// <summary>
        /// Commit message hook
        /// </summary>
        /// <param name="message">Commit message</param>
        /// <returns>Returns new commit message</returns>
        string OnCommitMessage(string message);
    }
}