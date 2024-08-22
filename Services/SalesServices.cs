using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pharma.DTO;
using pharma.Interface;
using pharma.Model;

namespace pharma.Services
{
    public class SalesServices
    {
         private readonly ISalesRepository salesRepository;

        public SalesServices(ISalesRepository dbe)
        {
            salesRepository = dbe;
        }

        public async Task<List<Sales>> GetAll()
        {
            var getAll = await salesRepository.GetAll();
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
        public async Task<Sales> GetById(int salesId)
        {
            var getById =await salesRepository.GetById(salesId);
            try
            {
                if(getById == null)
                {
                    throw new Exception($"Error occurred while getting drug with ID {salesId}");
                }
                return getById;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
               throw;
            }
        }
        public async Task<Sales> Add(SalesDto dto)
        {
            var add = await salesRepository.Add(dto);
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
        public async Task<bool> Delete(int salesID)
        {
            bool delete = await salesRepository.Delete(salesID);
            try
            {
                if(delete == false)
                {
                    throw new Exception($"Error occurred while deleting drug with ID {salesID}");
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