namespace statemachineSagasRabbitmqDemo.Domain.Contracts.ProcessLine
{
    public class Line
    {
        public Guid FileId { get; set; }
        public Guid LineId { get; set; }
    }
}
