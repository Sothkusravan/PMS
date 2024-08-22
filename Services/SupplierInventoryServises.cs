using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pharma.DTO;
using pharma.Interface;
using pharma.Model;
using pharma.Repository;

namespace pharma.Services
{
    public class SupplierInventoryServises
    {
        private readonly ISupplierInventoryRepository suppliersInventoryRepository;

        public SupplierInventoryServises(ISupplierInventoryRepository dbe)
        {
            suppliersInventoryRepository = dbe;
        }

         public async Task<List<SuppliersInventory>> GetAll()
        {
            var getAll= await suppliersInventoryRepository.GetAll();
            try
            {
                if(getAll == null)
                {
                    throw new Exception("Error occurred while getting all drugs");
                }
                return getAll;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
         
        public async Task<SuppliersInventory> GetById(int suplId)
        {
            var getById= await suppliersInventoryRepository.GetById(suplId);
            try
            {
                if(getById == null)
                {
                    throw new Exception($"Error occurred while getting drug with ID {suplId}");
                }
                return getById;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
               throw;
            }
        }
        public async Task<List<SuppliersInventory>> GetBySupplierId(int suplId)
        {
            var getById= await suppliersInventoryRepository.GetBySupplierId(suplId);
            try
            {
                if(getById == null)
                {
                    throw new Exception($"Error occurred while getting drug with ID {suplId}");
                }
                return getById;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
               throw;
            }
        }
         public async Task<SuppliersInventory> GetByDrugNameQuantityPrice(string drugName)
        {
            var getById= await suppliersInventoryRepository.GetByDrugNameQuantityPrice(drugName);
            try
            {
                if(getById == null)
                {
                    throw new Exception($"Error occurred while getting drug with ID {drugName}");
                }
                return getById;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
               throw;
            }
        }
         public async Task<SuppliersInventory> AddSupplierWithDrugDetails(SuppliersInventoryDto suppliersInventory)
        {
            var add= await suppliersInventoryRepository.Add(suppliersInventory);
            try
            {
                if(add == null)
                {
                    throw new Exception("Error occurred while adding new drug");
                }
                return add;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }               
        public async Task<bool> Update(int suplId, SuppliersInventory suppliersInventory)
        {
            bool update= await suppliersInventoryRepository.Update(suplId,suppliersInventory);
             try
            {
                if(update == false)
                {
                    throw new Exception($"Error occurred while updating drug with ID {suplId}");
                }
                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        public async Task<bool> Delete(int suplId)
        {
            bool delete= await suppliersInventoryRepository.Delete(suplId);
              try
            {
                if(delete == false)
                {
                    throw new Exception($"Error occurred while deleting drug with ID {suplId}");
                }
                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}