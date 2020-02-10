using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TableauWeb.Dto
{
    public class TableauInformation
    {
        public string UrlAffichage { get; set; }
        public string Nom { get; set; }
        public string NombreImpression { get; set; }
        public int ImageId { get; set; }
    }

    public class ImagesInformation
    {
        public int ImageId { get; set; }

        public string UrlAffichage { get; set; }

        public string NomBase { get; set; }

        public string Nom { get; set; }

        public int MaxImpression { get; set; }

    }
}
