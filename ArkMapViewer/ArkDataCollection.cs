using System.Text.Json;

namespace ArkMapViewer;

public class ArkDataCollection
{
    public List<DataEntry> items { get; set; } = new();
    public List<DataEntry> creatures { get; set; } = new();
    public List<DataEntry> structures { get; set; } = new();
}



public class DataEntry
{
    public string package { get; set; } = string.Empty;
    public string blueprint { get; set; } = string.Empty;
    public string _class { get; set; } = string.Empty;
    public string name { get; set; } = string.Empty;
}

