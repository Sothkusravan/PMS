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
    public class SalesRepository:ISalesRepository
    {
         private readonly PharmaDbContext db;

        public SalesRepository(PharmaDbContext dbContext)
        {
            db = dbContext;
        }

          #region Call the DTO class
        public  Sales dtoToSalesDetails(SalesDto dto)
        {
            return new Sales
            {
                DrugName = dto.DrugName,
                Quantity = dto.Quantity,
                Price = dto.Price,
                ManufacturedDate = dto.ManufacturedDate,
                ExpiryDate = dto.ExpiryDate
            };
        }
        #endregion

         #region  Used to Gett all drug details
        public async Task<List<Sales>> GetAll()
        {
            try
            {
                var obj = await db.SalesDetails.ToListAsync();
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

        #region  Used to get the drug details by drugId
        public async Task<Sales> GetById(int salesId)
        {
            try
            {
                var obj= await db.SalesDetails.SingleOrDefaultAsync(obj => obj.SalesId == salesId);
                if(obj == null)
                {
                    throw new Exception($"Error occurred while getting drug with ID {salesId}");
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
        

        #region  This Method Adds the drug details to database
        public async Task<Sales> Add(SalesDto dto)
        {
            try
            {
                Sales newDrug = dtoToSalesDetails(dto);
                if(newDrug == null)
                {
                    throw new Exception("Error occurred while adding new drug");
                }
                db.SalesDetails.Add(newDrug);
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
         #region  This method used to delete the drug details by drugId
        public async Task<bool> Delete(int salesID)
        {
            try
            {
                var drug = await db.SalesDetails.SingleOrDefaultAsync(i => i.SalesId == salesID);
                if (drug == null)
                {
                    throw new Exception($"Error occurred while deleting drug with ID {salesID}");
                }
                db.SalesDetails.Remove(drug);
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