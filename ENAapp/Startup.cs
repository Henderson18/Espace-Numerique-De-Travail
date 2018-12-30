using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ENAapp.Models;
using ENAapp.Models.Repositories;
using ENAapp.Models.Repositories.Implementations;
using ENAapp.Models.services;
using ENAapp.Repositories;
using ENAapp.Repositories.implementtation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace ENAapp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddSession();
            services.AddCors(options =>
            {
                
                options.AddPolicy("AllowSpecificOrigin", builder => builder
                .AllowAnyHeader()
                .WithOrigins("http://localhost:4200")
                .AllowAnyMethod()
                .AllowCredentials());
            });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            // services.AddMysql()
            services.AddDbContext<bd_entContext>(options =>
            options.UseMySql("server=localhost; port=3306; database=bd_ent; user=root; password=david"));
            services.AddTransient<IEtudiantRepository, EtudiantRepository>();
            services.AddTransient<IClasseRepository, ClasseRepository>();
            services.AddTransient<IFiliereRepository, FiliereRepository>();
            services.AddTransient<IGradeRepository, GradeRepository>();
            services.AddTransient<IInscritRepository, InscritRepository>();
            services.AddTransient<IMentionRepository, MentionRepository>();
            services.AddTransient<IMoyenneRepository, MoyenneRepository>();
            services.AddTransient<INationaliteRepository, NationaliteRepository>();
            services.AddTransient<INoteRepository, NoteRepository>();
            services.AddTransient<INotificationRepository, NotificationRepository>();
            services.AddTransient<IProgrammeRepository, ProgrammeRepository>();
            services.AddTransient<IResultatRepository, ResultatRepository>();
            services.AddTransient<ISemestreRepository, SemestreRepository>();
            services.AddTransient<IEvaluationRepository, EvaluationRepository>();
            services.AddTransient<ISpecialiteRepository, SpecialiteRepository>();
            services.AddTransient<ICourRepository, CourRepository>();
            services.AddTransient<ICompteRepository, CompteRepository>();
            services.AddSingleton<IEmailSender, EmailSender>();
            services.AddTransient<IOuvrageRepository, OuvrageRepository>();
            services.AddTransient<ICategorieRepository, CategorieRepository>();
            services.AddTransient<IEmpruntRepository, EmpruntRepository>();
            services.AddTransient<ICommentaireRepository, CommentaireRepository>();
            services.AddTransient<IEnseignantRepository, EnseignantRepository>();
            services.AddTransient<ITimeRepository, TimeRepository>();
            services.AddTransient<IVueRepository, VueRepository>();
            services.AddTransient<ISalleRepository, SalleRepository>();
            services.AddTransient<IJourRepository, JourRepository>();
            services.AddTransient<IClasseRepository, ClasseRepository>();
            services.AddTransient<IPeriodeRepository, PeriodeRepository>();
            services.AddTransient<ITimeService, TimeService>();
            services.AddSingleton<IEmailSender, EmailSender>();
            services.AddTransient<ITimeService, TimeService>();
            services.AddSingleton<IFileService,FileRepository>();
            //services.AddTransient<IRepository,Repository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseCors("AllowSpecificOrigin");

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseSession();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
