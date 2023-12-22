using Microsoft.EntityFrameworkCore;
using StudyGuidance.AppLogic;
using StudyGuidance.Infrastructure;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder.WithOrigins("https://localhost:7063")
                          .AllowAnyHeader()
                          .AllowAnyMethod());
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<StudyGuidanceDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddScoped<IQuizRepository, QuizDbRepository>();
builder.Services.AddScoped<IJobRepository, JobDbRepository>();
builder.Services.AddScoped<IRecruiterRepository, RecruiterDbRepository>();
builder.Services.AddScoped<IStudyCourseRepository, StudyCourseRepository>();
builder.Services.AddScoped<ITestamonialRepository, TestamonialRepository>();
builder.Services.AddScoped<IQuestionModificationService, QuestionModificationService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("AllowSpecificOrigin");

app.MapControllers();

app.Run();
