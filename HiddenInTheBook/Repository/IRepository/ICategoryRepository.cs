using HiddenInTheBook.Models;

namespace HiddenInTheBook.Repository.IRepository
{
    public interface ICategoryRepository : IRepository<Category>
    {
        void Update(Category obj);
        void Save();
    }
}
