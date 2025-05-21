using backend.erp.Application.Interfaces;
using backend.erp.Application.Mapping;
using backend.erp.Application.Services;
using backend.erp.Domain.Model;
using backend.erp.Infra.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySQL(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        b => b.MigrationsAssembly("backend.erp.Infra")
    ));

builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(MappingProfileUser));
builder.Services.AddScoped<IUsers, UserServices>();
builder.Services.AddScoped<IFornecedor, FornecedorServices>();
var app = builder.Build();



if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
