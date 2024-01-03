namespace ProductsTrackerTests.TestUtility;
using System;
using System.Collections.Generic;
using System.Reflection;

/// <summary>
/// Reference private object.
/// </summary>
public static class PrivateRefs
{
    /// <summary>
    /// Get value from private field.
    /// </summary>
    /// <typeparam name="T">target type.</typeparam>
    /// <param name="obj">target object.</param>
    /// <param name="name">field name.</param>
    /// <returns>field value.</returns>
    public static T? GetField<T>(this object obj, string name)
    {
        Type type;
        var bindingFlags = BindingFlags.NonPublic | BindingFlags.Static;

        if (obj.GetType().FullName == "System.RuntimeType") {
            type = (Type)obj;
        } else {
            bindingFlags |= BindingFlags.Instance;
            type = obj.GetType();
        }

        var fieldInfo = type.GetField(name, bindingFlags);

        if (fieldInfo?.GetValue(obj) == null) {
            fieldInfo = type.BaseType?.GetField(name, bindingFlags);
        }

        return (T?)fieldInfo?.GetValue(obj);
    }

    /// <summary>
    /// Set value to private field.
    /// </summary>
    /// <typeparam name="T">target type.</typeparam>
    /// <param name="obj">target class instance.</param>
    /// <param name="name">field name.</param>
    /// <param name="value">set value.</param>
    public static void SetField<T>(this object obj, string name, T value)
    {
        var bindingFlags = BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static;
        var fieldInfo = obj.GetType().GetField(name, bindingFlags);

        if (fieldInfo?.GetValue(obj) == null) {
            fieldInfo = obj.GetType().BaseType?.GetField(name, bindingFlags);
        }

        fieldInfo?.SetValue(obj, value);
    }

    /// <summary>
    /// Get private property reference.
    /// </summary>
    /// <typeparam name="T">target type.</typeparam>
    /// <param name="obj">target class instance.</param>
    /// <param name="name">field name.</param>
    /// <returns>Property reference.</returns>
    public static T? GetProperty<T>(this object obj, string name)
    {
        var bindingFlags = BindingFlags.NonPublic | BindingFlags.Instance;
        var propertyInfo = obj.GetType().GetProperty(name, bindingFlags);

        return (T?)propertyInfo?.GetValue(obj);
    }

    /// <summary>
    /// Get private property reference.
    /// </summary>
    /// <typeparam name="T">target type.</typeparam>
    /// <param name="obj">target class instance.</param>
    /// <param name="name">field name.</param>
    /// <param name="value">set value.</param>
    public static void SetProperty<T>(this object obj, string name, T value)
    {
        var propertyInfo = obj.GetType().GetProperty(name, BindingFlags.Public | BindingFlags.Instance)
                        ?? obj.GetType().GetProperty(name, BindingFlags.NonPublic | BindingFlags.Instance);

        propertyInfo?.SetValue(obj, value);
    }

    /// <summary>
    /// Invoke a private method that has a return value.
    /// </summary>
    /// <typeparam name="T">return target type.</typeparam>
    /// <param name="obj">target class instance.</param>
    /// <param name="name">method name.</param>
    /// <param name="arg">argument of the method.</param>
    /// <returns>return value of the method.</returns>
    public static T? Invoke<T>(this object obj, string name, params object[] arg)
        => (T?)GetMethodInfo(obj, name, arg)?.Invoke(obj, arg);

    /// <summary>
    /// Invoke the private method of the <paramref name="obj"/>.
    /// </summary>
    /// <param name="obj">target class instance.</param>
    /// <param name="name">method name.</param>
    /// <param name="arg">argument of the method.</param>
    public static void Invoke(this object obj, string name, params object[] arg)
        => GetMethodInfo(obj, name, arg)?.Invoke(obj, arg);

    private static MethodInfo? GetMethodInfo(object obj, string name, object[] arg)
    {
        var bindingFlags = BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.InvokeMethod;
        var argTypes = new List<Type>();

        foreach (var item in arg) {
            argTypes.Add(item.GetType());
        }

        var methodInfo = obj.GetType().GetMethod(name, bindingFlags, null, [.. argTypes], null)
            ?? obj.GetType().BaseType?.GetMethod(name, bindingFlags, null, [.. argTypes], null);

        return methodInfo;
    }
}