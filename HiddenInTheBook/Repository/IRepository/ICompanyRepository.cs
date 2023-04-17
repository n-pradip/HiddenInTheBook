using HiddenInTheBook.Models;

namespace HiddenInTheBook.Repository.IRepository
{
    public interface ICompanyRepository : IRepository<Company>
    {
        void Update(Company obj);
        void Save();
    }
}
