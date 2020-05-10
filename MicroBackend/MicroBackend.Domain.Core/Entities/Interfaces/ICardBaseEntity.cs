using System;
using System.Collections.Generic;
using System.Text;

namespace MicroBackend.Domain.Core.Entities.Interfaces
{
    public interface ICardBaseEntity<TKey> : IBaseEntity<TKey> where TKey : struct
    {
        Nullable<TKey> UpdateUser { get; set; }

        Nullable<TKey> CreateUser { get; set; }

        DateTime? CreateDate { get; set; }

        DateTime? UpdateDate { get; set; }
    }
}
