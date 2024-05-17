using FluentAssertions;
using Force.DeepCloner;
using Moq;
using VideoVista.Api.Models.VideoMetadatas;
using Xunit;

namespace VideoVista.Api.Tests.Unit.Services.VideoMetadatas
{
	public partial class VideoMetadataServiceTests
	{
		[Fact]
		public async Task ShouldAddVideoMetadataAsync()
		{
			//given
			VideoMetadata randomVideoMetadata = CreateRandomVideoMetadata();
			VideoMetadata inputVideoMetadata = randomVideoMetadata;
			VideoMetadata storageVideoMetadata = inputVideoMetadata;
			VideoMetadata expectedVideoMetadata = storageVideoMetadata.DeepClone();

			this.storageBrokerMock.Setup(broker =>
				broker.InsertVideoMetadataAsync(inputVideoMetadata))
					.ReturnsAsync(expectedVideoMetadata);

			//when
			VideoMetadata actualVideoMetadata =
				await this.videoMetadataService.AddVideoMetadataAsync(inputVideoMetadata);

			//then
			actualVideoMetadata.Should().BeEquivalentTo(expectedVideoMetadata);

			this.storageBrokerMock.Verify(broker =>
				broker.InsertVideoMetadataAsync(It.IsAny<VideoMetadata>()),
					Times.Once());

			this.storageBrokerMock.VerifyNoOtherCalls();
			this.loggingBrokerMock.VerifyNoOtherCalls();
		}
	}
}
