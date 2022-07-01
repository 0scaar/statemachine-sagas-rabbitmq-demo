using statemachineSagasRabbitmqDemo.Domain.File;

namespace statemachineSagasRabbitmqDemo.Infrastructure.Database.Entities
{
    public class File : Entity
    {
        public string FileName { get; set; }
        public FileStatus Status { get; set; }
        public virtual List<FileDetail> FileDetails { get; set; }
        public virtual List<FileLog> FileLogs { get; set; }
    }
}
