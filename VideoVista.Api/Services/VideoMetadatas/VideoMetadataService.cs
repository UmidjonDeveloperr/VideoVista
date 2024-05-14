using System;
using System.Linq;
using System.Threading.Tasks;
using VideoVista.Api.Brokers.Storages;
using VideoVista.Api.Models.VideoMetadatas;

namespace VideoVista.Api.Services.VideoMetadatas
{
	public class VideoMetadataService : IVideoMetadataService
	{
		private readonly IStorageBroker storageBroker;

		public VideoMetadataService(IStorageBroker storageBroker)
		{
			this.storageBroker = storageBroker;
		}

		public async ValueTask<VideoMetadata> AddVideoMetadataAsync(VideoMetadata videoMetadata) =>
			await this.storageBroker.InsertVideoMetadataAsync(videoMetadata);

		public IQueryable<VideoMetadata> RetrieveAllVideoMetadatas() =>
			this.storageBroker.SelectAllVideoMetadatas();

		public async ValueTask<VideoMetadata> RetrieveVideoMetadataByIdAsync(Guid Id) =>
			await this.storageBroker.SelectVideoMetadataAsync(Id);

		public async ValueTask<VideoMetadata> ModifyVideoMetadataAsync(VideoMetadata videoMetadata) =>
			await this.storageBroker.UpdateVideoMetadataAsync(videoMetadata);

		public async ValueTask<VideoMetadata> RemoveVideoMetadataAsync(Guid guid)
		{
			VideoMetadata gettingVideoMetadata =
				await this.storageBroker.SelectVideoMetadataAsync(guid);

			return await this.storageBroker.DeleteVideoMetadataAsync(gettingVideoMetadata);
		}
	}
}
