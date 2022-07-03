namespace statemachineSagasRabbitmqDemo.Application.Repositories.Database
{
    public interface IFileRepository
    {
        int Add(Domain.File.File file);
    }
}
