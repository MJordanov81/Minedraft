using System;
using System.Text;

public abstract class Provider : Machine
{
    private string id;
    private double energyOutput;

    protected Provider(string id, double energyOutput):
        base (id)
    {
        this.EnergyOutput = energyOutput;
    }

    public string Id
    {
        get { return this.id; }
    }

    public double EnergyOutput
    {
        get { return this.energyOutput; }
        protected set
        {
            if (value < 0)
            {
                throw new ArgumentException($"Provider is not registered, because of it's {nameof(EnergyOutput)}");
            }
            else if (value > 10000)
            {
                throw new ArgumentException($"Provider is not registered, because of it's {nameof(EnergyOutput)}");
            }
            else
            {
                this.energyOutput = value;
            }
        }
    }

    public override string ToString()
    {
        var result = new StringBuilder();

        result.AppendLine($"Energy Output: {this.EnergyOutput}");

        return result.ToString().Trim();
    }
}

