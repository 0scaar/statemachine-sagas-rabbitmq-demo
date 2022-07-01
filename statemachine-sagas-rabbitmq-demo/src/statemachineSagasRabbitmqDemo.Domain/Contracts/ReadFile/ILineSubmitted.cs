namespace statemachineSagasRabbitmqDemo.Domain.Contracts.ReadFile
{
    public interface ILineSubmitted
    {
        public Guid FileId { get; set; }
        public Guid LineId { get; set; }
    }
}
