using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogHandler.Services
{
    public interface IDialogService
    {
        string FilePath { get; set; }
        bool OpenFileDialog();
        bool SaveFileDialog();
    }
    public class DefaultDialogService : IDialogService
    {
        public string FilePath { get; set; }

        public bool OpenFileDialog()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                openFileDialog.Filter = "Text Files (.txt)}|*.txt";
                openFileDialog.Title = "Open a file...";
                FilePath = openFileDialog.FileName;
                return true;
            }
            return false;
        }
        public bool SaveFileDialog()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == true)
            {
                saveFileDialog.Filter = "Text Files (.rtf)|*.rtf";
                saveFileDialog.Title = "Save";
                FilePath = saveFileDialog.FileName;
                return true;
            }
            return false;
        }
    }
}
