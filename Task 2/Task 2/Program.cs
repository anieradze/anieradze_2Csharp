using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Linq;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<TaskItem> taskItems = new()
{
    new TaskItem(1, "Complete Assignment", "Important", new DateTime(2024, 9, 30)),
    new TaskItem(2, "Grocery Shopping", "Chore", new DateTime(2024, 10, 2)),
    new TaskItem(3, "Finish Project", "Work", new DateTime(2024, 10, 5)),
};

app.MapGet("/tasks", () => Results.Ok(taskItems));

// Like the way to ensure data type
app.MapGet("/task/{id:int}", (int id) =>
{
    var task = taskItems.SingleOrDefault(t => t.Id == id);
    return task is not null ? Results.Ok(task) : Results.NotFound($"Task with ID {id} not found");
});


app.Run();

public record TaskItem(int Id, string Title, string Category, DateTime DueDate);
