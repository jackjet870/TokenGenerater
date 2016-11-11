using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static ConstructionProject.TokenGeneratorHelper;


/*
 * Author : BILAL ASIF MIRZA
   DATE CREATED : 6/11/2016
*/

namespace ConstructionProject
{
    class TokenGenerator
    {
       
        private StringBuilder tokenBuilder;

        private string[] keyWords;
        private string[] operators;
        private string[] punctuation;


        const string IDENTIFIER = @"[a-zA-Z_][a-zA-Z0-9_]*";
        const string NUMBER = @"([\+|\-]?[0-9]([0-9]*([\.][0-9]*)?)(([e|E][+|-]?[0-9]+)?))";
        const string OPERATOR = @"(\+(\+|\=)?|\-(\-|\=)?|\*(\=)?|\/(\=)?|\!(\=)?|\=(\=?))";
        const string LITERAL = @"(\\"")(.*)?(\"")";

        private string[] breakedSourceCode;

        private void Init()
        {
            keyWords = System.IO.File.ReadAllLines(@"..\Debug\Keywords.txt");
            punctuation = System.IO.File.ReadAllLines(@"..\Debug\Punctuations.txt");
            tokenBuilder = new StringBuilder();
        }
        private bool IsKeyWord(string lexeme)
        {
           foreach(string keyword in keyWords)
            {
                if (lexeme == keyword)
                {
                    return true;
                }
            }
            return false;
        }

        private bool IsIdentifier(string lexeme)
        {
            return Regex.IsMatch(lexeme, IDENTIFIER, RegexOptions.Compiled);
        }

        private bool IsNumber(string lexeme)
        {
            return Regex.IsMatch(lexeme, NUMBER);
            
        }

        private bool IsOperator(string lexeme)
        {
            return Regex.IsMatch(lexeme, OPERATOR);
        }
        private bool IsLiteral(string lexeme)
        {
            return Regex.IsMatch(lexeme, LITERAL);
        }

        private bool IsPunctuation(string lexeme)
        {
            foreach(string punctuations in punctuation)
            {
                if(lexeme == punctuations)
                {
                    return true;
                }
            }
            return false;
        }

        public string GenerateToken(string sourceCode)
        {
            Init();
            breakedSourceCode = sourceCode.Split(new char[] { ' ', '\n' });
            foreach(string s in breakedSourceCode)
            {
                if(IsKeyWord(s))
                {
                    tokenBuilder.AppendLine($"KeyWord --- {s}");
                }
                else if(IsIdentifier(s))
                {
                    tokenBuilder.AppendLine($"Identifer --- {s}");

                }
               
                else if(IsOperator(s))
                {
                    tokenBuilder.AppendLine($"Operator --- {s}");

                }
                else if(IsLiteral(s))
                {
                    tokenBuilder.AppendLine($"Literal --- {s}");
                }
                else if(IsNumber(s))
                {
                    tokenBuilder.AppendLine($"Number --- {s}");

                }
                else if(IsPunctuation(s))
                {
                    tokenBuilder.AppendLine($"Punctuation --- {s}");
                }
            }
            return tokenBuilder.ToString();
        }

}
