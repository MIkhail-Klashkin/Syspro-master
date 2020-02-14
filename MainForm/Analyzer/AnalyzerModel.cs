using LogicDLL;

namespace MainForm
{
    class AnalyzerModel:IAnalyzerModel
    {
        
      
        public AnalyzerModel()
        {
            
        }

        public string AnalyzerMethod(string lines)
        {
            var analyzer = new Analyzer();
            return analyzer.Analyze(lines);
        }


    }
}
