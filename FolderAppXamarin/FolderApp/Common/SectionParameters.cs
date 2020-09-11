using FolderApp.Common.Enum;
using System;
using Xamarin.Forms;

namespace FolderApp.Common
{
    public static class SectionParameters
    {

        public static Color GetSectionColor(CategoriesEnum category)
        {
            switch (category) {
                case CategoriesEnum.Noticias:
                    return SectionColorEnum.Noticias;
                case CategoriesEnum.Capacitaciones:
                    return SectionColorEnum.Capacitaciones;
                case CategoriesEnum.Direccion:
                    return SectionColorEnum.Direccion;
                case CategoriesEnum.Produccion:
                    return SectionColorEnum.Produccion;
                case CategoriesEnum.RRHH:
                    return SectionColorEnum.RRHH;
                case CategoriesEnum.Social:
                    return SectionColorEnum.Social;
                default:
                    throw new Exception();
            }
        }

        public static string GetSectionTitle(CategoriesEnum category)
        {
            switch (category)
            {
                case CategoriesEnum.Noticias:
                    return SectionTitleEnum.Noticias;
                case CategoriesEnum.Capacitaciones:
                    return SectionTitleEnum.Capacitaciones;
                case CategoriesEnum.Direccion:
                    return SectionTitleEnum.Direccion;
                case CategoriesEnum.Produccion:
                    return SectionTitleEnum.Produccion;
                case CategoriesEnum.RRHH:
                    return SectionTitleEnum.RRHH;
                case CategoriesEnum.Social:
                    return SectionTitleEnum.Social;
                default:
                    throw new Exception();
            }
        }
    }
}
