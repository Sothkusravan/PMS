using System.Collections.Generic;
using System.Threading.Tasks;
using pharma.DTO;
using pharma.Model;

namespace pharma.Interface
{
    public interface ISuppliersRepository
    {
        Task<List<Suppliers>> GetAll();
        Task<Suppliers> GetById(int supplierId);
         Task<Suppliers> GetByEmail(string email);
        Task<Suppliers> Add(SuppliersDto suplpplier);
        // Task<Suppliers> AddSupplierWithDrugDetails(Suppliers model);
        Task<bool> Update(int id, Suppliers suppliers);
        Task<bool> Delete(int id);
    }
}
