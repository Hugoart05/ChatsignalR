using Microsoft.AspNetCore.Authentication.Cookies;
using SignalR.Chat.Business;
using SignalR.Chat.Contexto;
using SignalR.Chat.Interfaces;
using SignalR.Chat.Repository;
using SignalR.Chat.SignalR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ChatContext>();
builder.Services.AddScoped<IUsuario, UsuarioRepository>();
builder.Services.AddScoped<IMensagem, MensagemRepository>();
builder.Services.AddScoped<IContato, ContatoRepository>();
builder.Services.AddScoped<IRole,RoleRepository>();
builder.Services.AddScoped<IRegrasContato, RegrasContato>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSignalR();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.ExpireTimeSpan = TimeSpan.FromDays(1);
        options.SlidingExpiration = true;
        options.LoginPath = "/account";
        options.AccessDeniedPath = "/account";
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthentication();
app.MapHub<MessageHub>("/Chat");
app.UseRouting();



app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
