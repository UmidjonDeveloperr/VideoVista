using System;
using System.Linq;
using System.Threading.Tasks;
using VideoVista.Api.Models.VideoMetadatas;

namespace VideoVista.Api.Services.VideoMetadatas
{
	public interface IVideoMetadataService
	{
		ValueTask<VideoMetadata> AddVideoMetadataAsync(VideoMetadata videoMetadata);
		IQueryable<VideoMetadata> RetrieveAllVideoMetadatas();
		ValueTask<VideoMetadata> RetrieveVideoMetadataByIdAsync(Guid Id);
		ValueTask<VideoMetadata> ModifyVideoMetadataAsync(VideoMetadata videoMetadata);
		ValueTask<VideoMetadata> RemoveVideoMetadataAsync(Guid guid);
	}
}
