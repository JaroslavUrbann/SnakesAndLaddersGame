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
using Base.ViewModel;
using System.IO;

namespace Urban_Hra.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

        }

        protected void Rules_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Pravidla:" + Environment.NewLine + Environment.NewLine + "Podstatou hry je postup po herním plánu, kde Vás speciální políčka s hady či žebříky posouvají buď dopředu nebo dozadu. Vítězem se stává ten, kdo jako první dojde na konec." + Environment.NewLine + "Klikněte na ikonu kostky pro hod.");
        }

        protected void Ulozit_Click(object sender, EventArgs e)
        {
            File.AppendAllText("Vysledky.txt", "Vysledky:" + Environment.NewLine + "1. " + prvni.Text + Environment.NewLine + "2. " + druhy.Text + Environment.NewLine + "3. " + treti.Text + Environment.NewLine + "4. " + ctvrty.Text + Environment.NewLine + "5. " + paty.Text + Environment.NewLine + Environment.NewLine);
            Ulozit.IsEnabled = false;
        }

        // link to application object: ((App)Application.Current).something

        // binding: myComponent.SetBinding(myComponent.BindingProperty, new Binding("BindingPath"){Source = this.DataContext});

        /* Binding Example
            Binding myBinding = new Binding();
            myBinding.Path = new PropertyPath("Name");
            myBinding.Source = this.DataContext;
            BindingOperations.SetBinding(myButton, Button.ContentProperty, myBinding);

            Binding myCommandBinding = new Binding();
            myCommandBinding.Path = new PropertyPath("NewCommand");
            myCommandBinding.Source = this.DataContext;
            myButton.SetBinding(Button.CommandProperty, myCommandBinding);
         */
    }
}
