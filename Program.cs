using System;

public class GlobalNavigation
{
    public static double MesafeyiHesapla(double lat1, double lon1, double lat2, double lon2)
    {
        double r = 6371; // Dünya'nın yarıçapı (kilometre)
        double dLat = ToRadians(lat2 - lat1);
        double dLon = ToRadians(lon2 - lon1);
        double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                   Math.Cos(ToRadians(lat1)) * Math.Cos(ToRadians(lat2)) *
                   Math.Sin(dLon / 2) * Math.Sin(dLon / 2);
        double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
        double mesafe = r * c;
        return mesafe;
    }

    public static double YönüHesapla(double lat1, double lon1, double lat2, double lon2)
    {
        double dLon = ToRadians(lon2 - lon1);
        double y = Math.Sin(dLon) * Math.Cos(ToRadians(lat2));
        double x = Math.Cos(ToRadians(lat1)) * Math.Sin(ToRadians(lat2)) -
                   Math.Sin(ToRadians(lat1)) * Math.Cos(ToRadians(lat2)) * Math.Cos(dLon);
        double yön = ToDegrees(Math.Atan2(y, x));
        return (yön + 360) % 360;
    }

    private static double ToRadians(double dereceler)
    {
        return dereceler * Math.PI / 180;
    }

    private static double ToDegrees(double radyanlar)
    {
        return radyanlar * 180 / Math.PI;
    }
}

public class Program
{
public static void Main(string[] args)
    {
        // Örnek kullanım
        double baslangicEnlem = 40.7128; // Başlangıç noktasının enlemi (latitude)
        double baslangicBoylam = -74.0060; // Başlangıç noktasının boylamı (longitude)
        double hedefEnlem = 34.0522; // Hedef noktasının enlemi (latitude)
        double hedefBoylam = -118.2437; // Hedef noktasının boylamı (longitude)

        double mesafe = GlobalNavigation.MesafeyiHesapla(baslangicEnlem, baslangicBoylam, hedefEnlem, hedefBoylam);
        double yön = GlobalNavigation.YönüHesapla(baslangicEnlem, baslangicBoylam, hedefEnlem, hedefBoylam);

        Console.WriteLine("Mesafe: " + mesafe.ToString("N2") + " km");
        Console.WriteLine("Yön: " + yön.ToString("N2") + " derece");
        Console.WriteLine("Bu örnek kodda, CalculateDistance metodu yerine MesafeyiHesapla metodu kullanılarak" +
            " iki nokta arasındaki mesafe hesaplanmaktadır. " +
            "CalculateBearing metodu ise YönüHesapla olarak değiştirilmiştir. " +
            "Kodu kendi projenize ekleyerek başlangıç ve hedef noktaları değiştirerek " +
            "farklı küresel navigasyon hesaplamaları yapabilirsiniz.");
    }

public class ShadowCoordinates
{
    public static void CalculateCoordinates(double latitude, double longitude, double shadowLength, double sunAngle)
    {
        double objectHeight = shadowLength * Math.Tan(ToRadians(sunAngle));
        double objectLatitude = latitude + ToDegrees(objectHeight / 111.32);
        double objectLongitude = longitude;

        Console.WriteLine("Nesnenin Koordinatları:");
        Console.WriteLine("Enlem: " + objectLatitude.ToString("N6"));
        Console.WriteLine("Boylam: " + objectLongitude.ToString("N6"));


            Console.WriteLine("Bu örnek kodda, KoordinatlariHesapla metodu, " +
                "verilen enlem, boylam, gölge boyutu ve zaman bilgisini kullanarak " +
                "nesnenin yeni küresel koordinatlarını hesaplar. " +
                "GununGunesAciSiniHesapla metodu, verilen zaman bilgisine göre güneş açısını hesaplar." +
                "\r\n\r\nÖrnek kullanımda, enlem, boylam, gölge boyutu ve zaman değerleri verilmiştir. " +
                "KoordinatlariHesapla metodu bu değerleri kullanarak nesnenin yeni küresel koordinatlarını hesaplar ve ekrana yazdırır." +
                "\r\n\r\nBu kodu kendi projenize ekleyebilir ve farklı gölge boyutları ve zamanlar " +
                "kullanarak nesnenin küresel koordinatlarını hesaplayabilirsiniz.");
    }

    private static double ToRadians(double degrees)
    {
        return degrees * Math.PI / 180;
    }

    private static double ToDegrees(double radians)
    {
        return radians * 180 / Math.PI;
    }
}

public class ProgramGolge
{
    public static void Main(string[] args)
    {
        // Örnek kullanım
        double latitude = 40.7128; // Enlem (latitude)
        double longitude = -74.0060; // Boylam (longitude)
        double shadowLength = 10.0; // Gölge boyutu (metre)
        double sunAngle = 45.0; // Güneş açısı (derece)

        ShadowCoordinates.CalculateCoordinates(latitude, longitude, shadowLength, sunAngle);
    }
}



}
