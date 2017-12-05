using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PalpatineApi.BusinessLogic;
using PalpatineApi.DataAccess;
using PalpatineApi.DataAccess.Base;
using PalpatineApi.Models;
using System.Threading.Tasks;

namespace PalpatineApi.Tests.BusinessLogic
{
	[TestClass]
	public class GalleryBusinessLogicTests
	{
		private Mock<IGalleryDataAccess> GalleryDal;

		[TestMethod]
		public void TestGetGalleryById_Success()
		{
			GalleryDal = new Mock<IGalleryDataAccess>();
			Gallery testGallery = new Gallery
			{
				Id = 1,
				GalleryName = "TestGal"
			};

			GalleryDal.Setup(x => x.GetGalleryById(It.IsAny<int>())).Returns(Task.FromResult(testGallery));

			var systemUnderTest = new GalleryBusinessLogic(GalleryDal.Object);
			var result = systemUnderTest.GetGalleryById(1).Result;

			Assert.IsNotNull(result);
			Assert.AreEqual("TestGal", result.GalleryName);
		}

		[TestMethod]
		public void TestGetGalleryById_IdNotFound()
		{
			GalleryDal = new Mock<IGalleryDataAccess>();
			Gallery testGallery = new Gallery
			{
				Id = 1,
				GalleryName = "TestGal"
			};

			GalleryDal.Setup(x => x.GetGalleryById(It.IsAny<int>())).Returns(Task.FromResult(new Gallery()));

			var systemUnderTest = new GalleryBusinessLogic(GalleryDal.Object);
			var result = systemUnderTest.GetGalleryById(1).Result;

			Assert.IsNotNull(result);
			Assert.AreEqual(null, result.GalleryName);
		}

		[TestMethod]
		public void TestCreateGallery_Success()
		{
			GalleryDal = new Mock<IGalleryDataAccess>();
			string galleryName = "TestGallery";
			Gallery galleryResult = new Gallery
			{
				Id = 1,
				GalleryName = "TestGallery"
			};

			GalleryDal.Setup(x => x.CreateGallery(It.IsAny<Gallery>())).Returns(Task.FromResult(true));

			var systemUnderTest = new GalleryBusinessLogic(GalleryDal.Object);
			var result = systemUnderTest.CreateGallery(galleryName).Result;

			Assert.IsNotNull(result);
			Assert.IsTrue(result);
		}

		[TestMethod]
		public void TestCreateGallery_FailEmptyString()
		{
			string galleryName = "";
			var systemUnderTest = new GalleryBusinessLogic();
			var result = systemUnderTest.CreateGallery(galleryName).Result;

			Assert.IsNotNull(result);
			Assert.IsFalse(result);
		}
	}
}
