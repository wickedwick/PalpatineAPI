using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PalpatineApi.Models;

namespace PalpatineApi.BusinessLogic.Base
{
	public interface IGalleryBusinessLogic
	{
		Task<Gallery> GetGalleryById(int id);

		Task<bool> CreateGallery(string galleryName);

		Task<bool> UpdateGallery(int id, string galleryName);

		Task<bool> DeleteGallery(int id);

		Task<bool> AddImageToGallery(Image image, int galleryId);
	}
}
