using FlightAPI.Models;

namespace FlightAPI.Services.DocumentService
{
    public interface IDocumentService
    {
        Task<List<Document>> GetAllDocument();
        Task<Document>? GetDocumentById(int id);
        Task<List<Document>>? AddDocument(Document document);
        Task<List<Document>>? UpdateDocument(int id, Document document);
        Task<List<Document>>? DeleteDocument(int id);
    }
}
