using Dentistry.BLL.Mapping;
using Dentistry.BLL.Services.ClaimsService;
using Dentistry.BLL.Services.UserService;
using Dentistry.DAL.DataContext;
using Dentistry.DAL.Repositories.UserRepository;
using Dentistry.Domain.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


#region Other Services

builder.Services.AddDbContext<ApplicationDbContext>(
    o => o.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));
builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.Configure<RouteOptions>(o =>
{
    o.LowercaseUrls = true;
    o.LowercaseQueryStrings = true;
    o.AppendTrailingSlash = true;
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/login/login";
        options.AccessDeniedPath = "/user";
    });
builder.Services.AddAuthorization();

#endregion


#region Repositories

builder.Services.AddScoped<IUserRepository, UserRepository>();

#endregion


#region Services

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IClaimsService, ClaimsService>();

#endregion


var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
