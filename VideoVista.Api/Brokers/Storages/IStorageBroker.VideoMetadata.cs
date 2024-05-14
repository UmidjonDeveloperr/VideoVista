using System;
using System.Linq;
using System.Threading.Tasks;
using VideoVista.Api.Models.VideoMetadatas;

namespace VideoVista.Api.Brokers.Storages
{
	public partial interface IStorageBroker
	{
		ValueTask<VideoMetadata> InsertVideoMetadataAsync(VideoMetadata videoMetadata);
		IQueryable<VideoMetadata> SelectAllVideoMetadatas();
		ValueTask<VideoMetadata> SelectVideoMetadataAsync(Guid Id);
		ValueTask<VideoMetadata> UpdateVideoMetadataAsync(VideoMetadata videoMetadata);
		ValueTask<VideoMetadata> DeleteVideoMetadataAsync(VideoMetadata videoMetadata);
	}
}
