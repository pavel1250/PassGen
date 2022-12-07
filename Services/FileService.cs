using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections.ObjectModel;
using System.Xml.Serialization;

namespace LogHandler.Services
{
    public interface IFileService
    {
        void Write(string filename, string str);
        string Read(string filename);
    }

    public class FileService : IFileService
    {
        public void Write(string filename, string str)
        {
            try
            {
                using (Stream writer = new FileStream(filename, FileMode.Create))
                {

                    byte[] Buffer = Encoding.ASCII.GetBytes(str);
                    writer.Write(Buffer,0, Buffer.Length);
                }
            }
            catch { }
        }
        public string Read(string filename)
        {
            string outStr = "";

            using (Stream reader = new FileStream(filename, FileMode.Open))
            {
                long size = reader.Length;
                while (size > 0)
                {
                    byte[] buffer = new byte[1024];
                    int readen = reader.Read(buffer, 0, buffer.Length);
                    if (readen > 0)
                    {
                        outStr += System.Text.Encoding.UTF8.GetString(buffer, 0, buffer.Length);
                    }
                    if (size > readen) size -= readen;
                    else size = 0;
                }
            }
            return outStr;
        }
    }
}
