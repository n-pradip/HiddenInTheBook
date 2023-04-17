using HiddenInTheBook.DataAccess.Data;
using HiddenInTheBook.Models;
using HiddenInTheBook.Repository.IRepository;

namespace HiddenInTheBook.Repository
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        private ApplicationDbContext _db;
        public CompanyRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Company obj)
        {
            _db.Companies.Update(obj);

        }
    }
}
