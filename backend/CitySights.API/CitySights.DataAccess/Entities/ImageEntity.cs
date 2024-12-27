namespace CitySights.DataAccess.Entities
{
    public class ImageEntity
    {
        public Guid Id { get; set; }
        public Guid SightId { get; set; }
        public string FileName { get; set; } = string.Empty;
    }
}
