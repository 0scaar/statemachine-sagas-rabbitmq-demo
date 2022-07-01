using statemachineSagasRabbitmqDemo.Domain.Detail;

namespace statemachineSagasRabbitmqDemo.Application.Repositories.Services
{
    public interface IFileConvert
    {
        List<FileDetail> ConvertCsv(string file);
    }
}
