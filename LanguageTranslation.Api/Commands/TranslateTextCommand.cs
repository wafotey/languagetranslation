using System;
using MediatR;

namespace LanguageTranslation.Api.Commands
{
	public class TranslateTextCommand: IRequest<TranslateTextCommandResponseDto>
	{
		public string? Text { get; set; }
		public Guid LanguageId { get; set; }

		public int[] arr = new int[1];
		
		
	}


}

