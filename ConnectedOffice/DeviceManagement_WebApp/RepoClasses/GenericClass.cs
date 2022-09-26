using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp;
using System.Collections.Generic;

namespace DeviceManagement_WebApp.RepoClasses
{
    public class GenericClass<T> : IGenericClass<T> where T : class
    {
        protected readonly ConnectedOffice _context;
        public GenericClass(ConnectedOffice context)
        {
            _context = context;
        }
    }
}
