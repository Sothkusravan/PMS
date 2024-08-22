using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using pharma.Data;
using pharma.DTO;
using pharma.Interface;
using pharma.Model;

namespace pharma.Repository
{
    public class SuppliersRepository : ISuppliersRepository
    {
        private readonly PharmaDbContext db;

        public SuppliersRepository(PharmaDbContext dbContext)
        {
            db = dbContext;
        }

        #region This method retrives the all suppliers details
        public async Task<List<Suppliers>> GetAll()
        {
            try
            {
                var obj= await db.SuppliersDetails.ToListAsync();
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
        public async Task<Suppliers> GetById(int supplierId)
        {
            try
            {
                var obj = await db.SuppliersDetails.SingleOrDefaultAsync(obj => obj.SupplierId == supplierId);
                if(obj == null)
                {
                    throw new Exception("Error fetching supplier with ID {supplierId}");
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
        public async Task<Suppliers> GetByEmail(string email)
        {
            try
            {
                var obj = await db.SuppliersDetails.SingleOrDefaultAsync(obj => obj.EmailAddress == email);
                if(obj == null)
                {
                    throw new Exception("Error fetching supplier with ID {supplierId}");
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


        #region  This method add the suppliers details to datbase
        public async Task<Suppliers> Add(SuppliersDto suplpplier)
        {
            try
            {
                Suppliers newSupplier = dtoSuppliersdetails(suplpplier);
                if(newSupplier == null)
                {
                    throw new Exception("Error adding supplier");
                }
                db.SuppliersDetails.Add(newSupplier);
                await db.SaveChangesAsync();
                return newSupplier;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        #endregion

        #region This method Updates the suppliers details based on id
        public async Task<bool> Update(int id, Suppliers suppliers)
        {
            try
            {
                var supl = await db.SuppliersDetails.SingleOrDefaultAsync(i => i.SupplierId == id);
                if (supl == null)
                {
                    throw new Exception();
                }
                supl.SupplierName = suppliers.SupplierName;
                supl.Contact = suppliers.Contact;
                supl.EmailAddress = suppliers.EmailAddress;
                supl.Address = suppliers.Address;
                supl.Organisation = suppliers.Organisation;
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
        public async Task<bool> Delete(int id)
        {
            try
            {
                var supl = await db.SuppliersDetails.SingleOrDefaultAsync(i => i.SupplierId == id);
                if (supl == null)
                {
                   throw new Exception("Error deleting supplier with ID {id}");
                }
                db.SuppliersDetails.Remove(supl);
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
         private Suppliers dtoSuppliersdetails(SuppliersDto dto)
        {
            return new Suppliers
            {
                SupplierName = dto.SupplierName,
                Organisation = dto.Organisation,
                Contact = dto.Contact,
                EmailAddress = dto.EmailAddress,
                Address = dto.Address
              
            };
        }

        
    }
}
