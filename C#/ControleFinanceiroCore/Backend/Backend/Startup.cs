using System.IO.Compression;
using System.Text;
using Backend.Models;
using Backend.Repository;
using Backend.Repository.Context;
using Backend.Repository.Contract;
using Backend.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;

namespace Backend {
    public class Startup {
        public Startup (IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices (IServiceCollection services) {

            var ConnectionString = Configuration.GetConnectionString ("ConnetionStringDev");
            services.AddDbContext<DataBaseContext> (option => option.UseNpgsql (ConnectionString));

            //Configura o modo de compressão
            services.Configure<GzipCompressionProviderOptions>(
                options => options.Level = CompressionLevel.Optimal);
            services.AddResponseCompression(options =>
            {
                options.Providers.Add<GzipCompressionProvider>();
                options.EnableForHttps = true;
            });

            services.AddCors ();
            services.AddControllers ();

            services.AddScoped(typeof(IUsuarioRepository<Usuario>), typeof (UsuarioRepository));
            services.AddScoped(typeof(IContaReceitaRepository<ContaReceita>), typeof(ContaReceitaRepository));
            services.AddScoped(typeof(IContaDespesaRepository<ContaDespesa>), typeof(ContaDespesaRepository));
            services.AddScoped(typeof(ISituacaoLancamentoReceitaRepository<SituacaoLancamentoReceita>), typeof(SituacaoLancamentoReceitaRepository));
            services.AddScoped(typeof(ISituacaoLancamentoDespesaRepository<SituacaoLancamentoDespesa>), typeof(SituacaoLancamentoDespesaRepository));
            services.AddScoped(typeof(ILancamentoDespesaRepository<LancamentosDespesa>), typeof(LancamentoDespesaRepository));
            services.AddScoped(typeof(ILancamentoReceitaRepository<LancamentosReceita>), typeof(LancamentoReceitaRepository));
            services.AddScoped(typeof(IPagamentoDespesaRepository<PagamentoDespesa>), typeof(PagamentoDespesaRepository));
            services.AddScoped(typeof(IParecelaDepesaRepository<ParcelaDespesa>), typeof(ParcelaDespesaRepository));


            var key = Encoding.ASCII.GetBytes (Configurations.GetKeyToken());

            services.AddAuthentication (x => {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer (x => {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey (key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services.AddMvc ().SetCompatibilityVersion (CompatibilityVersion.Version_3_0);

            services.AddApiVersioning (options => {
                options.DefaultApiVersion = new ApiVersion (1, 0);
                options.ReportApiVersions = true;
                options.AssumeDefaultVersionWhenUnspecified = true;
            });

            services.AddVersionedApiExplorer (options => {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure (IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment ()) {
                app.UseDeveloperExceptionPage ();
            }

            app.UseHttpsRedirection ();

            app.UseRouting ();

            app.UseCors (x => x
                .AllowAnyOrigin ()
                .AllowAnyMethod ()
                .AllowAnyHeader ());

            app.UseAuthentication ();
            app.UseAuthorization ();

            app.UseEndpoints (endpoints => {
                endpoints.MapControllers ();
            });
        }
    }
}
