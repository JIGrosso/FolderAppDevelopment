using System.ComponentModel;

namespace FolderApp.Common
{
    public enum CategoriesEnum
    {
        [Description("Noticias")]
        Noticias = -1,

        [Description("Capacitaciones")]
        Capacitaciones = 21,

        [Description("Institucional")]
        Direccion = 24,

        [Description("Producción")]
        Produccion = 53,

        [Description("Recursos Humanos")]
        RRHH = 1,

        [Description("Social")]
        Social = 13
    }

}
