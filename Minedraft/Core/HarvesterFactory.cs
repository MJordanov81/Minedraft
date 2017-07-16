using System;
using System.Collections.Generic;

public static class HarvesterFactory
{
    public static Harvester Get(string type, List<string> arguments)
    {
        Harvester harvester = null;

        switch (type)
        {
            case "Hammer": harvester = new HammerHarvester(arguments[1], double.Parse(arguments[2]), double.Parse(arguments[3]));
                break;
            case "Sonic": harvester = new SonicHarvester(arguments[1], double.Parse(arguments[2]), double.Parse(arguments[3]), int.Parse(arguments[4]));
                break;
        }

        return harvester;
    }
}

