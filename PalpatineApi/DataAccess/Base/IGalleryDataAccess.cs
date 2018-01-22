using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PalpatineApi.Models;

namespace PalpatineApi.DataAccess.Base
{
	/// <summary>
	/// Data Access Layer for Gallery CRUD operations.
	/// </summary>
	public interface IGalleryDataAccess
	{
		/// <summary>
		/// Returns a Gallery object with all Images associated with it
		/// </summary>
		/// <param name="id">The Id of the gallery to return.</param>
		/// <returns>Gallery object</returns>
		Task<Gallery> GetGalleryById(int id);

		/// <summary>
		/// Returns the Gallery given it's name -- soon will have an attribute to check client info from headers.
		/// </summary>
		/// <param name="galleryName">The name of the gallery</param>
		/// <returns>The Gallery object with images.</returns>
		Task<Gallery> GetGalleryByName(string galleryName);

		/// <summary>
		/// Creates a new gallery.
		/// </summary>
		/// <param name="gallery">The gallery object from the BLL.</param>
		/// <returns>True if creation success, false if error.</returns>
		Task<bool> CreateGallery(Gallery gallery);

		/// <summary>
		/// Updates a gallery.
		/// </summary>
		/// <param name="gallery">The updated gallery from the BLL to save.</param>
		/// <returns>True if update is successful, false if error.</returns>
		Task<bool> UpdateGallery(Gallery gallery);

		/// <summary>
		/// Adds an image to an existing gallery.
		/// </summary>
		/// <param name="image">The image object to add.</param>
		/// <param name="galleryId">The gallery Id to add the image to.</param>
		/// <returns>True if success, false if error.</returns>
		Task<bool> AddImageToGallery(Image image, int galleryId);
	}
}
