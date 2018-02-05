namespace HooksNet.Hooks
{
    public interface IPostCheckoutHook : IGitHook
    {
        void OnPostCheckout();
    }
}