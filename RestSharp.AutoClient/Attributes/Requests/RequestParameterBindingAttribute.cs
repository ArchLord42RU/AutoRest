using System;
using System.Threading.Tasks;
using AutoRestClient.Processing.Requests;

namespace AutoRestClient.Attributes.Requests
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Parameter)]
    public abstract class RequestParameterBindingAttribute: Attribute
    {
        public virtual void Bind(RequestParameterBindingContext context) { }

        public virtual async Task BindAsync(RequestParameterBindingContext context)
        {
            await Task.CompletedTask;
        }
    }
}