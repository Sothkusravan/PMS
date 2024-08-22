using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using pharma.Data;
using pharma.DTO;
using pharma.Interface;
using pharma.Model;

namespace pharma.Repository
{
    public class SuppliersInventoryRepository:ISupplierInventoryRepository
    {
        private readonly PharmaDbContext db;

        public SuppliersInventoryRepository(PharmaDbContext dbContext)
        {
            db = dbContext;
        }

        
        #region This method retrives the all suppliers Inventory details
        public async Task<List<SuppliersInventory>> GetAll()
        {
            try
            {
                var obj= await db.SuppliersInventory.ToListAsync();
                if(obj == null)
                {
                    throw new Exception("Error fetching all suppliers");
                }
                return obj;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        #endregion

        #region This method retrives the suppliers details based on supplierId
        public async Task<SuppliersInventory> GetById(int suplId)
        {
            try
            {
                var obj = await db.SuppliersInventory.FirstOrDefaultAsync(obj => obj.SuplDrugId == suplId);
                if(obj == null)
                {
                    throw new Exception($"Error fetching supplierDrugIdID {suplId}");
                }
                return obj;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        #endregion
         #region This method retrives the suppliers details based on supplierId
        public async Task<List<SuppliersInventory>> GetBySupplierId(int suplId)
        {
            try
            {
                var obj = await db.SuppliersInventory.Where(obj => obj.SupplierId == suplId).ToListAsync();
                if(obj == null)
                {
                    throw new Exception($"Error fetching supplierDrugIdID {suplId}");
                }
                return obj;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        #endregion
          public async Task<SuppliersInventory> GetByDrugNameQuantityPrice(string drugName)
        {
            try
            {
                var obj = await db.SuppliersInventory.SingleOrDefaultAsync(obj => obj.DrugName == drugName);
                if(obj == null)
                {
                    throw new Exception($"Error fetching DrugName {drugName}");
                }
                return obj;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        


        #region  This method add the suppliers details to datbase
        public async Task<SuppliersInventory> Add(SuppliersInventoryDto Dto)
        {
            try
            {
                SuppliersInventory newSupplierDrug = dtoSuppliersInventorydetails(Dto);
                if(newSupplierDrug == null)
                {
                    throw new Exception("Error adding supplier");
                }
                db.SuppliersInventory.Add(newSupplierDrug);
                await db.SaveChangesAsync();
                return newSupplierDrug;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        #endregion

        #region This method Updates the suppliers details based on id
        public async Task<bool> Update(int suplId, SuppliersInventory suppliersInventory)
        {
            try
            {
                var supl = await db.SuppliersInventory.SingleOrDefaultAsync(i => i.SupplierId == suplId);
                if (supl == null)
                {
                    throw new Exception();
                }
                supl.Price = suppliersInventory.Price;
                supl.Quantity = suppliersInventory.Quantity;
                
                await db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        #endregion

        #region This method deletes the Supplier details based on id
        public async Task<bool> Delete(int suplId)
        {
            try
            {
                var supl = await db.SuppliersInventory.SingleOrDefaultAsync(i => i.SuplDrugId == suplId);
                if (supl == null)
                {
                   throw new Exception("Error deleting supplierDrug with ID {id}");
                }
                db.SuppliersInventory.Remove(supl);
                await db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        #endregion
        private SuppliersInventory dtoSuppliersInventorydetails(SuppliersInventoryDto dto)
        {
            return new SuppliersInventory
            {
                SupplierId = dto.SupplierId,
                DrugName = dto.DrugName,
                Price = dto.Price,
                Quantity = dto.Quantity,
                ManufacturedDate = dto.ManufacturedDate,
                ExpiryDate = dto.ExpiryDate
              
            };
        }

    }
}