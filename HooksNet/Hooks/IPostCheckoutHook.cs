using System.Collections.Generic;

namespace HooksNet
{

    public interface IPostCheckoutHook : IGitHook
    {
        void OnPostCheckout();
    }
}