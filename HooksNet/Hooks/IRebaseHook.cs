namespace HooksNet.Hooks
{
    public interface IRebaseHook : IGitHook
    {
        void OnRebase();
    }
}