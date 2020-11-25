using System;
using System.Threading.Tasks;
using AutoRestClient.Processing.Requests;

namespace AutoRestClient.Attributes.Requests
{
    [AttributeUsage(AttributeTargets.Interface | AttributeTargets.Class | AttributeTargets.Method)]
    public abstract class RequestModifierAttribute: Attribute
    {
        public virtual void Apply(RequestExecutionContext context) { }

        public virtual async Task ApplyAsync(RequestExecutionContext context)
        {
            await Task.CompletedTask;
        }
    }
}