using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PalpatineApi.Models;
using PalpatineApi.DataAccess.Base;
using System.Threading.Tasks;

namespace PalpatineApi.DataAccess
{
	public class GalleryDataAccess : IGalleryDataAccess
	{
		public async Task<bool> AddImageToGallery(Image image, int galleryId)
		{
			bool retVal = true;
			Gallery gallery = await GetGalleryById(galleryId);
			if (gallery == null) { return retVal; }
			gallery.Images.Add(image);
			try
			{
				using (PalpatineData ctx = new PalpatineData())
				{
					ctx.Gallery.Attach(gallery);
					var entry = ctx.Entry(gallery);
					entry.State = System.Data.Entity.EntityState.Modified;
					await ctx.SaveChangesAsync();
				}
				retVal = true;
			}
			catch (Exception ex)
			{
				retVal = false;
			}

			return retVal;
		}

		public async Task<bool> CreateGallery(Gallery gallery)
		{
			bool retVal = false;
			
			try
			{
				using (PalpatineData ctx = new PalpatineData())
				{
					ctx.Gallery.Add(gallery);
					await ctx.SaveChangesAsync();
				}
				retVal = true;
			}
			catch (Exception)
			{
				retVal = false;
			}

			return retVal;
		}

		public async Task<Gallery> GetGalleryByName(string galleryName) // and soon client id
		{
			Gallery gallery = null;

			try
			{
				using (PalpatineData ctx = new PalpatineData())
				{
					gallery = ctx.Gallery.Include("Images").Include("Images.Tags").Where(g => g.GalleryName == galleryName).FirstOrDefault();
				}
			}
			catch (Exception ex)
			{

			}

			return gallery;
		}

		public async Task<Gallery> GetGalleryById(int id)
		{
			Gallery gallery = null;

			try
			{
				using (PalpatineData ctx = new PalpatineData())
				{
					gallery = ctx.Gallery.Include("Images").Where(g => g.Id == id).FirstOrDefault();
				}
			}
			catch (Exception ex)
			{

			}

			return gallery;
		}

		public async Task<bool> UpdateGallery(Gallery gallery)
		{
			bool retVal = false;
			try
			{
				using (PalpatineData ctx = new PalpatineData())
				{
					ctx.Entry(gallery).State = System.Data.Entity.EntityState.Modified;
					await ctx.SaveChangesAsync();
				}
				retVal = true;
			}
			catch (Exception ex)
			{
				retVal = false;
			}
			return retVal;
		}
	}
}