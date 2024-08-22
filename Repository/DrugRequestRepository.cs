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
    public class DrugRequestRepository:IDrugRequestRepository
    {
        private readonly PharmaDbContext db;

        public DrugRequestRepository(PharmaDbContext dbContext)
        {
            db = dbContext;
        }

        public  DrugRequest dtoToDrugDetails(DrugRequestDto dto)
        {
            return new DrugRequest
            {
                UserId = dto.UserId,
                DrugName = dto.DrugName,
                Discription = dto.Discription,
                Quantity = dto.Quantity,
                ApproxPrice = dto.ApproxPrice,
                RequestedDate = dto.RequestedDate,
                Approved = dto.Approved
            };
        }

        #region  Used to Gett all drug request details
        public async Task<List<DrugRequest>> GetAll()
        {
            try
            {
                var obj = await db.DrugRequests.ToListAsync();
                if(obj == null)
                {
                    throw new Exception("Error occurred while getting all drugs");
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

        #region  Used to get the drug details by userId
        public async Task<List<DrugRequest>> GetById(int userId)
        {
            try
            {
                var obj= await db.DrugRequests.Where(i=>i.UserId == userId).ToListAsync();
                if(obj == null)
                {
                    throw new Exception($"Error occurred while getting drug with ID {userId}");
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

        #region  This Method Adds the request drug details to database
        public async Task<DrugRequest> Add(DrugRequestDto dto)
        {
            try
            {
                DrugRequest newDrug = dtoToDrugDetails(dto);
                if(newDrug == null)
                {
                    throw new Exception("Error occurred while adding new drug");
                }
                db.DrugRequests.Add(newDrug);
                await db.SaveChangesAsync();
                return newDrug;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        #endregion

        #region This method used to Update the drugRequest details by UserOd
        public async Task<bool> Update(int requestId, DrugRequestDto dto)
        {
            try
            {
                var drug = await db.DrugRequests.SingleOrDefaultAsync(i => i.RequestId == requestId);
                if (drug == null)
                {
                    throw new Exception($"Error occurred while updating drug with ID {requestId}");
                }
                drug.Approved = dto.Approved;
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

    }
}