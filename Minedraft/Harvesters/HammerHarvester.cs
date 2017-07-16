using System;
using System.Text;

public class HammerHarvester : Harvester
{
    public HammerHarvester(string id, double oreOutput, double energyRequirement) 
        : base(id, oreOutput, energyRequirement)
    {
        this.OreOutput *= 3;
        this.EnergyRequirement *= 2;
    }

    public override string ToString()
    {
        var result = new StringBuilder();
        result.AppendLine($"Hammer Harvester - {this.Id}");
        result.AppendLine(base.ToString());

        return result.ToString().Trim();
    }
}

