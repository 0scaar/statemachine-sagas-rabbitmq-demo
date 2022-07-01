namespace statemachineSagasRabbitmqDemo.Application.Repositories.Database
{
    public interface IFileRepository
    {
        void Add(Domain.File.File file);
    }
}
