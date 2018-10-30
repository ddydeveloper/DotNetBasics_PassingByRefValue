using PassingByRefValue;
using Xunit;

namespace PassingByRefValue_Tests
{
    public class WorkerTests
    {
        private readonly Worker _worker = new Worker();

        [Fact]
        public void ModifyAndAdd_ByValue_Test()
        {
            var a = 1;
            var b = 2;
            
            var result = _worker.ModifyAndAdd(a, b);

            Assert.True(result == 8);
            Assert.True(a == 1 && b == 2);
        }

        [Fact]
        public void ModifyAndAdd_ByRef_Test()
        {
            var a = 1;
            var b = 2;

            var result = _worker.ModifyAndAdd(ref a, ref b);

            Assert.True(result == 8);
            Assert.True(a == 2 && b == 4);
        }

        [Fact]
        public void ReInit_ByValue_Test()
        {
            var entity = new Entity {Id = 1, Name = "Name"};
            var result = _worker.ReInit(entity, false);

            Assert.True(entity.Id == 1 && entity.Name == "Name");
            Assert.True(result.Id == 2 && result.Name == "NameName");
        }

        [Fact]
        public void ReInit_ByValue_Null_Test()
        {
            var entity = new Entity { Id = 1, Name = "Name" };
            var result = _worker.ReInit(entity, true);

            Assert.True(entity.Id == 1 && entity.Name == "Name");
            Assert.True(result == null);
        }

        [Fact]
        public void ReInit_ByRef_Test()
        {
            var entity = new Entity { Id = 1, Name = "Name" };
            var result = _worker.ReInit(ref entity, false);

            Assert.True(entity.Id == 2 && entity.Name == "NameName");
            Assert.True(result.Id == 2 && result.Name == "NameName");
        }

        [Fact]
        public void ReInit_ByRef_Null_Test()
        {
            var entity = new Entity { Id = 1, Name = "Name" };
            var result = _worker.ReInit(ref entity, true);

            Assert.True(entity == null);
            Assert.True(result == null);
        }

        [Fact]
        public void Modify_ByValue_Test()
        {
            var entity = new Entity { Id = 1, Name = "Name" };
            var result = _worker.Modify(entity);

            Assert.True(entity.Id == 2 && entity.Name == "NameName");
            Assert.True(result.Id == 2 && result.Name == "NameName");
        }

        [Fact]
        public void Modify_ByRef_Test()
        {
            var entity = new Entity { Id = 1, Name = "Name" };
            var result = _worker.Modify(ref entity);

            Assert.True(entity.Id == 2 && entity.Name == "NameName");
            Assert.True(result.Id == 2 && result.Name == "NameName");
        }
    }
}
