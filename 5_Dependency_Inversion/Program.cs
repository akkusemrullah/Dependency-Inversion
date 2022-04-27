using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5_Dependency_Inversion
{
    /// <summary>
    /// Bir Notification sınıfımız olduğunu düşünelim ve bu sınıf aracılığıyla Email ve Sms gönderebilelim.
    /// Email gönderme işlemini yapabilen bir sınıfımız.
    /// Sms gönderebilen sınıfımız.
    /// ve bildirim göndereceğimizde ikisinide çalıştırmak amacıyla
    /// oluşturduğumuz bir Notification sınıfımız olmuş olsun.
    /// </summary>
    /// 

    /// Notification sınıfımız yüksek seviye bir sınıf
    /// olmasına rağmen daha düşük seviyeli olan Email ve SMS sınıflarına bağımlı olabilir.
    /// Bunun önüne geçmek için Dependency Inversion tasarımı ile bu problemi çöz

    interface Notification
    {
        void send(string message);
    }

    class Mail : Notification
    {
        public void send(string message)
        {
            Console.WriteLine("Mail başarı ile gönderildi (" + message + ")");
        }
    }

    class SMS: Notification
    {
        public void send(string message)
        {
            Console.WriteLine("SMS başarı ile gönderildi (" + message+")");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Notification> bildirimTipleri = new List<Notification>();
            Mail mail = new Mail();
            SMS sms = new SMS();
            bildirimTipleri.Add(mail);
            bildirimTipleri.Add(sms);

            foreach (var item in bildirimTipleri)
            {
                item.send("Mutlu yıllar !");
            }

            Console.ReadKey();
        }
    }
}
