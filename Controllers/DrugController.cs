using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using pharma.Interface;
using pharma.DTO;
using pharma.Services;
using Microsoft.VisualBasic;
using Microsoft.AspNetCore.Authorization;

namespace pharma.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DrugController : ControllerBase
    {
        private readonly DrugServices drugRepository;

        public DrugController(DrugServices dbe)
        {
            drugRepository = dbe;
        }

        #region It is HTTP action result containing drug details if successful, or an error message if an exception occurs 

        [HttpGet("GetAllDrugDetails")]
        public async Task<IActionResult> GetAllDrugDetails()
        {
            try
            {
                var drugDetails = await drugRepository.GetAll();
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
        [HttpGet("GetDrugDetail/{id}")]
        public async Task<IActionResult> GetDrugDetail(int id)
        {
            try
            {
                var drugDetail = await drugRepository.GetById(id);
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

        [HttpPost("AddDrugDetail")]
        public async Task<IActionResult> AddDrugDetail([FromBody] DrugDetailsDto dto)
        {
            try
            {
                var newDrugDetail = await drugRepository.Add(dto);
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

        #region It is HTTP action result Update drug details if successful, or an error message if an exception occurs 

        [HttpPut("UpdateDrugDetail/{id}")]
        public async Task<IActionResult> UpdateDrugDetail(int id, [FromBody] DrugDetailsDto dto)
        {
            try
            {
                if (!await drugRepository.Update(id, dto))
                {
                    throw new Exception();
                }
                return Content("Drug details updated successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $" Drug id was not found: {ex.Message}");
            }
        }
        #endregion
        [HttpPut("UpdateDrugDetailQuantity/{id}")]
        public async Task<IActionResult> UpdateDrugDetailQuantity(int id, [FromBody] DrugDetailsDtoUpdateQuantity dto)
        {
            try
            {
                if (!await drugRepository.UpdateQuantity(id, dto))
                {
                    throw new Exception();
                }
                return Content("Drug details updated successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $" Drug id was not found: {ex.Message}");
            }
        }

        #region It is HTTP action result Delete drug details if successful, or an error message if an exception occurs 

        [HttpDelete("DeleteDrugDetail/{id}")]
        public async Task<IActionResult> DeleteDrugDetail(int id)
        {
            try
            {
                if (!await drugRepository.Delete(id))
                {
                    throw new Exception();
                }
                return Content("Drug details deleted successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"drug id was not found: {ex.Message}");
            }
        }
        #endregion
    }
}


