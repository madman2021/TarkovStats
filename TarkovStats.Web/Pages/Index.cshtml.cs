using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TarkovStats.Pages;

public class Index : PageModel
{
    public IActionResult OnGet()
    {
        return RedirectToPage("/Raids/RecordRaid");
    }
}