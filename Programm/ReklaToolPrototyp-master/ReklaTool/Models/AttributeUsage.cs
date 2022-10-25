namespace ReklaTool.Models;

[AttributeUsage(AttributeTargets.Property)]
public class PositionKategorieAttribute : Attribute
{
    public string KategorieName { get; }

    public PositionKategorieAttribute(string kategorieName)
    {
        KategorieName = kategorieName;
    }
}