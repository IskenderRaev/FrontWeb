using AspNetCoreHero.ToastNotification.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shared.Core.Interfaces;
using StiGovKg.Application.Common.Interfaces;
using System.Threading;

namespace WebSti.Controllers
{
    public class BaseController : Controller
    {
        private IMediator _mediator;
        private INotyfService _notyfService;
        private IDictionaryService _dictionaryService;
        private readonly ILanguageService _languageService;
        private readonly ILocalizationService _localizationService;

        public BaseController(ILanguageService languageService, ILocalizationService localizationService)
        {
            _languageService = languageService;
            _localizationService = localizationService;
        }

        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
        protected INotyfService Notyf => _notyfService ??= HttpContext.RequestServices.GetService<INotyfService>();
        protected IDictionaryService DictionaryService => _dictionaryService ??= HttpContext.RequestServices.GetService<IDictionaryService>();

        public HtmlString Localize(string resourceKey, params object[] args)
        {
            var currentCulture = Thread.CurrentThread.CurrentUICulture.Name;

            var language = _languageService.GetLanguageByCulture(currentCulture);
            if (language != null)
            {
                var stringResource = _localizationService.GetStringResource(resourceKey, language.Id);
                if (stringResource == null || string.IsNullOrEmpty(stringResource.Value))
                {
                    return new HtmlString(resourceKey);
                }

                return new HtmlString((args == null || args.Length == 0)
                    ? stringResource.Value
                    : string.Format(stringResource.Value, args));
            }

            return new HtmlString(resourceKey);
        }
    }
}