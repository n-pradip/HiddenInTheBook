using HiddenInTheBook.DataAccess.Data;
using HiddenInTheBook.Models;
using HiddenInTheBook.Repository.IRepository;

namespace HiddenInTheBook.Repository
{
    public class ProductRepository : Repository<Product> , IProductRepository
    {
        private ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db) : base(db) { 
            _db = db;
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Product obj)
        {
           var objectFromDb = _db.Products.FirstOrDefault(u => u.Id == obj.Id);
            if (objectFromDb != null)
            {
                objectFromDb.Title = obj.Title;
                objectFromDb.ISBN = obj.ISBN;
                objectFromDb.Price = obj.Price;
                objectFromDb.Price50 = obj.Price50;
                objectFromDb.ListPrice = obj.ListPrice;
                objectFromDb.Price100 = obj.Price100;
                objectFromDb.Description = obj.Description;
                objectFromDb.CategoryId = obj.CategoryId;
                objectFromDb.Author = obj.Author;
                objectFromDb.CoverTypeId = obj.CoverTypeId;
                if(obj.ImageUrl != null)
                {
                    objectFromDb.ImageUrl = obj.ImageUrl;
                }
            }
        }
    }
}
