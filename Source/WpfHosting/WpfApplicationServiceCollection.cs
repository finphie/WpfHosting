using System.Collections;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.DependencyInjection;

namespace WpfHosting;

/// <summary>
/// WPFアプリケーション用の<see cref="ServiceCollection"/>クラスです。
/// </summary>
sealed class WpfApplicationServiceCollection : IServiceCollection
{
    readonly IServiceCollection _services = new ServiceCollection();

    /// <inheritdoc/>
    public int Count => _services.Count;

    /// <inheritdoc/>
    public bool IsReadOnly { get; set; }

    /// <inheritdoc/>
    public ServiceDescriptor this[int index]
    {
        get => _services[index];
        set
        {
            Check();
            _services[index] = value;
        }
    }

    /// <inheritdoc/>
    public void Add(ServiceDescriptor item)
    {
        Check();
        _services.Add(item);
    }

    /// <inheritdoc/>
    public void Clear()
    {
        Check();
        _services.Clear();
    }

    /// <inheritdoc/>
    public bool Contains(ServiceDescriptor item) => _services.Contains(item);

    /// <inheritdoc/>
    public void CopyTo(ServiceDescriptor[] array, int arrayIndex) => _services.CopyTo(array, arrayIndex);

    /// <inheritdoc/>
    public IEnumerator<ServiceDescriptor> GetEnumerator() => _services.GetEnumerator();

    /// <inheritdoc/>
    public int IndexOf(ServiceDescriptor item) => _services.IndexOf(item);

    /// <inheritdoc/>
    public void Insert(int index, ServiceDescriptor item)
    {
        Check();
        _services.Insert(index, item);
    }

    /// <inheritdoc/>
    public bool Remove(ServiceDescriptor item)
    {
        Check();
        return _services.Remove(item);
    }

    /// <inheritdoc/>
    public void RemoveAt(int index)
    {
        Check();
        _services.RemoveAt(index);
    }

    /// <inheritdoc/>
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    [DebuggerHidden]
    [DoesNotReturn]
    static void ThrowInvalidOperationException()
        => throw new InvalidOperationException("アプリケーションのビルド後にServiceCollectionを変更することはできません。");

    void Check()
    {
        if (IsReadOnly)
        {
            ThrowInvalidOperationException();
        }
    }
}
