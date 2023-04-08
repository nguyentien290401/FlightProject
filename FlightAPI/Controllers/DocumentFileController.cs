using FlightAPI.Models;
using FlightAPI.Services.DocumentFileService;
using FlightAPI.Services.DocumentFileService.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlightAPI.Controllers
{
    [Route("api/document-file")]
    [ApiController]
    public class DocumentFileController : ControllerBase
    {
        private readonly IDocumentFileService _documentFileService;
        public DocumentFileController(IDocumentFileService documentFileService)
        {
            _documentFileService = documentFileService;
        }

        [HttpPost("upload-document-file")]
        public async Task<ActionResult<DocumentFile>>? AddDocumentFile([FromForm] DocumentFileWithFormFile formFile)
        {
            var result = await _documentFileService.AddDocumentFile(formFile);
            if (result == null)
                return BadRequest("Can't add the document file.");

            return Ok(result);
        }

        [HttpPost("get-document-file/{id}")]
        public async Task<ActionResult<DocumentFile>>? GetDocumentFileByID(int id)
        {
            var result = await _documentFileService.GetDocumentFileByID(id);
            if (result == null)
                return NotFound("Can't find the document file or not exist.");

            return Ok(result);
        }

        [HttpDelete("delete-document-file/{id}")]
        public async Task<ActionResult<DocumentFile>>? DeleteDocumentFileByID(int id)
        {
            var result = await _documentFileService.DeleteDocumentFileByID(id);
            if (result == null)
                return BadRequest("Can't delete document file or it's not exist.");

            return Ok("Delete document file successfully.");
        }
    }
}
