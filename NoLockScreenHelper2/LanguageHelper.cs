using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NoLockScreenHelper2
{
    public class Language
    {
        public Language() { }

        public static void ChangeLanguage(string lang)
        {
            CultureInfo info = null;
            try // catch null or non exist culture
            {
                info = new CultureInfo(lang);
            }
            catch { }
            ChangeLanguage(info);
        }

        public static void ChangeLanguage(CultureInfo lang)
        {
            if (lang == null)
                lang = GetUserDefaultCulture();
            Thread.CurrentThread.CurrentCulture = lang;
            Thread.CurrentThread.CurrentUICulture = lang;
        }

        public static CultureInfo GetUserDefaultCulture()
        {
            var property = typeof(System.Globalization.CultureInfo).GetProperty("UserDefaultCulture", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic);
            var culture = (System.Globalization.CultureInfo)property.GetValue(null);
            return culture;
        }



        public static IEnumerable<CultureInfo> GetAvailableCultures()
        {
            List<CultureInfo> result = new List<CultureInfo>();
            ResourceManager rm = new ResourceManager(typeof(Resources.Lng));
            CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.AllCultures);
            foreach (CultureInfo culture in cultures)
            {
                if (culture.Equals(CultureInfo.InvariantCulture)) continue; //do not use "==", won't work
                ResourceSet rs = rm.GetResourceSet(culture, true, false);
                if (rs != null)
                    yield return culture;
            }
        }

        /// <summary>
        /// Return IEnumerable KeyVakue pairs with language name and value
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<KeyValuePair<string, CultureInfo>> GetAvailableLanguages()
        {
            var languages = new ObservableCollection<string>();
            var cultures = GetAvailableCultures();
            foreach (CultureInfo culture in cultures)
                yield return new KeyValuePair<string, CultureInfo>(culture.NativeName + " (" + culture.EnglishName + " [" + culture.TwoLetterISOLanguageName + "])", culture);
        }

    }
}
