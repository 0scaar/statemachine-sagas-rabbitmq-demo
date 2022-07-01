using statemachineSagasRabbitmqDemo.Application.Repositories.Database;

namespace statemachineSagasRabbitmqDemo.Infrastructure.Database.Repositories
{
    public class FileRepository : IFileRepository
    {
        public void Add(Domain.File.File file)
        {
            throw new NotImplementedException();
        }
    }
}
