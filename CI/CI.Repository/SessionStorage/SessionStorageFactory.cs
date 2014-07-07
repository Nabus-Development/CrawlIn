using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace CI.Repository.SessionStorage
{
    public static class SessionStorageFactory
    {
        private static ISessionStorageContainer _nhSessionStorageContainer;

        public static ISessionStorageContainer GetStorageContainer()
        {
            if (_nhSessionStorageContainer == null)
            {
                if (HttpContext.Current == null)
                    _nhSessionStorageContainer = new ThreadSessionStorageContainer();
                else
                    _nhSessionStorageContainer = new HttpSessionStorageContainer();
            }

            return _nhSessionStorageContainer;
        }
    }
}
