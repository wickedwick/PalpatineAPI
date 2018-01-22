using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PalpatineApi.Models;

namespace PalpatineApi.BusinessLogic.Base
{
	public interface IImageBusinessLogic
	{
		Task<Image> GetImage(int id);

		Task<bool> CreateImage(string source, string thumbnail, int thumbnailHeight, int thumbnailWidth, string caption, bool isSelected);

		Task<bool> UpdateImage(int id, string source, string thumbnail, int thumbnailHeight, int thumbnailWidth, string caption, bool isSelected);

		Task<bool> DeleteImage(int id);

		/// <summary>
		/// Gets all images associated with a gallery.
		/// </summary>
		/// <param name="galleryId">The ID of the gallery.</param>
		/// <returns>List of Image objects.</returns>
		Task<List<Image>> GetGalleryImages(int galleryId);
	}
}
