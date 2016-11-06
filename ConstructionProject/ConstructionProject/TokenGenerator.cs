using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static ConstructionProject.TokenGeneratorHelper;


namespace ConstructionProject
{
    class TokenGenerator
    {
       
        StringBuilder generatedTokens;
        string[] sourceCode;
        string[] literals;
        string[] keyWords;
        char[] punctuations;
        string[] operators;
       

        const string LITERAL = @"[a-zA-Z_][a-zA-Z0-9_]*";
        const string NUMBER = @"([\+|\-]?[0-9]([0-9]*([\.][0-9]*)?)(([e|E][+|-]?[0-9]+)?))";
        private void Init()
        {
            generatedTokens = new StringBuilder(); 
            sourceCode = TokenGeneratorHelper.GetSourceCode(@"E:\Visual Studio 15 WorkSpace\Univeristy\ConstructionProject\ConstructionProject\Program.cs");
            keyWords = TokenGeneratorHelper.GetKeywords();
            punctuations = TokenGeneratorHelper.GetPunctuations();
            operators = TokenGeneratorHelper.GetOperators();
        }
       

        private bool IsKeyword(string lexeme)
        {
           foreach(string keyWord in keyWords)
            {
                if(keyWord == lexeme)
                {
                    return true;
                }
            }
            return false;
        }

        private bool IsOperator(string lexmeme)
        {
            foreach(string opertor in operators)
            {
                if(opertor == lexmeme)
                {
                    return true;
                }
            }
            return false;
        }

        private bool IsPunctuation()
        {
            throw new NotImplementedException();
        }

        private bool IsLiteral(string lexeme)
        {
            return Regex.IsMatch(lexeme, LITERAL);
        }
        public string GenerateToken()
        {
            Init();
            foreach(string s in sourceCode)
            {
                if(IsKeyword(s))
                {
                    generatedTokens.AppendLine($"keyword {s}");
                }
                else if(IsLiteral(s))
                {
                    generatedTokens.AppendLine($"Literal {s}");
                }
            }
            return generatedTokens.ToString(); 
        }
    }
}
