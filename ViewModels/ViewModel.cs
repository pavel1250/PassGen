using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using LogHandler.Services;
using System.Windows.Input;
using Microsoft.Win32;
using System.Windows.Controls;
using PassGen.ViewModels;

namespace PassGen
{
    public class ViewModel : BaseViewModel
    {
        private Model __Model = null;

        private IFileService FileService;
        private IDialogService DialogService;

        public IDelegateCommand OpenCommand { protected set; get; }
        public IDelegateCommand SaveCommand { protected set; get; }
        public IDelegateCommand GenerateCommand { protected set; get; }
       

        public ViewModel(IFileService fileService, IDialogService dialogService, Model model)
        {
            this.FileService = fileService;
            this.DialogService = dialogService;
            this.OpenCommand = new DelegateCommand(ExecuteOpen);
            this.SaveCommand = new DelegateCommand(ExecuteSave);
            this.GenerateCommand = new DelegateCommand(ExecuteGenerate);

            __Model = model;
        }

        void ExecuteOpen(object param)
        {
            if (DialogService.OpenFileDialog() == true)
            {
                PasswordText = FileService.Read(DialogService.FilePath);
            }
        }
        void ExecuteSave(object param)
        {
            if (DialogService.SaveFileDialog() == true)
            {
                FileService.Write(DialogService.FilePath, PasswordText);
            }
        }
        void ExecuteGenerate(object param)
        {
            //WTF is this Oo??? Use save like ExecuteSave//
            try
            {
                using (StreamWriter writer = new StreamWriter("C:\\Users\\user\\Desktop\\Games\\Password for wifi.txt", true))
                {
                    writer.WriteLine(PasswordText);
                }//<-- writer more not available 
            }
            catch (Exception ex) { Message("Error", ex.Message); }
            //WTF is this Oo----//

            for (int j = 0; j < NumberOfPass; j++)
            {
                string password = __Model.GeneratePassword(Len, WithSybols);
                PasswordText += password + "\n";
            }
        }
        
        private int __Len = 0;
        public int Len
        {
            get { return __Len; }
            set { __Len = value; OnPropertyChanged(nameof(PasswordText)); }
        }
        
        public int __NumberOfPass = 0;
        public int NumberOfPass
        {
            get { return __NumberOfPass; }
            set { __NumberOfPass = value; OnPropertyChanged(nameof(NumberOfPass)); }
        }
        
        public bool WithSybols { get; set; }
        
        private string _passwordText;
        public string PasswordText
        {
            get { return _passwordText; }
            set { _passwordText = value; OnPropertyChanged(nameof(PasswordText)); }
        }

        private void Message(string caption, string message)
        {
            MessageBoxButton buttons = MessageBoxButton.OK;
            MessageBox.Show(message, caption, buttons);
        }
    }
}