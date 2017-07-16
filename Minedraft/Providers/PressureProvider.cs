using System;
using System.Text;

public class PressureProvider : Provider
{
    public PressureProvider(string id, double energyOutput) 
        : base(id, energyOutput)
    {
        this.EnergyOutput += energyOutput * 50 / 100;
    }

    public override string ToString()
    {
        var result = new StringBuilder();

        result.AppendLine($"Pressure Provider - {this.Id}");
        result.AppendLine(base.ToString());

        return result.ToString().Trim();
    }
}

