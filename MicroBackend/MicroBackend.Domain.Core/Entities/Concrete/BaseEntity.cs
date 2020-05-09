using MicroBackend.Domain.Core.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MicroBackend.Domain.Core.Entities.Concrete
{
    public abstract class BaseEntity<T> : IBaseEntity<T>
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Key]
        public T Id { get; set; }

        public BaseEntity()
        {

        }
        public BaseEntity(bool create)
        {
            if (create)
            {
                if (typeof(T) == typeof(string))
                {
                    this.Id = (T)(object)Guid.NewGuid().ToString();
                }
                else if (typeof(T) == typeof(Guid))
                {
                    this.Id = (T)(object)Guid.NewGuid();
                }
            }
        }
    }
}
