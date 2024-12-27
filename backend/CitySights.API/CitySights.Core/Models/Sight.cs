using CSharpFunctionalExtensions;

namespace CitySights.Core.Models
{
    public class Sight
    {
        private readonly List<Review> _reviews = [];

        private Sight(
            Guid id,
            string name,
            string description,
            Image? image,
            List<Review>? reviews)
        {
            Id = id;
            Name = name;
            Image = image;
            Description = description;
            _reviews = reviews;
        }

        public Guid Id { get; }
        public string Name { get; }
        public string Description { get; }
        public Image? Image { get; }
        public IReadOnlyCollection<Review>? Reviews => _reviews;

        public static Result<Sight> Create (Guid id, string name,
            string description, Image? image, List<Review>? reviews)
        {
            if(string.IsNullOrWhiteSpace(name) || name.Length > Review.MAX_TITLE_LENGTH)
            {
                return Result.Failure<Sight>($"Name can not be empty or more than {Review.MAX_TITLE_LENGTH} symbols.");
            }

            if (string.IsNullOrWhiteSpace(description) || description.Length > Review.MAX_REVIEW_LENGTH)
            {
                return Result.Failure<Sight>($"Description can not be empty or more than {Review.MAX_REVIEW_LENGTH} symbols.");
            }

            var sigth = new Sight(id, name, description, image, reviews);

            return Result.Success(sigth);
        }

    }
}
