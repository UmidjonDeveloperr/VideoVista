using Microsoft.EntityFrameworkCore;
using VideoVista.Api.Models.VideoMetadatas;

namespace VideoVista.Api.Brokers.Storages
{
	public partial class StorageBroker
	{
		public DbSet<VideoMetadata> VideoMetadatas { get; set; }
	}
}
