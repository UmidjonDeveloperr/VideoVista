using System;
using System.Linq;
using System.Threading.Tasks;
using VideoVista.Api.Brokers.Loggings;
using VideoVista.Api.Brokers.Storages;
using VideoVista.Api.Models.VideoMetadatas;

namespace VideoVista.Api.Services.VideoMetadatas
{
	public class VideoMetadataService : IVideoMetadataService
	{
		private readonly IStorageBroker storageBroker;
		private readonly ILoggingBroker loggingBroker;

		public VideoMetadataService(IStorageBroker storageBroker, ILoggingBroker loggingBroker)
		{
			this.storageBroker = storageBroker;
			this.loggingBroker = loggingBroker;
		}

		public async ValueTask<VideoMetadata> AddVideoMetadataAsync(VideoMetadata videoMetadata) =>
			await this.storageBroker.InsertVideoMetadataAsync(videoMetadata);

		public async ValueTask<VideoMetadata> ModifyVideoMetadataAsync(VideoMetadata videoMetadata) =>
			await this.storageBroker.UpdateVideoMetadataAsync(videoMetadata);


		public async ValueTask<VideoMetadata> RemoveVideoMetadataAsync(Guid Id)
		{
			VideoMetadata gettingVideoMetadata =
				await this.storageBroker.SelectVideoMetadataByIdAsync(Id);

			return await this.storageBroker.DeleteVideoMetadataAsync(gettingVideoMetadata);
		}


		public IQueryable<VideoMetadata> RetrieveAllVideoMetadatas() =>
			this.storageBroker.SelectAllVideoMetadatas();


		public async ValueTask<VideoMetadata> RetrieveVideoMetadataByIdAsync(Guid Id) =>
			await this.storageBroker.SelectVideoMetadataByIdAsync(Id);


	}
}
