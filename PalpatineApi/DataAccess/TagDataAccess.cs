using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PalpatineApi.Models;
using PalpatineApi.DataAccess.Base;
using System.Threading.Tasks;

namespace PalpatineApi.DataAccess
{
	public class TagDataAccess : ITagDataAccess
	{
		public async Task<bool> CreateTag(string title, string value)
		{
			bool retVal = false;
			Tag newTag = new Tag
			{
				Title = title,
				Value = value
			};

			using (PalpatineData ctx = new PalpatineData())
			{
				ctx.Tag.Add(newTag);
				await ctx.SaveChangesAsync();
				retVal = true;
			}

			return retVal;
		}

		public Task<bool> DeleteTag()
		{
			throw new NotImplementedException();
		}

		public Task<Tag> GetTag(int id)
		{
			throw new NotImplementedException();
		}

		public Task<bool> UpdateTag(int id, string title, string value)
		{
			throw new NotImplementedException();
		}
	}
}