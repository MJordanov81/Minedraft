using System;
using System.Text;

public abstract class Harvester : Machine
{
    private string id;
    private double oreOutput;
    private double energyRequirement;

    protected  Harvester(string id, double oreOutput, double energyRequirement)
        :base(id)
    {
        this.OreOutput = oreOutput;
        this.EnergyRequirement = energyRequirement;
    }

    public string Id
    {
        get { return this.id; }
    }

    public double OreOutput
    {
        get
        {
            return this.oreOutput;
        }
        protected set
        {
            if (value < 0)
            {
                throw new ArgumentException($"Harvester is not registered, because of it's {nameof(OreOutput)}");
            }

            this.oreOutput = value;
        }
    }

    public double EnergyRequirement
    {
        get { return this.energyRequirement; }
        protected set
        {
            if (value < 0)
            {
                throw new ArgumentException($"Harvester is not registered, because of it's {nameof(EnergyRequirement)}");
            }
            else if (value > 20000)
            {
                throw new ArgumentException($"Harvester is not registered, because of it's {nameof(EnergyRequirement)}");
            }
            else
            {
                this.energyRequirement = value;
            }
        }
    }

    public override string ToString()
    {
        var result = new StringBuilder();

        result.AppendLine($"Ore Output: {this.OreOutput}");
        result.AppendLine($"Energy Requirement: {this.EnergyRequirement}");

        return result.ToString().Trim();
    }
}

