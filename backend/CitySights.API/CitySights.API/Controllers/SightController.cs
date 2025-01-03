﻿using CitySights.API.Contracts;
using CitySights.Application.Services;
using CitySights.Core.Models;
using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Mvc;

namespace CitySights.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SightController : ControllerBase
    {
        private readonly string staticFilePath =
            Path.Combine(Directory.GetCurrentDirectory(), "StaticFiles\\Images");

        private readonly ISightService sightService;
        private readonly IImageService imageService;

        public SightController(ISightService sightService, IImageService imageService)
        {
            this.sightService = sightService;
            this.imageService = imageService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateSight([FromForm] SightRequest request)
        {
            var imageResult = await imageService.CreateImage(request.Image, staticFilePath);

            if (imageResult.IsFailure)
            {
                return BadRequest(imageResult.Error);
            }

            var sightResult = Sight.Create(imageResult.Value.SightId, request.Name, request.Description, imageResult.Value, null);

            if (sightResult.IsFailure)
            {
                return BadRequest(sightResult.Error);
            }

            var reusltId = await sightService.CreateSight(sightResult.Value);

            if (reusltId.IsFailure)
            {
                return BadRequest(reusltId.Error);
            }

            return Ok(reusltId.Value);
        }

        [HttpGet]
        public async Task<ActionResult> GetSight()
        {
            var sightResult = await sightService.GetSights();

            if (sightResult.IsFailure)
                return BadRequest(sightResult.Error);

            var sightResponse = await Task.WhenAll(sightResult.Value.Select(async sight =>
            {
                var imageBase64 = !string.IsNullOrEmpty(sight.Image.FileName)
                    ? (await imageService.GetImageAsBase64(sight.Image.FileName)).GetValueOrDefault()
                    : null;

                return new SightResponse(
                    sight.Id,
                    sight.Name,
                    sight.Description,
                    imageBase64,
                    sight.Reviews?.Select(r => new ReviewResponse(r.Id, r.Title, r.ReviewText, r.Rating)).ToList()
                );
            }));

            return Ok(sightResponse);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateSight([FromQuery] Guid id, [FromBody] SightRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Name) || string.IsNullOrWhiteSpace(request.Description))
            {
                return BadRequest();
            }

            await sightService.UpdateSight(id, request.Name, request.Description);

            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteSight([FromQuery] Guid id)
        {
            var result = await sightService.DeleteSight(id);

            return Ok();
        }
    }
}
