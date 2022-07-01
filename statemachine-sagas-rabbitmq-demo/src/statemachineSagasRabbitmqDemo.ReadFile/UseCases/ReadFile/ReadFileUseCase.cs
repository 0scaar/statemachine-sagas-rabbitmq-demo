using MassTransit;
using Serilog;
using statemachineSagasRabbitmqDemo.Application.Repositories.Services;
using statemachineSagasRabbitmqDemo.Domain.Contracts.ReadFile;

namespace statemachineSagasRabbitmqDemo.ReadFile.UseCases.ReadFile
{
    public class ReadFileUseCase : IReadFileUseCase
    {
        private readonly IFileConvert fileConvert;
        private readonly IBus bus;

        public ReadFileUseCase(IFileConvert fileConvert, IBus bus)
        {
            this.fileConvert = fileConvert;
            this.bus = bus;
        }

        public async Task Execute(ReadFileRequest request)
        {
            Log.Information($"JobReadFileUseCase - File: {request.File.FilePath}");

            request.FileDetails = fileConvert.ConvertCsv(request.File.FilePath);

            for (var i = 0; i < request.FileDetails.Count; i++)
            {
                request.FileDetails[i].SetFileId(request.File.FileId);
                await bus.Publish<ILineSubmitted>(new { FileId = request.File.FileId, LineId = request.FileDetails[i].Id });
            }
        }
    }
}
