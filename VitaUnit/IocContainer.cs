using System;
using System.Collections.Generic;

namespace VitaUnit
{
	public class IocContainer
	{
        private readonly Dictionary<Type, object> _registeredDependencies = new Dictionary<Type, object>();
        private readonly Dictionary<Type, Type> _registeredTypes = new Dictionary<Type, Type>();

        public T GetDependency<T>() where T : class
        {
            if (_registeredDependencies.ContainsKey(typeof(T)))
                return (T)_registeredDependencies[typeof(T)];

            if(_registeredTypes.ContainsKey(typeof(T)))
            {
                Type type = _registeredTypes[typeof (T)];
                return (T)Activator.CreateInstance(type);
            }

            System.Diagnostics.Debug.WriteLine("Unknown dependency requested: {0}", typeof(T).Name);
            return null;
        }

        public void RegisterDependency<T>(T value) where T : class
        {
            if (_registeredDependencies.ContainsKey(typeof(T)))
            {
                _registeredDependencies[typeof (T)] = value;
            }
            else
            {
                _registeredDependencies.Add(typeof(T), value);
            }
        }

        public void RegisterDependency<T, TU>() where T : class where TU : class
        {
            if (_registeredTypes.ContainsKey(typeof(T)))
            {
                _registeredTypes[typeof(T)] = typeof(TU);
            }
            else
            {
                _registeredTypes.Add(typeof(T), typeof(TU));
            }
        }
    }
}

