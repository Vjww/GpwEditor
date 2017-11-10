using System;
using Common.Editor.Infrastructure.Entities;

namespace GpwEditor.Infrastructure.TestClasses
{
    public class TestEntityImporter : IEntityImporter
    {
        private readonly TestDataContext _context;

        public TestEntityImporter(TestDataContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IEntity Import(int id)
        {
            if (id < 0) throw new ArgumentOutOfRangeException(nameof(id));

            var result = new TestEntity(); // TODO: replace with factory
            //result.Id = id;
            //result.Name = _context.Text.Read(id); // TODO: actual values required
            //result.Value = _context.Binary.Read(null, 0, 0, SeekOrigin.Begin); // TODO: actual values required
            return result;
        }
    }
}