using FlightAPI.Models;

namespace FlightAPI.Services.DocumentService
{
    public class DocumentService : IDocumentService
    {
        private static List<Document> documents = new List<Document>
        {
            new Document()
            {
                Id = 1,
                Name = "VJ001",
                CreateDate = Convert.ToDateTime("2022-02-42"),
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

        public List<Document> AddDocument(Document document)
        {
            documents.Add(document);
            return documents;
        }

        public List<Document>? DeleteDocument(int id)
        {
            var documentFound = documents.Find(x => x.Id == id);
            if (documentFound is null)
                return null;

            documents.Remove(documentFound);

            return documents;
        }

        public List<Document> GetAllDocument()
        {
            return documents;
        }

        public Document? GetDocumentById(int id)
        {
            var documentFound = documents.Find(x => x.Id == id);
            if (documentFound is null)
                return null;

            return documentFound;
        }

        public List<Document>? UpdateDocument(int id, Document request)
        {
            var documentFound = documents.Find(x => x.Id == id);
            if (documentFound is null)
                return null;

            documentFound.Name = request.Name;
            documentFound.CreateDate = request.CreateDate;
            documentFound.Note = request.Note;
            documentFound.Version = request.Version;

            return documents;
        }
    }
}
