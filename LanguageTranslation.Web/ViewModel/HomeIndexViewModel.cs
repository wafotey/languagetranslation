using System;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LanguageTranslation.Web.ViewModel
{
	public class HomeIndexViewModel
	{
		public string? SelectedLanguage { get; set; }
		public List<TranslationViewModel> Translations { get; set; } = new List<TranslationViewModel>();
		public List<SelectListItem> Languages { get; set; } = new List<SelectListItem>();
    }

	public class TranslationViewModel
	{
        public string? Text { get; set; }
        public string? Translated{ get; set; }
    }

	public class TranslationRowRequstViewModel
	{
      
        public string? Text { get; set; }
     
        public Guid LanguageId { get; set; }
    }
}

