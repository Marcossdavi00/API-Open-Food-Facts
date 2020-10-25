using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Service.ServiceJob
{
    public class ImportArchivo
    {
        public static async Task exportArchivo()
        {
            try
            {
                
                    var url = "https://static.openfoodfacts.org/data/delta/index.txt";
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await client.GetAsync(url);

                    var result = await response.Content.ReadAsStringAsync();
                    string[] cont = result.Split(' ', 'p');

                    string archivo1 = $"p{cont[1]}";
                    string archivo2 = $"p{cont[2]}";

                    var t = archivo1 + archivo2;

                    System.Net.WebClient File1 = new System.Net.WebClient();
                    System.Net.WebClient File2 = new System.Net.WebClient();

                    File1.DownloadFile($"https://static.openfoodfacts.org/data/delta/{archivo1}", @"C:\Users\HP\Desktop\Project ONeGreen\OneGreen\Arquivos\Dados1.rar");
                    File2.DownloadFile($"https://static.openfoodfacts.org/data/delta/{archivo2}", @"C:\Users\HP\Desktop\Project ONeGreen\OneGreen\Arquivos\Dados2.rar");
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
