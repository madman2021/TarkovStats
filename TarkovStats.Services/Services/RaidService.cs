using System.Text.Json;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using TarkovStats.Models;
using TarkovStats.Repo;
using TarkovStats.Services.Validation;

namespace TarkovStats.Services.Services;

public class RaidService : BaseService<Raid>, IRaidService
{
    private readonly UserInfo _userInfo;

    private void Validate(IValidationDictionary validationDictionary, Raid raid)
    {
    }

    public async Task<bool> InsertRaidAsync(IValidationDictionary state, Raid raid)
    {
        raid.UserId = _userInfo.UserId;
        Validate(state, raid);
        if (!state.IsValid) return false;
        await _context.AddAsync(raid);
        return true;
    }

    public async Task<PagedResponse<Raid>> GetRaids(int page, int recordsPerPage, bool desc)
    {
        var qry = _context.Raids.Where(r => r.UserId == _userInfo.UserId);
        if (desc)
        {
            qry = qry.OrderByDescending(r => r.Id);
        }

        var pagedResponse = await PagedResponse<Raid>.CreateAsync(qry, page, recordsPerPage, 5);
        return pagedResponse;
    }

    public async Task<bool> ClearRaids()
    {
        try
        {
            await _context.Raids.Where(r => r.UserId == _userInfo.UserId).ExecuteDeleteAsync();
            return true;
        }
        catch (Exception e)
        {
        }

        return false;
    }

    public async Task<bool> DeleteRaid(int id)
    {
        try
        {
            var raid = await _context.Raids.Where(r => r.UserId == _userInfo.UserId && r.Id == id).FirstOrDefaultAsync();
            if (raid != null)
            {
                _context.Raids.Remove(raid);
                await _context.SaveChangesAsync();
                return true;
            }
        }
        catch (Exception ex)
        {
        }

        return false;
    }


    public RaidService(TarkovStatsContext context, UserInfo userInfo) : base(context)
    {
        _userInfo = userInfo;
    }
}