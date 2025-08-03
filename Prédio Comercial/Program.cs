using Microsoft.EntityFrameworkCore;
using Pr�dio_Comercial.Interface;
using Pr�dio_Comercial.Repository;
using Pr�dio_Comercial.Service;
using AutoMapper;
using Pr�dio_Comercial;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSession(options =>
{
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddScoped<IUsuarios, UsuariosRepository>();
builder.Services.AddScoped<ISessionUsuary, SessionRepository>();
builder.Services.AddScoped<IProprietarios, ProprietariosRepository>();
builder.Services.AddScoped<IFiltragemDePagina, FilgragemDePaginaRepository>();
builder.Services.AddScoped<ILoggerService, LogerServiceRepository>();
builder.Services.AddScoped<IDashBoardDTO, DashBoardDTORepository>();
builder.Services.AddHttpContextAccessor();

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
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

app.UseRouting();
app.UseSession();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Usuarios}/{action=Login}/{id?}");

app.Run();
