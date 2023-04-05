using HiddenInTheBook.DataAccess.Data;
using HiddenInTheBook.Repository.IRepository;

namespace HiddenInTheBook.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;
        public UnitOfWork(ApplicationDbContext db) 
        {
            _db = db;
            Category = new CategoryRepository(_db);
            CoverType = new CoverTypeRepository(_db);
        }
        public ICategoryRepository Category { get; private set; }
        public ICoverTypeRepository CoverType { get; private set; }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
