using AutoMapper;
using Board.Application.AppData.Contexts.Adverts.Repositories;
using Board.Application.AppData.Contexts.Adverts.Services;
using Board.Application.AppData.Contexts.Categories.Repositories;
using Board.Application.AppData.Contexts.Categories.Services;
using Board.Application.AppData.Contexts.Comments.Repositories;
using Board.Application.AppData.Contexts.Comments.Services;
using Board.Application.AppData.Contexts.FavoriteAdverts.Repositories;
using Board.Application.AppData.Contexts.FavoriteAdverts.Services;
using Board.Application.AppData.Contexts.Files.Repositories;
using Board.Application.AppData.Contexts.Files.Services;
using Board.Application.AppData.Contexts.ImageAdverts.Repositories;
using Board.Application.AppData.Contexts.ImageAdverts.Services;
using Board.Application.AppData.Contexts.Messages.Repositories;
using Board.Application.AppData.Contexts.Messages.Services;
using Board.Application.AppData.Contexts.Roles.Repositories;
using Board.Application.AppData.Contexts.Roles.Services;
using Board.Application.AppData.Contexts.Users.Repositories;
using Board.Application.AppData.Contexts.Users.Services;
using Board.Application.AppData.Services;
using Board.Contracts.Advert;
using Board.Contracts.Interfaces;
using Board.Infastructure.Identity;
using Board.Infastructure.MapProfiles;
using Board.Infastructure.Repository;
using Board.Infrastucture.DataAccess;
using Board.Infrastucture.DataAccess.Contexts.Adverts;
using Board.Infrastucture.DataAccess.Contexts.Categories;
using Board.Infrastucture.DataAccess.Contexts.Comments;
using Board.Infrastucture.DataAccess.Contexts.FavoriteAdverts;
using Board.Infrastucture.DataAccess.Contexts.Files;
using Board.Infrastucture.DataAccess.Contexts.ImageAdverts;
using Board.Infrastucture.DataAccess.Contexts.Messages;
using Board.Infrastucture.DataAccess.Contexts.Roles;
using Board.Infrastucture.DataAccess.Contexts.Users;
using Board.Infrastucture.DataAccess.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.ComponentModel;
using System.Text;

var builder = WebApplication.CreateBuilder(args);



// Добавляем DbContext
builder.Services.AddSingleton<IDbContextOptionsConfigurator<BoardDbContext>, BoardDbContextConfiguration>();

builder.Services.AddDbContext<BoardDbContext>((Action<IServiceProvider, DbContextOptionsBuilder>)
    ((sp, dbOptions) => sp.GetRequiredService<IDbContextOptionsConfigurator<BoardDbContext>>()
        .Configure((DbContextOptionsBuilder<BoardDbContext>)dbOptions)));

builder.Services.AddScoped((Func<IServiceProvider, DbContext>)(sp => sp.GetRequiredService<BoardDbContext>()));

// Add repositories to the container.
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IAdvertRepository, AdvertRepository>();
builder.Services.AddScoped<IFileRepository, FileRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();
builder.Services.AddScoped<IMessageRepository, MessageRepository>();
builder.Services.AddScoped<IFavoriteAdvertRepository, FavoriteAdvertRepository>();
builder.Services.AddScoped<IImageAdvertRepository, ImageAdvertRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();


// Add services to the container.
builder.Services.AddScoped<IAdvertService, AdvertService>();
builder.Services.AddScoped<IFileService, FileService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IForbiddenWordsService, ForbiddenWordsService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<IMessageService, MessageService>();
builder.Services.AddScoped<IFavoriteAdvertService, FavoriteAdvertService>();
builder.Services.AddScoped<IImageAdvertService, ImageAdvertService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IClaimAcessor, HttpContextClaimAcessor>();


builder.Services.AddSingleton<IMapper>(new Mapper(GetMapperConfiguration()));

builder.Services.AddControllers();

builder.Services.AddCors();

#region Authentication & Authorization

builder.Services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(
    options =>
    {
        var secretKey = builder.Configuration["Jwt:Key"];

        options.RequireHttpsMetadata = false;
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateActor = false,
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
        };
    });

builder.Services.AddAuthorization();

#endregion

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Board Api", Version = "V1" });
    options.IncludeXmlComments(Path.Combine(Path.Combine(AppContext.BaseDirectory,
        $"{typeof(CreateAdvertDto).Assembly.GetName().Name}.xml")));
    options.IncludeXmlComments(Path.Combine(Path.Combine(AppContext.BaseDirectory, "Documentation.xml")));

    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"JWT Authorization header using the Bearer scheme.  
                        Enter 'Bearer' [space] and then your token in the text input below.
                        Example: 'Bearer secretKey'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = JwtBearerDefaults.AuthenticationScheme
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme="oauth2",
                Name= "Bearer",
                In = ParameterLocation.Header,
            },
            new List<string>()
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true) // allow any origin
    .AllowCredentials());
app.UseHsts();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();


static MapperConfiguration GetMapperConfiguration()
{
    var configuration = new MapperConfiguration(cfg =>
    {
        cfg.AddProfile<AdvertProfile>();
        cfg.AddProfile<CategoryProfile>();
        cfg.AddProfile<FileProfile>();
        cfg.AddProfile<CommentProfile>();
        cfg.AddProfile<MessageProfile>();
        cfg.AddProfile<FavoriteAdvertProfile>();
        cfg.AddProfile<ImageAdvertProfile>();
    });
    configuration.AssertConfigurationIsValid();
    return configuration;
}