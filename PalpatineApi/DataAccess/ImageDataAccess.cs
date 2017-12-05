using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PalpatineApi.Models;
using PalpatineApi.DataAccess.Base;
using System.Threading.Tasks;

namespace PalpatineApi.DataAccess
{
	public class ImageDataAccess : IImageDataAccess
	{
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
			Image image = null;

			try
			{
				using (PalpatineData ctx = new PalpatineData())
				{
					image = ctx.Image.Where(x => x.Id == id).FirstOrDefault();
				}
			}
			catch (Exception ex)
			{
				
			}

			return image;
		}
		
		public async Task<List<Image>> GetImages(int galleryId)
		{
			List<Image> images = new List<Image>();

			try
			{
				using (PalpatineData ctx = new PalpatineData())
				{
					images = ctx.Image.Where(x => x.Gallery.Id == galleryId).ToList();
				}
			}
			catch (Exception ex)
			{

			}

			return images;
		}

		public async Task<bool> UpdateImage(int id, string source, string thumbnail, int thumbnailHeight, int thumbnailWidth, string caption, bool isSelected)
		{
			bool retVal = false;
			Image image = await GetImage(id);
			if (image == null) return false;

			image.Source = source;
			image.Thumbnail = thumbnail;
			image.ThumbnailHeight = thumbnailHeight;
			image.ThumbnailWidth = thumbnailWidth;
			image.IsSelected = isSelected;
			image.Caption = caption;

			try
			{
				using (PalpatineData ctx = new PalpatineData())
				{
					ctx.Image.Attach(image);
					var entry = ctx.Entry(image);
					entry.State = System.Data.Entity.EntityState.Modified;
					await ctx.SaveChangesAsync();
				}
			}
			catch (Exception ex)
			{

			}

			return retVal;
		}
	}
}