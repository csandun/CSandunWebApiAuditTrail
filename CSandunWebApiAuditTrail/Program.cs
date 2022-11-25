using Audit.Core;
using Audit.EntityFramework;
using Audit.EntityFramework.Interceptors;
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
        
        .AddInterceptors(updateAuditableInterceptor)
        .AddInterceptors(new AuditSaveChangesInterceptor()) ; 
});

builder.Services.AddSingleton<IUserMockService, UserMockService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


Audit.Core.Configuration.Setup()
    .UseEntityFramework(_ => _
        .AuditTypeMapper(t => typeof(AuditLog))  
        .AuditEntityAction<AuditLog>((ev, entry, entity) =>
        {
            entity.Action = string.Empty;
            entity.AuditData = entry.ToJson();
            entity.EntityType = entry.EntityType.Name;
            entity.AuditDateTimeUtc = DateTime.Now;
            //entity.AuditDateTimeUtc = Environment.UserName;
            entity.UserId = Guid.NewGuid();
            entity.TablePk = entry.PrimaryKey.First().Value.ToString();
        })
        .IgnoreMatchedProperties(true));




var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();