namespace proof_of_concept_spa.Domain.Autofac
{
    using System.Configuration;
    using global::Autofac;
    using proof_of_concept_spa.Domain.Data;

    public class AutofacDomainModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SparebedsContext>()
                   .As<SparebedsContext>()
                   .WithParameter("connectionString", ConfigurationManager.ConnectionStrings["Sparebeds"].ConnectionString)
                   .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(this.ThisAssembly)
                   .Where(t => t.Name.EndsWith("Repository"))
                   .AsImplementedInterfaces()
                   .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
