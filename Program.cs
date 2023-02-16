/*
Đối tượng Host (IHost) object:
1. Dependency Injection(ID) : IServiceProvider(ServiceCollection)
2. Logging (ILogging)
3. Configuration
4. IHostedService => StartAsync : Run -> Chạy HTTP Server(Kestrel Http)
khi Kestrel chạy thì nó nhận các yêu cầu Http từ Client gửi đến(Máy chủ chạy và lắng nghe cho đến khi kthuc ứng dụng)
*/

/*
B1: Tạo IHostBulider (từ đối tượng này sinh ra Host)
B2: Cấu hình , đăng kí các dịch vụ (gọi ConfigureWebHostDefaults)
B3: IHostBulder.Build() -> Tạo được Host (IHost)
B4: Host.Run(); gọi Run() là gọi StartAsync -> máy chủ Kestrel được chạy
*/

//request => pipeline(Middleware) => response
//chúng ta phải chỉ là cho Host biết pipeline ở đâu để chuyển các request đến đó -> webBuilder sẽ xác định vị trí pipeline

namespace hello_asp
{
    class Program
    {
        // public static void Main(string[] args) {
        //     IHostBuilder builder = Host.CreateDefaultBuilder(args);

        //     //chuẩn bị cấu hình để khởi tạo nên đối tượng Host có các dịch vụ (Dependency InJect, Logging, ...)
        //     builder.ConfigureWebHostDefaults(
        //         (IWebHostBuilder webBuilder) => {
        //             //tuỳ biến cấu hình

        //             //muốn đổi tên ko dùng wwwroot 
        //             webBuilder.UseWebRoot("public");

        //             //chỉ ra Class có pipeline để gửi request (pipeline trong Configure của MyStartup.cs)
        //             webBuilder.UseStartup<MyStartUp>();
        //         }
        //     );

        //     IHost host = builder.Build();

        //     host.Run();
        // }

        public static void Main(string[] args) {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(WebBuilder => 
                {
                    // WebBuilder.UseWebRoot("public");
                    WebBuilder.UseStartup<MyStartUp>();
                });
                

    }
}
