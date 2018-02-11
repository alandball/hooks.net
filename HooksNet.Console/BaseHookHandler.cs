using System;
using System.Linq;

namespace HooksNet.Console
{
    public abstract class BaseHookHandler
    {
        public abstract void Handle(Type type);
    }

    public abstract class BaseHookHandler<T> : BaseHookHandler where T : class
    {
        protected T CreateInstance(Type type)
        {
            if (type.GetInterfaces().All(o => o != typeof(T)))
                return null;

            var hook = (T)Activator.CreateInstance(type);
            return hook;
        }
    }
}