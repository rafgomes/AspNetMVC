
using AspNetMVC.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace AspNetMVC.Services
{
    public class AlunoServices
    {
        public async Task<Aluno> Integracao(int id)
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetAsync($"http://localhost/aluno/{id}");
            var jsonString = await response.Content.ReadAsStringAsync();

            Aluno jsonObject = JsonConvert.DeserializeObject<Aluno>(jsonString);

            if (jsonObject != null)
            {
                return jsonObject;
            }
            else
            {
                return new Aluno
                {
                    Verificacao = true
                };
            }

        }

        public async Task<List<Aluno>> GetAlunos()
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetAsync($"http://localhost/alunos");
            var jsonString = await response.Content.ReadAsStringAsync();

            List<Aluno> jsonObject = JsonConvert.DeserializeObject<List<Aluno>>(jsonString);

            if (jsonObject != null)
            {
                return jsonObject;
            }

            return new List<Aluno>();

        }
    }
}