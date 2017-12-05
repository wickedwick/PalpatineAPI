using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PalpatineApi.Models
{
	public class Image
	{
		[Key]
		public int Id { get; set; }

		public string Source { get; set; }

		public string Thumbnail { get; set; }

		public int ThumbnailHeight { get; set; }

		public int ThumbnailWidth { get; set; }

		public string Caption { get; set; }

		public bool IsSelected { get; set; }

		public virtual List<Tag> Tags {get; set;}

		public virtual Gallery Gallery { get; set; }
	}
}