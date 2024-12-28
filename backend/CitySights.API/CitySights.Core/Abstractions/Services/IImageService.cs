using CitySights.Core.Models;
using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Http;

namespace CitySights.Application.Services
{
    public interface IImageService
    {
        Task<Result<Image>> CreateImage(IFormFile titleImage, string path);
        Task<Result<string>> GetImageAsBase64(string filePath);
    }
}