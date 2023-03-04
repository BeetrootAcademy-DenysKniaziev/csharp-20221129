using Lesson35.HomeWork.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDbContext>();
builder.Services.Configure<ApiBehaviorOptions>(options => options.SuppressInferBindingSourcesForParameters = true);
builder.Services.AddSwaggerGen();
builder.Services.AddMvc(options =>
{
    options.Filters.Add(new FileLoggingFilter("log.txt"));
});


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseSwagger();
app.UseSwaggerUI();
app.UseMiddleware<ExceptionMiddleware>();
app.UseMiddleware<CheckTokenMiddleware>(new List<string>()
{   "abrikos",
    "ananas",
    "kapusta"
});

app.Run();
