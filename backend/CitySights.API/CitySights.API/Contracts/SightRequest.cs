using System.ComponentModel.DataAnnotations;

namespace CitySights.API.Contracts
{
    public record SightRequest(
        [Required] string Name,
        [Required] string Description,
        IFormFile? Image);
}
