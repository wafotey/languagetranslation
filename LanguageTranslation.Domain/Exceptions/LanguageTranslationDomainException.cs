using System;
namespace LanguageTranslation.Domain.Exceptions
{
	public class LanguageTranslationDomainException: Exception
    {
		public LanguageTranslationDomainException()
		{
		}

		public LanguageTranslationDomainException(string message): base(message)
		{

		}

		public LanguageTranslationDomainException(string message,Exception innerException): base(message,innerException)
		{

		}
	}
}

