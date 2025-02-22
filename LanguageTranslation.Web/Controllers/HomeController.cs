using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using LanguageTranslation.Web.Models;
using LanguageTranslation.Web.Services;
using LanguageTranslation.Web.ViewModel;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LanguageTranslation.Web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ILanguageTranslationService _languageTranslationService;

    public HomeController(ILogger<HomeController> logger,ILanguageTranslationService languageTranslationService)
    {
        _logger = logger;
        _languageTranslationService = languageTranslationService ?? throw new ArgumentNullException(nameof(ILanguageTranslationService));
    }

    [HttpGet]
    public async Task<IActionResult> Index(Guid languageId = default)
    {
        var response = await _languageTranslationService.GetAllTranslatedText(languageId);

        var vm = new HomeIndexViewModel();

        if (response == null)
            return View(vm);

        vm.SelectedLanguage = response?.SelectedLanguage.ToString();

        foreach(var language in response!.Languages)
        {
            vm.Languages.Add(new SelectListItem
            {
                 Text = language.Name,
                 Value = language.Id.ToString()
            });
        }

        foreach(var translate in response.Translations)
        {
            vm.Translations.Add(new TranslationViewModel
            {
                 Text = translate.Text,
                 Translated = translate.Translated
            });
        }

        return View(vm);
    }

    [HttpGet("/GetTranslation")]
    public async Task<IActionResult> OnGetTranslationPartial(Guid languageId)
    {
        var response = await _languageTranslationService.GetAllTranslatedText(languageId);

        var vm = new HomeIndexViewModel();

        if (response == null)
            return View(vm);

        vm.SelectedLanguage = response?.SelectedLanguage.ToString();

        foreach (var language in response!.Languages)
        {
            vm.Languages.Add(new SelectListItem
            {
                Text = language.Name,
                Value = language.Id.ToString()
            });
        }

        foreach (var translate in response.Translations)
        {
            vm.Translations.Add(new TranslationViewModel
            {
                Text = translate.Text,
                Translated = translate.Translated
            });
        }

        return PartialView("_Translations", vm);
    }

    [HttpPost]
    public async Task<IActionResult> OnPostTranslationRowPartial([FromBody]  TranslationRowRequstViewModel model)
    {
        var response = await _languageTranslationService.GetTranslatedText(new GetATranslatedTextRequestDto
        {
            LanguageId = model.LanguageId,
            Text = model.Text
        });

        var vm = new TranslationViewModel
        {
            Text = response?.Text,
            Translated = response?.Translated
        };

        return PartialView("_TranslationRow", vm);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

