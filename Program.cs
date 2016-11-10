using System;

namespace ConsoleApplication
{
    public class Program
    {
        static void ClaimWarranty(SoldArticle article)
        {
            DateTime now = DateTime.Now;
            article.MoneyBackGuarantee.Claim(now, () => Console.WriteLine("Money back"));
            article.ExpressWarranty.Claim(now, () => Console.WriteLine("Offer repair"));
        }
        public static void Main(string[] args)
        {
            DateTime sellingDate = new DateTime(2016, 11, 9);
            TimeSpan moneyBackSpan = TimeSpan.FromDays(30);
            TimeSpan warrantySpan = TimeSpan.FromDays(365);

            IWarranty moneyBack = new TimeLimitedWarranty(sellingDate, moneyBackSpan);
            IWarranty warranty = new TimeLimitedWarranty(sellingDate, warrantySpan);

            SoldArticle article = new SoldArticle(moneyBack, warranty);

            ClaimWarranty(article);

            article.NotOperational();
            Console.WriteLine("Not operational");

            ClaimWarranty(article);
        }
    }
}
