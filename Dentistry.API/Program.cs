using Dentistry.BLL.Exceptions;
using Dentistry.BLL.Mapping;
using Dentistry.BLL.Services.AccountService;
using Dentistry.BLL.Services.ClaimsService;
using Dentistry.BLL.Services.DoctorService;
using Dentistry.BLL.Services.DoctorsNoteService;
using Dentistry.BLL.Services.MessageService;
using Dentistry.BLL.Services.PasswordService;
using Dentistry.BLL.Services.ReviewService;
using Dentistry.BLL.Services.ScheduleService;
using Dentistry.BLL.Services.UserService;
using Dentistry.DAL;
using Dentistry.DAL.DataContext;
using Dentistry.DAL.Repositories.DayRepository;
using Dentistry.DAL.Repositories.DoctorRepository;
using Dentistry.DAL.Repositories.NoteRepository;
using Dentistry.DAL.Repositories.ReviewRepository;
using Dentistry.DAL.Repositories.UserRepository;
using Dentistry.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<RouteOptions>(o =>
{
    o.LowercaseUrls = true;
    o.LowercaseQueryStrings = true;
    o.AppendTrailingSlash = true;
});

builder.Services.AddAutoMapper(config =>
{
    config.AddProfile(typeof(MappingProfile));
});


builder.Services.AddContext(builder.Configuration);

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/login/login";
        options.AccessDeniedPath = "/user";
    });
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
        policy.AllowAnyOrigin();
    });
});

builder.Services.AddAuthorization();

#region Repositories

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IDoctorRepository, DoctorRepository>();
builder.Services.AddScoped<INoteRepository, NoteRepository>();
builder.Services.AddScoped<IDayRepository, DayRepository>();
builder.Services.AddScoped<IReviewRepository, ReviewRepository>();

#endregion


#region Services

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IClaimsService, ClaimsService>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IPasswordService, PasswordService>();
builder.Services.AddScoped<IDoctorService, DoctorService>();
builder.Services.AddScoped<INoteService, NoteService>();
builder.Services.AddScoped<IMessageService,  MessageService>();
builder.Services.AddScoped<IDayService,  DayService>();
builder.Services.AddScoped<IReviewService,  ReviewService>();

builder.Services.AddSingleton<CodeBuffer>();



#endregion

builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    try
    {
        var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        DbInitializer.Initialize(context);
    }
    catch
    {
        throw new DatabaseNotInitializedException<ApplicationDbContext>();
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }


app.UseHttpsRedirection();

app.UseCors("AllowAll");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
