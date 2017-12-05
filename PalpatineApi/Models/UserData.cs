using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PalpatineApi.Models
{
	public class UserData
	{
		[Key]
		public string Id { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; } 

		public string UserGuid { get; set; }
	}
}