using FluentValidation;
using MediatR;
using MediatR.Pipeline;
using System.Reflection;
using WebApp.Business.Behaviors;
using WebApp.Business.Handlers;
using WebApp.Business.Validators;
using WebApp.Data.Repositories;
using WebApp.Data.Repositories.Abstract;

namespace WebApp.Api.Extensions
{
    internal static class DependencyInjectionExtension
    {
        internal static void AddDependencyResolvers(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddValidatorsFromAssembly(typeof(GetSampleByIdQueryValidator).Assembly);
            services.AddMediatR(typeof(GetSampleByIdHandler).GetTypeInfo().Assembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddTransient(typeof(IRequestExceptionHandler<,,>), typeof(ExceptionHandlingBehavior<,,>));

            services.AddScoped(typeof(IReadOnlyRepository<>), typeof(ReadOnlyRepository<>));
            services.AddScoped(typeof(IWritableRepository<>), typeof(WritableRepository<>));
        }
    }
}