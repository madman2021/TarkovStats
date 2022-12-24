using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TarkovStats.Models;
using TarkovStats.Services.Validation.ViewModels;

namespace TarkovStats.Pages;

public class Maps : PageModel
{
    public Dictionary<Map, MapInfo> MapList => MapCollection.Maps;

    public void OnGet()
    {
    }
}