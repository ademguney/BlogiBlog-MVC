using Blogi.Application.Services.LanguageService;
using Blogi.Application.Services.StringResourceService;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Razor.Internal;

namespace Blogi.UI.Models
{
    public abstract class CustomBaseViewPage<TModel> : RazorPage<TModel>
    {
        [RazorInject]
        public ILanguageService LanguageService { get; set; }

        [RazorInject]
        public IStringResourceService LocalizationService { get; set; }

        public delegate HtmlString Localizer(string resourceKey, params object[] args);

        private Localizer _localizer;
        public Localizer Localize
        {
            get
            {
                if (_localizer == null)
                {
                    var currentCulture = Thread.CurrentThread.CurrentUICulture.Name;

                    var language = LanguageService.GetByCultureAsync(currentCulture);
                    if (language != null)
                    {
                        _localizer = (resourceKey, args) =>
                        {
                            var stringResource = LocalizationService.GetAsync(resourceKey, language.Result.Id);

                            if (stringResource == null || string.IsNullOrEmpty(stringResource.Result.Value))
                            {
                                return new HtmlString(resourceKey);
                            }

                            return new HtmlString(args == null || args.Length == 0
                                ? stringResource.Result.Value
                                : string.Format(stringResource.Result.Value, args));
                        };
                    }
                }
                return _localizer;
            }
        }
    }

    public abstract class CustomBaseViewPage : CustomBaseViewPage<dynamic> { }
}
