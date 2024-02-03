namespace ShoppingCartService.Models.DTO
{
    public class Track
    {
        public int TrackId { get; set; }
        public string Name { get; set; }
        public List<string> Artists { get; set; }
        public List<string> Genres { get; set; }
        public string Album { get; set; }
        public string Year { get; set; }
        public int Price {  get; set; }
    }
}
