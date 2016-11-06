using System.Text;
using System.IO;
using static System.Console;


namespace ConstructionProject
{
    public static class TokenGeneratorHelper
    {
        public static string[] GetKeywords()
        {
            string[] instanceKeywords = System.IO.File.ReadAllLines(@"..\Files\Keywords.txt");
            return instanceKeywords;
        }
        public static char[] GetPunctuations()
        {
           
               byte[] instanceBytes = System.IO.File.ReadAllBytes(@"..\Files\Punctuations.txt");
               char[] instancePunctuations = Encoding.ASCII.GetChars(instanceBytes);
               return instancePunctuations;
        }
        public static string[] GetOperators()
        {
            string[] instanceOperators = System.IO.File.ReadAllLines(@"..\Files\Operators.txt");
            return instanceOperators;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static string[] GetSourceCode(string filePath)
        {
            string s = File.ReadAllText(filePath);
            string[] sourceCode = s.Split(new char[] {' ','\n','\r','.',';','(',')'});
            
            //string[] splittedCode = sourceCode.Split(' ');
            return sourceCode;
        }
    }
}
