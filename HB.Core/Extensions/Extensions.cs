using System;
using System.Globalization;
using System.Linq;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace HB.Core.Extensions
{
    public static class Entensions
    {
        #region IsValidEmailAddress
        /// <summary>
        /// Bir string'in email adresi olup olmadığını kontrol eder.
        /// </summary>
        /// <param name="s"></param>
        /// <returns>bool</returns>
        public static bool IsValidEmailAddress(this string s)
        {
            try
            {
                var temp = new MailAddress(s);

                string validEmailPattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|" + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)" + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";
                var regex = new Regex(validEmailPattern, RegexOptions.IgnoreCase);

                if (!regex.IsMatch(s))
                {
                    return false;
                }

            }
            catch
            {
                return false;
            }
            return true;
        }
        #endregion

        #region ToUrlSlug
        /// <summary>
        /// String veriyi url formatında geçerli bir stringe dönüştürür
        /// </summary>
        /// <returns>Slug String'i Döndürür.</returns>
        public static string ToUrlSlug(this string text)
        {
            return Regex.Replace(Regex.Replace(Regex.Replace(text.Trim().ToLower().Replace(" ", "-").Replace("ö", "o").Replace(".", "").Replace("ç", "c").Replace("ş", "s").Replace("ı", "i").Replace("ğ", "g").Replace("ü", "u"), @"\s+", " "), @"\s", ""), @"[^a-z0-9\s-]", "");
        }

        public static string SplitPhoneMask(this string text)
        {
            return text.Replace("(", "").Replace(")", "").Replace(" ", "");
        }

        public static string FirstCharToUpper(this string input)
        {
            switch (input)
            {
                case null: throw new ArgumentNullException(nameof(input));
                case "": throw new ArgumentException($"{nameof(input)} cannot be empty", nameof(input));
                default: return input.First().ToString().ToUpper(new CultureInfo("tr-TR")) + input.Substring(1);
            }
        }


        public static string ToUniqueSlug(this string text)
        {
            var date = DateTime.Now;
            text = text + "-" + date.Year + date.Month + date.Day + date.Minute;
            text = text.ToUrlSlug();
            return text;
        }

        #endregion
    }
}