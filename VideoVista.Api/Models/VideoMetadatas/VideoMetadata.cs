using System;

namespace VideoVista.Api.Models.VideoMetadatas
{
	public class VideoMetadata
	{
		public Guid Id { get; set; }
		public string Title { get; set; }
		public string Discription { get; set; }
		public string BlobPath { get; set; }
		public string ThubNail { get; set; }
		public DateTimeOffset CreatedDate { get; set; }
		public DateTimeOffset UpdatedDate { get; set; }
	}
}
