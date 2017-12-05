using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PalpatineApi.Models
{
	public class Gallery
	{
		[Key]
		public int Id { get; set; }

		public string GalleryName { get; set; }

		public virtual List<Image> Images { get; set; }
	}
}