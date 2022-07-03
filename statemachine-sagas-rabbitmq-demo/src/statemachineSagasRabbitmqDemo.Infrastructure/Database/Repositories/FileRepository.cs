using AutoMapper;
using statemachineSagasRabbitmqDemo.Application.Repositories.Database;

namespace statemachineSagasRabbitmqDemo.Infrastructure.Database.Repositories
{
    public class FileRepository : IFileRepository
    {
        private readonly IMapper mapper;

        public FileRepository(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public int Add(Domain.File.File file)
        {
            using (var context = new Context())
            {
                var model = mapper.Map<Entities.File>(file);
                context.Files.Add(model);
                return context.SaveChanges();
            }
        }
    }
}
