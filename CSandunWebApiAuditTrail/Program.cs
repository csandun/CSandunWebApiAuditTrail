using CSandunWebApiAuditTrail.DbContextInterceptors;
using CSandunWebApiAuditTrail.Models;
using CSandunWebApiAuditTrail.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddSingleton<UpdateAuditableEntitiesInterceptor>();

builder.Services.AddDbContext<TodoContext>((serviceProvider,opt) =>
{
    var updateAuditableInterceptor = serviceProvider.GetService<UpdateAuditableEntitiesInterceptor>();
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
        .AddInterceptors(updateAuditableInterceptor);
});

builder.Services.AddSingleton<IUserMockService, UserMockService>();
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