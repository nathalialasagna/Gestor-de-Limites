using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2;
using Gestor_de_Limite.DataAccess.Repository.IRepository;
using Gestor_de_Limite.DataAccess.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSingleton<IAmazonDynamoDB, AmazonDynamoDBClient>();
builder.Services.AddSingleton<IDynamoDBContext, DynamoDBContext>();

builder.Services.AddScoped<IContaRepository, ContaRepository>();
builder.Services.AddScoped<ITransacaoRepository, TransacaoRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{area=Client}/{controller=Home}/{action=Index}/{id?}");

app.Run();
