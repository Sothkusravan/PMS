using System.Collections.Generic;
using System.Threading.Tasks;
using pharma.DTO;
using pharma.Model;

namespace pharma.Interface
{
    public interface IOrderDetailsRepository
    {
        Task<List<OrderDetails>> GetAll();
        Task<OrderDetails> GetById(int orderId);
        Task<OrderDetails> Add(OrderDetailsDto dto);
        Task<bool> Update(int id, OrderDetailsDto orderdetails);
        Task<bool> Delete(int id);
    }
}
