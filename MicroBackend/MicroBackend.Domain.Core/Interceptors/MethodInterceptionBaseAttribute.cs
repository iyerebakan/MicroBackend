using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroBackend.Domain.Core.Interceptors
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public abstract class MethodInterceptionBaseAttribute : Attribute, IInterceptor
    {

        public virtual void Intercept(IInvocation invocation)
        {
            throw new NotImplementedException();
        }
    }
}
