using Domain.Contract;

namespace Domain.Asbtract
{
    public abstract class BaseEntity<T> : Audit, IEntity<T>
    {
        public virtual T Id { get; set; }
    }


}
