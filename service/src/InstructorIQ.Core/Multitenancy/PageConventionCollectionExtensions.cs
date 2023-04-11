using System;

using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace InstructorIQ.Core.Multitenancy;

public static class PageConventionCollectionExtensions
{
    public static IPageRouteModelConvention AddPageTenantRoute(this PageConventionCollection pageConventionCollection, string pageName, bool rewrite = true)
    {
        return rewrite
            ? pageConventionCollection.AddPageRouteModelConvention(pageName, RewriteTenantPageRoute)
            : pageConventionCollection.AddPageRouteModelConvention(pageName, AppendTenantPageRoute);
    }

    public static IPageRouteModelConvention AddAreaPageTenantRoute(this PageConventionCollection pageConventionCollection, string areaName, string pageName, bool rewrite = true)
    {
        return rewrite
            ? pageConventionCollection.AddAreaPageRouteModelConvention(areaName, pageName, RewriteTenantPageRoute)
            : pageConventionCollection.AddAreaPageRouteModelConvention(areaName, pageName, AppendTenantPageRoute);
    }

    public static IPageRouteModelConvention AddFolderTenantRoute(this PageConventionCollection pageConventionCollection, string folderPath, bool rewrite = true)
    {
        return rewrite
            ? pageConventionCollection.AddFolderRouteModelConvention(folderPath, RewriteTenantPageRoute)
            : pageConventionCollection.AddFolderRouteModelConvention(folderPath, AppendTenantPageRoute);
    }

    public static IPageRouteModelConvention AddAreaFolderTenantRoute(this PageConventionCollection pageConventionCollection, string areaName, string folderPath, bool rewrite = true)
    {
        return rewrite
            ? pageConventionCollection.AddAreaFolderRouteModelConvention(areaName, folderPath, RewriteTenantPageRoute)
            : pageConventionCollection.AddAreaFolderRouteModelConvention(areaName, folderPath, AppendTenantPageRoute);
    }



    private static void RewriteTenantPageRoute(PageRouteModel model)
    {
        var selectorCount = model.Selectors.Count;
        for (var i = 0; i < selectorCount; i++)
        {
            var selector = model.Selectors[i];

            var template = selector.AttributeRouteModel.Template;
            var tenantTemplates = AttributeRouteModel.CombineTemplates("{tenant}", template);

            selector.AttributeRouteModel.Template = tenantTemplates;
        }
    }

    private static void AppendTenantPageRoute(PageRouteModel model)
    {
        var selectorCount = model.Selectors.Count;
        for (var i = 0; i < selectorCount; i++)
        {
            var selector = model.Selectors[i];
            var appended = new SelectorModel(selector);

            var template = appended.AttributeRouteModel.Template;
            var tenantTemplates = AttributeRouteModel.CombineTemplates("{tenant}", template);

            appended.AttributeRouteModel.Template = tenantTemplates;
            model.Selectors.Add(appended);
        }
    }
}
