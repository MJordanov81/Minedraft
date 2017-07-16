using System;
using System.Text;

public class SolarProvider : Provider
{
    public SolarProvider(string id, double energyOutput) 
        : base(id, energyOutput)
    {
    }
    public override string ToString()
    {
        var result = new StringBuilder();

        result.AppendLine($"Solar Provider - {this.Id}");
        result.AppendLine(base.ToString());

        return result.ToString().Trim();
    }
}

