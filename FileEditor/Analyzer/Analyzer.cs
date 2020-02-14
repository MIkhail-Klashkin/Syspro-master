using System.CodeDom.Compiler;
using System.Threading;


namespace LogicDLL
{
    public class Analyzer: IAnalyzer
    {
       
        string codeStart = "using System;\n" + 
                           "namespace AnalyzeCode\n" + 
                           "{\n\tpublic static class AnalyzerClass\n" + 
                           "\t{\n" +
                           "\t\tpublic static int AnalyzeMethod()\n" + 
                           "\t\t{";
        string programCodeEnd = "\t\t\treturn countOfWhileRepeat;\n" + 
                                "\t\t}\n" + 
                                "\t}\n" + 
                                "}";

        public string AnalyzerResult { get;  set; }
        public string Analyze(string lines)
        {
            int lastIndex;
            string whileCycle;
            var compiler = CodeDomProvider.CreateProvider("CSharp");
            var parametres = new CompilerParameters
            {
                GenerateInMemory = true,
                IncludeDebugInformation = false
            };
            try
            {
               lastIndex= lines.LastIndexOf("}");
            }
            catch
            { 
                return AnalyzerResult = "Ошибка во входной строке";
            }
            try
            {
                 whileCycle = lines.Substring(0, lastIndex);
            }
            catch
            {
                return AnalyzerResult = "Ошибка во входной строке";
            }
            string countOfWhileRepeatString = "\ncountOfWhileRepeat++;\n}";
            string whileCycleWithInc = whileCycle + countOfWhileRepeatString;
            string resultOfWhileCycle = whileCycleWithInc + lines.Substring(lastIndex + 1);
            string sourceCode = codeStart + "\nint countOfWhileRepeat=0;\n" + resultOfWhileCycle + programCodeEnd;
            CompilerResults results = compiler.CompileAssemblyFromSource(parametres, sourceCode);
            if (results.Errors.Capacity > 0)  AnalyzerResult = "Ошибка во входной строке";
            object repeatCount = null;
            
            Thread compileThread = new Thread(() =>
            {
                try
                {
                    repeatCount = results.CompiledAssembly.GetType("AnalyzeCode.AnalyzerClass").GetMethod("AnalyzeMethod").Invoke(null, null);
                    if(Check(lines, repeatCount)) AnalyzerResult=(int)repeatCount>0?"Цикл выполнится больше одного раза":"Цикл не выполнится ни разу";

                }
                catch
                {
                    AnalyzerResult = "Ошибка во входной строке";
                }
                
            });

            compileThread.Start();
            Thread.Sleep(100);
            return AnalyzerResult;

        }
         bool Check(string lines, object repeatCount)
            {
                int position = 0;
                bool isWhile = false;
                int positionStartCycle;
                int inputStructureLength = lines.Length;
                do
                {
                    positionStartCycle = lines.IndexOf("while", position);

                    if (positionStartCycle == -1) return false;

                    if (positionStartCycle == 0)
                    {
                        if (inputStructureLength > 5 && !char.IsLetterOrDigit(lines[5]))
                        {
                            isWhile = true;
                            break;
                        }
                    }

                    if (positionStartCycle + 1 < inputStructureLength)
                    {
                        var prevChar = lines[positionStartCycle - 1];
                        var nextChar = lines[positionStartCycle + 7];

                        if (!char.IsLetterOrDigit(prevChar) && prevChar != '/' && !char.IsLetterOrDigit(nextChar))
                        {
                            isWhile = true;
                            break;
                        }
                    }
                  
                    position = positionStartCycle;

                } while (position < lines.Length && position != -1);

            if (isWhile)
            {
                return true;
            }
            else return false;
            
            }
        }
}

