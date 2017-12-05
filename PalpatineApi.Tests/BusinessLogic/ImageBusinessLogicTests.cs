using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PalpatineApi.Models;
using PalpatineApi.DataAccess.Base;
using PalpatineApi.DataAccess;
using PalpatineApi.BusinessLogic.Base;
using PalpatineApi.BusinessLogic;

namespace PalpatineApi.Tests.BusinessLogic
{

	[TestClass]
	public class ImageBusinessLogicTests
	{
		private Mock<IImageDataAccess> ImageDal;

		[TestMethod]
		public void TestGetImage_Success()
		{
			Image image = new Image
			{
				Id = 1,
				Source = "/test/url/1"
			};
			ImageDal = new Mock<IImageDataAccess>();
			ImageDal.Setup(x => x.GetImage(It.IsAny<int>())).Returns(Task.FromResult(image));
			var systemUnderTest = new ImageBusinessLogic(ImageDal.Object);
			var result = systemUnderTest.GetImage(1).Result;

			Assert.IsNotNull(result.Source);
			Assert.AreEqual("/test/url/1", result.Source);
		}
	}
}
