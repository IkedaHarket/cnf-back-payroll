using Backend.ProyectName.API.Domain.Exceptions;
using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Backend.ProyectName.API.Application.Utils
{
    public static class TaxId
    {
        /// <summary>
        /// Limpia y separa el rut y dv, no Valida el rut
        /// </summary>
        /// <param name="completeTaxId">Rut con digito verificador</param>
        /// <returns>rut integer</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static (int taxId, string dv) Get(string completeTaxId)
        {
            try
            {
                string taxIdClean = Clean(completeTaxId);
                var number = taxIdClean[0..^1];
                return (Convert.ToInt32(number), taxIdClean[^1..]);
            }
            catch (Exception ex)
            {
                throw new InvalidRutException(completeTaxId, ex);
            }
        }

        private static string Clean(string completeTaxId)
        {
            string expression = "\\.|-|_| ";
            completeTaxId = completeTaxId ?? throw new ArgumentNullException(nameof(completeTaxId));
            var taxIdClean = Regex.Replace(completeTaxId, expression, "");
            taxIdClean = taxIdClean.Replace("?", "");
            return taxIdClean.ToUpper();
        }

        public static string FormatWithOutDots(string completeTaxId)
        {
            var (taxId, dv) = Get(completeTaxId);
            return $"{taxId}-{dv}";
        }

        public static string Clear(string completeTaxId)
        {
            var (taxId, dv) = Get(completeTaxId);
            return $"{taxId}{dv}";
        }

        public static string FormatClear(string completeTaxId)
        {
            var (taxId, dv) = Get(completeTaxId);
            return $"{taxId}{dv}";
        }

        public static bool IsValid(string completeTaxId)
        {
            try
            {
                completeTaxId = Clean(completeTaxId);

                var (taxId, dv) = Get(completeTaxId);

                int s = 1;
                for (int m = 0; taxId != 0; taxId /= 10) s = (s + taxId % 10 * (9 - m++ % 6)) % 11;

                return dv.ToCharArray()[0] == (char)(s != 0 ? s + 47 : 75);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static string Format(string completeTaxId)
        {
            var (taxId, dv) = Get(completeTaxId);

            CultureInfo elGR = CultureInfo.CreateSpecificCulture("el-GR");
            string rutDot = String.Format(elGR, "{0:0,0}", taxId);

            return $"{rutDot}-{dv}";
        }
    }
}