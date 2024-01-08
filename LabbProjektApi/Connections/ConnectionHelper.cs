using LabbProjektApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace LabbProjektApi.Connections
{
    public static class ConnectionHelper
    {
        public static WebApplicationBuilder AddDatabaseContext(this WebApplicationBuilder builder)
        {
            string connectionString = builder.Configuration.GetConnectionString("ApplicationContext");

            void IdidNotWantToUseALambdaInAddDbContextMethod(DbContextOptionsBuilder options)
            {//Name is for myself to hardcode information to my brain of how stuff is connected thru this program.
                //Not yet comftertable(*bekväm* för lat för kolla stavning) with lambdas.
                options.UseSqlServer(connectionString);
            }

            builder.Services.AddDbContext<ApplicationContext>(IdidNotWantToUseALambdaInAddDbContextMethod);

            builder.Services.AddControllers().AddJsonOptions(options =>
            {// Av någon anledning så fastnade Json fetchen i en oändlig loop pga many-to-many relations.
                //Tvungen att koda in en ignorer för cycles
                    // Efter lite studier så skulle jag ha gjort en DTO (Data Transfer Object) för att hjälpa EF hitta allt.
                        // PGA Kommentaren ovan så har jag skapat en DTO enl rek, och är benägen att få det fungera.(skrivet innan lyckat försök)
                options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
                //IgnoreCycles - Denna lösning är icke att rekommendera, att ignorera problem istället för schysst struktur är inget jag står för.
                //Med det sagt, jag behåller för erfarenhetens skull.
            });

            return builder;
        }

        public static void AppConnectors()
        {
            var builder = WebApplication.CreateBuilder();

            builder.AddDatabaseContext();

            var app = builder.Build();

            // Routrar om http requests till https, övar på koda säkerhet
            app.UseHttpsRedirection();

            // Gör så man kan använda statiska filer som html, css och javascript, bilder etc. 
            app.UseStaticFiles();

            // Den routrar requests till den lämpliga endpointed som matchar den requesten som skrivits
            app.UseRouting();

            // Den säger åt ASP.NET Core att kolla efter controllers i appen och använda rätt väg,
            // den gör det möjligt för requests att kopplas till controllen.
            app.MapControllers();

            app.MapGet("/", GetMainRootMessage.MessageForRoot);

            app.Run();
        }
    }
}
