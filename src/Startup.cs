using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using MediatR;
using IYLTDSU.Api.Mappers;
using IYLTDSU.Business;
using IYLTDSU.Business.X01;
using IYLTDSU.Business.X01.Games.Create;
using Newtonsoft.Json;

namespace IYLTDSU.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDefaultAWSOptions(Configuration.GetAWSOptions());
            services.AddAWSService<IAmazonDynamoDB>(Configuration.GetAWSOptions("DynamoDb"));
            services.AddTransient<IDynamoDBContext, DynamoDBContext>();
            services.Configure<ApplicationOptions>(Configuration.GetSection(nameof(ApplicationOptions)));
            services.AddAutoMapper(x => x.AddMaps(typeof(GamesMapper)));
            services.AddTransient<X01GameService>();
            services.AddMediatR(typeof(CreateX01GameCommand));
            services.Configure<RouteOptions>(options => options.LowercaseUrls = true);
            services.AddControllers();
            services.AddCors(x => x.AddDefaultPolicy(p => p.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()));
            services.AddEndpointsApiExplorer();
            services.AddOpenApiDocument(options =>
            {
                options.GenerateEnumMappingDescription = true;
                options.Title = "Connectingdarts API";
                options.AllowNullableBodyParameters = false;
                options.Version = "1";
                options.DocumentName = "v1";
                options.PostProcess = document =>
                {
                    document.Produces = new List<string>
                    {
                        "application/json"
                    };
                };
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseOpenApi();
            app.UseSwaggerUi3(x =>
            {
                x.AdditionalSettings["displayOperationId"] = true;
            });

            app.UseRouting();
            app.UseCors();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

