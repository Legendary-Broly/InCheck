using System;
using System.Collections.Generic;

namespace InCheck.Core.Services
{
    public sealed class ServiceContainer
    {
        private readonly Dictionary<Type, object> _services = new();

        public void Register<TService>(TService instance) where TService : class
        {
            if (instance == null)
            {
                throw new ArgumentNullException(nameof(instance));
            }

            _services[typeof(TService)] = instance;
        }

        public TService Resolve<TService>() where TService : class
        {
            if (_services.TryGetValue(typeof(TService), out var instance))
            {
                return (TService)instance;
            }

            throw new InvalidOperationException($"Service not registered: {typeof(TService).Name}");
        }
    }
}
