using System;
namespace LanguageTranslation.Api.DelegateHandlers
{
	public class LoggingDelegateHandler: DelegatingHandler
    {
		private readonly ILogger<LoggingDelegateHandler> _logger;
		public LoggingDelegateHandler(ILogger<LoggingDelegateHandler> logger)
		{
			_logger = logger;
		}


        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
		{
			_logger.LogInformation("");
			var httpResponseMessage =  await base.SendAsync(request, cancellationToken);
			_logger.LogInformation("");
			return httpResponseMessage;
        }

    }
}

