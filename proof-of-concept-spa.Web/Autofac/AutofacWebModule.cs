namespace proof_of_concept_spa.Web.Autofac
{
    using System.Web;

    using global::Autofac;
    using proof_of_concept_spa.Domain.Organisation;
    using proof_of_concept_spa.Domain.Users;
    using proof_of_concept_spa.Web.Providers;

    public class AutofacWebModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // used in CurrentUserProvider
            builder.Register(c => new HttpContextWrapper(HttpContext.Current)).As<HttpContextBase>().InstancePerLifetimeScope();
            builder.Register(ctx => HttpContext.Current).As<HttpContext>().InstancePerLifetimeScope();

            builder.RegisterType<OrganisationRepository>().As<IOrganisationRepository>().InstancePerRequest();
            builder.RegisterType<UserRepository>().As<IUserRepository>().InstancePerRequest();
            builder.RegisterType<CurrentUserProvider>().As<ICurrentUserProvider>().InstancePerRequest();

            base.Load(builder);
        }
    }
}