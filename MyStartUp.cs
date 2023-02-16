using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

public class MyStartUp {
    //pthuc dùng để đăng kí các dịch vụ (Dependency Injection)
    public void ConfigureServices(IServiceCollection services) {
        // services.AddSingleton
    }

    //dùng để xây dựng chuỗi pipeline(Middleware) mà request đi qua 
    public async void Configure(IApplicationBuilder app, IWebHostEnvironment env) {

        //thiết lậP cho phép thiết lập file tĩnh mà lưu trong thư mục mặc định wwwroot
        //khi ta truy cập địa chỉ nào đó VD:http://localhost:5176/1.txt , nếu file đó có trong wwwroot thì trả về nội dung của file đó và request sẽ ko được đi tiếp trên pipeline
        //StaticFileMiddleware
        app.UseStaticFiles();

       //EndpointMiddleware - khi request đi qua middleware này thì nó sẽ phân tích địa chỉ truy cập và điều hướng request đó đi theo 1 luồng đến 1 EndPonit nhất định 
       //Các EndPoint định nghĩa trong phương thức UseEndPoints
        app.UseRouting();

        app.UseEndpoints(endponit => {
            //nếu truy cập Get đến địa chỉ home thì điểm cuối EndPonit được thi hành
            endponit.MapGet("/", async(context) => {
                await context.Response.WriteAsync("Trang chu");
            });

            endponit.MapGet("/about", async(context) => {
                await context.Response.WriteAsync("Trang gioi thieu");
            });

            endponit.MapGet("/contact", async(context) => {
                await context.Response.WriteAsync("Trang ket noi");
            });

            endponit.MapGet("/content", async(context) => {
                await context.Response.WriteAsync("Trang noi dung");
            });
        });

        //terminate middleware
        //pathMatch - là địa chỉ để truy vấn, nếu địa chỉ truy vấn phù hợp thì sẽ được chạy
        app.Map("/abc", app1 => {
            app1.Run(async (context) => {
                await context.Response.WriteAsync("noi dung tra ve tu abc");
            });
        });

        //StatusCodePages - là middleware cuối cùng trong pipeline
        app.UseStatusCodePages();
       

        //terminate middleware
        // app.Run(async(HttpContext context) => {
        //     //pthuc Response sẽ trả về client và WriteAsync để viết nội dung trả về cho Client
        //     await context.Response.WriteAsync("Xin chao day la MyStartUp");
        // });
    }
}