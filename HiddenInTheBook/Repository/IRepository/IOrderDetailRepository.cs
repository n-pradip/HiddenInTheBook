using HiddenInTheBook.Models;

namespace HiddenInTheBook.Repository.IRepository
{
    public interface IOrderDetailRepository : IRepository<OrderDetail>
    {
        void Update(OrderDetail obj);
    }
}
