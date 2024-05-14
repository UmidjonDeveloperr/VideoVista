using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using VideoVista.Api.Models.VideoMetadatas;

namespace VideoVista.Api.Brokers.Storages
{
	public partial class StorageBroker
	{
		public DbSet<VideoMetadata> VideoMetadatas { get; set; }

		public async ValueTask<VideoMetadata> InsertVideoMetadataAsync(VideoMetadata videoMetadata) =>
			await InsertAsync(videoMetadata);

		public IQueryable<VideoMetadata> SelectAllVideoMetadatas() =>
			SelectAll<VideoMetadata>();

		public async ValueTask<VideoMetadata> SelectVideoMetadataAsync(Guid Id) =>
			await SelectAsync<VideoMetadata>(Id);

		public async ValueTask<VideoMetadata> UpdateVideoMetadataAsync(VideoMetadata videoMetadata) =>
			await UpdateAsync(videoMetadata);

		public async ValueTask<VideoMetadata> DeleteVideoMetadataAsync(VideoMetadata videoMetadata) =>
			await DeleteAsync(videoMetadata);
	}
}
