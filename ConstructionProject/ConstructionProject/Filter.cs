using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace ConstructionProject
{
    class Filter
    {
        public static string CommentRemove(string fileName)
        {
            string[] sourceCode = System.IO.File.ReadAllLines(fileName);
            StringBuilder builder = new StringBuilder();
            foreach (string s in sourceCode)
            {
                string a = s.Trim();
                if (a.StartsWith("/*") && a.EndsWith("*/"))
                {
                    builder.Append(a.TrimStart(new char[] { '*', '/' }).TrimEnd(new char[] { '*', '/' }).Replace(" ", ""));
                }
                else if (a.Contains("//"))
                {
                    builder.Append(a.TrimStart(new char[] { '/' }));
                }

            }
            return builder.ToString();
        }
    }
}
