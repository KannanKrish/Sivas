namespace Sivas.Models;

public static class ProductEnergyStarExtension
{
    public static string GetEnergyStar(this ProductEnergyStar energyStar) =>
        energyStar switch
        {
            ProductEnergyStar.Five => "FiveStar",
            ProductEnergyStar.Four => "FourStar",
            ProductEnergyStar.Three => "ThreeStar",
            ProductEnergyStar.Two => "TwoStar",
            ProductEnergyStar.One => "OneStar",
            ProductEnergyStar.None => string.Empty,
            _ => string.Empty
        };
}