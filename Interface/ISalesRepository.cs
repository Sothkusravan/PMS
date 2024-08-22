using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pharma.DTO;
using pharma.Model;

namespace pharma.Interface
{
    public interface ISalesRepository
    {
        Task<List<Sales>> GetAll();
        Task<Sales> GetById(int salesId);
        Task<Sales> Add(SalesDto dto);
        Task<bool> Delete(int salesID);
        
    }
}