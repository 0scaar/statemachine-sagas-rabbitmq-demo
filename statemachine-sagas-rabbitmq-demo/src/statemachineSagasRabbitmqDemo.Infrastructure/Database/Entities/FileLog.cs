namespace statemachineSagasRabbitmqDemo.Infrastructure.Database.Entities
{
    public class FileLog : Entity
    {
        public Guid FileId { get; set; }
        public DateTime DateLog { get; set; }
        public string Message { get; set; }
        public string Error { get; set; }
        public File File { get; set; }
    }
}
