using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WebAPi6.Context;
using WebAPi6.ServiceImp;
using WebAPi6.Services;
using WebAPi6.TokenGenerator;
using Stripe;
using WebAPi6.Middleware.NotificationService;
using CorePush.Google;
using CorePush.Apple;
using WebAPi6.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddDbContext<FoodOrderDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString")));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Token Generator Service
builder.Services.AddScoped<ITokenGenerator, TokenGeneratorImp>();

builder.Services.AddScoped<IUser, UserImp>();
builder.Services.AddScoped<IRestaurant, RestaurantImp>();
builder.Services.AddScoped<IMeal, MealImp>();
builder.Services.AddScoped<IMealSubcategory, MealSubcategoryImp>();
builder.Services.AddScoped<IOrder, OrderImp>();
builder.Services.AddScoped<ICart, CartImp>();
builder.Services.AddScoped<IOrderConfirmation, OrderConfirmationImp>();
builder.Services.AddTransient<INotificationService, NotificationServiceImp>();
builder.Services.AddHttpClient<FcmSender>();
builder.Services.AddHttpClient<ApnSender>();

builder.Services.Configure<TokenParams>(builder.Configuration.GetSection("JSONWebTokenPramas"));
builder.Services.Configure<FcmNotificationSetting>(builder.Configuration.GetSection("FcmNotification"));

builder.Services.AddAuthentication(options => {
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer( options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuerSigningKey = bool.Parse(builder.Configuration["JSONWebTokenPramas:ValidateIssueSignature"]),
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JSONWebTokenPramas:IssuerSigningKey"])),
        ValidateIssuer = bool.Parse(builder.Configuration["JSONWebTokenPramas:ValidateIssuer"]),
        ValidIssuer = builder.Configuration["JSONWebTokenPramas:ValidIssuer"],
        ValidateAudience = bool.Parse(builder.Configuration["JSONWebTokenPramas:ValidateAudience"]),
        ValidAudience = builder.Configuration["JSONWebTokenPramas:ValidAudience"],
        RequireExpirationTime = bool.Parse(builder.Configuration["JSONWebTokenPramas:RequireExpirationTime"]),
        ValidateLifetime = bool.Parse(builder.Configuration["JSONWebTokenPramas:ValidateLifeTime"])

    };
});

builder.Services.AddCors(policyBuilder =>
    policyBuilder.AddDefaultPolicy(policy =>
        policy.WithOrigins("*").AllowAnyHeader().AllowAnyHeader())
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
