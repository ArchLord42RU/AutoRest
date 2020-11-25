using System;

namespace AutoRestClient.Processing
{
    public interface IValueResolver
    {
        TValue Resolve<TValue>();

        object Resolve(Type objectType);
    }
}