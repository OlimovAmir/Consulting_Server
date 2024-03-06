namespace Consulting_Server.Models.BaseModels
{
    public abstract class BaseEntity
    {
        public Guid Id { get; }

        public BaseEntity()
        {
            Id = Guid.NewGuid();
        }

        public override string ToString()
        {
            return $"Id:{Id} ({GetType().Name})";
        }
    }
}
