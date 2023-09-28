using Data.Contexto;
using Data.Repository;
using Domain.Entities;
using Domain.Interfaces.Repository;
using Domain.Interfaces.Services;
using Domain.Services;
using FASistemas.Token;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DbContextBase>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDefaultIdentity<Usuario>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<DbContextBase>();
builder.Services.AddScoped(s =>
{
    var httpClient = new HttpClient
    {
        BaseAddress = new Uri("http://localhost:5290/") // Substitua pela URL da sua API
    };
    return httpClient;
});

builder.Services.AddSingleton(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
builder.Services.AddSingleton<ICategoriaRepository, CategoriaRepository>();
builder.Services.AddSingleton<IClienteRepository, ClienteRepository>();
builder.Services.AddSingleton<IContaPagarRepository, ContaPagarRepository>();
builder.Services.AddSingleton<IContaReceberRepository, ContaReceberRepository>();
builder.Services.AddSingleton<IFormaPagamentoRepository, FormaPagamentoRepository>();
builder.Services.AddSingleton<IMesaRepository, MesaRepository>();
builder.Services.AddSingleton<IProdutoRepository, ProdutoRepository>();
builder.Services.AddSingleton<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddSingleton<IVendaRepository, VendaRepository>();
builder.Services.AddSingleton<IVendaItensRepository, VendaItensRepository>();

builder.Services.AddSingleton<ICategoriaServices, CategoriaServices>();
builder.Services.AddSingleton<IClienteServices, ClienteServices>();
builder.Services.AddSingleton<IContaPagarServices, ContaPagarServices>();
builder.Services.AddSingleton<IContasReceberServices, ContasReceberServices>();
builder.Services.AddSingleton<IFormaPagamentoServices, FormaPagamentoServices>();
builder.Services.AddSingleton<IMesaServices, MesaServices>();
builder.Services.AddSingleton<IProdutoServices, ProdutoServices>();
builder.Services.AddSingleton<IUsuarioServices, UsuarioServices>();
builder.Services.AddSingleton<IVendaServices, VendaServices>();
builder.Services.AddSingleton<IVendaItensServices, VendaItensServices>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
             .AddJwtBearer(option =>
             {
                 option.TokenValidationParameters = new TokenValidationParameters
                 {
                     ValidateIssuer = false,
                     ValidateAudience = false,
                     ValidateLifetime = true,
                     ValidateIssuerSigningKey = true,

                     ValidIssuer = "Teste.Securiry.Bearer",
                     ValidAudience = "Teste.Securiry.Bearer",
                     IssuerSigningKey = JwtSecurityKey.Create("Secret_Key-12345678")
                 };

                 option.Events = new JwtBearerEvents
                 {
                     OnAuthenticationFailed = context =>
                     {
                         Console.WriteLine("OnAuthenticationFailed: " + context.Exception.Message);
                         return Task.CompletedTask;
                     },
                     OnTokenValidated = context =>
                     {
                         Console.WriteLine("OnTokenValidated: " + context.SecurityToken);
                         return Task.CompletedTask;
                     }
                 };
             });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

var devCliente = "https://localhost:4200";
app.UseCors(x =>
x.AllowAnyOrigin()
.AllowAnyMethod()
.AllowAnyHeader()
.WithOrigins(devCliente));


app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();