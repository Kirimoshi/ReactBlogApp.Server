using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ReactBlogApp.Server.Endpoints;
using ReactBlogApp.Server.Extensions;
using System.Reflection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using ReactBlogApp.Server;
using ReactBlogApp.Server.Models;
using ReactBlogApp.Server.AppContext;
using ReactBlogApp.Server.Contracts;

var builder = WebApplication.CreateBuilder(args);

builder.AddApplicationServices();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Blog API",
        Version = "v1",
        Description = "CRUD operations for all your blog needs"
    });


    // Set the comments path for the Swagger JSON and UI.
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Enter 'Bearer {token}'! START WITH 'Bearer'!",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new List<string>()
        }
    });
});



builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {           
            ValidateIssuer = true,   
            ValidIssuer = AuthOptions.ISSUER,           
            ValidateAudience = true,
            ValidAudience = AuthOptions.AUDIENCE,
            ValidateLifetime = true,
            IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
            ValidateIssuerSigningKey = true,
        };
    }
    );
builder.Services.AddAuthorization();


var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseExceptionHandler();

app.MapPost("/login", async (LoginUserRequest loginData, BlogContext context) =>
{
    UserModel? user = await context.Users.FirstOrDefaultAsync(
        u => u.Email == loginData.Email
    );

    if (user is null || !BCrypt.Net.BCrypt.Verify(loginData.Password, user.PasswordHash))
        return Results.Unauthorized();

    var claims = new List<Claim>
    {
        new(ClaimTypes.Name, user.Email),
        new(ClaimTypes.NameIdentifier, user.Id.ToString())
    };

    var jwt = new JwtSecurityToken(
        issuer: AuthOptions.ISSUER,
        audience: AuthOptions.AUDIENCE,
        claims: claims,
        expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(30)),
        signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256)
    );

    var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

    var response = new
    {
        access_token = encodedJwt,
        username = user.Email
    };

    return Results.Json(response);
});

app.MapGroup("/api/v1/")
    .WithTags("Article endpoints")
    .MapArticleEndpoint();

app.Map("/", async context => await context.Response.WriteAsync("Hello!"));

app.Run();