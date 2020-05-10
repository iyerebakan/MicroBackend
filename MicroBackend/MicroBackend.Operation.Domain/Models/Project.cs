using MicroBackend.Domain.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroBackend.Operation.Domain.Models
{
    public class Project : CardBaseEntity<int>
    {
        public Project(bool create, int? userId) : base(create, userId)
        {
        }

        public Project() : base(false, null)
        {
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? DueDate { get; set; }
        public Guid OwnerId { get; set; }

    }
}
