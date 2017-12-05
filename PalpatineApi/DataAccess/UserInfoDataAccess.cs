using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PalpatineApi.Models;
using System.Threading.Tasks;

namespace PalpatineApi.DataAccess
{
	public class UserInfoDataAccess : Base.IUserInfoDataAccess
	{
		public ApplicationUser GetUserInfo(string userId)
		{
			ApplicationUser user = null;
			using (ApplicationDbContext ctx = new ApplicationDbContext())
			{
				user = ctx.Users.Where(u => u.Id == userId).FirstOrDefault();
			}

			return user;
		}

		public UserData GetUserData(string userId)
		{
			UserData userData = null;
			using (PalpatineData ctx = new PalpatineData())
			{
				userData = ctx.UserData.Where(u => u.UserGuid == userId).FirstOrDefault();
			}

			return userData;
		}

		public async Task<bool> UpdateUser(UserViewModel userModel)
		{
			var retVal = false;
			var userData = new UserData();

			try
			{
				using (PalpatineData ctx = new PalpatineData())
				{
					userData = ctx.UserData.Where(u => u.Id == userModel.UserId).FirstOrDefault();
					ctx.UserData.Attach(userData);

					var entry = ctx.Entry(userData);
					entry.State = System.Data.Entity.EntityState.Modified;

					await ctx.SaveChangesAsync();
				}
				
				retVal = true;
			}
			catch (Exception ex)
			{
				retVal = false;
			}

			return retVal;
		}

		public async Task<bool> DeleteUser(string userId)
		{
			throw new NotImplementedException();
		}
	}
}