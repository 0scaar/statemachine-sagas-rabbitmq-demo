namespace statemachineSagasRabbitmqDemo.Domain.Contracts.MoveFile
{
    public class ReadFileSubmitted
    {
        public Guid FileId { get; private set; }
        public string File { get; private set; }

        public ReadFileSubmitted(Guid fileId, string file)
        {
            FileId = fileId;
            File = file;
        }
    }
}
