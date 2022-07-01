using AutoMapper;
using CsvHelper;
using CsvHelper.Configuration;
using statemachineSagasRabbitmqDemo.Application.Repositories.Services;
using statemachineSagasRabbitmqDemo.Domain.Detail;
using statemachineSagasRabbitmqDemo.Infrastructure.Csv.FileDetail;
using System.Globalization;
using System.Text.RegularExpressions;

namespace statemachineSagasRabbitmqDemo.Infrastructure.Services
{
    public class FileConvert : IFileConvert
    {
        private readonly IMapper mapper;

        public FileConvert(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public List<FileDetail> ConvertCsv(string file)
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                PrepareHeaderForMatch = h => Regex.Replace(h.Header.ToLower(), "[^0-9a-zA-Z]+", string.Empty)
            };

            using var reader = new StreamReader(file);
            using var csv = new CsvReader(reader, config);

            csv.Context.RegisterClassMap<FileDetailMap>();

            var lines = csv.GetRecords<FileDetailItem>().ToList();

            return mapper.Map<List<FileDetail>>(lines);
        }
    }
}
