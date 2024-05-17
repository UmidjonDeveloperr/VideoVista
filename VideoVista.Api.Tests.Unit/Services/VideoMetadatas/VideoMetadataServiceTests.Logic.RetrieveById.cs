using FluentAssertions;
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
		public async Task ShouldRetrieveVideoMetadataById()
		{
			//given
			Guid randomId = Guid.NewGuid();
			VideoMetadata randomVideoMetadata = CreateRandomVideoMetadata();
			VideoMetadata storageVideoMetadata = randomVideoMetadata;
			VideoMetadata expectedVideoMetadata = storageVideoMetadata;

			this.storageBrokerMock.Setup(broker =>
				broker.SelectVideoMetadataByIdAsync(randomId))
					.ReturnsAsync(storageVideoMetadata);

			//when
			VideoMetadata actualVideoMetadata = 
				await this.videoMetadataService.RetrieveVideoMetadataByIdAsync(randomId);

			//then
			actualVideoMetadata.Should().BeEquivalentTo(expectedVideoMetadata);

			this.storageBrokerMock.Verify(broker =>
				broker.SelectVideoMetadataByIdAsync(randomId), Times.Once);

			this.storageBrokerMock.VerifyNoOtherCalls();
			this.loggingBrokerMock.VerifyNoOtherCalls();
		}
	}
}
