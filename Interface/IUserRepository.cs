using System.Collections.Generic;
using System.Threading.Tasks;
using pharma.DTO;
using pharma.Model;

namespace pharma.Interface
{
    public interface IUserRepository
    {
        Task<List<User>> GetAll();
        Task<User> GetById(int userId);
        Task<User> Add(User user);
       Task<bool> Update(int userId, UserDto dto);
        Task<bool> UpdatePassword(string userName,string email, UserDto dto);
        Task<bool> Delete(int id);
    }
}
