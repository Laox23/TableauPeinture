namespace TableauWeb.Dto
{
    public class TableauInformation
    {
        public string UrlAffichage { get; set; }
        public string Nom { get; set; }
        public string NombreImpression { get; set; }
        public int ImageTableauId { get; set; }
    }

    public class ImagesInformation
    {
        public int ImageTableauId { get; set; }

        public string UrlAffichage { get; set; }

        public string NomBase { get; set; }

        public string Nom { get; set; }

        public int MaxImpression { get; set; }

    }
}