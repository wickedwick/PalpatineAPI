using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PalpatineApi.Models
{
	public class Tag
	{
		[Key]
		public int Id { get; set; }

		public string Title { get; set; }

		public string Value { get; set; }
	}
}