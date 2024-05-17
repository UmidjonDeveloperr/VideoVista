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

		public ValueTask<VideoMetadata> ModifyVideoMetadataAsync(VideoMetadata videoMetadata)
		{
			throw new NotImplementedException();
		}

		public ValueTask<VideoMetadata> RemoveVideoMetadataAsync(Guid Id)
		{
			throw new NotImplementedException();
		}

		public IQueryable<VideoMetadata> RetrieveAllVideoMetadatas()
		{
			throw new NotImplementedException();
		}

		public ValueTask<VideoMetadata> RetrieveVideoMetadataByIdAsync(Guid Id)
		{
			throw new NotImplementedException();
		}
	}
}
