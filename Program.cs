using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2;
using AutoMapper;
using IYLTDSU.Api.Models.Games;
using IYLTDSU.Backend.LambdaApi;
using IYLTDSU.Business.Games.X01.Create;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer()
                .AddOpenApiDocument();
builder.Services.AddAWSLambdaHosting(LambdaEventSource.HttpApi);
builder.Services.AddAWSService<IAmazonDynamoDB>(builder.Configuration.GetAWSOptions("DynamoDb"));
builder.Services.AddTransient<IDynamoDBContext, DynamoDBContext>();
builder.Services.Configure<ApplicationOptions>(builder.Configuration.GetSection(nameof(ApplicationOptions)));
builder.Services.AddAutoMapper(x => x.AddMaps(typeof(X01GamesMapper)));
builder.Services.AddMediatR(typeof(CreateX01GameCommand));
var app = builder.Build();

app.UseOpenApi();
app.UseSwaggerUI();

app.MapControllers();

app.MapGet("/", () => "Welcome to running ASP.NET Core Minimal API on AWS Lambda");

app.UseHttpsRedirection();
app.UseAuthorization();

app.Run();
