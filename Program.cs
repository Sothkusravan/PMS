using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Logging;
using pharma.Data;
using pharma.Interface;
using pharma.Repository;
using Microsoft.AspNetCore.Diagnostics;
using pharma.Services;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var jwtSettings = builder.Configuration.GetSection("JwtSettings");
var secretKey = jwtSettings["SecretKey"];

if (string.IsNullOrEmpty(secretKey))
{
    throw new ApplicationException("JWT SecretKey is missing or invalid in configuration.");
}

var key = Encoding.ASCII.GetBytes(secretKey);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtSettings["Issuer"],
            ValidAudience = jwtSettings["Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(key),
        };
        options.Events = new JwtBearerEvents
        {
            OnMessageReceived = context =>
            {
                if (context.Request.Cookies.ContainsKey("JwtToken"))
                {
                    context.Token = context.Request.Cookies["JwtToken"];
                }
                return Task.CompletedTask;
            }
        };
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Admin", policy => policy.RequireRole("Admin"));
    options.AddPolicy("Doctor", policy => policy.RequireRole("Doctor"));
    options.AddPolicy("DoctorOrAdmin", policy => policy.RequireRole("Doctor", "Admin"));
});

builder.Services.AddDbContext<PharmaDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddScoped<UserControllerServises>();
builder.Services.AddTransient<ISuppliersRepository, SuppliersRepository>();
builder.Services.AddScoped<SuppliersServises>();
builder.Services.AddTransient<IDrugRepository, DrugRepository>();
builder.Services.AddScoped<DrugServices>();
builder.Services.AddTransient<IOrderDetailsRepository, OrderDetailsRepository>();
builder.Services.AddScoped<OrderDetailsServises>();
builder.Services.AddTransient<IDrugRequestRepository, DrugRequestRepository>();
builder.Services.AddScoped<DrugRequestServises>();
builder.Services.AddTransient<IEmailService, EmailRepository>();
builder.Services.AddScoped<EmailService>();
builder.Services.AddTransient<ISupplierInventoryRepository, SuppliersInventoryRepository>();
builder.Services.AddScoped<SupplierInventoryServises>();
builder.Services.AddTransient<ISalesRepository, SalesRepository>();
builder.Services.AddScoped<SalesServices>();



builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Your API", Version = "v1" });
});



var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(builder =>
    builder.WithOrigins("http://localhost:3000")
           .AllowAnyMethod()
           .AllowAnyHeader()
);




app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.UseExceptionHandler(errorApp =>
{
    errorApp.Run(async context =>
    {
        context.Response.StatusCode = StatusCodes.Status500InternalServerError;
        context.Response.ContentType = "application/json";

        var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();
        var errorMessage = exceptionHandlerPathFeature?.Error.Message ?? "An error occurred.";

        await context.Response.WriteAsJsonAsync(new { error = errorMessage });
    });
});

app.Run();
