using ShoppingCartService.Models.DTO;
using ShoppingCartService.Repositories;

namespace ShoppingCartService.Services
{
    public class TracksService
    {
        private readonly TracksRepository _tracksRepository;

        public TracksService(TracksRepository tracksRepository)
        {
            _tracksRepository = tracksRepository;
        }

        public Track GetTrackById(int trackId)
        {
            return _tracksRepository.GetTracks().FirstOrDefault(t => t.TrackId == trackId);
        }
    }
}