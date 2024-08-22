using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using pharma.Interface;
using pharma.DTO;
using pharma.Services;
using Microsoft.AspNetCore.Authorization;

namespace pharma.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderDetailsController : ControllerBase
    {
        private readonly OrderDetailsServises orderDetailsRepository;

        public OrderDetailsController(OrderDetailsServises dbe)
        {
            orderDetailsRepository = dbe;
        }

        #region It is HTTP action result containing Order details if successful, or an error message if an exception occurs 

        [HttpGet("GetAllOrderDetails")]
        public async Task<IActionResult> GetAllOrderDetails()
        {
            try
            {
                var orderDetails = await orderDetailsRepository.GetAll();
                if(orderDetails == null)
                {
                    throw new Exception();
                }
                return Ok(orderDetails);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        #endregion

        #region It is HTTP action result containing Order details based on Id if successful, or an error message if an exception occurs 

        [HttpGet("GetOrderDetail/{id}")]
        public async Task<IActionResult> GetOrderDetail(int id)
        {
            try
            {
                var orderDetail = await orderDetailsRepository.GetById(id);
                if (orderDetail == null)
                {
                    throw new Exception();
                }
                return Ok(orderDetail);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"OrderId was not found:{ex.Message}");
            }
        }
        #endregion

        #region It is HTTP action result Add Order details if successful, or an error message if an exception occurs 

        [HttpPost("AddOrderDetail")]
        public async Task<IActionResult> AddOrderDetail([FromBody]OrderDetailsDto orderDetail)
        {
            try
            {
                var newOrderDetail = await orderDetailsRepository.Add(orderDetail);
                if(newOrderDetail == null)
                {
                    throw new Exception();
                }
                return Ok(newOrderDetail);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        #endregion

        #region It is HTTP action result Update Order details if successful, or an error message if an exception occurs 

        [HttpPut("UpdateOrderDetail/{id}")]
        public async Task<IActionResult> UpdateOrderDetail(int id, [FromBody] OrderDetailsDto dto)
        {
            try
            {
                if (!await orderDetailsRepository.Update(id, dto))
                {
                    throw new Exception();
                }
                return Content("Order details updated successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"OrderId was not found: {ex.Message}");
            }
        }
        #endregion

        #region It is HTTP action result Delete Order details if successful, or an error message if an exception occurs 

        [HttpDelete("DeleteOrderDetail/{id}")]
        public async Task<IActionResult> DeleteOrderDetail(int id)
        {
            try
            {
                if (!await orderDetailsRepository.Delete(id))
                {
                    throw new Exception();
                }
                return Content("Order details successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"OrderId was not found: {ex.Message}");
            }
        }
        #endregion
    }
    
}
