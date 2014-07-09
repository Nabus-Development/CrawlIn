using CI.Model.IndustryGroups;
using CI.Model.Infrastructure.Domain;

namespace CI.Model.Industries
{
    public class Industry : IAggregateRoot
    {
        public virtual int Id { get; protected set; }
        public virtual string Code { get; set; }
        public virtual IndustryGroup Group { get; set; }
        public virtual string Description { get; set; }
    }
}
