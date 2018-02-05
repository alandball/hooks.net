namespace HooksNet.Hooks
{
    public interface IPrePushHook : IGitHook
    {
        void OnPrePush();
    }
}