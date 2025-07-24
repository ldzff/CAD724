using System;
using System.IO;
using System.Text.Json;
using RobTeach.Models;
using RobTeach.Services;

public class Program
{
    public static void Main()
    {
        var config = new Configuration { ProductName = "TestProduct" };
        var options = new JsonSerializerOptions { WriteIndented = true };
        options.Converters.Add(new DxfPointJsonConverter());
        options.Converters.Add(new DxfVectorJsonConverter());
        options.Converters.Add(new TrajectoryJsonConverter());
        string json = JsonSerializer.Serialize(config, options);
        // Manually set version to 0 for testing migration
        json = json.Replace("\"Version\": 1,", "\"Version\": 0,");
        File.WriteAllText("test_config_v0.json", json);
        Console.WriteLine("test_config_v0.json created.");
    }
}
