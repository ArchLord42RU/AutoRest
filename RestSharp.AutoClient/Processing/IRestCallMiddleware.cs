using System;
using System.Threading.Tasks;

namespace AutoRestClient.Processing
{
    public interface IRestCallMiddleware
    {
        void Invoke(ExecutionContext context, Action<ExecutionContext> next);
    }

    public interface IAsyncRestCallMiddleware
    {
        Task InvokeAsync(ExecutionContext context, Func<ExecutionContext, Task> next);
    }
    
    public interface IRestCallMiddleware<TClient>: IRestCallMiddleware
    {
    }

    public interface IAsyncRestCallMiddleware<TClient>: IAsyncRestCallMiddleware
    {
    } 
}