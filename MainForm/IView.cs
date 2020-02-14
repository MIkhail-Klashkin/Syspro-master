

namespace MainForm
{
    interface IView: ILowFunctionView, IAnalyzerView, IFileView
    {
        string Log { set; }
    }   
}
