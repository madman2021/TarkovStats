using TarkovStats.Models;
using TarkovStats.Services.Validation;

namespace TarkovStats.Services;

public interface IRaidService
{
    Task<bool> InsertRaidAsync(IValidationDictionary state,Raid raid);
    Task<PagedResponse<Raid>> GetRaids(int page,int recordsPerPage,bool desc);
    Task<bool> ClearRaids();
    Task<bool> DeleteRaid(int id);
    Task<bool> SaveChanges();
}