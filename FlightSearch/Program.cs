var builder = WebApplication.CreateBuilder(args);

builder.Logging.AddConsole();

builder.Services.AddHttpClient();

builder.Services.AddControllers().AddNewtonsoftJson();

builder.Services.AddCors(options =>
{
  options.AddPolicy("AllowAll",
      policy =>
      {
        policy.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
      });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
  app.UseDeveloperExceptionPage();
}

app.UseCors("AllowAll");

app.MapControllers();

app.Run();