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

        #region Fake Document Data list
        private static List<Document> documents = new List<Document>
        {
            new Document()
            {
                Id = 1,
                Name = "VJ001",
                CreateDate = Convert.ToDateTime("2022-02-24"),
                Note = "Go to Tokyo",
                Version = "1.0"
            },
            new Document()
            {
                Id = 2,
                Name = "VJ002",
                CreateDate = Convert.ToDateTime("2022-04-29"),
                Note = "Go to Osaka",
                Version = "1.0"
            },

            new Document()
            {
                Id = 3,
                Name = "VJ003",
                CreateDate = Convert.ToDateTime("2022-09-28"),
                Note = "Go to Kyoto",
                Version = "1.0"
            }
        };
        #endregion

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
