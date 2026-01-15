using ClickHouse.Client.ADO;
using LazyFoxTrader.Models;

namespace LazyFoxTrader.Services;

public class ClickHouseService
{
    private readonly string _connectionString;

    public ClickHouseService(IConfiguration config)
    {
        _connectionString = config.GetConnectionString("ClickHouse")!;
    }

    public ClickHouseConnection Open()
    {
        var conn = new ClickHouseConnection(_connectionString);
        conn.Open();
        return conn;
    }

    public async Task BulkInsertTradesAsync(IEnumerable<Trade> trades)
    {
        using var conn = Open();
        using var bulk = conn.CreateBulkCopy("Trades");

        await bulk.WriteToServerAsync(trades);
    }

    public IEnumerable<Trade> GetTrades(string symbol)
    {
        using var conn = Open();
        using var cmd = conn.CreateCommand();

        cmd.CommandText = $"SELECT * FROM Trades WHERE Symbol = '{symbol}' ORDER BY Timestamp";
        using var reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            yield return new Trade
            {
                Timestamp = reader.GetDateTime(0),
                Open = reader.GetDecimal(1),
                High = reader.GetDecimal(2),
                Low = reader.GetDecimal(3),
                Close = reader.GetDecimal(4),
                Volume = reader.GetInt64(5),
                TradeCount = reader.GetInt64(6),
                VolumeWeightedPrice = reader.GetDecimal(7)
            };
        }
    }
}
