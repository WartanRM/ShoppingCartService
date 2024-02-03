using ShoppingCartService.Models;
using ShoppingCartService.Models.DTO;

namespace ShoppingCartService.Repositories
{
    public class TracksRepository
    {
        private readonly ShoppingCartContext _context;

        public TracksRepository(ShoppingCartContext context)
        {
            _context = context;
        }

        public IEnumerable<Track> GetTracks()
        {
            return _context.Tracks.ToList();
        }
    }
}