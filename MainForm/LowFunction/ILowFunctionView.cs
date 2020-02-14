using System;

namespace MainForm
{
    interface ILowFunctionView
    {
        event EventHandler Calc_Click;
        int Arg1 { get; set; }
        int Arg2 { get; set; }
        int Result { get; set; }
    }
}
