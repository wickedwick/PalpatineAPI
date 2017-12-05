using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PalpatineApi.Models;

namespace PalpatineApi.DataAccess.Base
{
	public interface IUserInfoDataAccess
	{
		ApplicationUser GetUserInfo(string userId);

		UserData GetUserData(string userId);

		Task<bool> UpdateUser(UserViewModel userModel);

		Task<bool> DeleteUser(string userId);
	}
}
