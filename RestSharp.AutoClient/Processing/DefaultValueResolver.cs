using System;

namespace AutoRestClient.Processing
{
    public class DefaultValueResolver: IValueResolver
    {
        public TValue Resolve<TValue>()
        {
            return Activator.CreateInstance<TValue>();
        }

        public object Resolve(Type objectType)
        {
            return Activator.CreateInstance(objectType);
        }
    }
}