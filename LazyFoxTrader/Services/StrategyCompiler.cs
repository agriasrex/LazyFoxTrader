using LazyFoxTrader.Models;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;

namespace LazyFoxTrader.Services;

public class StrategyCompiler
{
    public StrategyCompileResult Compile(string code)
    {
        try
        {
            CSharpScript.Create(code,
                ScriptOptions.Default
                    .AddImports("System", "System.Linq", "LazyFoxTrader.Models"));

            return new StrategyCompileResult { Success = true };
        }
        catch (Exception ex)
        {
            return new StrategyCompileResult
            {
                Success = false,
                Errors = { ex.Message }
            };
        }
    }
}
