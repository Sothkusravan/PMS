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
    public class DrugRequestServises
    {
        private readonly IDrugRequestRepository drugRepository;

        public DrugRequestServises(IDrugRequestRepository dbe)
        {
            drugRepository = dbe;
        }
        public async Task<List<DrugRequest>> GetAll()
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

        public async Task<List<DrugRequest>> GetById(int userId)
        {
            var getById =await drugRepository.GetById(userId);
            try
            {
                if(getById == null)
                {
                    throw new Exception($"Error occurred while getting user with ID {userId}");
                }
                return getById;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
               throw;
            }
        }

        public async Task<DrugRequest> Add(DrugRequestDto dto)
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

        public async Task<bool> Update(int userId, DrugRequestDto dto)
        {
            var update = await drugRepository.Update(userId,dto);
            try
            {
                if(update == null)
                {
                    throw new Exception("Error occurred while updating new drug");
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