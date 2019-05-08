using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Receita.Core.Persistencia.Storage;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace FIAP14NET.Receita.HttpTriggerFuntionReceitas
{
    public static class Function1
    {
        [FunctionName("HttpFuncionReceitas")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] Guid id,
            ILogger log)
        {
            ImageStore imageStore = new ImageStore();
            var uri = _imageStore.UriFor(id.ToString());

            return View(receita);


            return OkResult();
        }


    }
}
