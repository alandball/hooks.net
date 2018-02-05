using System.Collections.Generic;

namespace HooksNet
{

    public interface IPostRewriteHook : IGitHook
    {
        void OnPostRewrite();
    }
}