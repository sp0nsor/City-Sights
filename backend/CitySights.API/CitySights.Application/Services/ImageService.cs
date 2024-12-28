using CitySights.Core.Models;
using CitySights.DataAccess.Repositories;
using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Http;

namespace CitySights.Application.Services
{
    public class ImageService : IImageService
    {
        private readonly IImageRepository imageRepository;

        public ImageService(IImageRepository imageRepository)
        {
            this.imageRepository = imageRepository;
        }

        public async Task<Result<Image>> CreateImage(IFormFile titleImage, string path)
        {
            try
            {
                var fileName = Path.GetFileName(titleImage.Name);
                var filePath = Path.Combine(path, fileName);

                await using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await titleImage.CopyToAsync(stream);
                }

                var image = Image.Create(Guid.NewGuid(), Guid.NewGuid(), filePath);

                //await imageRepository.Create(image.Value);

                return image;
            }
            catch (Exception ex)
            {
                return Result.Failure<Image>(ex.Message);
            }
        }
    }
}
