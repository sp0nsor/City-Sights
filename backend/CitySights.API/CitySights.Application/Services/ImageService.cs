using CitySights.Core.Models;
using CitySights.DataAccess.Repositories;
using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Http;

namespace CitySights.Application.Services
{
    public class ImageService : IImageService
    {
        public async Task<Result<Image>> CreateImage(IFormFile titleImage, string path)
        {
            try
            {
                var fileName = Path.GetFileName(titleImage.FileName);
                Console.WriteLine(titleImage.FileName);
                var filePath = Path.Combine(path, fileName);

                await using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await titleImage.CopyToAsync(stream);
                }

                var image = Image.Create(Guid.NewGuid(), Guid.NewGuid(), filePath);

                return image;
            }
            catch (Exception ex)
            {
                return Result.Failure<Image>(ex.Message);
            }
        }
        
        public async Task<Result<string>> GetImageAsBase64(string filePath)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    return Result.Failure<string>("File not found");
                }

                byte[] bytes = await File.ReadAllBytesAsync(filePath);

                return Result.Success(Convert.ToBase64String(bytes));
            }
            catch(Exception ex)
            {
                return Result.Failure<string>(ex.Message); 
            }
        }
    }
}
