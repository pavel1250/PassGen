using Microsoft.VisualBasic;
using PassGen;
using PassGen.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
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
    /// Логика взаимодействия для IntegerUpDown.xaml
    /// </summary>
    public partial class IntegerUpDown : UserControl
    {
        private Range<int> __Range = null;
        public IDelegateCommand UpCommand { protected set; get; }
        public IDelegateCommand DownCommand { protected set; get; }

        public IntegerUpDown()
        {
            InitializeComponent();
            UpCommand = new DelegateCommand(ExecuteUp, CanExecuteUp);
            DownCommand = new DelegateCommand(ExecuteDown, CanExecuteDwon);
            __Range = new Range<int>(0, 20);
        }

        private void __UpdateVisibility()
        {
            UpCommand.RaiseCanExecuteChanged();
            DownCommand.RaiseCanExecuteChanged();
        }

        public int Value
        {
            get { return (int)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); __UpdateVisibility(); }
        }

        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register(nameof(Value),
            typeof(int), typeof(IntegerUpDown),
            new FrameworkPropertyMetadata(0, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register(nameof(Text),
            typeof(string), typeof(IntegerUpDown),
            new FrameworkPropertyMetadata("No name"));

        //Command Interface
        void ExecuteUp(object param) { if (__Range.IsOutUpperRange(Value)) Value++; }
        bool CanExecuteUp(object param) { return __Range.IsOutUpperRange(Value); }

        void ExecuteDown(object param) { if (__Range.IsOutLowerRange(Value)) Value--; }
        bool CanExecuteDwon(object param) { return __Range.IsOutLowerRange(Value); }
    }
}
