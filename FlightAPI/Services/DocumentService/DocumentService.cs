using FlightAPI.DatabaseContext;
using FlightAPI.Models;
using FlightAPI.Services.DocumentService.DTO;
using Microsoft.EntityFrameworkCore;

namespace FlightAPI.Services.DocumentService
{
    public class DocumentService : IDocumentService
    {
        private readonly FlightDbContext _dbContext;
        public DocumentService(FlightDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Document>> GetAllDocumentByFlightID(int flightID)
        {
            var documents = await _dbContext.Documents.Where(f => f.FlightID == flightID).ToListAsync();

            return documents;
        }  

        public async Task<Document>? GetDocumentById(int id)
        {
            var documentFound = await _dbContext.Documents.FirstOrDefaultAsync(x => x.Id == id);
            if (documentFound is null)
                return null;

            return documentFound;
        }

        public async Task<List<Document>> AddDocument(AddDocumentDTO request)
        {
            var flight = await _dbContext.Flights.FindAsync(request.FlightID);
            if (flight == null)
                return null;

            var newDocument = new Document()
            {
                Name = request.Name,
                Note = request.Note,
                Version = Convert.ToString(request.Version + 0.1),
                Flight = flight,
            };

            _dbContext.Documents.Add(newDocument);
            await _dbContext.SaveChangesAsync();

            return await GetAllDocumentByFlightID(newDocument.FlightID);
        }

        public async Task<List<Document>>? UpdateDocument(int id, Document document)
        {
            if (id != document.Id)
                return null;

            var documentFound = await _dbContext.Documents.FindAsync(id);

            if (documentFound is null)
                return null;

            documentFound.Name = document.Name;
            documentFound.CreateDate = document.CreateDate;
            documentFound.Note = document.Note;
            documentFound.Version = document.Version;
            documentFound.FlightID = document.FlightID;

            await _dbContext.SaveChangesAsync();

            return await _dbContext.Documents.ToListAsync();
        }

        public async Task<List<Document>>? DeleteDocument(int id)
        {
            var documentFound = await _dbContext.Documents.FindAsync(id);
            if (documentFound == null)
                return null;

            _dbContext.Documents.Remove(documentFound);
            await _dbContext.SaveChangesAsync();

            return await _dbContext.Documents.ToListAsync();
        }

    }
}
