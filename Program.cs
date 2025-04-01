using FastEndpoints;
using iSchool_Solution.Helper;
using iSchool_Solution.Repository;
using iSchool_Solution.Services;
using Microsoft.AspNetCore.HttpOverrides;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors();
builder.Services.ConfigureSqlContext(builder.Configuration);
builder.Services.AddMemoryCache();

// Repository registrations
builder.Services.AddScoped<EvaluationRepository>();
builder.Services.AddScoped<StudentRepository>();
builder.Services.AddScoped<CourseRepository>();
builder.Services.AddScoped<TranscriptRepository>();
builder.Services.AddScoped<CommunicationRepository>();
builder.Services.AddScoped<RegistrationRepository>();
builder.Services.AddScoped<FinanceRepository>(); 
builder.Services.AddScoped<ResearchRepository>();
builder.Services.AddScoped<LibraryRepository>();

// Service registrations
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<CourseService>();
builder.Services.AddScoped<CourseQueryService>();
builder.Services.AddScoped<EmailService>();
builder.Services.AddScoped<EnrollmentService>();
builder.Services.AddScoped<DashboardService>();
builder.Services.AddScoped<TranscriptService>();
builder.Services.AddScoped<StudentService>();
builder.Services.AddScoped<FinanceService>();
builder.Services.AddScoped<InvoiceService>(); 
builder.Services.AddScoped<PaystackService>();
builder.Services.AddScoped<ResearchService>();
builder.Services.AddScoped<LibraryService>();

builder.Services.ConfigureEmail(builder.Configuration);

builder.Services.ConfigureIdentity();
builder.Services.AddAuthentication(); 
builder.Services.ConfigureJwt(builder.Configuration);


builder.Services.AddControllers();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();


var app = builder.Build();

app.ConfigureExceptionHandler();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.MapOpenApi();
}
else
{
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.All
});
app.UseCors("CorsPolicy");

app.UseAuthentication();

app.UseAuthorization();

// Fast Endpoints
app.UseFastEndpoints();

//app.MapControllers();

app.Run();