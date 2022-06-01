using Marketplace;
using Marketplace.Api;
using Marketplace.Contracts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(); 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo {
        Title = "ClassifiedAds",
        Version = "v1",
    });
});
builder.Services.AddSingleton<IEntityStore,RavenDBEntityStore>();
builder.Services.AddSingleton<IHandleCommand<ClassifiedAds.V1.Create>, CreateClassifiedAdHandle>();
//builder.Services.AddSingleton<IHandleCommand<ClassifiedAds.V1.Create>>( C=>
//        new RetryingCommandHandle<ClassifiedAds.V1.Create>(
//            new CreateClassifiedAdHandle(C.GetService<RavenDBEntityStore>())));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "ClassifiedAds v1");
    });
}


app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
