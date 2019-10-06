using System;

namespace EntityFrameworkUdemy.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly PlutoContext _context;

        public UnitOfWork(PlutoContext context)
        {
            _context = context;
            Courses = new CourseRepository(_context);
        }

        public ICourseRepository Courses { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}