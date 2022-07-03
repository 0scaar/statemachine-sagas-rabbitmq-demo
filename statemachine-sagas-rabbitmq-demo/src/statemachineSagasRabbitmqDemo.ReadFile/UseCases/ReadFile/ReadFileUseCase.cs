using MassTransit;
using Serilog;
using statemachineSagasRabbitmqDemo.Application.Repositories.Database;
using statemachineSagasRabbitmqDemo.Application.Repositories.Services;
using statemachineSagasRabbitmqDemo.Domain.Contracts.ReadFile;
using statemachineSagasRabbitmqDemo.Domain.Detail;

namespace statemachineSagasRabbitmqDemo.ReadFile.UseCases.ReadFile
{
    public class ReadFileUseCase : IReadFileUseCase
    {
        private readonly IFileConvert fileConvert;
        private readonly IBus bus;
        private readonly IFileRepository fileRepository;
        private readonly IFileLogRepository fileLogRepository;

        public ReadFileUseCase(IFileConvert fileConvert, IBus bus, 
            IFileRepository fileRepository, IFileLogRepository fileLogRepository)
        {
            this.fileConvert = fileConvert;
            this.bus = bus;
            this.fileRepository = fileRepository;
            this.fileLogRepository = fileLogRepository;
        }

        public async Task Execute(ReadFileRequest request)
        {
            Log.Information($"JobReadFileUseCase - File: {request.File.FilePath}");

            try
            {
                request.AddProcessLog(request.File.FileId, "ReadFileUseCase - Register file");

                request.FileDetails = fileConvert.ConvertCsv(request.File.FilePath);

                var fileDetails = new List<FileDetail>();

                for (var i = 0; i < request.FileDetails.Count; i++)
                {
                    var fileDetail = new FileDetail(request.FileDetails[i].Id, request.File.FileId, request.FileDetails[i].StoreName, request.FileDetails[i].Cnpj, request.FileDetails[i].CompanyName);
                    fileDetails.Add(fileDetail);

                    request.FileDetails[i].SetFileId(request.File.FileId);
                    await bus.Publish<ILineSubmitted>(new { FileId = request.File.FileId, LineId = request.FileDetails[i].Id });
                }

                var file = new Domain.File.File(request.File.FileId, request.File.FilePath, Domain.File.FileStatus.InProcess);
                file.SetFileDetails(fileDetails);

                fileRepository.Add(file);
            }
            catch (Exception ex)
            {
                request.AddErrorLog(request.File.FileId, $"ReadFileUseCase - Error in Register file", ex.Message);
            }
            finally
            {
                fileLogRepository.Add(request.FileLogs);
            }
        }
    }
}
