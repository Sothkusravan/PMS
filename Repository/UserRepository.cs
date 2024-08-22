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
    public class UserRepository : IUserRepository
    {
        private readonly PharmaDbContext db;

        public UserRepository(PharmaDbContext dbContext)
        {
            db = dbContext;
        }

        #region This method retrives the all user details 
        public async Task<List<User>> GetAll()
        {
            try
            {
                var obj= await db.UserDetails.ToListAsync();
                if(obj == null)
                {
                    throw new Exception("Error fetching all users");
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

        #region This method retrives the user details based on userId
        public async Task<User> GetById(int userId)
        {
            try
            {
                var obj = await db.UserDetails.SingleOrDefaultAsync(obj => obj.UserId == userId);
                if(obj == null)
                {
                    throw new Exception("Error fetching user with ID {userId}");
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

        #region This method adds the user details to the database
        public async Task<User> Add(User user)
        {
            try
            {
                if (user == null)
                {
                    throw new Exception();
                }
                db.UserDetails.Add(user);
                await db.SaveChangesAsync();
                return user;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        #endregion

        #region This method is updates userDetails based on userId
        public async Task<bool> Update(int id, User user)
        {
            try
            {
                var obj = await db.UserDetails.SingleOrDefaultAsync(i => i.UserId == id);
                if (obj == null)
                {
                    throw new Exception("Error updating user with ID {id}");
                }
                obj.UserName = user.UserName;
                obj.Contact = user.Contact;
                obj.UserAddress = user.UserAddress;
                obj.Role = user.Role;
                obj.Email = user.Email;
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

        #region This method is updates Password based on UserName and Email
        public async Task<bool> UpdatePassword(string userName,string email, UserDto user)
        {
            try
            {
                var obj = await db.UserDetails.SingleOrDefaultAsync(i => i.UserName == userName && i.Email ==email);
                if (obj == null)
                {
                    throw new Exception("Error updating user password");
                }
                obj.UserPassword = user.UserPassword;
                
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

        #region This method is deletes the userDetails based on userId
        public async Task<bool> Delete(int id)
        {
            try
            {
                var obj = await db.UserDetails.SingleOrDefaultAsync(i => i.UserId == id);
                if (obj == null)
                {
                    throw new Exception("Error deleting user with ID {id}");
                }
                db.UserDetails.Remove(obj);
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

          public async Task<bool> Update(int userId, UserDto dto)
        {
            try
            {
                var drug = await db.UserDetails.SingleOrDefaultAsync(i => i.UserId == userId);
                if (drug == null)
                {
                    throw new Exception($"Error occurred while updating drug with ID {userId}");
                }
                drug.Approval = dto.Approval;
                await db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
                
            }
        }

        public  User dtoToUserDetails(UserDto dto)
        {
            return new User
            {
                Approval = dto.Approval,
                UserPassword = dto.UserPassword
                
            };
        }
        


        
    }
}
