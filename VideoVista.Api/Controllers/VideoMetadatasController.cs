﻿using Microsoft.AspNetCore.Mvc;
using RESTFulSense.Controllers;
using System;
using System.Linq;
using System.Threading.Tasks;
using VideoVista.Api.Models.VideoMetadatas;
using VideoVista.Api.Services.VideoMetadatas;

namespace VideoVista.Api.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class VideoMetadatasController : RESTFulController
	{
		private readonly IVideoMetadataService videoMetadataService;

		public VideoMetadatasController(IVideoMetadataService videoMetadataService)
		{
			this.videoMetadataService = videoMetadataService;
		}

		[HttpPost]
		public async ValueTask<ActionResult<VideoMetadata>> PostVideoMetadataAsync(VideoMetadata videoMetadata)
		{
			VideoMetadata postedVideoMetadata =
				await this.videoMetadataService.AddVideoMetadataAsync(videoMetadata);

			return Created(postedVideoMetadata);
		}

		[HttpGet]
		public ActionResult<IQueryable<VideoMetadata>> GetAllVideoMetadatas()
		{
			IQueryable storageVideoMetadatas =
				this.videoMetadataService.RetrieveAllVideoMetadatas();

			return Ok(storageVideoMetadatas);
		}

		[HttpGet("{VideoMetadataId}")]
		public async ValueTask<ActionResult<VideoMetadata>> GetVideoMetadataByIdAsync(Guid VideoMetadataId)
		{
			VideoMetadata storageVideoMetadata =
				await this.videoMetadataService.RetrieveVideoMetadataByIdAsync(VideoMetadataId);

			return Ok(storageVideoMetadata);
		}

		[HttpPut]
		public async ValueTask<ActionResult<VideoMetadata>> PutVideoMetadataAsync(VideoMetadata videoMetadata)
		{
			VideoMetadata storedVideoMetadata =
				await this.videoMetadataService.ModifyVideoMetadataAsync(videoMetadata);

			return Ok(storedVideoMetadata);
		}

		[HttpDelete]
		public async ValueTask<ActionResult<VideoMetadata>> DeleteVideoMetadataAsync(Guid videoMetadataId)
		{
			VideoMetadata storageVideoMetadata =
				await this.videoMetadataService.RemoveVideoMetadataAsync(videoMetadataId);

			return Ok(storageVideoMetadata);
		}

	}
}
