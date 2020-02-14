using LogicDLL;

namespace MainForm
{
    class FileModel:IFileModel
    {

        readonly IFile file; 
        public FileModel(IFile file)
        {
            this.file = file;
        }

        public void Add()
        {
            
            new FormAdd(FormAdd.FileWork.AddNotes, file).ShowDialog();
        }
        public void Open(string path)
        {
            
            file.Open(path);
        }
        public void Edit(int index, string address, int port, string servertype)
        {
            
            file.Edit(index, address, port, servertype);
        }
        public void Delete(int index)
        {
            
            file.Delete(index);
        }
        public void Save(string path)
        {
            
            file.Save(path);
        }

    }
}
