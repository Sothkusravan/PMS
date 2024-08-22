using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using pharma.DTO;
using pharma.Interface;
using pharma.Model;
using pharma.Services;

namespace pharma.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SuppliersController : ControllerBase
    {
        private readonly SuppliersServises suppliersRepository;

        public SuppliersController(SuppliersServises dbe)
        {
            suppliersRepository = dbe;
        }

        #region It is HTTP action result containing Suppliers details if successful, or an error message if an exception occurs 

        [HttpGet("GetAllSuppliers")]
        public async Task<IActionResult> GetAllSuppliers()
        {
            try
            {
                var suppliers = await suppliersRepository.GetAll();
                if(suppliers == null)
                {
                    throw new Exception();
                }
                return Ok(suppliers);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        #endregion

        #region It is HTTP action result containing Suppliers details based on Id if successful, or an error message if an exception occurs 

        [HttpGet("GetSupplier/{id}")]
        public async Task<IActionResult> GetSupplier(int id)
        {
            try
            {
                var supplier = await suppliersRepository.GetById(id);
                if (supplier == null)
                {
                    throw new Exception("Suppliers id not found");
                }
                return Ok(supplier);
            }
            catch (Exception ex)
            {
                return StatusCode(500,$"SupplierId was not found: {ex.Message}");
            }
        }
        #endregion

         [HttpGet("GetSupplierByEmail/{email}")]
        public async Task<IActionResult> GetSupplierByEmail(string email)
        {
            try
            {
                var supplier = await suppliersRepository.GetByEmail(email);
                if (supplier == null)
                {
                    throw new Exception("Suppliers email not found");
                }
                return Ok(supplier);
            }
            catch (Exception ex)
            {
                return StatusCode(500,$"Supplier email was not found: {ex.Message}");
            }
        }

        

         #region It is HTTP action result Add Suppliers details if successful, or an error message if an exception occurs 
         [HttpPost("AddSupplier")]
        public async Task<IActionResult> AddSupplier([FromBody] SuppliersDto supplier)
        {
            try
            {
                var newSupplier = await suppliersRepository.AddSupplierWithDrugDetails(supplier);
                if(newSupplier == null)
                {
                    throw new Exception();
                }
                return Ok(newSupplier);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error adding new supplier: {ex.Message}");
            }
        }  
        #endregion

        #region It is HTTP action result Update Suppliers details if successful, or an error message if an exception occurs 

        [HttpPut("UpdateSupplier/{id}")]
        
        public async Task<IActionResult> UpdateSupplier(int id, [FromBody]Suppliers supplier)
        {
            try
            {
                if (!await suppliersRepository.Update(id, supplier))
                {
                    throw new Exception();
                }
                return Content("Supplier details updated successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"SupplierId was not found: {ex.Message}");
            }
        }
        #endregion

        #region It is HTTP action result containing Suppliers details if successful, or an error message if an exception occurs 

        [HttpDelete("DeleteSupplier/{id}")]
        public async Task<IActionResult> DeleteSupplier(int id)
        {
            try
            {
                if (!await suppliersRepository.Delete(id))
                {
                    throw new Exception();
                }
                return Content($"Removing of supplier details {id} is successfull");
            }
            catch (Exception ex)
            {
                return StatusCode(500,$"SupplierId was not found: {ex.Message}");
            }
        }
        #endregion
    }
}
