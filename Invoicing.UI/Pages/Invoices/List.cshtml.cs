using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Invoicing.UI.Pages.Invoices
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration _configuration;

        public string ApiBaseUrl { get; private set; }

        public ListModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void OnGet()
        {
            ApiBaseUrl = _configuration["ApiBaseUrl"];
        }
    }
}
