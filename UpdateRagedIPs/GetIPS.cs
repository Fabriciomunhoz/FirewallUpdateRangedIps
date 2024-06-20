using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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

            for (var x = 1; x <= 100; x++)
            {
                try
                {
                    var ip = driver.FindElement(By.XPath($"/html/body/div[1]/div[3]/main/div[3]/table/tbody/tr[{x}]/td[2]/strong")).Text;

                    using (StreamWriter writer = new StreamWriter("dados.txt", true))
                    {
                        try
                        {
                        File.Copy("dados.txt", "dados_backup.txt", true);

                        }catch(Exception e) { Console.WriteLine("Erro ao tentar fazer Backup"); }
                        try
                        {
                            File.WriteAllText("dados.txt", "");
                            writer.WriteLine(ip);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Erro ao restaurar o arquivo de Backup");
                        }
                        finally
                        {
                            if (File.Exists("dados_backup.txt"))
                            {
                            }
                        }
                    }


                }
                catch (Exception ex) { }


            }
            ////*[@id="app"]/div[3]/main/div[3]/table/tbody/tr[1]



        }


    }
}
