using System.ComponentModel.DataAnnotations;

namespace CitySights.API.Contracts
{
    public record ReviewResponse(
        Guid Id,
        string Title,
        string ReviewText,
        int Rating);
}
