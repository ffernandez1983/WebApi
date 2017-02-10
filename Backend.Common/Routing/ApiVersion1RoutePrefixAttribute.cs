﻿using System.Web.Http;

namespace Backend.WebAPI.Common.Routing
{
    public class ApiVersion1RoutePrefixAttribute : RoutePrefixAttribute
    {
        private const string RouteBase = "{apiVersion:apiVersionConstraint(v1)}";
        private const string PrefixRouteBase = RouteBase + "/";

        public ApiVersion1RoutePrefixAttribute(string routePrefix)
            : base(string.IsNullOrWhiteSpace(routePrefix) ? RouteBase : PrefixRouteBase + routePrefix)
        {
        }
    }
}