using System;
using LogicDLL;

namespace MainForm
{
    class FilePresenter
    {
        readonly IFileModel model;

        readonly IView view;
        readonly IFile file;
       
        public FilePresenter(IFileModel model, IView view, IFile file)
        {
            this.file = file;
            this.model = model;
            this.view = view;
            view.OpenFile_Click += ViewOpenFile_Click;
            view.SaveFile_Click += ViewSaveFile_Click;
            view.AddFile_Click += ViewAddFile_Click;
            view.DeleteFile_Click += ViewDeleteFile_Click;
            view.EditFile_Click += ViewEditFile_Click;

        }

        private void ViewEditFile_Click(object sender, EventArgs e)
        {
            try
            {
                
                model.Edit(view.Index, view.Address, view.Port, view.ServerType);
                view.UpdateTable_Handler(file.Notes);
                view.Log = "Изменения записи успешно завершены";
            }
            catch
            {
                view.Log = "Не удалось изменить запись";
            }
        }

        private void ViewDeleteFile_Click(object sender, EventArgs e)
        {
            try
            {
                model.Delete(view.Index);
                view.UpdateTable_Handler(file.Notes);
                view.Log = "Выбранная запись успешно удалена";
            }
            catch
            {
                view.Log = "Не удалось удалить выбранную запись";
            }
        }

        private void ViewAddFile_Click(object sender, EventArgs e)
        {
            try
            {

                model.Add();
                view.UpdateTable_Handler(file.Notes);
                view.Log = "Запись успешно добавлена";
        }
            catch
            {
                view.Log = "Не удалось добавить запись";
            }
}

        private void ViewSaveFile_Click(object sender, EventArgs e)
        { 
            model.Save(view.Path);
            view.Log = "Файл успешно сохранён";
        }

        private void ViewOpenFile_Click(object sender, EventArgs e)
        {
            try
            {
                view.Log = "Попытка открытия файла";
                model.Open(view.Path);
                view.UpdateTable_Handler(file.Notes);
                view.Log = "Файл успешно открыт";
            }
            catch
            {
                view.Log = "Ошибка открытия файла";
            }
        }
    }
}
