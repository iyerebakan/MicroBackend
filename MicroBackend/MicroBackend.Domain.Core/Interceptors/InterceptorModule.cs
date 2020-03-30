
using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace MicroBackend.Domain.Core.Interceptors
{
    public static class InterceptorModule
    {
        public static ContainerBuilder InterceptorModuleSelector(this ContainerBuilder builder,Assembly assembly)
        {
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
            return builder;
        }
    }
}
