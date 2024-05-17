using Moq;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tynamix.ObjectFiller;
using VideoVista.Api.Brokers.Loggings;
using VideoVista.Api.Brokers.Storages;
using VideoVista.Api.Models.VideoMetadatas;
using VideoVista.Api.Services.VideoMetadatas;

namespace VideoVista.Api.Tests.Unit.Services.VideoMetadatas
{
	public partial class VideoMetadataServiceTests
	{
		private readonly Mock<IStorageBroker> storageBrokerMock;
		private readonly Mock<ILoggingBroker> loggingBrokerMock;
		private readonly IVideoMetadataService videoMetadataService;

        public VideoMetadataServiceTests()
        {
			this.storageBrokerMock = new Mock<IStorageBroker>();
            this.loggingBrokerMock = new Mock<ILoggingBroker>();

			this.videoMetadataService =
				new VideoMetadataService(storageBroker: this.storageBrokerMock.Object,
				loggingBroker: this.loggingBrokerMock.Object);
        }



		private static int GetRandomNumber() =>
			new IntRange(min: 0, max: 9).GetValue();

		private static IQueryable<VideoMetadata> CreateRandomVideoMetadatas() =>
			CreateVideoMetadataFiller(date: GetRandomDateTimeOffset)
				.Create(count: GetRandomNumber()).AsQueryable<VideoMetadata>();

		private static VideoMetadata CreateRandomVideoMetadata() =>
			CreateVideoMetadataFiller(date: GetRandomDateTimeOffset).Create();

		private static DateTimeOffset GetRandomDateTimeOffset =>
			new DateTimeRange(earliestDate: new DateTime()).GetValue();

		private static Filler<VideoMetadata> CreateVideoMetadataFiller(DateTimeOffset date)
		{
			var filler = new Filler<VideoMetadata>();
			filler.Setup().OnType<DateTimeOffset>().Use(date);

			return filler;
		}
    }
}
