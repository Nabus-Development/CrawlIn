using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CI.Model.Infrastructure.Domain;

namespace CI.Model.Industries
{
    public class Industry : IAggregateRoot
    {
        public virtual int Id { get; set; }
        public virtual string Description { get; set; }
    }
}
