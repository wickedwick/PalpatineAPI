using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PalpatineApi.Models;

namespace PalpatineApi.DataAccess.Base
{
	public interface ITagDataAccess
	{
		Task<bool> CreateTag(string title, string value);

		Task<bool> UpdateTag(int id, string title, string value);

		Task<Tag> GetTag(int id);

		Task<bool> DeleteTag();
	}
}
