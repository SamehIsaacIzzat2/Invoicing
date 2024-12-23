using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace Invoicing.UI.Pages.Invoices
{
    
    public class DeleteModel : PageModel
    {
        private readonly IConfiguration _configuration;

        public string ApiBaseUrl { get; private set; }

        public DeleteModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void OnGet()
        {
            ApiBaseUrl = _configuration["ApiBaseUrl"];
        }
    }
}
