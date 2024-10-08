using Amazon.Runtime;
using Amazon.SimpleNotificationService;
using Amazon.SQS;
using EventOne.Data;
using EventOne.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var sqsClient = new AmazonSQSClient(
    new BasicAWSCredentials(
        builder.Configuration.GetSection("AWS:AccessKeyID").Value,
        builder.Configuration.GetSection("AWS:SecretAccessKey").Value
    ), Amazon.RegionEndpoint.USEast2
);

var snsClient = new AmazonSimpleNotificationServiceClient(
    new BasicAWSCredentials(
        builder.Configuration.GetSection("AWS:AccessKeyID").Value,
        builder.Configuration.GetSection("AWS:SecretAccessKey").Value
    ), Amazon.RegionEndpoint.USEast2
);

builder.Services.AddSingleton<IAmazonSQS>(sqsClient);
builder.Services.AddSingleton<IAmazonSimpleNotificationService>(snsClient);

var connection = builder.Configuration.GetConnectionString("SQLiteConnection");

// Add services to the container.


// Configure SQLite with Entity Framework
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("SQLiteConnection")));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IDriversService, DriversService>();
builder.Services.AddScoped<IQueueService, QueueService>();
builder.Services.AddScoped<INotificationService, NotificationService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
