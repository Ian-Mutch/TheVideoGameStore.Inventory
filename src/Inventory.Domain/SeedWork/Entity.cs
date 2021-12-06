using MediatR;

namespace TheVideoGameStore.Inventory.Domain.SeedWork;

public class Entity
{
    public virtual int Id
    {
        get => _id;
        protected set => _id = value;
    }
    public List<INotification> DomainEvents { get; private set; }

    int? _requestedHashCode;
    int _id;

    public void AddDomainEvent(INotification eventItem)
    {
        DomainEvents ??= new List<INotification>();
        DomainEvents.Add(eventItem);
    }
    public void RemoveDomainEvent(INotification eventItem)
    {
        if (DomainEvents is null) return;
        DomainEvents.Remove(eventItem);
    }

    public bool IsTransient()
    {
        return Id == default;
    }

    public override bool Equals(object obj)
    {
        if (obj is null or not Entity)
            return false;
        if (ReferenceEquals(this, obj))
            return true;
        if (GetType() != obj.GetType())
            return false;
        var item = (Entity)obj;
        return !item.IsTransient() && !IsTransient() && item.Id == Id;
    }

    public override int GetHashCode()
    {
        if (!IsTransient())
        {
            if (!_requestedHashCode.HasValue)
                _requestedHashCode = Id.GetHashCode() ^ 31;
            // XOR for random distribution. See:
            // https://docs.microsoft.com/archive/blogs/ericlippert/guidelines-and-rules-for-gethashcode
            return _requestedHashCode.Value;
        }
        else
            return base.GetHashCode();
    }
    public static bool operator ==(Entity left, Entity right) => Equals(left, null) ? Equals(right, null) : left.Equals(right);
    public static bool operator !=(Entity left, Entity right) => !(left == right);
}
