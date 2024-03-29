﻿namespace proof_of_concept_spa.Web
{
    using System.Reflection;
    using System.Web.Http;
    using global::Autofac;
    using global::Autofac.Features.ResolveAnything;
    using global::Autofac.Integration.WebApi;
    using proof_of_concept_spa.Domain.Autofac;
    using proof_of_concept_spa.Web.Autofac;

    internal static class AutofacConfig
    {
        public static void Configure(HttpConfiguration config)
        {
            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterModule<AutofacWebModule>();
            builder.RegisterModule<AutofacDomainModule>();
            builder.RegisterSource(new AnyConcreteTypeNotAlreadyRegisteredSource());
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}