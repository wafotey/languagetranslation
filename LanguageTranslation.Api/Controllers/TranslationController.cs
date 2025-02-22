using System;
using LanguageTranslation.Api.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LanguageTranslation.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TranslationController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<TranslationController> _logger;
		public TranslationController(ILogger<TranslationController> logger,IMediator mediator)
		{
            _logger = logger;
            _mediator = mediator ?? throw new ArgumentNullException(nameof(IMediator));
		}

        [HttpPost]
        public async Task<IActionResult> Translate(TranslateTextCommand command) => Ok(await _mediator.Send(command));
	}
}

