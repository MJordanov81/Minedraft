using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

public class DraftManager
{

    private List<Harvester> harvesters;
    private List<Provider> providers;
    private double totalStoredEnergy;
    private double totalMinedOre;
    private string mode;

    public DraftManager()
    {
        this.harvesters = new List<Harvester>();
        this.providers = new List<Provider>();
        this.mode = "Full";
    }

    public string RegisterHarvester(List<string> arguments)
    {
        try
        {
            var type = arguments[0];
            Harvester harvester = HarvesterFactory.Get(type, arguments.Skip(1).ToList());
            this.harvesters.Add(harvester);

            return $"Successfully registered {arguments[0]} Harvester - {arguments[1]}";
        }
        catch (Exception e)
        {
            return e.Message;
        }
    }

    public string RegisterProvider(List<string> arguments)
    {
        try
        {
            var type = arguments[0];
            Provider provider = ProviderFactory.Get(type, arguments.Skip(1).ToList());
            providers.Add(provider);

            return $"Successfully registered {arguments[0]} Provider - {arguments[1]}";
        }
        catch (Exception e)
        {
            return e.Message;
        }
    }

    public string Day()
    {
        double energyProvidedThisDay = 0;
        double oreMinedThisDay = 0;

        double totalEnergyRequirement;

        if (this.harvesters.Count == 0)
        {
            energyProvidedThisDay = providers.Sum(p => p.EnergyOutput);
            oreMinedThisDay = 0;

            this.totalStoredEnergy += energyProvidedThisDay;
        }
        else
        {
            switch (this.mode)
            {
                case "Full":
                    energyProvidedThisDay = providers.Sum(p => p.EnergyOutput);
                    totalEnergyRequirement = harvesters.Sum(h => h.EnergyRequirement);

                    if (energyProvidedThisDay + this.totalStoredEnergy >= totalEnergyRequirement)
                    {
                        oreMinedThisDay = harvesters.Sum(h => h.OreOutput);

                        this.totalStoredEnergy += energyProvidedThisDay - totalEnergyRequirement;
                        this.totalMinedOre += oreMinedThisDay;
                    }
                    else
                    {
                        this.totalStoredEnergy += energyProvidedThisDay;
                    }

                    break;

                case "Half":
                    energyProvidedThisDay = providers.Sum(p => p.EnergyOutput);
                    totalEnergyRequirement = harvesters.Sum(h => h.EnergyRequirement * 60 / 100);

                    if (energyProvidedThisDay + this.totalStoredEnergy >= totalEnergyRequirement)
                    {
                        oreMinedThisDay = harvesters.Sum(h => h.OreOutput * 50 / 100);

                        this.totalStoredEnergy += energyProvidedThisDay - totalEnergyRequirement;
                        this.totalMinedOre += oreMinedThisDay;
                    }
                    else
                    {
                        this.totalStoredEnergy += energyProvidedThisDay;
                    }
                    break;

                default:
                    energyProvidedThisDay = providers.Sum(p => p.EnergyOutput);
                    this.totalStoredEnergy += energyProvidedThisDay;
                    break;
            }
        }

        var result = new StringBuilder();

        result.AppendLine($"A day has passed.");
        result.AppendLine($"Energy Provided: {energyProvidedThisDay}");
        result.AppendLine($"Plumbus Ore Mined: {oreMinedThisDay}");

        return result.ToString().Trim();
    }

    public string Mode(List<string> arguments)
    {
        /*        if (this.mode != arguments[0])
                {*/
        this.mode = arguments[0];

        return $"Successfully changed working mode to {arguments[0]} Mode";  // to check if changing to the same value would require message
                                                                             /*        }
                                                                                     return "";*/
    }

    public string Check(List<string> arguments)
    {
        var thisId = arguments[0];

        foreach (var harvester in this.harvesters)
        {
            if (harvester.Id == thisId)
            {
                return harvester.ToString();
            }
        }

        foreach (var provider in this.providers)
        {
            if (provider.Id == thisId)
            {
                return provider.ToString();
            }
        }

        return $"No element found with id - {thisId}";
    }

    public string ShutDown()
    {

        var result = new StringBuilder();

        result.AppendLine($"System Shutdown");
        result.AppendLine($"Total Energy Stored: {this.totalStoredEnergy}");
        result.AppendLine($"Total Mined Plumbus Ore: {this.totalMinedOre}");

        return result.ToString().Trim();
    }
}

