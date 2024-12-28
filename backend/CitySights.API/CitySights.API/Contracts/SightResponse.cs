namespace CitySights.API.Contracts
{
    public record SightResponse(
        string Name,
        string Descriptions,
        string ImagePath,
        List<ReviewResponse>? Reviews);
}
