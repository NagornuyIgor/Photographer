using System;
using System.Collections.Generic;

namespace UnitTestProject1
{
    public static class Ioc
    {
        #region should be replaced with real Ioc container
        private static Dictionary<Type, Type> _iocCollection;
        static Ioc()
        {
            _iocCollection = new Dictionary<Type, Type>()
            {
                { typeof(IUploadFileService), typeof(UploadFileService) }
            };
        }
        #endregion should be replaced with real Ioc container

        public static T Get<T>() where T : class
        {
            if(_iocCollection.ContainsKey(typeof(T)))
            {
                return Activator.CreateInstance(_iocCollection[typeof(T)]) as T;
            }

            throw new NotImplementedException();
        }

        public static void Add<T>(T obj)
        {
            // this methos replace dependency in IOC container

            throw new NotImplementedException();
        }
    }
}
