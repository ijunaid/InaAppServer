using Microsoft.Azure.Mobile.Server.Files;
using Microsoft.Azure.Mobile.Server.Files.Controllers;
using InaAppService.DataObjects;
using System.Web.Http;
using System.Threading.Tasks;
using System.Net.Http;
using System.Collections.Generic;

namespace InaAppService
{
	public class InaAppStorageController : StorageController<TodoItem>
	{
		public InaAppStorageController()
		{
		}

		[HttpPost]
		[Route("tables/TodoItem/{id}/StorageToken")]
		public async Task<HttpResponseMessage> PostStorageTokenRequest(string id, StorageTokenRequest value)
		{
			StorageToken token = await GetStorageTokenAsync(id, value);

			return Request.CreateResponse(token);
		}

		// Get the files associated with this record
		[HttpGet]
		[Route("tables/TodoItem/{id}/MobileServiceFiles")]
		public async Task<HttpResponseMessage> GetFiles(string id)
		{
			IEnumerable<MobileServiceFile> files = await GetRecordFilesAsync(id);

			return Request.CreateResponse(files);
		}

		[HttpDelete]
		[Route("tables/TodoItem/{id}/MobileServiceFiles/{name}")]
		public Task Delete(string id, string name)
		{
			return base.DeleteFileAsync(id, name);
		}
	}
}
