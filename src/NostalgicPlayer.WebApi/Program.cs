using NostalgicPlayer.DataAccess.Interfaces.Albums;
using NostalgicPlayer.DataAccess.Interfaces.Genres;
using NostalgicPlayer.DataAccess.Interfaces.Musics;
using NostalgicPlayer.DataAccess.Interfaces.Singers;
using NostalgicPlayer.DataAccess.Interfaces.Users;
using NostalgicPlayer.DataAccess.Repositories.Albums;
using NostalgicPlayer.DataAccess.Repositories.Genres;
using NostalgicPlayer.DataAccess.Repositories.Musics;
using NostalgicPlayer.DataAccess.Repositories.Singers;
using NostalgicPlayer.DataAccess.Repositories.Users;
using NostalgicPlayer.Service.Interfaces.Albums;
using NostalgicPlayer.Service.Interfaces.Auth;
using NostalgicPlayer.Service.Interfaces.Common;
using NostalgicPlayer.Service.Interfaces.Genres;
using NostalgicPlayer.Service.Interfaces.Musics;
using NostalgicPlayer.Service.Interfaces.Notifications;
using NostalgicPlayer.Service.Interfaces.Singers;
using NostalgicPlayer.Service.Services.Albums;
using NostalgicPlayer.Service.Services.Auth;
using NostalgicPlayer.Service.Services.Common;
using NostalgicPlayer.Service.Services.Genres;
using NostalgicPlayer.Service.Services.Musics;
using NostalgicPlayer.Service.Services.Notifications;
using NostalgicPlayer.Service.Services.Singers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();
builder.Services.AddMemoryCache();

//-> DI and IoC containers
builder.Services.AddScoped<IGenreRepository, GenreRepository>();
builder.Services.AddScoped<ISingerRepository, SingerRepository>();
builder.Services.AddScoped<IMusicRepository, MusicRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAlbumRepository, AlbumRepository>();

builder.Services.AddScoped<IFileService, FileService>();
builder.Services.AddScoped<IGenreService, GenreService>();
builder.Services.AddScoped<ISingerService, SingerService>();
builder.Services.AddScoped<IMusicService, MusicService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IAlbumService, AlbumService>();
builder.Services.AddScoped<ITokenService, TokenService>();

builder.Services.AddSingleton<ISmsSender, SmsSender>();
//->

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthorization();
app.MapControllers();
app.Run();