using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyScriptureJournal.Data;
using MyScriptureJournal.Models;

namespace MyScriptureJournal.Pages.Scriptures
{
    public class IndexModel : PageModel
    {
        private readonly MyScriptureJournalContext _context;

        public IndexModel(MyScriptureJournalContext context)
        {
            _context = context;
        }

        public IList<Scripture> Scripture { get; set; } = default!;
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public SelectList Book { get; set; }
        [BindProperty(SupportsGet = true)]
        public string ScriptureBook { get; set; }

        // Add the sort order parameter to support sorting
        [BindProperty(SupportsGet = true)]
        public string SortOrder { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<string> bookQuery = from m in _context.Scripture
                                           orderby m.Book
                                           select m.Book;

            var scriptures = from m in _context.Scripture
                             select m;

            if (!string.IsNullOrEmpty(SearchString))
            {
                scriptures = scriptures.Where(s => s.Note.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(ScriptureBook))
            {
                scriptures = scriptures.Where(x => x.Book.Contains(ScriptureBook));
            }

            // Apply sorting based on SortOrder
            scriptures = SortOrder switch
            {
                "book_asc" => scriptures.OrderBy(s => s.Book),
                "book_desc" => scriptures.OrderByDescending(s => s.Book),
                "date_asc" => scriptures.OrderBy(s => s.DateAdded),
                "date_desc" => scriptures.OrderByDescending(s => s.DateAdded),
                _ => scriptures.OrderBy(s => s.Book), // Default sort by Book
            };

            Book = new SelectList(await bookQuery.Distinct().ToListAsync());
            Scripture = await scriptures.AsNoTracking().ToListAsync();
        }
    }
}
