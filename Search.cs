using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace AlfaTask
{
    public class Search
    {
        public string SearchInString(string file, string keyWord1)
        {
            string searchRes = "";

            var splText = file.Split(new Char[] { ':', '\t', '\n' }).ToList();

            foreach (var s in splText)
            {
                if (s.Trim() != "" && Regex.IsMatch(s, keyWord1))
                {
                    searchRes = splText[splText.IndexOf(keyWord1) + 1];
                    break;
                }
            }
            return searchRes;
        }
    }
}
