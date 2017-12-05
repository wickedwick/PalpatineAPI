using PalpatineApi.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.ModelBinding;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using PalpatineApi.Models;
using PalpatineApi.Providers;
using PalpatineApi.Results;
using PalpatineApi.BusinessLogic;
using PalpatineApi.BusinessLogic.Base;

namespace PalpatineApi.Controllers
{
	[Authorize]
	[EnableCors(origins: "http://localhost:3000,https://localhost:3000,http://localhost:5000,https://localhost:5000", headers: "*", methods: "*")]
	[RoutePrefix("api/UserInfo")]
	public class UserInfoController : ApiController
    {
		private readonly IUserInfoBusinessLogic userInfoBll;
		private const string ErrorMessage = "You do not have access to this user's information";
		private ApplicationUserManager userManager;
		
		public ApplicationUserManager UserManager
		{
			get
			{
				return userManager ?? Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
			}
			private set
			{
				userManager = value;
			}
		}

		public UserInfoController()
		{
			this.userInfoBll = new UserInfoBusinessLogic();
		}

		public UserInfoController(IUserInfoBusinessLogic userInfoBll)
		{
			this.userInfoBll = userInfoBll;
		}

		public UserInfoController(IUserInfoBusinessLogic userInfoBll, ApplicationUserManager usermanager)
		{
			this.userInfoBll = userInfoBll;
			this.UserManager = usermanager;
		}
		
		[JwtAuthentication]
		[HttpGet]
		public async Task<UserViewModel> Get(string id)
		{
			if (User.IsInRole("Emperor") || User.IsInRole("Vader") || User.Identity.GetUserId() == id)
			{
				return await userInfoBll.GetUserInfo(id);
			}

			throw new UnauthorizedAccessException(ErrorMessage);
		}

		[JwtAuthentication]
		[HttpPut]
		public async Task<UserViewModel> Put(string id, [FromBody]UserViewModel model)
		{
			if (User.IsInRole("Emperor") || User.IsInRole("Vader") || User.Identity.GetUserId() == id)
			{
				var user = await UserManager.FindByIdAsync(id);
				user.Email = model.Email;
				user.PhoneNumber = model.PhoneNumber;
				user.UserName = model.UserName;
				var updatedUser = await UserManager.UpdateAsync(user);
				return new UserViewModel();
			}

			throw new UnauthorizedAccessException(ErrorMessage);
		}
    }
}
