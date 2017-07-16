using System;
using System.Text;

public class SonicHarvester : Harvester
{
    private int sonicFactor; // redundant??

    public SonicHarvester(string id, double oreOutput, double energyRequirement, int sonicFactor) 
        : base(id, oreOutput, energyRequirement)
    {
        this.EnergyRequirement /= sonicFactor;
    }

    public override string ToString()
    {
        var result = new StringBuilder();
        result.AppendLine($"Sonic Harvester - {this.Id}");
        result.AppendLine(base.ToString());

        return result.ToString().Trim();
    }
}

