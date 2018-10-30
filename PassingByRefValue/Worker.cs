using System;

namespace PassingByRefValue
{
    public class Worker
    {
        public int ModifyAndAdd(int a, int b)
        {
            a += a;
            b += b;

            return a * b;
        }

        public int ModifyAndAdd(ref int a, ref int b)
        {
            a += a;
            b += b;

            return a * b;
        }

        public Entity ReInit(Entity a, bool toNull)
        {
            a = toNull ? null : new Entity {Id = a.Id + a.Id, Name = a.Name + a.Name};
            return a;
        }

        public Entity ReInit(ref Entity a, bool toNull)
        {
            a = toNull ? null : new Entity { Id = a.Id + a.Id, Name = a.Name + a.Name };
            return a;
        }

        public Entity Modify(Entity a)
        {
            a.Id += a.Id;
            a.Name += a.Name;

            return a;
        }

        public Entity Modify(ref Entity a)
        {
            a.Id += a.Id;
            a.Name += a.Name;

            return a;
        }
    }
}
