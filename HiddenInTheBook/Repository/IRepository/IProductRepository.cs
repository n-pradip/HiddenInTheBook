using HiddenInTheBook.Models;

namespace HiddenInTheBook.Repository.IRepository
{
    public interface IProductRepository : IRepository<Product>
    {
        void Update(Product obj);
        void Save();
    }
}
