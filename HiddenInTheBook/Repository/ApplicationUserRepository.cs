using HiddenInTheBook.DataAccess.Data;
using HiddenInTheBook.Models;
using HiddenInTheBook.Repository.IRepository;

namespace HiddenInTheBook.Repository
{
    public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository
    {
        private ApplicationDbContext _db;

        public ApplicationUserRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

    }
}
