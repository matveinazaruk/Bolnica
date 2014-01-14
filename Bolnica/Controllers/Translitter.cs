using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Bolnica.Controllers
{
    public class Translitter
    {

        private static string rus = "абвгдеёжзийклмнопрстуфхцчшщъыьэюяАБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
        private static string eng = "abvgde%jziyklmnoprstufhc$#@!?|>qxABVGDE/JZIYKLMNOPRSTUFHC=+:_*^<';";
        public static string FromRusToEng(String message) {
            StringBuilder sb = new StringBuilder();
            foreach (char c in message) {
                if (rus.Contains(c))
                {
                    int k = rus.IndexOf(c);
                    sb.Append(eng.ToCharArray().ElementAt(k));
                }
                else {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }
        public static string FromEngToRus(string message)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in message)
            {
                if (eng.Contains(c))
                {
                    int k = eng.IndexOf(c);
                    sb.Append(rus.ToCharArray().ElementAt(k));
                }
                else
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }
    }
}