using LazyFoxTrader.Models;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;

namespace LazyFoxTrader.Services;

public class AlpacaService
{
    private readonly HttpClient _http;
    private readonly ClickHouseService _clickhouse;
    private readonly IConfiguration _config;

    public AlpacaService(ClickHouseService clickhouse, IConfiguration config)
    {
        _clickhouse = clickhouse;
        _config = config;

        _http = new HttpClient();
        _http.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

        _http.DefaultRequestHeaders.Add("APCA-API-KEY-ID", _config["Alpaca:AccountKey"]);
        _http.DefaultRequestHeaders.Add("APCA-API-SECRET-KEY", _config["Alpaca:AccountSecret"]);
    }

    public async Task LoadSymbolsAndTradesAsync(string timeframe, int limit)
    {
        var symbolsJson = await _http.GetStringAsync(
            "https://paper-api.alpaca.markets/v2/assets?status=active&asset_class=us_equity");

        var symbols = JArray.Parse(symbolsJson);

        foreach (var s in symbols)
        {
            var ticker = s["symbol"]!.ToString();
            await LoadTradesForSymbol(ticker, timeframe, limit);
        }
    }

    private async Task LoadTradesForSymbol(string symbol, string timeframe, int limit)
    {
        var url =
            $"https://data.alpaca.markets/v2/stocks/bars?symbols={symbol}&timeframe={timeframe}&limit={limit}&feed=iex";

        var json = await _http.GetStringAsync(url);
        var bars = JObject.Parse(json)["bars"]![symbol]!;

        var trades = bars.Select(b => new Trade
        {
            Timestamp = DateTime.Parse(b["t"]!.ToString()),
            Open = b["o"]!.Value<decimal>(),
            High = b["h"]!.Value<decimal>(),
            Low = b["l"]!.Value<decimal>(),
            Close = b["c"]!.Value<decimal>(),
            Volume = b["v"]!.Value<long>(),
            TradeCount = b["n"]!.Value<long>(),
            VolumeWeightedPrice = b["vw"]!.Value<decimal>()
        });

        await _clickhouse.BulkInsertTradesAsync(trades);
    }
}
