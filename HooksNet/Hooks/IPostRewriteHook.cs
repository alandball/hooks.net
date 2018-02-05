using HooksNet.Hooks;

namespace HooksNet
{
    public interface IPostRewriteHook : IGitHook
    {
        void OnPostRewrite();
    }
}