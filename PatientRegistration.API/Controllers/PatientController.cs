using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Intrinsics.X86;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using PatientRegistration.Infrastructure.Models;
using PatientRegistration.Infrastructure.Repsoitory;
using static System.Net.WebRequestMethods;


namespace YourNamespace.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class PatientController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IRepository _repo;

        public PatientController(IHttpClientFactory httpClientFactory, IConfiguration configuration, IRepository repo)
        {
            _repo = repo;
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }
        private readonly IConfiguration _configuration;

        [HttpGet]
        public async Task<string> Authenticate()
        {
            // Replace these values with your actual credentials
            string identifier = _configuration["mindwareAuth:identifier"];
            string password = _configuration["mindwareAuth:password"];
            string credString = $"{{\"identifier\": \"{identifier}\", \"password\": \"{password}\"}}";

            HttpResponseMessage response = null;
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Post, "https://testapi.mindware.us/auth/local");
                var content = new StringContent(credString, null, "application/json");
                request.Content = content;
                response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();

                return GetToken(response.Content.ReadAsStream());
            }
            catch
            {
                return "Failed to authenticate";
            }
        }

        

        [HttpGet]
        public async Task<IActionResult> GetAllLabVisitsForPatient(string ssn)
        {
           
            var url = $"https://testapi.mindware.us/patient-lab-visits?SSN={ssn}";
            var   json= await Get(url);
            _repo.Add(Deserialize<Patient_Lab_Visit>(json));
            _repo.Save();
            return Ok(json);

        }



        [HttpGet]
        public async Task<IActionResult> GetLabResults(int labVisitId)
        {

            var url = $"https://testapi.mindware.us/Patient-lab-results/?lab_visit_id={labVisitId}";
            var json = await Get(url);
            _repo.Add(Deserialize<Patient_Lab_Result>(json));
            _repo.Save();
            return Ok(json);
        }

        [HttpGet]
        public async Task<IActionResult> GetVaccination(string ssn)
        {
            var url = $"https://testapi.mindware.us/patient-vaccinations?SSN={ssn}";
            var  json = await Get(url);
            _repo.Add(Deserialize<Patient_Vaccination_Data>(json));
            _repo.Save();
            return Ok(json);

        }
        private static string GetToken(Stream json)
        {
            JsonDocument jsonDocument = JsonDocument.Parse(json);
            JsonElement root = jsonDocument.RootElement;

            return root.GetProperty("jwt").GetString();

        }
        private async Task<string> Get(string apiUrl)
        {
            var token = Authenticate().Result;
            using (var client = new HttpClient())
            {
                var request = new HttpRequestMessage(HttpMethod.Post, apiUrl);
                request.Headers.Add("Authorization", $"Bearer {token}");
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();

            }
        }

        private T Deserialize<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
