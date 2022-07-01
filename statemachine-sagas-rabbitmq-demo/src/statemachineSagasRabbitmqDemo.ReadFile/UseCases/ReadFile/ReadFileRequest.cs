using statemachineSagasRabbitmqDemo.Domain.Contracts.ReadFile;
using statemachineSagasRabbitmqDemo.Domain.Detail;

namespace statemachineSagasRabbitmqDemo.ReadFile.UseCases.ReadFile
{
    public class ReadFileRequest
    {
        public Domain.Contracts.ReadFile.File File { get; private set; }
        public List<FileDetail> FileDetails { get; set; }
        public IEnumerable<ILineSubmitted> LineSubmitteds { get; set; }

        public ReadFileRequest(Domain.Contracts.ReadFile.File file)
        {
            File = file;
        }
    }
}
