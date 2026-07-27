namespace BuildingBlocks.Contracts.Events
{
    public class IntegrationEvent
    {
        public Guid Id { get; private set; }

        public DateTime CreatedDate { get; private set; }

        protected IntegrationEvent()
        {
            Id = Guid.NewGuid();
            CreatedDate = DateTime.UtcNow;
        }
    }
}
