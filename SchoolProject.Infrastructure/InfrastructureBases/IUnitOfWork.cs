using Microsoft.EntityFrameworkCore.Storage;
using SchoolProject.Infrastructure.Context;

namespace SchoolProject.Infrastructure.InfrastructureBases
{
    public interface IUnitOfWork
    {
        IDbContextTransaction BeginTransaction();
        void Commit();
        void RollBack();
    }
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public IDbContextTransaction BeginTransaction()
        {
            return _context.Database.BeginTransaction();
        }

        public void Commit()
        {
            _context.Database.CommitTransaction();
        }

        public void RollBack()
        {
            _context.Database.RollbackTransaction();
        }
    }

}
