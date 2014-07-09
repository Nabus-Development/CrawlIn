using CI.Model.IndustryGroups;
using FluentNHibernate.Mapping;

namespace CI.Repository.Mapping
{
    public class IndustryGroupMap : ClassMap<IndustryGroup>
    {
        public IndustryGroupMap()
        {
            Id(g => g.Id);
            Map(g => g.GroupName).Unique().Not.Nullable();
        }
    }
}
