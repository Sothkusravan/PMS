using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pharma.DTO;
using pharma.Interface;
using pharma.Model;

namespace pharma.Services
{
    public class OrderDetailsServises
    {
        private readonly IOrderDetailsRepository orderDetailsRepository;

        public OrderDetailsServises(IOrderDetailsRepository dbe)
        {
            orderDetailsRepository = dbe;
        }

        public async Task<List<OrderDetails>> GetAll()
        {
            var getAll= await orderDetailsRepository.GetAll();
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
        public async Task<OrderDetails> GetById(int orderId)
        {
            var getById= await orderDetailsRepository.GetById(orderId);
             try
            {
                if(getById == null)
                {
                    throw new Exception($"Error occurred while getting drug with ID {orderId}");
                }
                return getById;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
               throw;
            }
        }
        public async Task<OrderDetails> Add(OrderDetailsDto dto)
        {
            var add= await orderDetailsRepository.Add(dto);
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
        public async Task<bool> Update(int orderId, OrderDetailsDto dto)
        {
            bool update= await orderDetailsRepository.Update(orderId,dto);
            try
            {
                if(update == false)
                {
                    throw new Exception($"Error occurred while updating drug with ID {orderId}");
                }
                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        public async Task<bool> Delete(int orderId)
        {
            bool delete= await orderDetailsRepository.Delete(orderId);
            try
            {
                if(delete == false)
                {
                    throw new Exception($"Error occurred while deleting drug with ID {orderId}");
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