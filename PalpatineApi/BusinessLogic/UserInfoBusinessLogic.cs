using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using PalpatineApi.Models;
using PalpatineApi.DataAccess;
using PalpatineApi.DataAccess.Base;

namespace PalpatineApi.BusinessLogic
{
	public class UserInfoBusinessLogic : Base.IUserInfoBusinessLogic
	{
		private readonly IUserInfoDataAccess userInfoDal;

		public UserInfoBusinessLogic()
		{
			this.userInfoDal = new UserInfoDataAccess();
		}

		public UserInfoBusinessLogic(IUserInfoDataAccess userInfoDal)
		{
			this.userInfoDal = userInfoDal;
		}

		public async Task<UserViewModel> GetUserInfo(string userId)
		{
			var identityUser = userInfoDal.GetUserInfo(userId);
			var userData = userInfoDal.GetUserData(userId);
			
			return MapDataToModel(identityUser, userData);
		}

		public Task<UserViewModel> UpdateUserInfo(string userId, UserViewModel userModel)
		{
			if (!userInfoDal.UpdateUser(userModel).Result)
			{
				throw new TaskCanceledException("User information failed to save");
			}

			return GetUserInfo(userId);
		}

		private UserViewModel MapDataToModel(ApplicationUser user, UserData data)
		{
			var userModel = new UserViewModel
			{
				FirstName = data.FirstName ?? "",
				LastName = data.LastName ?? "",
				Email = user.Email ?? "",
				PhoneNumber = user.PhoneNumber ?? "",
				UserName = user.UserName ?? "",
				UserId = user.Id ?? ""
			};
			return userModel;
		}
	}
}