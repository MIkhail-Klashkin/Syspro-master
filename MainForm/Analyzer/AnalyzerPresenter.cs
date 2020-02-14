using System;

namespace MainForm
{
    class AnalyzerPresenter
    {
        readonly IView view;
        readonly IAnalyzerModel model;
        public AnalyzerPresenter(IAnalyzerModel model, IView view)
        {
            this.view = view;
            this.model = model;
            view.AnalyzerButtonEvent += new EventHandler(Analyzer);
        }
        private void Analyzer(object sender, EventArgs e)
        {
            try
            {
                view.Log = "Начало анализа";
                view.AnalyzerResult = model.AnalyzerMethod(view.InputAnalyzeLines);
                view.Log = "Анализ выполнен успешно";
            }
            catch
            {
                view.AnalyzerResult = "Ошибка в входной строке";
            }
        }
    }
}
