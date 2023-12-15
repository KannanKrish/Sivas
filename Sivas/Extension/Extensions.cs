namespace Sivas.Extension;

public static class Extensions
{
    public static async Task<byte[]> ConvertToBytes(this IFormFile image)
    {
        using var target = new MemoryStream();
        await image.CopyToAsync(target);
        return target.ToArray();
    }

    public static IHtmlContent HtmlRaw(this IHtmlHelper _, string source) => new HtmlString(source);
}