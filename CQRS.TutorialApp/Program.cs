using CQRS.TutorialApp.CQRS.Handlers;
using CQRS.TutorialApp.Data.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddNewtonsoftJson(opt =>
{
    opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});

builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"), options =>
    {
        options.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name);
    });
});
//builder.Services.AddScoped<GetStudentByIdQueryHandler>();
//builder.Services.AddScoped<GetStudentsQueryHandler>();

//// Command Registration

//builder.Services.AddScoped<CreateStudentCommandHandler>();
//builder.Services.AddScoped<RemoveStudentCommandHandler>();
//builder.Services.AddScoped<UpdateOneStudentCommandHandler>();


builder.Services.AddMediatR(typeof(Program));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
