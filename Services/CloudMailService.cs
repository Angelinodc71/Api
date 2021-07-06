using System;
using System.Diagnostics;
using Microsoft.Extensions.Configuration;

namespace Api.Services
{
    public class CloudMailService : IMailService
    {
        private IConfiguration _configuration;
        public CloudMailService(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }
        public void Send (string subject, string message)
        {
            Debug.WriteLine($"Mail enviado de {_configuration["mailSettings:mailFromAddress"]} hacía {_configuration["mailSettings:mailToAddress"]} desde el CloudMailService");
            Debug.WriteLine($"Asunto: {subject}");
            Debug.WriteLine($"Mensaje: {message}");
        }
    }
}