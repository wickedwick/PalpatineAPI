using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PalpatineApi.Models;

namespace PalpatineApi.BusinessLogic.Base
{
	public interface IAuthenticationBusinessLogic
	{
		string GetTokenInstance(string username);
	}
}
