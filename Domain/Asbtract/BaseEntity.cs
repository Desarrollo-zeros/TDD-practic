using Domain.Contract;
using System.ComponentModel.DataAnnotations;

namespace Domain.Asbtract
{
    public abstract class BaseEntity<T> : BaseEntity, IEntity<T>
    {
        [Key]
        public virtual T Id { get; set; }
    }
    public abstract class BaseEntity : Audit
    {
        [Key]
        public virtual object Id { get; set; }
    }
}
