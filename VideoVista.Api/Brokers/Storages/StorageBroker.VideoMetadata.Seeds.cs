using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using VideoVista.Api.Models.VideoMetadatas;

namespace VideoVista.Api.Brokers.Storages
{
	public partial class StorageBroker
	{
		private static void SeedVideoMetadata(EntityTypeBuilder<VideoMetadata> builder)
		{
			builder.HasData(new VideoMetadata
			{
				Id = Guid.Parse("47729a8b-e359-493e-a982-e7c818cd1220"),
				Title = "Title",
				Discription = "FirstDiscription",
				BlobPath = "path",
				ThubNail = "thubnail",
				CreatedDate = DateTimeOffset.Now,
				UpdatedDate = DateTimeOffset.Now
			});
		}
	}
}
