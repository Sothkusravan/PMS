using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pharma.DTO;
using pharma.Model;

namespace pharma.Interface
{
    public interface IDrugRepository
    {
         Task<List<DrugDetails>> GetAll();
        Task<DrugDetails> GetById(int drugId);
         Task<DrugDetails> Add(DrugDetailsDto dto);
        Task<bool> Update(int drugId, DrugDetailsDto drugdetails);
        Task<bool> UpdateQuanity(int drugId, DrugDetailsDtoUpdateQuantity drugdetails);
        
         Task<bool> Delete(int drugId);
    }
}