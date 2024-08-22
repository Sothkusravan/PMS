using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using pharma.DTO;
using pharma.Services;

namespace pharma.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalesController : ControllerBase
    {
         private readonly SalesServices salesRepository;

        public SalesController(SalesServices dbe)
        {
            salesRepository = dbe;
        }

        #region It is HTTP action result containing drug details if successful, or an error message if an exception occurs 

        [HttpGet("GetAllSalesDetails")]
        public async Task<IActionResult> GetAllSalesDetails()
        {
            try
            {
                var drugDetails = await salesRepository.GetAll();
                if(drugDetails==null)
                {
                    throw new Exception();
                }
                return Ok(drugDetails);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

        }
        #endregion

        #region It is HTTP action result containing drug details based on iD if successful, or an error message if an exception occurs 
        [HttpGet("GetSalesDetail/{id}")]
        public async Task<IActionResult> GetSalesDetail(int id)
        {
            try
            {
                var drugDetail = await salesRepository.GetById(id);
                if (drugDetail == null)
                {
                    throw new Exception();
                }
                return Ok(drugDetail);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Drug id was not found: {ex.Message}");
            }
        }
        #endregion

        #region It is HTTP action result Add drug details if successful, or an error message if an exception occurs 

        [HttpPost("AddsalesDetail")]
        public async Task<IActionResult> AddsalesDetail([FromBody] SalesDto dto)
        {
            try
            {
                var newDrugDetail = await salesRepository.Add(dto);
                if(newDrugDetail == null)
                {
                    throw new Exception();
                }
                return Ok(newDrugDetail);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        #endregion

          [HttpDelete("DeleteSalesDetails/{salesId}")]
        public async Task<IActionResult> DeleteSalesDetails(int salesId)
        {
            try
            {
                if (!await salesRepository.Delete(salesId))
                {
                    throw new Exception();
                }
                return Content("sales details deleted successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"sales id was not found: {ex.Message}");
            }
        }
        
    }
}