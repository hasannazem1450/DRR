using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Framework.Contracts.Abstracts
{
    public abstract class Entity<T>
    {
        public T Id { get; protected set; }
        public bool IsDeleted { get; protected set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? ModifiedAt { get; set; }
    }

    public abstract class EntityWithEnable<T> : Entity<T>
    {
        public bool IsEnabled { get; protected set; }
    }
}
