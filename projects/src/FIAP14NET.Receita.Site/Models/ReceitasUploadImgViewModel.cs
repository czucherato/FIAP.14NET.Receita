using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FIAP14NET.Receita.Site.Models
{
    public class ReceitasUploadImgViewModel
    {
        public IFormFile Imagem { get; set; }
        public Guid Id { get; set; }
    }
}
