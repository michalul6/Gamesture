using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class GameContext
{
    readonly Dictionary<Type, object> _services = new();

    public void Register<T>(T instance)
    {
        _services[typeof(T)] = instance;
    }

    public T Resolve<T>() => (T)_services[typeof(T)];

    public void Inject(MonoBehaviour view)
    {
        var fields = view.GetType()
            .GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

        foreach (var f in fields)
        {
            if (!Attribute.IsDefined(f, typeof(InjectAttribute))) continue;

            if (_services.TryGetValue(f.FieldType, out var service))
                f.SetValue(view, service);
            else
                Debug.LogWarning($"No service for {f.FieldType} in {view}");
        }
    }
}