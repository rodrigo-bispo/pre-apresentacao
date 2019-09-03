using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Monitoria.Models
{
    public class Remessa
    {
        public IEnumerable<HttpPostedFileBase> Arquivos { get; set; }
    }
}