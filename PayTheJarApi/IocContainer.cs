using PayTheJarApi.AppUsers;
using PayTheJarApi.Fouls;
using PayTheJarApi.Jars;
using SimpleInjector;
using SimpleInjector.Lifestyles;

namespace PayTheJarApi
{
    public static class IocContainer
    {
        private static Container _instance;
        public static Container Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Container();
                    _instance.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

                    // Type registration for dependency injection
                    _instance.Register<IJarRepository, JarRepository>(Lifestyle.Singleton);
                    _instance.Register<IAppUserRepository, AppUserRepository>(Lifestyle.Singleton);
                    _instance.Register<IFoulRepository, FoulRepository>(Lifestyle.Singleton);
                }

                return _instance;
            }
        }

        public static T GetInstance<T>()
            where T : class
        {
            using (AsyncScopedLifestyle.BeginScope(Instance))
            {
                return Instance.GetInstance<T>();
            }
        }
    }
}