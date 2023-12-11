using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System.Xml.Linq;


namespace text_redactor
{

    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void test_button_Click(object sender, RoutedEventArgs e)
        {
            
        }
        private void txt_click(object sender, RoutedEventArgs e)
        {
            string name = textbox2.Text;
            if (name.Trim() == "")
            {
                MessageBox.Show("ошибка, введите имя файла");
            }
            else
            {
                string path = @"C:\\Users\\User\\Desktop\\яблочный спас всех спас\\c#\\" + name + @".txt";
                string text = textbox1.Text;
                try
                {
                    File.WriteAllText(path, text);

                    MessageBox.Show("текстовый файл создан.");
                }
                catch
                {
                    MessageBox.Show("Ошибка");
                }
            }
        }
        private void docx_click(object sender, RoutedEventArgs e)
        {
            string name = textbox2.Text;
            string text = textbox1.Text;
            string path = @"C:\\Users\\User\\Desktop\\яблочный спас всех спас\\c#\\" + name + @".docx";

            string filePath = path;

            try
            {
                using (WordprocessingDocument wordDocument = WordprocessingDocument.Create(filePath, WordprocessingDocumentType.Document))
                {
                    MainDocumentPart mainPart = wordDocument.AddMainDocumentPart();
                    mainPart.Document = new Document();
                    Body body = mainPart.Document.AppendChild(new Body());

                    DocumentFormat.OpenXml.Wordprocessing.Paragraph paragraph = body.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Paragraph());
                    DocumentFormat.OpenXml.Wordprocessing.Run run = paragraph.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Run());
                    run.AppendChild(new Text(text));
                }

                MessageBox.Show("документ создан");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка");
            }
    }
        private void save_click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("saved");
        }
        private void open_click(object sender, RoutedEventArgs e)
        {
         
        }
    }
}
