using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CitySights.API.Contracts
{
    public record ReviewRequest(
        [Required] Guid SightId,
        [Required] string Title,
        [Required] string ReviewText,
        [Required] int Rating);
}
