namespace Sivas.Extension;

public static class HttpPostedFileBaseExtension
{
    public static byte[] ConvertToBytes(this HttpPostedFileBase image)
    {
        var reader = new BinaryReader(image.InputStream);
        var imageBytes = reader.ReadBytes(image.ContentLength);
        return imageBytes;
    }
}