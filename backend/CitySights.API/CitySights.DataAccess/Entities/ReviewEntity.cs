namespace CitySights.DataAccess.Entities
{
    public class ReviewEntity
    {
        public Guid Id { get; set; }
        public Guid SightId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string ReviewText { get; set; } = string.Empty;
        public int Rating { get; set; } = 0;

    }
}
