using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpdateRagedIPs
{
    public class GetIPS
    {

        public void getRangeIPS()
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.nslookup.io/domains/www.youtube.com/webservers/");

            //var trCounter = driver.FindElement(By.XPath("\"/html/body/div[1]/div[3]/main/div[3]/table/tbody/tr"));
            //Console.WriteLine(trCounter);
            var tabela = driver.FindElement(By.XPath("/html/body/div[1]/div[3]/main/div[3]/table"));

            for (var x = 1; x <= 30; x++)
            {
                try
                {
                    var ip = driver.FindElement(By.XPath($"/html/body/div[1]/div[3]/main/div[3]/table/tbody/tr[{x}]/td[2]/strong")).Text;
                    Console.WriteLine(ip);
                 

                }
                catch(Exception ex) { }


            }
            ////*[@id="app"]/div[3]/main/div[3]/table/tbody/tr[1]



        }


    }
}
