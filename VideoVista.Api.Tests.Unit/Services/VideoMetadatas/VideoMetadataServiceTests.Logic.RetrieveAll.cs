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
		public void ShouldRetrieveAllVideoMetadatas()
		{
			//given
			IQueryable<VideoMetadata> randomVideoMetadatas = CreateRandomVideoMetadatas();
			IQueryable<VideoMetadata> storageVideoMetadatas = randomVideoMetadatas;
			IQueryable<VideoMetadata> expectedVideoMetadatas = storageVideoMetadatas;

			this.storageBrokerMock.Setup(broker =>
				broker.SelectAllVideoMetadatas()).Returns(storageVideoMetadatas);

			//when
			IQueryable<VideoMetadata> actualVideoMetadata =
				this.videoMetadataService.RetrieveAllVideoMetadatas();

			//then
			actualVideoMetadata.Should().BeEquivalentTo(expectedVideoMetadatas);

			this.storageBrokerMock.Verify(broker =>
				broker.SelectAllVideoMetadatas(), Times.Once);

			this.storageBrokerMock.VerifyNoOtherCalls();
			this.loggingBrokerMock.VerifyNoOtherCalls();
		}
	}
}
