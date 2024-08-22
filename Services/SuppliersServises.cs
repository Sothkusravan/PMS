using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pharma.DTO;
using pharma.Interface;
using pharma.Model;

namespace pharma.Services
{
    public class SuppliersServises
    {
        private readonly ISuppliersRepository suppliersRepository;

        public SuppliersServises(ISuppliersRepository dbe)
        {
            suppliersRepository = dbe;
        }
        public async Task<List<Suppliers>> GetAll()
        {
            var getAll= await suppliersRepository.GetAll();
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
        public async Task<Suppliers> GetById(int supplierId)
        {
            var getById= await suppliersRepository.GetById(supplierId);
            try
            {
                if(getById == null)
                {
                    throw new Exception($"Error occurred while getting drug with ID {supplierId}");
                }
                return getById;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
               throw;
            }
        }
          public async Task<Suppliers> GetByEmail(string email)
        {
            var getById= await suppliersRepository.GetByEmail(email);
            try
            {
                if(getById == null)
                {
                    throw new Exception($"Error occurred while getting drug with ID {email}");
                }
                return getById;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
               throw;
            }
        }
         public async Task<Suppliers> AddSupplierWithDrugDetails(SuppliersDto suppliers)
        {
            var add= await suppliersRepository.Add(suppliers);
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
        public async Task<bool> Update(int suuplierId, Suppliers suppliers)
        {
            bool update= await suppliersRepository.Update(suuplierId,suppliers);
             try
            {
                if(update == false)
                {
                    throw new Exception($"Error occurred while updating drug with ID {suuplierId}");
                }
                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        public async Task<bool> Delete(int suuplierId)
        {
            bool delete= await suppliersRepository.Delete(suuplierId);
              try
            {
                if(delete == false)
                {
                    throw new Exception($"Error occurred while deleting drug with ID {suuplierId}");
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