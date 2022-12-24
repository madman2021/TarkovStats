using TarkovStats.Models;

namespace TarkovStats.Services.Validation.ViewModels;

public class MapInfo
{
    public Map Map { get; set; }
    public string DisplayName { get; set; }
    public string ThumbImg { get; set; }
    public Dictionary<string,MapTypeInfo> MapTypeInfos { get; set; }
}

public class MapTypeInfo
{
    public string DisplayName { get; set; }
    public string ImageUrl { get; set; }
}