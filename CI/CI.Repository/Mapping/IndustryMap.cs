using CI.Model.Industries;
using FluentNHibernate.Mapping;

namespace CI.Repository.Mapping
{
    public class IndustryMap : ClassMap<Industry>
    {
        public IndustryMap()
        {
            Id(i => i.Id);
            Map(i => i.Code).Unique().Not.Nullable();
            References(i => i.Group).Not.Nullable().Column("IndustryGroup_Id");
            Map(i => i.Description).Not.Nullable();
        }
    }
}
