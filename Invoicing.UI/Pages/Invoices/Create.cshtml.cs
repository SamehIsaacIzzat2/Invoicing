using Microsoft.AspNetCore.Mvc.RazorPages;

public class CreateModel : PageModel
{
    private readonly IConfiguration _configuration;

    public string ApiBaseUrl { get; private set; }

    public CreateModel(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void OnGet()
    {
        ApiBaseUrl = _configuration["ApiBaseUrl"];
    }
}
