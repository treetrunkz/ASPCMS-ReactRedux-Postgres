using Microsoft.EntityFrameworkCore; // place this line at the beginning of file.

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<NoteDb>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();


record Note(int id)
{
    public string text { get; set; } = default!;
    public bool done { get; set; } = default!;
};

class NoteDb : DbContext
{
    public NoteDb(DbContextOptions<NoteDb> options) : base(options)
    {

    }
    public DbSet<Note> Notes => Set<Note>();
}