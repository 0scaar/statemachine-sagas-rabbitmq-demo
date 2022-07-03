using statemachineSagasRabbitmqDemo.Domain.Detail;

namespace statemachineSagasRabbitmqDemo.Domain.File
{
    public class File : Entity
    {
        public string FileName { get; private set; }
        public FileStatus Status { get; private set; }
        public List<FileDetail> FileDetails { get; private set; }

        public File(Guid id, string fileName, FileStatus status)
        {
            Id = id;
            FileName = fileName;
            Status = status;
        }

        public void SetFileDetails(List<FileDetail> fileDetails)
            => FileDetails = fileDetails;
    }
}
