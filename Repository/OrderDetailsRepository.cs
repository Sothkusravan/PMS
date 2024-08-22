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
    public class OrderDetailsRepository : IOrderDetailsRepository
    {
        private readonly PharmaDbContext db;

        public OrderDetailsRepository(PharmaDbContext dbContext)
        {
            db = dbContext;
        }

        #region  This method retrive the all order details
        public async Task<List<OrderDetails>> GetAll()
        {
            try
            {
                var obj= await db.OrderDetails.ToListAsync();
                if(obj == null)
                {
                    throw new Exception("Error occurred while fetching all order details");
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

        #region This method retrive the order details by orderId
        public async Task<OrderDetails> GetById(int orderId)
        {
            try
            {
                var obj= await db.OrderDetails.SingleOrDefaultAsync(i => i.OrderId == orderId);
                if(obj == null)
                {
                    throw new Exception("Error occurred while fetching order detail with ID {orderId}");
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

        #region This method Adds the order details to database
        public async Task<OrderDetails> Add(OrderDetailsDto dto)
        {
            try
            {
                OrderDetails newOrderDetail = dtoToOrderdetails(dto);
                if(newOrderDetail == null)
                {
                    throw new Exception("Error occurred while adding new order detail");
                }
                db.OrderDetails.Add(newOrderDetail);
                await db.SaveChangesAsync();
                return newOrderDetail;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        #endregion

        #region  This method is used to update the order details by orderId
        public async Task<bool> Update(int id, OrderDetailsDto dto)
        {
            try
            {
                var order = await db.OrderDetails.SingleOrDefaultAsync(i => i.OrderId == id);
                if (order == null)
                {
                    throw new Exception("Error occurred while updating order detail with ID {id}");
                }
                    order.PickUpStatus = dto.PickUpStatus;
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

        #region This method deletes the order details based on OrderId
        public async Task<bool> Delete(int id)
        {
            try
            {
                var order = await db.OrderDetails.SingleOrDefaultAsync(i => i.OrderId == id);
                if (order == null)
                {
                    throw new Exception("Error occurred while deleting order detail with ID {id}");
                }
                db.OrderDetails.Remove(order);
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

        #region Callin the DTO Class
        private OrderDetails dtoToOrderdetails(OrderDetailsDto dto)
        {
            return new OrderDetails
            {
                UserId = dto.UserId,
                DrugName = dto.DrugName,
                Quantity = dto.Quantity,
                PricePerUnit = dto.PricePerUnit,
                OrderedDate = dto.OrderedDate,
                PickUpStatus = dto.PickUpStatus
            };
        }
        #endregion
    }
}
