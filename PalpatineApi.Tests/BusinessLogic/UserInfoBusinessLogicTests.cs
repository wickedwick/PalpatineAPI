using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PalpatineApi.Models;
using PalpatineApi.BusinessLogic;
using PalpatineApi.BusinessLogic.Base;
using PalpatineApi.DataAccess;
using PalpatineApi.DataAccess.Base;

namespace PalpatineApi.Tests.BusinessLogic
{
	[TestClass]
	public class UserInfoBusinessLogicTests
	{
		private Mock<IUserInfoDataAccess> userInfoDal;

		[TestMethod]
		public void TestGetUserInfo()
		{
			userInfoDal = new Mock<IUserInfoDataAccess>();
			ApplicationUser testUser = new ApplicationUser
			{
				Id = "test",
				UserName = "testyMctest"
			};
			UserData data = new UserData
			{
				FirstName = "testFirst",
				LastName = "testLast"
			};

			userInfoDal.Setup(x => x.GetUserInfo(It.IsAny<string>())).Returns(testUser);
			userInfoDal.Setup(x => x.GetUserData(It.IsAny<string>())).Returns(data);

			var systemUnderTest = new UserInfoBusinessLogic(userInfoDal.Object);
			var result = systemUnderTest.GetUserInfo("test").Result;

			Assert.IsNotNull(result);
			Assert.AreEqual("testyMctest", result.UserName);
		}
	}
}
