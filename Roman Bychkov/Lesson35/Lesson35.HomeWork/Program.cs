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
app.UseMiddleware<CheckTokenMiddleware>(new List<Guid>()
{  
    Guid.Parse("49c1c358-a0f1-44cd-8fa2-b9a496527bff"),
    Guid.Parse("69e07543-5d2d-4dd8-8cea-91dae294630b"),
    Guid.Parse("32d8f66f-2f55-430f-b86a-d3cd713f9fe7")
});

app.Run();
