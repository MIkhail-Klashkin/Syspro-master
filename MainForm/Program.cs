using System;
using System.Windows.Forms;
using LogicDLL;

namespace MainForm
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            PlainTextFile textFile = new PlainTextFile();
            MainForm form = new MainForm();
            _ = new FilePresenter(new FileModel(textFile), form, textFile);
            _ = new AnalyzerPresenter(new AnalyzerModel(), form);
            _ = new LowFunctionPresenter(new LowFunctionModel(), form);
            Application.Run(form);
        }
    }
}
