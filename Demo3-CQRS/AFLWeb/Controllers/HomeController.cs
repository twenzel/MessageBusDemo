using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AFLContracts.Messages;
using AFLWeb.Models;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace AFLWeb.Controllers
{
    public class HomeController : Controller
    {
        private ISendEndpointProvider _bus;

        public HomeController(ISendEndpointProvider bus)
        {
            _bus = bus;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> OpenApplications()
        {
            var model = new OpenApplicationsModel()
            {
                Applications = new List<Application>()
            };

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5001");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("api/applications/open");
                if (response.IsSuccessStatusCode)
                {
                    model.Applications = await response.Content.ReadAsAsync<IEnumerable<Application>>();
                }
            }
                
            return View(model);
        }

        public async Task<IActionResult> ClosedApplications()
        {
            var model = new ClosedApplicationsModel()
            {
                Applications = new List<ClosedApplication>()
            };

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5001");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("api/applications/accepted");
                if (response.IsSuccessStatusCode)
                {
                    model.Applications = await response.Content.ReadAsAsync<IEnumerable<ClosedApplication>>();
                }
            }
            
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AcceptApplication(string applicationId)
        {
            var sendEndpoint = await _bus.GetSendEndpoint(new Uri(ConfigurationManager.AppSettings["rabbitMQCommandQueue"]));

            await sendEndpoint.Send(new AcceptApplication() { ApplicationId = applicationId});

            return new JsonResult("ok");
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
