namespace statemachineSagasRabbitmqDemo.Infrastructure.Database.Entities
{
    public class FileDetail : Entity
    {
        public Guid FileId { get; set; }
        public string StoreName { get; set; }
        public string Cnpj { get; set; }
        public string CompanyName { get; set; }
        public File File { get; set; }
    }
}
