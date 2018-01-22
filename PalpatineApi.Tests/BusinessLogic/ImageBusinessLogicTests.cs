using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PalpatineApi.Models;
using PalpatineApi.DataAccess.Base;
using PalpatineApi.DataAccess;
using PalpatineApi.BusinessLogic.Base;
using PalpatineApi.BusinessLogic;
using System.Collections.Generic;

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

		[TestMethod]
		public void TestGetGalleryImages()
		{
			Image image = new Image
			{
				Id = 1,
				Source = "/test/url/1"
			};
			Image image2 = new Image
			{
				Id = 2,
				Source = "/test/url/1"
			};
			Image image3 = new Image
			{
				Id = 3,
				Source = "/test/url/1"
			};
			List<Image> imageArr = new List<Image>();
			imageArr.Add(image);
			imageArr.Add(image2);
			imageArr.Add(image3);
			ImageDal = new Mock<IImageDataAccess>();
			ImageDal.Setup(x => x.GetImages(It.IsAny<int>())).Returns(Task.FromResult(imageArr));
			var systemUnderTest = new ImageBusinessLogic(ImageDal.Object);
			var result = systemUnderTest.GetGalleryImages(0).Result;

			Assert.AreEqual(image.Source, result[0].Source);
			Assert.AreEqual(image2.Id, result[1].Id);
			Assert.AreEqual(image3, result[2]);
		}
	}
}
