namespace HooksNet
{
    public interface IPrePushHook : IGitHook
    {
        void OnPrePush();
    }
}