using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using pharma.DTO;
using pharma.Services;

namespace pharma.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DrugRequestController : ControllerBase
    {
        private readonly DrugRequestServises drugRequestRepository;

        public DrugRequestController(DrugRequestServises dbe)
        {
            drugRequestRepository = dbe;
        }


    #region It is HTTP action result containing drug details if successful, or an error message if an exception occurs 

    [HttpGet("GetAllDrugDetails")]
    public async Task<IActionResult> GetAllDrugDetails()
    {
        try
        {
            var drugDetails = await drugRequestRepository.GetAll();
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
                var drugDetail = await drugRequestRepository.GetById(id);
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
        public async Task<IActionResult> AddDrugDetail([FromBody] DrugRequestDto dto)
        {
            try
            {
                var newDrugDetail = await drugRequestRepository.Add(dto);
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

        #region It is HTTP action result update Approved status if successful, or an error message if an exception occurs 
        [HttpPut("UpdateDrug/{requestId}")]
        public async Task<IActionResult> UpdateDrug(int requestId,[FromBody] DrugRequestDto dto)
        {
            try
            {
                var newDrugDetail = await drugRequestRepository.Update(requestId,dto);
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



    }

    
}