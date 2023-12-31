﻿using System.Reflection;
using Microsoft.Extensions.Localization;
using Wbc.WebUI.Resources;

namespace Wbc.WebUI.Services
{
    public class CommonLocalizationService
    {
        private readonly IStringLocalizer _localizer;

        public CommonLocalizationService(IStringLocalizerFactory factory)
        {
            var assemblyName = new AssemblyName(typeof(CommonResources).GetTypeInfo().Assembly.FullName);

            _localizer = factory.Create(nameof(CommonResources), assemblyName.Name);
        }

        public string Get(string key)
        {
            return _localizer[key];
        }
    }
}