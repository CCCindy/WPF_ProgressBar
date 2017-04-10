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


namespace WpfApplication1
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

            //设置ProgressBar 属性
            ProgressBar.Minimum = 0;
            ProgressBar.Maximum = 100;
            ProgressBar.Value = 0;

            //设置ProgressBar1 属性
            ProgressBar1.Minimum = 0;
            ProgressBar1.Maximum = 100;
            ProgressBar1.Value = 0;
        }

        private delegate void UpdateProgressBarDelegate(System.Windows.DependencyProperty dp, Object value);

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            //Application.Current.Shutdown();
            Environment.Exit(0);
            
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {

                if (textBox.Text.Length != 0 && textBox1.Text.Length != 0 && int.Parse(textBox.Text) != 0 && int.Parse(textBox1.Text) != 0)
                {

                    button.IsEnabled = false;

                    ProgressBar.Value = 0;
                    ProgressBar.Maximum = int.Parse(textBox.Text);
                    ProgressBar1.Value = 0;
                    ProgressBar1.Maximum = int.Parse(textBox1.Text);
                    double value = 0;
                    UpdateProgressBarDelegate updatePbDelegate = new UpdateProgressBarDelegate(ProgressBar.SetValue);
                    UpdateProgressBarDelegate updatePbDelegate1 = new UpdateProgressBarDelegate(ProgressBar1.SetValue);
                    do
                    {
                        value += 100;
                        Dispatcher.Invoke(updatePbDelegate1,
                            System.Windows.Threading.DispatcherPriority.Background
                            , new object[] { ProgressBar.ValueProperty, value }
                            );

                        if (ProgressBar1.Value == ProgressBar1.Maximum && ProgressBar.Value != ProgressBar.Maximum)
                        {
                            ProgressBar1.Value = 0;
                            value = 0;
                            ProgressBar.Value++;
                        }

                    }
                    while (ProgressBar1.Value != ProgressBar1.Maximum);
                    MessageBox.Show("完成");
                    button.IsEnabled = true;
                }
                else { MessageBox.Show("第一级值和第二级值不能为0");
            }
        }
    }
}
