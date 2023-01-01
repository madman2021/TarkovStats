using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using TarkovStats.Models;
using TarkovStats.Services;
using TarkovStats.Services.Validation;

namespace TarkovStats.Pages;

public class RecordRaid : PageModel
{
    private readonly IRaidService _raidService;

    public RecordRaid(IRaidService raidService)
    {
        _raidService = raidService;
        Maps = MapCollection.Maps.Select(m => (m.Key, m.Value.DisplayName, m.Value.ThumbImg)).ToArray();
        Results = Enum.GetNames<RaidResult>();
    }

    public class RecordRaidViewModel
    {
        [DisplayName("Map"), Required] public Map Map { get; set; }
        [DisplayName("Raid Result"), Required] public RaidResult RaidResult { get; set; }
        [DisplayName("PMC Kills"), Required] public uint PmcKills { get; set; }
        [DisplayName("ScavKills"), Required] public uint ScavKills { get; set; }
        [DisplayName("Total EXP"), Required] public uint ExpTotal { get; set; }

        [DisplayName("Raid Length (min)"), Required]
        public int MinLength { get; set; }
    }

    [BindProperty] public RecordRaidViewModel Input { get; set; }

    public (Map Map, string Display, string ImageUrl)[] Maps { get; }
    public string[] Results { get; }


    public void OnGet()
    {
    }

    [TempData(Key = "IndexMessage")] public string Message { get; set; }
    public bool HasMessage => !String.IsNullOrWhiteSpace(Message);

    [TempData(Key = "ErrorHolder")]
    public bool MessageError { get; set; }
    public async Task<IActionResult> OnPostAsync()
    {
        var raid = new Raid()
        {
            PmcKills = Input.PmcKills,
            RaidResult = Input.RaidResult,
            ScavKills = Input.ScavKills,
            Map = Input.Map,
            MinLength = Input.MinLength,
            EnteredAt = DateTime.Now,
            TotalEXP = Input.ExpTotal
        };
        if (await _raidService.InsertRaidAsync(new ModelStateWrapper(ModelState), raid) &&
            await _raidService.SaveChanges())
        {
            Message = $"Your {raid.Map} raid has been recorded";
            return RedirectToPage();
        }

        Message = "Failed to save raid";
        return Page();
    }
}