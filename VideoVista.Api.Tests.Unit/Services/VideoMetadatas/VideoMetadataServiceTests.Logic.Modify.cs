﻿using FluentAssertions;
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
		public async Task ShouldModifyVideoMetadataAsync()
		{
			//given
			VideoMetadata randomVideoMetadata = CreateRandomVideoMetadata();
			VideoMetadata inputVideoMetadata = randomVideoMetadata;
			VideoMetadata updatedVideoMetadata = inputVideoMetadata.DeepClone();
			VideoMetadata expectedVideoMetadata = updatedVideoMetadata.DeepClone();

			this.storageBrokerMock.Setup(broker =>
				broker.UpdateVideoMetadataAsync(inputVideoMetadata))
					.ReturnsAsync(updatedVideoMetadata);

			//when
			VideoMetadata actualVideoMetadata = 
				await this.videoMetadataService.ModifyVideoMetadataAsync(inputVideoMetadata);

			//then
			actualVideoMetadata.Should().BeEquivalentTo(expectedVideoMetadata);

			this.storageBrokerMock.Verify(broker =>
				broker.UpdateVideoMetadataAsync(It.IsAny<VideoMetadata>()), Times.Once);

			this.storageBrokerMock.VerifyNoOtherCalls();
			this.loggingBrokerMock.VerifyNoOtherCalls();
		}
	}
}