using System;
using Infrastructure.Unleash;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebUI.Handler
{
    public class FeatureFlagAttribute : Attribute, IAuthorizationFilter
    {
        readonly string _flag;
        private IFeatureFlagService _featureFlagservice;
        public FeatureFlagHandler(string flag)
        {
            // _featureFlagservice = new FeatureFlagService()
            _flag = flag;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var featureFlag = (IFeatureFlagService)context.HttpContext.RequestServices.GetService(typeof(IFeatureFlagService));
            if (!featureFlag.IsEnabled(_flag))
            {
                context.Result = new NotFoundResult();
                return;
            }

        }
    }
}