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
        public ActionResult<List<Document>> GetAllDocument()
        {
            return _documentService.GetAllDocument();
        }

        [HttpGet("{id}")]
        public ActionResult<Document> GetDocumentById(int id)
        {
            var result = _documentService.GetDocumentById(id);
            if (result is null)
                return NotFound("Not Found Document");

            return Ok(result);
        }

        [HttpPost]
        public ActionResult<List<Document>> AddDocument(Document document)
        {
            var result = _documentService.AddDocument(document);
            if (result is null)
                return NotFound("Not Found Document");

            return Ok(result);
        }

        [HttpPut("{id}")]
        public ActionResult<List<Document>> UpdateDocument(int id, Document request)
        {
            var result = _documentService.UpdateDocument(id, request);
            if (result is null)
                return NotFound("Not Found Document");

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public ActionResult<List<Document>> DeleteDocument(int id)
        {
            var result = _documentService.DeleteDocument(id);
            if (result is null)
                return NotFound("Not Found Document");

            return Ok(result);
        }
    }
}
