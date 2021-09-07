using System;

namespace Framework.Domain
{
    public abstract class Entity
    {
        public Guid Id { get; private set; }
        public byte[] RowVersion { get; set; }
        public Entity(Guid id)
        {
            Id = id;
        }

        protected Entity() { }
        public override bool Equals(object obj)
        {
            return this.Id.Equals((obj as Entity).Id);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
