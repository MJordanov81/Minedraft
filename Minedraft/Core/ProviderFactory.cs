using System;
using System.Collections.Generic;

public static class ProviderFactory
{
    public static Provider Get(string type, List<string> arguments)
    {
        Provider provider = null; 

        switch (type)
        {
            case "Pressure": provider = new PressureProvider(arguments[1], double.Parse(arguments[2]));
                break;
            case "Solar": provider = new PressureProvider(arguments[1], double.Parse(arguments[2]));
                break;
        }

        return provider;
    }
}

