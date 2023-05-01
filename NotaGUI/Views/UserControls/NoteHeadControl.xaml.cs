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
using NotaGUI.Views.Windows;
namespace NotaGUI.Views.UserControls
{
    /// <summary>
    /// Interaction logic for NoteHeadControl.xaml
    /// </summary>
    public partial class NoteHeadControl : UserControl
    {
        public NoteHeadControl()
        {
            InitializeComponent();
        }

        private void OpenButton_Click(object sender, RoutedEventArgs e)
        {
            NoteEditWindow noteEditWindow = new NoteEditWindow((int)this.OpenButton.Tag);
            noteEditWindow.Show();  
        }
    }
}
