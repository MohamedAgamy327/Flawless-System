using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTO
{
    public class uploadDTO
    {
        [FromForm(Name = "file")]
        public IFormFile File { get; set; }
    }
}
