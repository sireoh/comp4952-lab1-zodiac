using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace comp4952_lab1_zodiac.Pages;

public class IndexModel : PageModel
{
    [BindProperty]
    public int year { get; set; }

    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {

    }

    public IActionResult OnPost()
    {
        int nextYear = DateTime.Now.Year + 1;
        if (year < 1900 || year > nextYear)
        {
            ViewData["Result"] = $"Year must be between 1900 and {nextYear}. Please try again.";
        }
        else
        {
            ViewData["Result"] = $"Your zodiac is {Utils.GetZodiac(year)}";
            ViewData["ImageSrc"] = Utils.GetImageSrc(Utils.GetZodiac(year));
        }
        return Page();
    }

}
