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

namespace DiagramEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<String> DataList { get; set; }
        public List<int> point { get; set; }//
       
          
        public MainWindow()
        {

            InitializeComponent();
            List<String> DataList = new List<String>();
            List<int> point = new List<int>();
            legend.Focus();
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            String comb = legend.Text+" => " + data.Text;
            datalist.Items.Add(comb);
            DataList.Add(comb);
            string a = data.Text;
            int i = int.Parse(data.Text);
            point.Add(i);
            legend.Clear();
            data.Clear();
            legend.Focus();
        }

        private void drawRect(double h, double w, Brush f, Brush s, double t, double a , double b)
        {
            Rectangle r = new Rectangle();
            r.Width = w;
            r.Height = h;
            r.Fill = f;
            r.Stroke = s;
            r.StrokeThickness = t;
            r.RenderTransform = new TranslateTransform(a,b-w);
            viewBox.Children.Add(r);
        }

        private void draw_Click(object sender, RoutedEventArgs e)
        {
            
            foreach (var item in DataList)
            {
                drawRect(point[1], 10, Brushes.Orange,Brushes.Blue, 3, 0, viewBox.ActualHeight);
            }
            
                      
        }

        private void del_Click(object sender, RoutedEventArgs e)
        {
            int k = datalist.SelectedIndex;
            if (k == -1)
                MessageBox.Show("You didt't select an item to delete", "Warning",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
            else
                datalist.Items.RemoveAt(k);
        }

        private void reset_Click(object sender, RoutedEventArgs e)
        {

        }

        private void save_Click(object sender, RoutedEventArgs e)
        {

        }

        private void view_Click(object sender, RoutedEventArgs e)
        {

        }

        
    }
}
