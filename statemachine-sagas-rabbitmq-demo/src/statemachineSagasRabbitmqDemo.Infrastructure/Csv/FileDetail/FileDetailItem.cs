namespace statemachineSagasRabbitmqDemo.Infrastructure.Csv.FileDetail
{
    public class FileDetailItem
    {
        public Guid Id { get => Guid.NewGuid(); }
        public string StoreName { get; set; }
        public string Cnpj { get; set; }
        public string CompanyName { get; set; }
    }
}
