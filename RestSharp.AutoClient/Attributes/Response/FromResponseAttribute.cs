﻿using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AutoRestClient.Processing;
using AutoRestClient.Processing.Response;

namespace AutoRestClient.Attributes.Response
{
    public class FromResponseAttribute: ResponseParameterBindingAttribute
    {
        public override async Task BindAsync(ResponseParameterBindingContext context)
        {
            var retVal = context.ReturnValue ?? Activator.CreateInstance(context.ReturnValueType);
            
            var props = context.ReturnValueType
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(x => x.CanWrite);

            foreach (var prop in props)
            {
                var propContext = new ResponseParameterBindingContext
                {
                    Deserializer = context.Deserializer,
                    Response = context.Response,
                    ReturnValue = prop.GetValue(retVal),
                    ReturnValueType = prop.PropertyType
                };

                await ProcessingUtils.ApplyResponseParameterBindingAttributes(prop, propContext);

                prop.SetValue(retVal, propContext.ReturnValue);
            }

            context.ReturnValue = retVal;
        }
    }
}