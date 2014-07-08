using CI.Model.Infrastructure.Domain;

namespace CI.Model.IndustryGroups
{
    public class IndustryGroup : IAggregateRoot
    {
        public virtual int Id { get; protected set; }
        public virtual string GroupName { get; set; }
    }
}
