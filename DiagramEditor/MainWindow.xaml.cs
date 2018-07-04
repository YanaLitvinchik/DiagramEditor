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
        List<DiagramInfo> dinfo = new List<DiagramInfo>();
        const int interval = 10;
        public double WidthRect { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            legend.Focus();
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            String comb = legend.Text+" => " + data.Text;
            datalist.Items.Add(comb);
            dinfo.Add(new DiagramInfo(legend.Text, Int32.Parse(data.Text)));
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
        //private void drawText(string content, double x, double y, int fontsize)
        //{
        //    Label l = new Label();
        //    l.FontSize = fontsize;
        //    l.Content = content;
        //    viewBox.Children.Add(l);
        //    l.RenderTransform = new TranslateTransform(x - l.FontSize, y - l.FontSize * 2);
        //}
        private void DrawDiagram()
        {
            WidthRect = (viewBox.ActualWidth - (interval * dinfo.Count)) / dinfo.Count - interval;
            double x = interval;
            double y = viewBox.ActualHeight - interval;
            int max = dinfo.Max(k => k.point);
            double height;
            foreach (var item in dinfo)
            {
                height = ((100 * item.point) / max) * 5;
                drawRect(WidthRect, height, Brushes.Orange, Brushes.Blue, 3, x, y - height);
                x += WidthRect + interval;
            }
        }
        private void draw_Click(object sender, RoutedEventArgs e)
        {
            viewBox.Children.Clear();
            DrawDiagram();
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
            viewBox.Children.Clear();
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {

        }

        private void view_Click(object sender, RoutedEventArgs e)
        {

        }

        
    }
}
