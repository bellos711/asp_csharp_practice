using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
//new stuff
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using crudelicious.Models; //YOUR CLASS NAME AND THE CONTEXT IN THE MODELS YOU CREATED

namespace crudelicious
{
    public class Startup
    {
        
        public IConfiguration Configuration {get;}
        //new stuff
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }//end startup

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //new stuff
            services.AddDbContext<MyContext>(options => options.UseMySql(Configuration["DBInfo:ConnectionString"])); //From your models class context

            //usual stuff
            services.AddSession();
            services.AddMvc(options => options.EnableEndpointRouting = false);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //usual stuff
            app.UseSession();
            app.UseStaticFiles();
            app.UseMvc();
        }
    }
}
