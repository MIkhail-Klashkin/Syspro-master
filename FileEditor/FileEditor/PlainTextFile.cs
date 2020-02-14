using System.Collections.Generic;
using System.IO;


namespace LogicDLL
{
    public class PlainTextFile : IFile
    {
        public LinkedList<INote> Notes { get; set; }
        public void Open(string path)
        {
            Notes = new LinkedList<INote>();
    
            using(StreamReader streamReader = new StreamReader(path))
            {
                string line = streamReader.ReadLine();
                while(line!=null)
                {
                    if (line!=null)
                    {
                        var record = line.Split(',');
                        if(record.Length==3)
                        {
                            Notes.AddFirst(new PlainTextNote(record[0], int.Parse(record[1]), record[2]));
                        }
                    }
                    line = streamReader.ReadLine();
                }
            }
            
        }

        public void CreateFile()
        {
            Notes = new LinkedList<INote>();
        }
        public void Save(string path)
        {
            if (Notes != null)
            {

                var record = Notes.First;
                using (StreamWriter streamWriter = new StreamWriter(path))
                {

                   
                    while (record != null)
                    {
                        streamWriter.WriteLine($"{record.Value.Address},{record.Value.Port}, {record.Value.ServerType}");
                        record = record.Next;
                    }
                }
            }
        }
        public void Add(string address, int port, string servertype)
        {
            
            if (Notes != null)
            {
             
                Notes.AddLast(new PlainTextNote() { Address = address, Port = port, ServerType = servertype });
            }
            else
            {
                Notes = new LinkedList<INote>();
                Notes.AddLast(new PlainTextNote() { Address = address, Port = port, ServerType = servertype });
            }
        }
      
        public void Edit(int index, string address, int port, string servertype)
        {
            if (Notes.First != null)
            {
                LinkedListNode<INote> node = Notes.First;
                while (index != 0 && node != null)
                {
                    index--;
                    node = node.Next;
                }
                if (index == 0)
                {
                    node.Value = new PlainTextNote(address, port, servertype);
                }
            }
        }
        public void Delete(int index)
        {
            LinkedListNode<INote> node = Notes.First;
            while (index != 0 && node != null)
            {
                index--;
                node = node.Next;
            }
            if(index==0)
            {
                Notes.Remove(node.Value);
            }
        }

    }
}