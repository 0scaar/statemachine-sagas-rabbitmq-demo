namespace statemachineSagasRabbitmqDemo.Domain.Detail
{
    public class FileDetail : Entity
    {
        public Guid FileId { get; private set; }
        public string StoreName { get; private set; }
        public string Cnpj { get; private set; }
        public string CompanyName { get; private set; }

        public FileDetail(Guid id, Guid fileId, string storeName, string cnpj, string companyName)
        {
            Id = id;
            FileId = fileId;
            StoreName = storeName;
            Cnpj = cnpj;
            CompanyName = companyName;
        }

        public FileDetail()
        {

        }

        public void SetFileId(Guid fileId) => FileId = fileId;
    }
}
