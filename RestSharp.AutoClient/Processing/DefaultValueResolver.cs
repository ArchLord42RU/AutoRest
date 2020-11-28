using System;

namespace AutoRestClient.Processing
{
    public class DefaultValueResolver: IValueResolver
    {
        public object Resolve(Type objectType)
        {
            return Activator.CreateInstance(objectType);
        }
    }
}