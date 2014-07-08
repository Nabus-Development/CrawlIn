using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CI.Model.Infrastructure.Configuration
{
    public interface IConnectionString
    {
        string ConnectionString { get; }
    }
}
