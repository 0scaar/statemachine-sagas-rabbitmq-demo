using CsvHelper.Configuration;

namespace statemachineSagasRabbitmqDemo.Infrastructure.Csv.FileDetail
{
    public class FileDetailMap : ClassMap<FileDetailItem>
    {
        public FileDetailMap()
        {
            Map(m => m.StoreName).Name("Nome da Loja", "Name of the store");
            Map(m => m.Cnpj).Name("CNPJ", "Cnpj");
            Map(m => m.CompanyName).Name("Razão Social", "Company Name");
        }
    }
}
