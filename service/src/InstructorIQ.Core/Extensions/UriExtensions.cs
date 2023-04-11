using System;
using System.Collections.Generic;
using System.Text;

namespace InstructorIQ.Core.Extensions;

public static class UriExtensions
{
    public static string ToLocalPath(this Uri uri)
    {
        if (!uri.IsAbsoluteUri)
            return uri.ToString();


        return uri.PathAndQuery + uri.Fragment;
    }
}
