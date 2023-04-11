using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;

namespace InstructorIQ.Core.Services;

public class CookieStateService : IStateService
{
    private readonly IHttpContextAccessor _contextAccessor;

    public CookieStateService(IHttpContextAccessor contextAccessor)
    {
        _contextAccessor = contextAccessor;
    }

    public void WriteState<T>(T state, string name)
    {
        var type = typeof(T);
        var key = $"_{name}_{type.Name}";
        var json = JsonSerializer.Serialize(state);

        var response = _contextAccessor.HttpContext.Response;
        response.Cookies.Append(key, json);
    }

    public T ReadState<T>(string name)
    {
        var type = typeof(T);
        var key = $"_{name}_{type.Name}";

        var request = _contextAccessor.HttpContext.Request;
        if (!request.Cookies.TryGetValue(key, out var json))
            return default(T);

        return JsonSerializer.Deserialize<T>(json);
    }
}
