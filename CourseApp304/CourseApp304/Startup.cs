using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CourseApp304.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Configuration;
using CourseApp304.Data.Abstract;
using CourseApp304.Data.Concrete;
using CourseApp304.Data.Abstact;

namespace CourseApp304
{
    public class Startup
    {
        public IConfiguration Configuration;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)  //Dependency Injection
        {
            services.AddMvc();  // Projeye MVC olarak kullanacağımı deklare ediyorum.

            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DataConnection"));
                options.EnableSensitiveDataLogging(true);
            });

            services.AddDbContext<UserContext>(context =>
            {
                context.UseSqlServer(Configuration.GetConnectionString("UserConnection"));
            });

            services.AddTransient<ICourseRepository, EfCourseRepository>();
            services.AddTransient<IInstructorRepository, EfInstructorRepository>();
            services.AddTransient<IUserRepository,UserRepository>();
            services.AddTransient<IGenericRepository<Contact>, GenericRepository<Contact>>();
            services.AddTransient<IGenericRepository<Address>, GenericRepository<Address>>();
            services.AddTransient<IGenericRepository<Student>, GenericRepository<Student>>();
            services.AddTransient<IStudentRepository, EfStudentRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,DataContext dataContext, UserContext userContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                SeedDatabase.Seed(dataContext);
                SeedDatabase.Seed(userContext);
            }


            // Bir hata oluştuğunda kullanıcı da bu hatayı görsün.
            app.UseDeveloperExceptionPage();


            // Hata sayfalarını görmemize yarıyor. (404, 502, ...gibi)
            app.UseStatusCodePages();


            // wwwroot ==> Tarayıcı tarafından ulaşılması gereken CSS, js ve image gibi dosyaslı toplu halde barındıran ve core yapısının dışarı açılan kapısıdır.

            // Sisteme bunu tanıtmak için aşağıdaki kod satırını yazıyoruz.
            app.UseStaticFiles();

            //
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"node_modules")),
                RequestPath = new PathString("/vendor")
            });



            //Route kullanımı için bunu yamamız gerekiyor
            app.UseMvcWithDefaultRoute();



            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute(
            //        name: "default",
            //        template: "{controller=Home}/{action=Index}");
            //});
            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});
        }
    }
}
