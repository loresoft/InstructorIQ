using System;
using System.Collections.Generic;

namespace InstructorIQ.Core.Utility;

public class DisposableBag : IDisposable
{
    private readonly Stack<IDisposable> _disposeStack = new Stack<IDisposable>();

    public T Create<T>() where T : IDisposable, new()
    {
        var t = new T();
        _disposeStack.Push(t);

        return t;
    }

    public T Create<T>(Func<T> creator) where T : IDisposable
    {
        var t = creator();
        _disposeStack.Push(t);

        return t;
    }


    public void Dispose()
    {
        while (_disposeStack.Count > 0)
        {
            var d = _disposeStack.Pop();
            d.Dispose();
        }

    }
}
