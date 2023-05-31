namespace Sivas.Extension;

public static class ProductEnergyStarExtension
{
    public static string GetEnergyStar(this ProductEnergyStar energyStar)
    {
        var productStar = "";
        productStar = energyStar switch
        {
            ProductEnergyStar.Five => "FiveStar",
            ProductEnergyStar.Four => "FourStar",
            ProductEnergyStar.Three => "ThreeStar",
            ProductEnergyStar.Two => "TwoStar",
            ProductEnergyStar.One => "OneStar",
            ProductEnergyStar.None => productStar,
            _ => productStar
        };

        return productStar;
    }
}