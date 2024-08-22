using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using pharma.Data;
using pharma.DTO;
using pharma.Model;
using pharma.Interface;

namespace pharma.Repository
{
    public class DrugRepository : IDrugRepository
    {
        private readonly PharmaDbContext db;

        public DrugRepository(PharmaDbContext dbContext)
        {
            db = dbContext;
        }

        #region Call the DTO class
        public  DrugDetails dtoToDrugDetails(DrugDetailsDto dto)
        {
            return new DrugDetails
            {
                SupplierId = dto.SupplierId,
                DrugName = dto.DrugName,
                Quantity = dto.Quantity,
                Price = dto.Price,
                ManufacturedDate = dto.ManufacturedDate,
                ExpiryDate = dto.ExpiryDate
            };
        }
        #endregion
          public  DrugDetails dtoToDrugDetailsQuantity(DrugDetailsDtoUpdateQuantity dto1)
        {
            return new DrugDetails
            {
               
                Quantity = dto1.Quantity,
                
            };
        }

        #region  Used to Gett all drug details
        public async Task<List<DrugDetails>> GetAll()
        {
            try
            {
                var obj = await db.DrugInventory.ToListAsync();
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
        public async Task<DrugDetails> GetById(int drugId)
        {
            try
            {
                var obj= await db.DrugInventory.SingleOrDefaultAsync(obj => obj.DrugId == drugId);
                if(obj == null)
                {
                    throw new Exception($"Error occurred while getting drug with ID {drugId}");
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
        public async Task<DrugDetails> Add(DrugDetailsDto dto)
        {
            try
            {
                DrugDetails newDrug = dtoToDrugDetails(dto);
                if(newDrug == null)
                {
                    throw new Exception("Error occurred while adding new drug");
                }
                db.DrugInventory.Add(newDrug);
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

        #region This method used to Update the drug details by drugId
        public async Task<bool> Update(int drugId, DrugDetailsDto dto)
        {
            try
            {
                var drug = await db.DrugInventory.SingleOrDefaultAsync(i => i.DrugId == drugId);
                if (drug == null)
                {
                    throw new Exception($"Error occurred while updating drug with ID {drugId}");
                }
                drug.Quantity = dto.Quantity;
                drug.Price = dto.Price;
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
         #region This method used to Update the drug details by drugId
        public async Task<bool> UpdateQuanity(int drugId, DrugDetailsDtoUpdateQuantity dto)
        {
            try
            {
                var drug = await db.DrugInventory.SingleOrDefaultAsync(i => i.DrugId == drugId);
                if (drug == null)
                {
                    throw new Exception($"Error occurred while updating drug with ID {drugId}");
                }
                drug.Quantity = dto.Quantity;
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

        #region  This method used to delete the drug details by drugId
        public async Task<bool> Delete(int drugId)
        {
            try
            {
                var drug = await db.DrugInventory.SingleOrDefaultAsync(i => i.DrugId == drugId);
                if (drug == null)
                {
                    throw new Exception($"Error occurred while deleting drug with ID {drugId}");
                }
                db.DrugInventory.Remove(drug);
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
