using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TarkovStats.Models;
using TarkovStats.Services;

namespace TarkovStats.Pages;

public class Show : PageModel
{
    private readonly IRaidService _raidService;
    [TempData(Key = "ShowMessage")] public string Message { get; set; }

    public bool HasMessage => !string.IsNullOrWhiteSpace(Message);

    public Show(IRaidService raidService)
    {
        _raidService = raidService;
    }

    public PagedResponse<Raid> RaidsList { get; set; }

    public async Task OnGet(int currentPage)
    {
        RaidsList = await _raidService.GetRaids(currentPage, 20, true);
    }

    public async Task<IActionResult> OnPostDeleteAsync(int id)
    {
        if (await _raidService.DeleteRaid(id))
        {
            Message = "Raid deleted";
        }
        else
        {
            Message = "Error failed to delete";
        }

        ;
        return RedirectToPage();
    }
}