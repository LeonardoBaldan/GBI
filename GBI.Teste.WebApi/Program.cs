using AutoMapper;
using GBI.Teste.Model.Cadastro;
using GBI.Teste.Repository;
using GBI.Teste.Repository.Context;
using GBI.Teste.Repository.Interface;
using GBI.Teste.Repository.Query;
using GBI.Teste.WebApi;
using GBI.Teste.WebApi.Model.Cadastro;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "GBI WebAPI", Version = "v1" });
});

// Add services to the container.
builder.Services.AddDbContext<GBITesteSqlContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConn")));
builder.Services.AddTransient<ICommand<UsuarioModel>, UsuarioCommand>();
builder.Services.AddTransient<IQuery<UsuarioModel>, UsuarioQuery>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// automapper
var config = new MapperConfiguration(cfg =>
{
    cfg.CreateMap<UsuarioViewModel, UsuarioModel>().ReverseMap();
});
IMapper mapper = config.CreateMapper();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.MapPost("api/v1/usuario/incluir", (ICommand<UsuarioModel> command, [FromBody] UsuarioViewModel p) =>
{
    command.Incluir(mapper.Map<UsuarioModel>(p));
    return Results.Ok("Registro cadastrado com sucesso");
}).WithTags("Usuários");

app.MapPut("api/v1/usuario/alterar", (ICommand<UsuarioModel> command, [FromBody] UsuarioViewModel p) =>
{
    command.Alterar(mapper.Map<UsuarioModel>(p));
    return Results.Ok("Registro alterado com sucesso");
}).WithTags("Usuários");

app.MapDelete("api/v1/usuario/excluir", (ICommand<UsuarioModel> command, Guid id) =>
{
    command.Excluir(id);
    return Results.Ok("Registro excluído com sucesso");
}).WithTags("Usuários");

app.MapGet("api/v1/usuario/{id}/obter", (IQuery<UsuarioModel> query, Guid id) =>
{
    var resultado = query.Obter(id);
    if (resultado == null)
        return Results.NoContent();

    return Results.Ok(resultado);
}).WithTags("Usuários");

app.MapGet("api/v1/usuario/listar", (IQuery<UsuarioModel> query) =>
{
    var resultado = query.Listar();
    if (resultado.Count() == 0)
        return Results.NoContent();

    return Results.Ok(resultado);

}).WithTags("Usuários");

app.Run();