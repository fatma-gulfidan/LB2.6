using System;

class EmailPruefer
{
    public static string EmailPruefen(string email)
    {
        // "@" karakterinin varlığını kontrol et
        if (!email.Contains("@"))
        {
            return "Es gibt kein @ Zeichen! (namedomain.com)";
        }

        string[] teile = email.Split('@');
        if (teile.Length != 2 || string.IsNullOrEmpty(teile[0]))
        {
            return "Empfänger fehlt! (@domain.com)";
        }

        if (!teile[1].Contains("."))
        {
            return "Domain fehlt! (vorname.name@)";
        }

        string[] domainTeile = teile[1].Split('.');
        
        // Eğer domain parçasının yeterli kısmı yoksa
        if (domainTeile.Length < 2 || string.IsNullOrEmpty(domainTeile[0]) || string.IsNullOrEmpty(domainTeile[1]))
        {
            return "Domain nicht korrekt (vorname.name@domain)";
        }

        // Ek olarak, e-posta adresinin geçerli olduğunu kontrol et
        if (domainTeile.Length > 2)
        {
            // Eğer birden fazla domain parçası varsa (örneğin, co.uk, com.tr)
            for (int i = 2; i < domainTeile.Length; i++)
            {
                if (string.IsNullOrEmpty(domainTeile[i]))
                {
                    return "Domain nicht korrekt (vorname.name@domain)";
                }
            }
        }

        return "Email korrekt (name.vorname@domain.com)";
    }

    static void Main(string[] args)
    {
        // Kullanıcıdan e-posta adresi girmesini iste
        Console.Write("Bitte Email eingeben: ");
        string email = Console.ReadLine();

        // E-posta doğruluğunu kontrol et ve sonucu yazdır
        string ergebnis = EmailPruefen(email);
        Console.WriteLine(ergebnis);
    }
}
