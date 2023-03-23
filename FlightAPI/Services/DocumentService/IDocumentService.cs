using FlightAPI.Models;

namespace FlightAPI.Services.DocumentService
{
    public interface IDocumentService
    {
        List<Document> GetAllDocument();
        Document? GetDocumentById(int id);
        List<Document>? AddDocument(Document document);
        List<Document>? UpdateDocument(int id, Document request);
        List<Document>? DeleteDocument(int id);
    }
}
