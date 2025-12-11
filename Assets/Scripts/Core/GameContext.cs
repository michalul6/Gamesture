using System;
using System.Collections.Generic;

public class GameContext
{
    readonly Dictionary<Type, object> _services = new();

    public void Register<T>(T instance)
    {
        _services[typeof(T)] = instance;
    }

    public T Resolve<T>() => (T)_services[typeof(T)];
}