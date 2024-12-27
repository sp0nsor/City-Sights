using CSharpFunctionalExtensions;
using System.Reflection.Emit;

namespace CitySights.Core.Models
{
    public class Review
    {
        public const int MAX_RATING = 5;
        public const int MAX_TITLE_LENGTH = 50;
        public const int MAX_REVIEW_LENGTH = 200;

        private Review(Guid id,
            Guid sightId,
            string title,
            string reviewText,
            int rating)
        {
            Id = id;
            SightId = sightId;
            Title = title;
            ReviewText = reviewText;
            Rating = rating;
        }

        public Guid Id { get; }
        public Guid SightId { get; }
        public string Title { get; }
        public string ReviewText { get; }
        public int Rating { get; }

        public static Result<Review> Create(Guid id, Guid sightId,
            string title, string reviewText, int rating)
        {
            if(string.IsNullOrWhiteSpace(title) || title.Length > MAX_TITLE_LENGTH)
            {
                return Result.Failure<Review>($"Title can not be empty or more than {MAX_TITLE_LENGTH} symbols.");
            }

            if (string.IsNullOrWhiteSpace(reviewText) || reviewText.Length > MAX_REVIEW_LENGTH)
            {
                return Result.Failure<Review>($"Review can not be empty or more than {MAX_REVIEW_LENGTH} symbols.");
            }

            if (rating < 0 || rating > MAX_RATING)
            {
                return Result.Failure<Review>($"Rating can not be negative or more than {MAX_RATING}.");
            }

            var review = new Review(id, sightId, title, reviewText, rating);

            return Result.Success(review);
        }
    }
}
