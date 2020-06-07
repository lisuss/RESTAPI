using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SwaggerOptions = MyWebApi.Options.SwaggerOptions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace MyWebApi.Installer
{
    public interface IInstaller
    {
        void InstallServices(IServiceCollection services, IConfiguration configuration);
    }
}
