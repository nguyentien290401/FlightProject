using FlightAPI.Models;
using FlightAPI.Services.DocumentService.DTO;

namespace FlightAPI.Services.DocumentService
{
    public interface IDocumentService
    {
        Task<List<Document>> GetAllDocumentByFlightID(int flightID);
        Task<Document>? GetDocumentById(int id);
        Task<List<Document>>? AddDocument(AddDocumentDTO document);
        Task<List<Document>>? UpdateDocument(int id, Document document);
        Task<List<Document>>? DeleteDocument(int id);
    }
}
