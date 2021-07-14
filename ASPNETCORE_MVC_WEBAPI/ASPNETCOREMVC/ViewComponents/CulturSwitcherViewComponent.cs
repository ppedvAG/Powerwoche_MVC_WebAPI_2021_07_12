using ASPNETCOREMVC.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCOREMVC.ViewComponents
{
    public class CulturSwitcherViewComponent : ViewComponent
    {
        private IOptions<RequestLocalizationOptions> _localizationOptions;

        //Was können ViewComponents
        //-DI Unterstützung
        public CulturSwitcherViewComponent(IOptions<RequestLocalizationOptions> localizationOptions)
        {
            _localizationOptions = localizationOptions;
        }


        public IViewComponentResult Invoke()
        {
            var cultureFeature = HttpContext.Features.Get<IRequestCultureFeature>();

            var model = new CultureSwitcherModel
            {
                SupportedCultures = _localizationOptions.Value.SupportedUICultures.ToList(),
                CurrentUICulture = cultureFeature.RequestCulture.UICulture
            };

            return View(model);
        }
    }
}

