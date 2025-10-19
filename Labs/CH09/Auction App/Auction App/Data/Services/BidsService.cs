using Auction_App.Models;
using Microsoft.EntityFrameworkCore;

namespace Auction_App.Data.Services
{
    public class BidsService : IBidsService
    {
        private readonly ApplicationDbContext _context;

        public BidsService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Add(Bid bid)
        {
            _context.Bids.Add(bid);
            await _context.SaveChangesAsync();
        }

        public IQueryable<Bid> GetAll()
        {
           var applicationDbContext = from a in _context.Bids.Include(b => b.Listing).ThenInclude(b => b.User)
                select a;
           return applicationDbContext;
        }
    }
}
