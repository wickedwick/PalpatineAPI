using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PalpatineApi.Models;

namespace PalpatineApi.DataAccess.Base
{
	public interface IGalleryDataAccess
	{
		Task<Gallery> GetGalleryById(int id);

		Task<bool> CreateGallery(Gallery gallery);

		Task<bool> UpdateGallery();

		Task<bool> AddImageToGallery(Image image, int galleryId);
	}
}
