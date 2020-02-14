using LogicDLL;
using System;
using System.Collections.Generic;

namespace MainForm
{
    interface IFileView
    {
        event EventHandler OpenFile_Click;
        event EventHandler SaveFile_Click;
        event EventHandler AddFile_Click;
        event EventHandler DeleteFile_Click;
        event EventHandler EditFile_Click;
        int Index { get; }
        string Address { get; set; }
        int Port { get; set; }
        string ServerType { get; set; }
        string Path { get; set; }
        void UpdateTable_Handler(LinkedList<INote> notes);

    }
}
