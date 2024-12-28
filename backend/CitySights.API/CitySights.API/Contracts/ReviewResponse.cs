using System.ComponentModel.DataAnnotations;

namespace CitySights.API.Contracts
{
    public record ReviewResponse(
        string Title,
        string ReviewText,
        int Rating);
}
