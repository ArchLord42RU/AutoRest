using System;

namespace AutoRestClient.Processing
{
    public interface IValueResolver
    {
        object Resolve(Type objectType);
    }
}