using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FlightAPI.Models;
using FlightAPI.Services.DocumentService;

namespace FlightAPI.Controllers
{
    [Route("api/document")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        private readonly IDocumentService _documentService;
        public DocumentController(IDocumentService documentService)
        {
            _documentService = documentService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Document>>> GetAllDocument()
        {
            return await _documentService.GetAllDocument();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Document>>? GetDocumentById(int id)
        {
            var result = await _documentService.GetDocumentById(id);
            if (result is null)
                return NotFound("Not Found Document");

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<Document>>>? AddDocument(Document document)
        {
            var result = await _documentService.AddDocument(document);
            if (result is null)
                return NotFound("Not Found Document");

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Document>>>? UpdateDocument(int id, Document document)
        {
            var result = await _documentService.UpdateDocument(id, document);
            if (result is null)
                return NotFound("Not Found Document");

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Document>>>? DeleteDocument(int id)
        {
            var result = await _documentService.DeleteDocument(id);
            if (result is null)
                return NotFound("Not Found Document");

            return Ok(result);
        }
    }
}
