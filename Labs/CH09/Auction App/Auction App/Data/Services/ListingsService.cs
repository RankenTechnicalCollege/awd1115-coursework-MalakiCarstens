using Auction_App.Models;
using Microsoft.EntityFrameworkCore;

namespace Auction_App.Data.Services
{
    public class ListingsService : IListingsService
    {
        private readonly ApplicationDbContext _context;

    public ListingsService(ApplicationDbContext context)
    {
        _context = context;
    }
    
        public IQueryable<Listing> GetAll()
        {
           var applicationDbContext = _context.Listings.Include(l => l.User);
           return applicationDbContext;
        }
        public async Task Add(Listing listing)
        {
            _context.Listings.Add(listing);
            await _context.Listings.AddAsync(listing);
            await _context.SaveChangesAsync();
        }

        public async Task<Listing> GetById(int? id)
        {
            var listing = await _context.Listings
                .Include(l => l.User)
                .Include(l => l.Bids)
                .Include(l => l.Comments)
                .ThenInclude(c => c.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            return listing;
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
