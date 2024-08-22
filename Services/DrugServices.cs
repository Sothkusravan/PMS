using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using pharma.DTO;
using pharma.Interface;
using pharma.Model;

namespace pharma.Services
{
    public class DrugServices
    {
        private readonly IDrugRepository drugRepository;

        public DrugServices(IDrugRepository dbe)
        {
            drugRepository = dbe;
        }

        public async Task<List<DrugDetails>> GetAll()
        {
            var getAll = await drugRepository.GetAll();
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
        public async Task<DrugDetails> GetById(int drugId)
        {
            var getById =await drugRepository.GetById(drugId);
            try
            {
                if(getById == null)
                {
                    throw new Exception($"Error occurred while getting drug with ID {drugId}");
                }
                return getById;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
               throw;
            }
        }
        public async Task<DrugDetails> Add(DrugDetailsDto dto)
        {
            var add = await drugRepository.Add(dto);
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
        public async Task<bool> Update(int drugId, DrugDetailsDto dto)
        {
            bool update= await drugRepository.Update(drugId,dto);
            try
            {
                if(update == false)
                {
                    throw new Exception($"Error occurred while updating drug with ID {drugId}");
                }
                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
         public async Task<bool> UpdateQuantity(int drugId, DrugDetailsDtoUpdateQuantity dto)
        {
            bool update= await drugRepository.UpdateQuanity(drugId,dto);
            try
            {
                if(update == false)
                {
                    throw new Exception($"Error occurred while updating drug with ID {drugId}");
                }
                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        
        
        public async Task<bool> Delete(int drugId)
        {
            bool delete = await drugRepository.Delete(drugId);
            try
            {
                if(delete == false)
                {
                    throw new Exception($"Error occurred while deleting drug with ID {drugId}");
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