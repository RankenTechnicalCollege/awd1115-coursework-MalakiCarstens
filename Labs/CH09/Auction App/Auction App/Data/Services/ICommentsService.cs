using Auction_App.Models;

namespace Auction_App.Data.Services
{
    public interface ICommentsService
    {
        Task Add(Comment comment);
    }
}
