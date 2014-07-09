using CI.Model.CompanySize;
using FluentNHibernate.Mapping;

namespace CI.Repository.Mapping
{
    public class CompanySizeMap : ClassMap<CompanySize>
    {
        public CompanySizeMap()
        {
            Id(c => c.Id);
            Map(c => c.Code).Unique().Not.Nullable();
            Map(c => c.Description).Not.Nullable();
        }
    }
}
