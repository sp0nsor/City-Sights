using CSharpFunctionalExtensions;

namespace CitySights.Core.Models
{
    public class Image
    {
        private Image(Guid id, string fileName)
        {
            Id = id;
            FileName = fileName;
        }

        public Guid Id { get; }
        public string FileName { get; }

        public static Result<Image> Create(Guid id, string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                return Result.Failure<Image>("File name can not be empty");
            }

            var image = new Image(id, fileName);

            return Result.Success(image);
        }
    }
}
