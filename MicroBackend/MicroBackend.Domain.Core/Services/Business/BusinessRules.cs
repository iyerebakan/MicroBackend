using MicroBackend.Domain.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroBackend.Domain.Core.Services.Business
{
    public class BusinessRules<T> where T : class,new()
    {
        public static IServiceDataResult<T> Run(params IServiceDataResult<T>[] logics)
        {
            foreach (var result in logics)
            {
                if (!result.Success)
                {
                    return result;
                }
            }
            return null;
        }
    }
}
