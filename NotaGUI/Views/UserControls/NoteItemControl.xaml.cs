using NotaGUI.Views.Windows;
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

namespace NotaGUI.Views.UserControls
{
    /// <summary>
    /// Interaction logic for NoteItemControl.xaml
    /// </summary>
    public partial class NoteItemControl : UserControl
    {
        public NoteItemControl()
        {
            InitializeComponent();
        }

        //Command for Delete button
        public static readonly DependencyProperty _deleteCommand = DependencyProperty.Register(
    "DeleteCommand", typeof(ICommand), typeof(UserControl));

        public ICommand DeleteCommand
        {
            get => (ICommand)GetValue(_deleteCommand);
            set => SetValue(_deleteCommand, value);
        }

        //Command for opening edit window
        public static readonly DependencyProperty _openEditWindow = DependencyProperty.Register(
            "OpenEditWindowCommand", typeof(ICommand), typeof(UserControl));

        public ICommand OpenEditWindowCommand
        {
            get => (ICommand)GetValue(_openEditWindow);
            set => SetValue(_openEditWindow, value);
        }
    }
}
