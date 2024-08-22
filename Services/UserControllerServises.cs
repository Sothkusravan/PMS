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
    public class UserControllerServises
    {
        private readonly IUserRepository userRepository;

        public UserControllerServises(IUserRepository dbe)
        {
            userRepository = dbe;
        }
        public async Task<List<User>> GetAll()
        {
            var getAll= await userRepository.GetAll();
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
        public async Task<User> GetById(int userId)
        {
            var getById= await userRepository.GetById(userId);
            try
            {
                if(getById == null)
                {
                    throw new Exception($"Error occurred while getting drug with ID {userId}");
                }
                return getById;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
               throw;
            }
        }
        public async Task<User> Add(User user)
        {
            var add= await userRepository.Add(user);
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
        // public async Task<bool> Update(int userId, User user)
        // {
        //     bool update= await userRepository.Update(userId,user);
        //     try
        //     {
        //         if(update == false)
        //         {
        //             throw new Exception($"Error occurred while updating drug with ID {userId}");
        //         }
        //         return true;
        //     }
        //     catch(Exception ex)
        //     {
        //         Console.WriteLine(ex.Message);
        //         throw;
        //     }
        // }
        public async Task<bool> UpdatePassword(string userName,string email, UserDto dto)
        {
            bool update= await userRepository.UpdatePassword(userName,email,dto);
            try
            {
                if(update == false)
                {
                    throw new Exception($"Error occurred while updating drug with ID ");
                }
                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        public async Task<bool> Delete(int userId)
        {
            bool delete = await userRepository.Delete(userId);
              try
            {
                if(delete == false)
                {
                    throw new Exception($"Error occurred while deleting drug with ID {userId}");
                }
                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
         public async Task<bool> Update(int userId, UserDto dto)
        {
            var update = await userRepository.Update(userId,dto);
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