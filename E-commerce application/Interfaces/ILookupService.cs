using E_commerce_application.DTOs.Lookups.Request;
using E_commerce_application.DTOs.Lookups.Response;

namespace E_commerce_application.Interfaces
{
    public interface ILookupService
    {
    Task<List<LookuptypeDTOs>> ReadLookupType();
    Task<List<LookupItemDTO>> GetLookupItem(int LookupTypeId);
    Task UpdateLookupItem(UpdateLookupItemDTO input);
    }
}
