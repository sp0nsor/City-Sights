using CSharpFunctionalExtensions;

namespace CitySights.Core.Models
{
    public class Image
    {
        private Image(Guid id, Guid sightId, string fileName)
        {
            Id = id;
            FileName = fileName;
            SightId = sightId;
        }

        public Guid Id { get; }
        public Guid SightId { get; }
        public string FileName { get; }

        public static Result<Image> Create(Guid id, Guid sightId, string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                return Result.Failure<Image>("File name can not be empty");
            }

            var image = new Image(id, sightId, fileName);

            return Result.Success(image);
        }
    }
}
