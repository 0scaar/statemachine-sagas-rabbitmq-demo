using AutoMapper;
using statemachineSagasRabbitmqDemo.Application.Repositories.Database;
using statemachineSagasRabbitmqDemo.Domain.Log;

namespace statemachineSagasRabbitmqDemo.Infrastructure.Database.Repositories
{
    public class FileLogRepository : IFileLogRepository
    {
        private readonly IMapper mapper;

        public FileLogRepository(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public int Add(List<FileLog> fileLog)
        {
            using (var context = new Context())
            {
                var model = mapper.Map<List<Entities.FileLog>>(fileLog);
                context.FileLogs.AddRange(model);
                return context.SaveChanges();
            }
        }
    }
}
