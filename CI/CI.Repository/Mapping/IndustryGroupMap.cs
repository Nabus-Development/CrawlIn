using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CI.Model.Industries;
using CI.Model.IndustryGroups;
using FluentNHibernate.Mapping;

namespace CI.Repository.Mapping
{
    public class IndustryGroupMap : ClassMap<IndustryGroup>
    {
        public IndustryGroupMap()
        {
            Id(g => g.Id);
            Map(g => g.GroupName).Unique();
        }
    }
}
