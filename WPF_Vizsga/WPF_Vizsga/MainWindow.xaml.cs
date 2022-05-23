using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;

namespace WPF_Vizsga
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly List<Teglalap> teglalapList = new List<Teglalap>();
        public MainWindow()
        {
            InitializeComponent();

            teglalapList = File.ReadAllText("teglalap.txt").Split('\n').Where(x => !x.StartsWith("A")).Select(x => new Teglalap(x)).ToList();

            data.ItemsSource = teglalapList;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (atext.Text != "" && btext.Text != "")
            {
                if (int.TryParse(atext.Text, out _) && int.TryParse(btext.Text, out _))
                {
                    teglalapList.Add(new Teglalap(int.Parse(atext.Text), int.Parse(btext.Text)));
                    data.Items.Refresh();
                }
                else MessageBox.Show("Valamelyik nem szám!");
            }
            else MessageBox.Show("Valamelyik rublika üres!");
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            if(data.SelectedIndex != -1)
            {
                teglalapList.Remove(data.SelectedItem as Teglalap);
                data.Items.Refresh();
            }
        }

        private void WriteToFile_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StreamWriter writer = new StreamWriter("teglalapout.txt", false);

                writer.WriteLine("A\tB");

                foreach (var item in teglalapList)
                {
                    writer.WriteLine($"{item.A}\t{item.B}");
                }

                writer.Close();

                MessageBox.Show("Writing complete!");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
