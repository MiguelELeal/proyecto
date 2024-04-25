using Microsoft.EntityFrameworkCore;
using proyecto.Context;
using proyecto.Repositories;
using proyecto.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("Connection");
builder.Services.AddDbContext<AgroCacao>(options => options.UseSqlServer(connectionString));
//servicio rol
builder.Services.AddScoped<IRolRepository, RolRepository>();
builder.Services.AddScoped<IRolService, RolService>();

//servicio Cutivo
builder.Services.AddScoped<ICultivoRepository, CultivoRepository>();
builder.Services.AddScoped<ICultivoService, CultivoService>();

//servicio Estado
builder.Services.AddScoped<IEstadoCultivoRepository, EstadoCultivoRepository>();
builder.Services.AddScoped<IEStadoCultivoService, EstadoCultivoService>();

//servicio Insumos
builder.Services.AddScoped<IInsumosRepository, InsumosRepository>();
builder.Services.AddScoped<IInsumosService, InsumosService>();

//servicio Requeridos
builder.Services.AddScoped<IInsumosRequeridosRepository, InsumosRequeridoRepository>();
builder.Services.AddScoped<IInsumosRequeridosService, InsumosRequeridosService>();

//servicio logro
builder.Services.AddScoped<IlogroRepository, LogroRepository>();
builder.Services.AddScoped<ILogroService, LogroService>();

//servicios logro conseguido
builder.Services.AddScoped<ILogroConseguidoRepositiory, LogroConseguidoRepositiory>();
builder.Services.AddScoped<ILogroConseguidoService, LogroConseguidoService>();

//servicio  partida
builder.Services.AddScoped<IPartidaRepository, PartidaRepository>();
builder.Services.AddScoped<IPartidaService, PartidaService>();

//servicio  procedimiento
builder.Services.AddScoped<IProcedimientoRepository, ProcedimientoRepository>();
builder.Services.AddScoped<IProcedimientoService, ProcedimientoService>();

//servicio  siembra
builder.Services.AddScoped<ISiembraRepository, SiembraRepository>();
builder.Services.AddScoped<ISiembraService, SiembraService>();

//servicio Terreno
builder.Services.AddScoped<ITerrenoRepository, TerrenoRepository>();
builder.Services.AddScoped<ITerrenoService, TerrenoService>();

//servicio Tipo Documento
builder.Services.AddScoped<ITipoDocumentoRepository, TipoDocumentoRepository>();
builder.Services.AddScoped<ITipoDocumentoService, TipoDocumentoService>();

//servicio Tipo Procedimiento
builder.Services.AddScoped<ITipoProcedimientRepository, TipoProcedimientRepository>();
builder.Services.AddScoped<ITipoProcediminetoService, TipoProcediminetoService>();

//servicio TrabajadoresRequeridos
builder.Services.AddScoped<ITrabajadoresRequeridosRepository, TrabajadoresRequeridosRepository>();
builder.Services.AddScoped<ITrabajadoresRequeridosService, TrabajadoresRequeridosService>();

//servicio Trabajadores
builder.Services.AddScoped<ITrabajadoresRepository, TrabajadoresRepository>();
builder.Services.AddScoped<ITrabajadoresService, TrabajadoresService>();

//servicio Usuario
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();

//servicio Usuario
builder.Services.AddScoped<IDatosPartidaRepository, DatosPartidaRepository>();
builder.Services.AddScoped<IDatosPartidaService, DatosPartidaService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
