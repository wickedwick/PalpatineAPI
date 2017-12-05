using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PalpatineApi.Models;

namespace PalpatineApi.BusinessLogic.Base
{
	public interface IUserInfoBusinessLogic
	{
		Task<UserViewModel> GetUserInfo(string userId);

		Task<UserViewModel> UpdateUserInfo(string userId, UserViewModel userModel);
	}
}
