using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var orders = new List<Order>();
// var jobs = new List<Job>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/", () =>
{
    return orders;
});

app.MapPost("/", (CreateEmployer body) =>
{
    if (orders.Count == 0)
    {
        orders.Add(new Order()
        {
        
            Id = orders.Count,
            Customer = body.Customer,
            Executor = body.Executor,
            Phone = body.Phone,
            Job = body.Job
        });
    }
    else {
        orders.Add(new Order()
    {
        
        Id = orders.Last().Id + 1,
        Customer = body.Customer,
        Executor = body.Executor,
        Phone = body.Phone,
        Job = body.Job
    });
        
    }
    return "Ok!";
});

app.MapPost("/{id:int}/remove", (int id) =>
{
    var order = orders.First(e => e.Id == id);
    orders.Remove(order);
    return "Ok!";
});


/* app.MapPost("/works", (CreateWork body) =>


{
    if (jobs.Count == 0)
    {
        jobs.Add(new Work()
        {
        
            Id = jobs.Count,
            
            Job = body.Job,
            Price = body.Price,
            Phone = body.Phone
        });
    }
    else {
        jobs.Add(new Work()
        {
            Id = jobs.Last().Id + 1,
            Job = body.Job,
            Price = body.Price,
            Phone = body.Phone
        });
        
    }
    return "Ok!";
});

*/
app.UseStaticFiles();

app.Run();

public class Order
{
    public int Id { get; set; } 
    public string Customer { get; set; } // заказчик
    public string Executor { get; set; } // исполнитель
    public string Phone { get; set; } // номер телефона
    public string Job { get; set; } // какая работа
}

public class Work
{
    public int Id { get; set; }
    public string Executor { get; set; } // исполнитель
    public string Job { get; set; } // какая работа
    public string Price { get; set; } // стоимость
    public string Phone { get; set; } // номер телефона
    
}


public class CreateWork
{
    public string Executor { get; set; } // исполнитель
    public string Job { get; set; } // какая работа
    public string Price { get; set; } // стоимость
    public string Phone { get; set; } // номер телефона
}
public class CreateEmployer
{
    public string Customer { get; set; } 
    public string Executor { get; set; }
    public string Phone { get; set; }
    public string Job { get; set; }
}