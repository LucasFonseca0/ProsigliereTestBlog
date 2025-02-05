using Application.Interfaces;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.UnitOfWork;
using Application.Services;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

ServicesInjection(builder);
RepositoriesInjection(builder);

var app = builder.Build();

// Apply migrations automatically
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext.Database.Migrate();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();

static void ServicesInjection(WebApplicationBuilder builder)
{
    builder.Services.AddScoped<IBlogPostService, BlogPostService>();
    builder.Services.AddScoped<ICommentService, CommentService>();
}

static void RepositoriesInjection(WebApplicationBuilder builder)
{
    builder.Services.AddScoped<IBlogPostRepository, BlogPostRepository>();
    builder.Services.AddScoped<ICommentRepository, CommentRepository>();
}