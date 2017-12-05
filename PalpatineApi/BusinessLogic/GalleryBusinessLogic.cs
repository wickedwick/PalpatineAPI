using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PalpatineApi.Models;
using PalpatineApi.BusinessLogic.Base;
using PalpatineApi.DataAccess;
using PalpatineApi.DataAccess.Base;
using System.Threading.Tasks;

namespace PalpatineApi.BusinessLogic
{
	public class GalleryBusinessLogic : IGalleryBusinessLogic
	{
		private readonly IGalleryDataAccess GalleryDal;

		public GalleryBusinessLogic()
		{
			GalleryDal = new GalleryDataAccess();
		}

		public GalleryBusinessLogic(IGalleryDataAccess galleryDal)
		{
			GalleryDal = galleryDal;
		}

		public async Task<bool> AddImageToGallery(Image image, int galleryId)
		{
			Gallery gallery = await GetGalleryById(galleryId);
			if (gallery == null) { return galse; }

			gallery.Images.Add(image);
			//UpdateGallery(gallery);
		}

		public async Task<bool> CreateGallery(string galleryName)
		{
			if (string.IsNullOrWhiteSpace(galleryName))
				return false;

			Gallery gallery = new Gallery
			{
				GalleryName = galleryName
			};

			return await GalleryDal.CreateGallery(gallery);
		}

		public Task<bool> DeleteGallery(int id)
		{
			throw new NotImplementedException();
		}

		public async Task<Gallery> GetGalleryById(int id)
		{
			Gallery gallery = await GalleryDal.GetGalleryById(id);
			return gallery;
		}

		public Task<bool> UpdateGallery(int id, string galleryName)
		{
			throw new NotImplementedException();
		}
	}
}