using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PalpatineApi.DataAccess.Base;
using PalpatineApi.DataAccess;
using PalpatineApi.Models;
using System.Threading.Tasks;

namespace PalpatineApi.BusinessLogic
{
	public class ImageBusinessLogic : Base.IImageBusinessLogic
	{
		private readonly IImageDataAccess ImageDal;

		public ImageBusinessLogic()
		{
			ImageDal = new ImageDataAccess();
		}

		public ImageBusinessLogic(IImageDataAccess imageDal)
		{
			ImageDal = imageDal;
		}

		public Task<bool> CreateImage(string source, string thumbnail, int thumbnailHeight, int thumbnailWidth, string caption, bool isSelected)
		{
			throw new NotImplementedException();
		}

		public Task<bool> DeleteImage(int id)
		{
			throw new NotImplementedException();
		}

		public async Task<Image> GetImage(int id)
		{
			return await ImageDal.GetImage(id);
		}

		public Task<bool> UpdateImage(int id, string source, string thumbnail, int thumbnailHeight, int thumbnailWidth, string caption, bool isSelected)
		{
			throw new NotImplementedException();
		}

		public async Task<List<Image>> GetGalleryImages(int galleryId)
		{
			return await ImageDal.GetImages(galleryId);
		}
	}
}