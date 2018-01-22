using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using PalpatineApi.BusinessLogic;
using PalpatineApi.BusinessLogic.Base;
using PalpatineApi.Models;
using System.Web.Http.Cors;

namespace PalpatineApi.Controllers
{
	[Authorize]
	[EnableCors(origins: "http://localhost:3000,https://localhost:3000,http://localhost:5000,https://localhost:5000", headers: "*", methods: "*")]
	[RoutePrefix("api/Gallery")]
	public class GalleryController : ApiController
    {
		private readonly IGalleryBusinessLogic GalleryBll;
		private readonly IImageBusinessLogic ImageBll;

		public GalleryController(IGalleryBusinessLogic galleryBll, IImageBusinessLogic imageBll)
		{
			GalleryBll = galleryBll;
			ImageBll = imageBll;
		}

		public GalleryController()
		{
			GalleryBll = new GalleryBusinessLogic();
			ImageBll = new ImageBusinessLogic();
		}

        // GET: api/Gallery
        public IEnumerable<Gallery> Get()
        {
			return new Gallery[1];
        }

        // GET: api/Gallery/5
        public async Task<Gallery> Get(int id)
        {
			var gallery = await GalleryBll.GetGalleryById(id);
			return gallery;
        }

		[AllowAnonymous]
		[HttpGet]
		[Route("GetImagesByGalleryName")]
		public async Task<List<Image>> GetImagesByGalleryName(string galleryName)
		{
			Gallery gallery = await GalleryBll.GetGalleryByName(galleryName);
			return (gallery == null || gallery.Images == null) ? new List<Image>() : gallery.Images;
		}
		
        // POST: api/Gallery
        public async Task<bool> Post([FromBody]string galleryName)
        {
			return await GalleryBll.CreateGallery(galleryName);
        }

        // PUT: api/Gallery/5
        public async void Put(int id, [FromBody]string value)
        {
			await GalleryBll.UpdateGallery(id, value);
        }

        // DELETE: api/Gallery/5
        public void Delete(int id)
        {
        }

		[Route("AddImage")]
		public async void AddImage(int imageId, int galleryId)
		{
			Gallery gallery = await GalleryBll.GetGalleryById(galleryId);
			if (gallery == null) { return; }
			Image image = await ImageBll.GetImage(imageId);
			if (image == null) { return; }
			if (!await GalleryBll.AddImageToGallery(image, gallery.Id))
			{
				//error
			}
		}
    }
}
