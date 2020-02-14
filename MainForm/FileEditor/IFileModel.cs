

namespace MainForm
{
        interface IFileModel
        {
           // IFile file { get; set; }
            void Add();
            void Delete(int index);
            void Edit(int index, string address, int port, string servertype);
            void Open(string path);
            void Save(string path);
        }
}
