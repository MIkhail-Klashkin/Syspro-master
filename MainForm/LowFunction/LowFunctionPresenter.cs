using System;

namespace MainForm
{
    class LowFunctionPresenter
    {
        readonly IView view;
        readonly ILowFunctionModel model;
        public LowFunctionPresenter(ILowFunctionModel model, IView view)
        {
            this.model = model;
            this.view = view;
            view.Calc_Click += ViewCalc_Click;
        }

        private void ViewCalc_Click(object sender, EventArgs e)
        {
            try
            {
                view.Log = "Начало выполнения низкоуровневой вставки";
                view.Result = model.XOR(view.Arg1, view.Arg2);
                view.Log = "Операция побитового исключающего или успешно выполнена";
            }
            catch
            {
                view.Log = "Ошибка в операции";
            }
        }
    }
    
}
