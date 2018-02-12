using System.Collections.Generic;

namespace HooksNet.HookContext
{
    public class GitHookContext
    {
        private readonly List<string> _commandsToRun;


        public GitHookContext()
        {
            _commandsToRun =  new List<string>();
        }

        public void RunProcess()
        {

        }

        public void RunGitCommand(string command)
        {
            _commandsToRun.Add(command);
        }
    }
}