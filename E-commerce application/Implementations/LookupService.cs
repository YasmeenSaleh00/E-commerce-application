using E_commerce_application.Context;
using E_commerce_application.DTOs.Lookups.Request;
using E_commerce_application.DTOs.Lookups.Response;
using E_commerce_application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace E_commerce_application.Implementations
{
    public class LookupService : ILookupService
    {
        private readonly CommerceDbContext _dbContext;
        public LookupService(CommerceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<LookupItemDTO>> GetLookupItem(int LookupTypeId)
        {
            if(LookupTypeId != null)
            {
                var result = from li in _dbContext.LookupItems
                             join lt in _dbContext.LookupTypes
                             on li.LookupTypeId equals lt.Id
                             where li.LookupTypeId == LookupTypeId
                             select new LookupItemDTO
                             {
                                 Id = li.Id,
                                 LookupTypName = lt.Name,
                                 Value = li.Value,
                                 CreationDate =li.CreationDate.ToShortDateString(), 
                                 IsDeleted = li.IsDeleted,

                             };
                return await result.ToListAsync();  
            }
            else
            {
                throw new Exception("You must Add the LookupTypeId");
            }
        }

        public async Task<List<LookuptypeDTOs>> ReadLookupType()
        {
            var result = from li in _dbContext.LookupTypes
                         select new LookuptypeDTOs
                         {
                             Id = li.Id,
                             Name = li.Name,
                       
                             CreationDate = li.CreationDate.ToString(),
                             IsDeleted = li.IsDeleted,
                         };
            return await  result.ToListAsync();
        }

        public async Task UpdateLookupItem(UpdateLookupItemDTO input)
        {
            if(input != null)
            {
               var rs = await _dbContext.LookupItems.FirstOrDefaultAsync(z=>z.Id == input.Id);
                if (rs != null)
                {
                    if (!string.IsNullOrEmpty(input.Value))
                    {
                        rs.Value = input.Value;
                        rs.ModificationDate= DateTime.Now;
                        
                    }
                    if (input.IsDeleted != null)
                    {
                        rs.IsDeleted = (bool)input.IsDeleted;
                        rs.ModificationDate = DateTime.Now;
                    }
                    _dbContext.Update(rs);
                    await _dbContext.SaveChangesAsync();

                }
                else
                {
                    throw new Exception($"No Lookup with the Given Id {input.Id}");
                }

            }
            else
            {
                throw new Exception("At Least give The Id");
            }
        }
    }
}
