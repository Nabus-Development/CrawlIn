using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CI.Model.Industries;
using FluentNHibernate.Mapping;

namespace CI.Repository.Mapping
{
    public class IndustryMap : ClassMap<Industry>
    {
        public IndustryMap()
        {
            Id(i => i.Id);
            Map(i => i.Code).Unique();
            References(i => i.Group).Not.Nullable().Column("IndustryGroupId");
            Map(i => i.Description);
        }
    }
}
