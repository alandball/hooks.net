namespace HooksNet.Hooks
{
    public interface IPrepareCommitMessageHook : IGitHook
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message">Commit message</param>
        /// <param name="source">Commit messages source </param>
        /// <returns>New commit message</returns>
        string OnPrepareCommitMessage(string message, CommitMessageSource source);
    }
}