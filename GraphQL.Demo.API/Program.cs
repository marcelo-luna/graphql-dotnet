using GraphQL.Demo.API.Schema.Queries;

namespace GraphQL.Demo.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddGraphQLServer().AddQueryType<Query>();

            var app = builder.Build();

            //app.MapGet("/", () => "Hello World!");

            app.UseRouting();

            app.UseEndpoints(endpoints => 
            {
                endpoints.MapGraphQL();
            });

            app.Run();
        }
    }
}
