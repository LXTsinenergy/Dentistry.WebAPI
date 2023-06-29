using Dentistry.BLL.Mapping;
using Dentistry.BLL.Services.UserService;
using Dentistry.DAL.DataContext;
using Dentistry.DAL.Repositories.UserRepository;
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

#endregion


#region Repositories

builder.Services.AddScoped<IUserRepository, UserRepository>();

#endregion


#region Services

builder.Services.AddScoped<IUserService, UserService>();

#endregion
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
