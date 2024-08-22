using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pharma.DTO;
using pharma.Model;

namespace pharma.Interface
{
    public interface IDrugRequestRepository
    {
        Task<List<DrugRequest>> GetAll();
        Task<List<DrugRequest>> GetById(int userId);
        Task<DrugRequest> Add(DrugRequestDto dto);
        Task<bool> Update(int userId, DrugRequestDto dto);
    }
}