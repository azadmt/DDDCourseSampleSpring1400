using Framework.Domain;
using System;
using Xunit;

namespace Framework.Test
{
    public class EntityTest
    {
        [Fact]
        public void Shauld_Equal_WhithSameId()
        {
            var id = Guid.NewGuid();
            var Entity1 = new MyEntity(id);
            var Entity2 = new MyEntity(id);
            Assert.Equal(Entity1, Entity2);
        }
    }

    public class MyEntity : Entity
    {
        public MyEntity(Guid id):base(id)
        {

        }
    }
}
