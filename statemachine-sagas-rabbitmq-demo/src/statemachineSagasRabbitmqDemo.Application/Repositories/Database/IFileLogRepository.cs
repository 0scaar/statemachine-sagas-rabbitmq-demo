using statemachineSagasRabbitmqDemo.Domain.Log;

namespace statemachineSagasRabbitmqDemo.Application.Repositories.Database
{
    public interface IFileLogRepository
    {
        int Add(List<FileLog> fileLog);
    }
}
