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
            ViewData["isValid"] = false;
            ViewData["AlertType"] = "alert alert-danger";
            ViewData["ResultString"] = $"Year must be between 1900 and {nextYear}. Please try again.";
        }
        else
        {
            ViewData["isValid"] = true;
            ViewData["AlertType"] = "alert alert-success";
            ViewData["ResultString"] = Utils.GetZodiac(year);
            ViewData["ResultImageSrc"] = Utils.GetImageSrc(Utils.GetZodiac(year));
        }
        return Page();
    }

}
