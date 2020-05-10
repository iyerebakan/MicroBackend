using MicroBackend.Domain.Core.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MicroBackend.Domain.Core.Entities.Concrete
{
    public abstract class CardBaseEntity<TKey> : BaseEntity<TKey>, ICardBaseEntity<TKey> where TKey : struct
    {
        [MaxLength(128)]
        public Nullable<TKey> UpdateUser { get; set; }

        [MaxLength(128)]
        public Nullable<TKey> CreateUser { get; set; }

        public DateTime? CreateDate { get; set; }

        public DateTime? UpdateDate { get; set; }

        public CardBaseEntity(bool create, TKey? userId)
            : base(create)
        {
            if (create)
            {
                this.CreateUser = userId;
                this.CreateDate = DateTime.Now;
            }
        }

    }
}
