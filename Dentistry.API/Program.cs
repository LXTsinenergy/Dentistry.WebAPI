using Dentistry.API.Controllers;
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
using Dentistry.DAL.DataContext;
using Dentistry.DAL.Repositories.DayRepository;
using Dentistry.DAL.Repositories.DoctorRepository;
using Dentistry.DAL.Repositories.NoteRepository;
using Dentistry.DAL.Repositories.ReviewRepository;
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
