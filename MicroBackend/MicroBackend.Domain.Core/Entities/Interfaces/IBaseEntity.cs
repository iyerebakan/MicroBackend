using System;
using System.Collections.Generic;
using System.Text;

namespace MicroBackend.Domain.Core.Entities.Interfaces
{
    public interface IBaseEntity<T>
    {
        T Id { get; set; }
    }
}
