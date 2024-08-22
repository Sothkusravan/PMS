using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pharma.DTO;
using pharma.Model;

namespace pharma.Interface
{
    public interface ISupplierInventoryRepository
    {
        Task<List<SuppliersInventory>> GetAll();
        Task<SuppliersInventory> GetById(int suplId);
        Task<List<SuppliersInventory>> GetBySupplierId(int suplId);
        Task<SuppliersInventory> GetByDrugNameQuantityPrice(string drugName);
        Task<SuppliersInventory> Add(SuppliersInventoryDto Dto);
         Task<bool> Update(int suplId, SuppliersInventory suppliersInventory);
          Task<bool> Delete(int suplId);
    }
}