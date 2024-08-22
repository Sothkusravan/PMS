using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using pharma.Data;
using pharma.DTO;
using pharma.Interface;
using pharma.Model;
using pharma.Services;

namespace pharma.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly EmailService _emailService;


        private readonly UserControllerServises userRepository;

        private readonly PharmaDbContext pharmaDbContext;

        public UserController(UserControllerServises dbe,EmailService emailService, PharmaDbContext pharmaDbContext)
        {
            userRepository = dbe;
            _emailService = emailService;
            this.pharmaDbContext=pharmaDbContext;

        }

        #region It is HTTP action result containing User details if successful, or an error message if an exception occurs 

        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var users = await userRepository.GetAll();
                if(users == null)
                {
                    throw new Exception();
                }
                return Ok(users);
            }
            catch (Exception ex)
            {
                return StatusCode(500,$"Internal server error:{ex.Message}");
            }
        }
        #endregion

        #region It is HTTP action result containing User details based UserID if successful, or an error message if an exception occurs 

        [HttpGet("GetUser/{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            try
            {
                var user = await userRepository.GetById(id);
                if (user == null)
                {
                    throw new Exception();
                }
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500,$"UserId was not found:{ex.Message}");
            }
        }
        #endregion

        #region It is HTTP action result Add User details if successful, or an error message if an exception occurs 

        [HttpPost("AddUser")]
        public async Task<IActionResult> AddUser([FromBody]User user)
        {
            try
            {
                var newUser = await userRepository.Add(user);
                if(newUser == null)
                {
                    throw new Exception();
                }
                return Ok(newUser);
            }
            catch (Exception ex)
            {
                return StatusCode(500,$"Internal server error:{ex.Message}");
            }
        }
        #endregion

        #region It is HTTP action result Update User details if successful, or an error message if an exception occurs 

        [HttpPut("UpdateUser/{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody]UserDto user)
        {
            try
            {
                if (!await userRepository.Update(id, user))
                {
                    throw new Exception();
                }

                var users=pharmaDbContext.UserDetails.FirstOrDefault(a=>a.UserId==id);
                if(users?.Role=="Doctor")
                {
                    await _emailService.DoctorByEmail(users.UserName,users.Email,users.UserPassword);
                     return Content("Updating user is successfyll");
                }
                else if(users?.Role=="Pharmacist")
                {
                    await _emailService.PharmacistByEmail(users.UserName,users.Email);
                     return Content("Updating user is successfyll");
                }
                else if(users?.Role=="Salesman")
                {
                    await _emailService.SalesManByEmail(users.UserName,users.Email);
                     return Content("Updating user is successfyll");
                }
                else{
                    await _emailService.SendApprovalByEmail(users.UserName,users.Email,users.UserPassword);
                return Content("Updating user is successfyll");
                }
                
            }
            catch (Exception ex)
            {
                return StatusCode(500,$"UserId was not found:{ex.Message}");
            }
        }
        #endregion


        

        #region It is HTTP action result Delete User details if successful, or an error message if an exception occurs 

        [HttpDelete("DeleteUser/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                if (!await userRepository.Delete(id))
                {
                    throw new Exception();
                }
                return Content($"Removing user with id {id} is successfull");
            }
            catch (Exception ex)
            {
                return StatusCode(500,$"UserId was not found: {ex.Message}");
            }
        }
        #endregion

         #region It is HTTP action result Update User Password if successful, or an error message if an exception occurs 

        [HttpPut("UpdatePassword/{userName}")]
        public async Task<IActionResult> UpdatePassword(string userName,string email, [FromBody]UserDto user)
        {
            try
            {
                if (!await userRepository.UpdatePassword(userName,email,user))
                {
                    throw new Exception();
                }
                return Content("Updating user is successfyll");
            }
            catch (Exception ex)
            {
                return StatusCode(500,$"UserId was not found:{ex.Message}");
            }
        }
        #endregion
    }
}
