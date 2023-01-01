using TarkovStats.Models;
using TarkovStats.Services.Validation.ViewModels;

namespace TarkovStats;

public static class MapCollection
{
    public static readonly Dictionary<Map, MapInfo> Maps = new()
    {
        {
            Map.Customs, new MapInfo()
            {
                DisplayName = "Customs",
                ThumbImg = "/img/map_thumb/customs.jpg",
                Map = Map.Customs,
                MapTypeInfos = new()
                {
                    {
                        "flat", new MapTypeInfo()
                        {
                            DisplayName = "Flat",
                            ImageUrl = "/img/maps/Customs.png"
                        }
                    },
                    {
                        "3d", new MapTypeInfo()
                        {
                            DisplayName = "3D",
                            ImageUrl = "/img/maps/customs-3d.jpg"
                        }
                    }
                }
            }
        },
        {
            Map.Woods, new MapInfo()
            {
                DisplayName = "Woods",
                ThumbImg = "/img/map_thumb/woods.jpg",
                Map = Map.Woods,
                MapTypeInfos = new()
                {
                    {
                        "flat", new MapTypeInfo()
                        {
                            DisplayName = "Flat",
                            ImageUrl = "/img/maps/Woods.png"
                        }
                    }
                }
            }
        },
        {
            Map.Factory, new MapInfo()
            {
                DisplayName = "Factory",
                ThumbImg = "/img/map_thumb/factory.jpg",
                Map = Map.Factory,
                MapTypeInfos = new()
                {
                }
            }
        },
        {
            Map.Interchange, new MapInfo()
            {
                DisplayName = "Interchange",
                ThumbImg = "/img/map_thumb/interchange.jpg",
                Map = Map.Woods,
                MapTypeInfos = new()
                {
                    {
                        "Flat", new MapTypeInfo()
                        {
                            DisplayName = "Flat",
                            ImageUrl = "/img/maps/Interchange.webp"
                        }
                    }
                }
            }
        },
        {
            Map.Reserve, new MapInfo()
            {
                DisplayName = "Reserve",
                ThumbImg = "/img/map_thumb/reserve.jpg",
                Map = Map.Reserve,
                MapTypeInfos = new()
                {
                    {
                        "3D", new MapTypeInfo()
                        {
                            DisplayName = "3D",
                            ImageUrl = "/img/maps/reserve.png"
                        }
                    },
                    {
                        "Flat", new MapTypeInfo()
                        {
                            DisplayName = "Flat",
                            ImageUrl = "/img/maps/new_reserve.png"
                        }
                    }
                }
            }
        },
        {
            Map.Shoreline, new MapInfo()
            {
                DisplayName = "Shoreline",
                ThumbImg = "/img/map_thumb/shoreline.jpg",
                Map = Map.Woods,
                MapTypeInfos = new()
                {
                    {
                        "flat", new MapTypeInfo()
                        {
                            DisplayName = "Flat",
                            ImageUrl = "/img/maps/Shoreline.webp"
                        }
                    }
                }
            }
        },
        {
            Map.Labs, new MapInfo()
            {
                DisplayName = "The LAB",
                ThumbImg = "/img/map_thumb/labs.jpg",
                Map = Map.Woods,
                MapTypeInfos = new()
                {
                }
            }
        },
        {
            Map.Lighthouse, new MapInfo()
            {
                DisplayName = "Lighthouse",
                ThumbImg = "/img/map_thumb/lighthouse.jpg",
                Map = Map.Woods,
                MapTypeInfos = new()
                {
                }
            }
        },
        {
            Map.Streets, new MapInfo()
            {
                DisplayName = "Streets",
                ThumbImg = "/img/map_thumb/streets.webp",
                Map = Map.Streets,
                MapTypeInfos = new()
                {
                    {
                        "flat", new MapTypeInfo()
                        {
                            DisplayName = "Flat",
                            ImageUrl = "/img/maps/streets_flat.webp"
                        }
                    }
                }
            }
        }
    };
}