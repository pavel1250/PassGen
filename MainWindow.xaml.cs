using LogHandler.Services;
using LogHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace PassGen
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            FileService = new FileService();
            DialogService = new DefaultDialogService();
            Model = new Model();
            ViewModel = new ViewModel(FileService, DialogService, Model);
            
            Model.SetViewModel(ViewModel);
            
            InitializeComponent();

            this.DataContext = ViewModel;
        }

        private FileService FileService = null;
        private DefaultDialogService DialogService = null;
        private ViewModel ViewModel = null;
        private Model Model = null;
    }
}
