using HiddenInTheBook.Models;

namespace HiddenInTheBook.Repository.IRepository
{
    public interface ICoverTypeRepository : IRepository<CoverType>
    {
        void Update(CoverType obj);
        void Save();
    }
}
