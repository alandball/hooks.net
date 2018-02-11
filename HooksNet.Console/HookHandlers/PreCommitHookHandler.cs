using System;
using HooksNet.Hooks;

namespace HooksNet.Console
{
    public class PreCommitHookHandler : BaseHookHandler<IPreCommitHook>
    {
        readonly GitHookContext _context;

        public PreCommitHookHandler(GitHookContext context)
        {
            _context = context;
        }

        public override void Handle(Type type)
        {
            var instance = CreateInstance(type);
            instance?.OnPreCommit(new PreCommitHookContext(_context.Files));
        }
    }
}