using System;
using System.Collections.Generic;
using System.Text;

namespace MicroBackend.Domain.Core.Entities.Interfaces
{
    public interface ICardBaseEntity<TKey> : IBaseEntity<TKey>
    {
        int? UpdateUser { get; set; }

        int? CreateUser { get; set; }

        DateTime? CreateDate { get; set; }

        DateTime? UpdateDate { get; set; }
    }
}
