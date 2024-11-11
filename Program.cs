using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAdB2C"));

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("UserPolicy", policy => policy.RequireClaim("role", "User"));
    options.AddPolicy("AdminPolicy", policy => policy.RequireClaim("role", "Administrator"));
});

builder.Services.AddDbContext<BlogContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnectionPostGree"))
);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication(); 
app.UseAuthorization(); 

app.Run();


