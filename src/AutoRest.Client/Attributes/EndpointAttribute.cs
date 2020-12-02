using System;

namespace AutoRest.Client.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class EndpointAttribute: Attribute
    {
        public string Route { get; }

        public EndpointAttribute(string route = default)
        {
            Route = route;
        }
    }
}