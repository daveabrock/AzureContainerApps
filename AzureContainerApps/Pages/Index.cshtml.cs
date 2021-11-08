using AzureContainerApps.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AzureContainerApps.Pages
{
    public class IndexModel : PageModel
    {
        private MyDbContext _context;
        public IndexModel(MyDbContext context)
        {
            _context = context;
        }

        public List<Customer> Customers { get; set; }

        public void OnGet()
        {
            Customers = (from customer in _context.Customer.Take(10)
                         select customer).ToList();
        }
    }
}