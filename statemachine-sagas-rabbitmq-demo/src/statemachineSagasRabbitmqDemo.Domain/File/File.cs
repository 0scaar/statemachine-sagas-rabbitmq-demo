namespace statemachineSagasRabbitmqDemo.Domain.File
{
    public class File : Entity
    {
        public string FileName { get; private set; }
        public FileStatus Status { get; private set; }

        public File(Guid id, string fileName, FileStatus status)
        {
            Id = id;
            FileName = fileName;
            Status = status;
        }
    }
}
