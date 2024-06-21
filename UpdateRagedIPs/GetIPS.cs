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

                        }
                        catch (Exception e) { Console.WriteLine("Erro ao tentar fazer Backup"); }
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



        public void ReadAllDomains()
        {
            string rootFolder = @"C:\Users\jmed\Documents\Projetos\UpdateRagedIPs\UpdateRagedIPs\BL";


            ProcessDirectory(rootFolder);

            Console.WriteLine("Ok");

            Console.ReadKey();

        }


        static void ProcessDirectory(string currentFolder)
        {
            try
            {


                string[] files = Directory.GetFiles(currentFolder);
                foreach (string file in files)
                {
                    ProcessFiles(file);

                }


                string[] subFolders = Directory.GetDirectories(currentFolder);
                foreach (string subFolder in subFolders)
                {
                    ProcessDirectory(subFolder);
                }
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine($"Not permission for access: {currentFolder}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error for access: {currentFolder}. Error: {ex.Message}");
            }
        }

        static void ProcessFiles(string pathFile)
        {

            var driver = new ChromeDriver();


            try
            {
                Console.WriteLine($"Read file: {pathFile}");

                string[] lines = File.ReadAllLines(pathFile);
                int linesCounter = 0;

                foreach (string line in lines)
                {
                    Console.WriteLine("Site: " + line);
                    linesCounter++;

                    driver.Navigate().GoToUrl($"https://www.nslookup.io/domains/{line}/webservers/");


                    
                        using (StreamWriter writer = new StreamWriter("Ips.txt"))
                        {
                            for (int x = 0; x < 1000; x++)
                            {
                                var ip = driver.FindElement(By.XPath($"/html/body/div[1]/div[3]/main/div[3]/table/tbody/tr[{x}]/td[2]/strong")).Text;
                                writer.WriteLine(ip);
                                Console.WriteLine(ip);
                            }
                        }
                        driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(2);

                    
                }

                Console.WriteLine(linesCounter);
            }
            catch (Exception ex) { }
        }
    }
}
