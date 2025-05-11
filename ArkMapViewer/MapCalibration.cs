using System.Text.Json;

namespace ArkMapViewer;

public class MapCalibrations
{
    public Dictionary<string, MapCalibration> Calibrations { get; set; } = new();
    public MapCalibrations()
    {
        Calibrations = JsonSerializer.Deserialize<List<MapCalibration>>(File.ReadAllText("MapCalibrations.json"))?.ToDictionary(kv => kv.Filename, kv => kv) ?? new Dictionary<string, MapCalibration>();
    }
}

public class MapCalibration
{
    public string Filename { get; set; } = string.Empty;

    public double PixelOffsetX { get; set; }
    public double PixelOffsetY { get; set; }

    public double PixelScaleX { get; set; }
    public double PixelScaleY { get; set; }

    public double LatOffset { get; set; }
    public double LonOffset { get; set; }

    public double LatDivisor { get; set; }
    public double LonDivisor { get; set; }
}

