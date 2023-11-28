using ContactsFS.Data.Contexts;
using ContactsFS.Logic.Services;
using ContactsFS.Logic.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetValue<string>("ContactDbConnection");
builder.Services.AddDbContext<ContactDbContext>(options => {
    options.UseNpgsql(connectionString);
});

builder.Services.AddTransient<ContactDbContext>();
builder.Services.AddTransient<IContactService, ContactService>();
builder.Services.AddCors();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.MapControllers();

app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseDefaultFiles();
app.UseStaticFiles();

app.Run();
