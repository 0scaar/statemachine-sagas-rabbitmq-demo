namespace statemachineSagasRabbitmqDemo.Domain.Contracts.ReadFile
{
    public class File
    {
        public Guid FileId { get; set; }
        public string FilePath { get; set; }
    }
}
