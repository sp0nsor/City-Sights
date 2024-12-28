namespace CitySights.API.Contracts
{
    public record SightResponse(
        Guid id,
        string Name,
        string Descriptions,
        string ImagePath,
        List<ReviewResponse>? Reviews);
}
