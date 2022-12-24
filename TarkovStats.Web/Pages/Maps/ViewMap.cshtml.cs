using Microsoft.AspNetCore.Mvc.RazorPages;
using TarkovStats.Models;

namespace TarkovStats.Pages;

public class ViewMap : PageModel
{
    public string ImageUrl { get; set; }
    public void OnGet(Map map,string name)
    {
        var selectedMap = MapCollection.Maps[map].MapTypeInfos[name].ImageUrl;
        ImageUrl = selectedMap;
    }
}