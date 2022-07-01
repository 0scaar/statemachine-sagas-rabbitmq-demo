namespace statemachineSagasRabbitmqDemo.ReadFile.UseCases.ReadFile
{
    public interface IReadFileUseCase
    {
        Task Execute(ReadFileRequest request);
    }
}
