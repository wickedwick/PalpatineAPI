﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PalpatineApi.Models;

namespace PalpatineApi.DataAccess.Base
{
	public interface IImageDataAccess
	{
		Task<Image> GetImage(int id);

		Task<bool> CreateImage(string source, string thumbnail, int thumbnailHeight, int thumbnailWidth, string caption, bool isSelected);

		Task<bool> UpdateImage(int id, string source, string thumbnail, int thumbnailHeight, int thumbnailWidth, string caption, bool isSelected);

		Task<bool> DeleteImage(int id);

		Task<List<Image>> GetImages(int galleryId);
	}
}
