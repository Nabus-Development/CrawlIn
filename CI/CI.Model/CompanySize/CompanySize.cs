﻿using CI.Model.Infrastructure.Domain;

namespace CI.Model.CompanySize
{
    public class CompanySize : IAggregateRoot
    {
        public virtual int Id { get; protected set; }
        public virtual string Code { get; set; }
        public virtual string Description { get; set; }
    }
}
