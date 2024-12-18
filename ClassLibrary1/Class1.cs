using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
public class StockPrice
{
    public int Id { get; set; }
    public string Ticker { get; set; }
    public double Price { get; set; }
    public DateTime Date { get; set; }
}

public class TodaysCondition
{
    public int Id { get; set; }
    public string Ticker { get; set; }
    public string Condition { get; set; }
}

public class StockContext : DbContext
{
    public DbSet<StockPrice> StockPrices { get; set; }
    public DbSet<TodaysCondition> TodaysConditions { get; set; }

    public StockContext() => Database.EnsureCreated();

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite("Data Source=C:/Users/nikav/source/repos/lab11sem3/ClassLibrary1/bin/Debug/net8.0/stockdata.db");
}