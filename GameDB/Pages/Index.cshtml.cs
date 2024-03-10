using GameDB.Models;
using GameDB.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace GameDB.Pages
{
    public class IndexModel : PageModel
    {
        public List<Game> Games { get; set; }

        private readonly ILogger<IndexModel> _logger;
        private readonly AppDbContext _context;

        public IndexModel(ILogger<IndexModel> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public void OnGet()
        {
            Games = _context.Games.Include(g => g.Genres).ToList();
        }
    }
}
