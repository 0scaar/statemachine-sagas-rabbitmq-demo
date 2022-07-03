using statemachineSagasRabbitmqDemo.Domain.Contracts.ReadFile;
using statemachineSagasRabbitmqDemo.Domain.Detail;
using statemachineSagasRabbitmqDemo.Domain.Log;

namespace statemachineSagasRabbitmqDemo.ReadFile.UseCases.ReadFile
{
    public class ReadFileRequest
    {
        public Domain.Contracts.ReadFile.File File { get; private set; }
        public List<FileDetail> FileDetails { get; set; }
        public IEnumerable<ILineSubmitted> LineSubmitteds { get; set; }
        public List<FileLog> FileLogs { get; set; }

        public ReadFileRequest(Domain.Contracts.ReadFile.File file)
        {
            File = file;
            FileDetails = new List<FileDetail>();
            LineSubmitteds = new List<ILineSubmitted>();
            FileLogs = new List<FileLog>();
        }

        public void AddProcessLog(Guid fileId, string message)
        {
            var fileLog = new FileLog(fileId, message);
            FileLogs.Add(fileLog); 
        }

        public void AddErrorLog(Guid fileId, string message, string error)
        {
            var fileLog = new FileLog(fileId, message, error);
            FileLogs.Add(fileLog);
        }
    }
}
