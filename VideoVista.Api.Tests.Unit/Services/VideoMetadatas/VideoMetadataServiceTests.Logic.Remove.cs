using FluentAssertions;
using Force.DeepCloner;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoVista.Api.Models.VideoMetadatas;
using Xunit;

namespace VideoVista.Api.Tests.Unit.Services.VideoMetadatas
{
	public partial class VideoMetadataServiceTests
	{
		[Fact]
		public async Task ShouldRemoveVideoMetadataAsync()
		{
			//given
			Guid randomGuid = Guid.NewGuid();
			VideoMetadata randomVideoMetadata = CreateRandomVideoMetadata();
			VideoMetadata storageVideoMetadata = randomVideoMetadata.DeepClone();
			VideoMetadata deletedVideoMetadata = randomVideoMetadata.DeepClone();
			VideoMetadata expectedDeletedVideoMetadata = deletedVideoMetadata.DeepClone();

			this.storageBrokerMock.Setup(broker =>
				broker.SelectVideoMetadataByIdAsync(It.IsAny<Guid>()))
					.ReturnsAsync(storageVideoMetadata);

			this.storageBrokerMock.Setup(broker =>
				broker.DeleteVideoMetadataAsync(storageVideoMetadata))
					.ReturnsAsync(deletedVideoMetadata);

			//when
			VideoMetadata actualDeletedVideoMetadata =
				await this.videoMetadataService.RemoveVideoMetadataAsync(randomGuid);

			//then
			actualDeletedVideoMetadata.Should().BeEquivalentTo(expectedDeletedVideoMetadata);

			this.storageBrokerMock.Verify(broker =>
				broker.SelectVideoMetadataByIdAsync(It.IsAny<Guid>()), Times.Once);

			this.storageBrokerMock.Verify(broker =>
				broker.DeleteVideoMetadataAsync(It.IsAny<VideoMetadata>()), Times.Once);

			this.storageBrokerMock.VerifyNoOtherCalls();
			this.loggingBrokerMock.VerifyNoOtherCalls();
		}



	}
}
