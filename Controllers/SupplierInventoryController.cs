using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using pharma.DTO;
using pharma.Model;
using pharma.Repository;
using pharma.Services;

namespace pharma.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SupplierInventoryController : ControllerBase
    {
         private readonly SupplierInventoryServises _suppliersInventoryService;

        public SupplierInventoryController(SupplierInventoryServises suppliersInventoryService)
        {
            _suppliersInventoryService = suppliersInventoryService;
        }

           #region It is HTTP action result containing Suppliers details if successful, or an error message if an exception occurs 

        [HttpGet("GetAllSuppliersInventory")]
        public async Task<IActionResult> GetAllSuppliersInventory()
        {
            try
            {
                var suppliersInevtory = await _suppliersInventoryService.GetAll();
                if(suppliersInevtory == null)
                {
                    throw new Exception();
                }
                return Ok(suppliersInevtory);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        #endregion

        #region It is HTTP action result containing Suppliers details based on Id if successful, or an error message if an exception occurs 

        [HttpGet("GetSupplierInventoryByID/{suplId}")]
        public async Task<IActionResult> GetSupplierInventoryByID(int suplId)
        {
            try
            {
                var supplier = await _suppliersInventoryService.GetById(suplId);
                if (supplier == null)
                {
                    throw new Exception("SuppliersDrug id not found");
                }
                return Ok(supplier);
            }
            catch (Exception ex)
            {
                return StatusCode(500,$"SupplierId was not found: {ex.Message}");
            }
        }
        #endregion

        [HttpGet("GetSupplierInventoryBySuplierID/{supplerId}")]
        public async Task<IActionResult> GetSupplierInventoryBySuplierID(int supplerId)
        {
            try
            {
                var supplier = await _suppliersInventoryService.GetBySupplierId(supplerId);
                if (supplier == null)
                {
                    throw new Exception("SuppliersDrug id not found");
                }
                return Ok(supplier);
            }
            catch (Exception ex)
            {
                return StatusCode(500,$"SupplierId was not found: {ex.Message}");
            }
        }
         [HttpGet("GetByDrugNameQuantityPrice/{drugName}")]
        public async Task<IActionResult> GetByDrugNameQuantityPrice(string drugName)
        {
            try
            {
                var supplier = await _suppliersInventoryService.GetByDrugNameQuantityPrice(drugName);
                if (supplier == null)
                {
                    throw new Exception("SuppliersDrug id not found");
                }
                return Ok(supplier);
            }
            catch (Exception ex)
            {
                return StatusCode(500,$"SupplierId was not found: {ex.Message}");
            }
        }

        

         #region It is HTTP action result Add Suppliers details if successful, or an error message if an exception occurs 
         [HttpPost("AddDrug")]
        public async Task<IActionResult> AddDrug([FromBody] SuppliersInventoryDto supplierInventory)
        {
            try
            {
                var newSupplier = await _suppliersInventoryService.AddSupplierWithDrugDetails(supplierInventory);
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

        [HttpPut("UpdateDrug/{id}")]
        public async Task<IActionResult> UpdateDrug(int id, [FromBody]SuppliersInventory supplier)
        {
            try
            {
                if (!await _suppliersInventoryService.Update(id, supplier))
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

        [HttpDelete("DeleteDrug/{id}")]
        public async Task<IActionResult> DeleteDrug(int id)
        {
            try
            {
                if (!await _suppliersInventoryService.Delete(id))
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