using System;
using System.Collections;
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
using VinhHungHung.CustomControl;
using VinhHungHung.Model;
using System.Windows.Xps.Packaging;
using System.Printing;
using System.Windows.Xps;
using System.IO;
using VinhHungHung.View;

namespace VinhHungHung
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Max of column on logo grid
        /// </summary>
        public const Int16 MAX_COLUMN = 6;
        //    LogoModel logo = new LogoModel()
        //    {
        //        Param1 = "40/2"
        //    };
        public MainWindow()
        {
            InitializeComponent();
            //this.DataContext = logo;
        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            // ctrlLogo.Param1 = "abc";
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Logo logo = new Logo();
            logo.Width = 302;
            logo.Height = 302;
            logo.IsEditable = true;
            logo.CanChangeQty = true;
            lstLogo.Items.Add(logo);
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            // Check if list contain items
            if (lstLogo.Items.Count > 0)
            {
                if (lstLogo.SelectedIndex == -1)
                {
                    // Not selected any item -> Remove last
                    lstLogo.Items.RemoveAt(lstLogo.Items.Count - 1);
                }
                else
                {
                    // Remove selected item
                    lstLogo.Items.RemoveAt(lstLogo.SelectedIndex);
                }
                
            }
        }

        async private void btnPrint_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog printDlg = new PrintDialog();
            if (printDlg.ShowDialog() == true)
            {
                //printDialog.PrintVisual(aa, "My First Print Job");
                //printDialog.PrintDocument(((IDocumentPaginatorSource)printArea).DocumentPaginator, "printfilename");
                //System.Printing.PrintCapabilities capabilities = printDlg.PrintQueue.GetPrintCapabilities(printDlg.PrintTicket);

                //double scale = Math.Min(capabilities.PageImageableArea.ExtentWidth / printArea.ActualWidth, capabilities.PageImageableArea.ExtentHeight /

                //myscrollvier.ActualHeight);

                //myscrollvier.LayoutTransform = new ScaleTransform(scale, scale);

                //Size sz = new Size(capabilities.PageImageableArea.ExtentWidth, capabilities.PageImageableArea.ExtentHeight);

                ////update the layout of the visual to the printer page size.

                //myscrollvier.Measure(sz);

                //myscrollvier.Arrange(new Rect(new Point(capabilities.PageImageableArea.OriginWidth, capabilities.PageImageableArea.OriginHeight), sz));
                ////now print the visual to printer to fit on the one page.

                //printDlg.PrintVisual(myscrollvier, "First Fit to Page WPF Print");
            }
            //PrintDialog printDialog = new PrintDialog();
            //if (printDialog.ShowDialog() == true)
            //{
            //    printDialog.PrintVisual(gridReport, "Print Report");
            //}
            DoPreview("asdf");
        }
        private void handlePrintPreview()
        {
            gridData.Children.Clear();
            int i = 0;
            Brush color = Brushes.Yellow;
            foreach (var item in lstLogo.Items)
            {
                for (int j = 0; j < ((Logo)item).Quantity; j++)
                {
                    int index = i % 6;
                    int rowIdx = i / 6;
                    if (index == 0)
                    {
                        RowDefinition row = new RowDefinition();
                        gridData.RowDefinitions.Add(row);
                    }
                    Logo logo = new Logo((Logo)item);
                    logo.Width = 130;
                    logo.Height = 130;
                    logo.Background = color;
                    Grid.SetRow(logo, rowIdx);
                    Grid.SetColumn(logo, index);
                    gridData.Children.Add(logo);
                    i++;
                }
                if (color == Brushes.Yellow)
                {
                    color = Brushes.Orange;
                }
                else
                {
                    color = Brushes.Yellow;
                }
            }
        }

        private void btnPreview_Click(object sender, RoutedEventArgs e)
        {
            this.Dispatcher.Invoke(() => handlePrintPreview());
        }
        private string _previewWindowXaml = @"<Window
                                                xmlns                 ='http://schemas.microsoft.com/netfx/2007/xaml/presentation'
                                                xmlns:x               ='http://schemas.microsoft.com/winfx/2006/xaml'
                                                Title                 ='Print Preview - @@TITLE'
                                                Height                ='200'
                                                Width                 ='300'
                                                WindowStartupLocation ='CenterOwner'>
                                                <DocumentViewer Name='dv1'/>
                                             </Window>";

        internal void DoPreview(string title)
        {
            string fileName = System.IO.Path.GetRandomFileName();
            FlowDocumentScrollViewer visual = (FlowDocumentScrollViewer)(aa);
            try
            {
                // write the XPS document
                using (XpsDocument doc = new XpsDocument(fileName, FileAccess.ReadWrite))
                {
                    XpsDocumentWriter writer = XpsDocument.CreateXpsDocumentWriter(doc);
                    writer.Write(visual);
                }

                // Read the XPS document into a dynamically generated
                // preview Window 
                using (XpsDocument doc = new XpsDocument(fileName, FileAccess.Read))
                {
                    FixedDocumentSequence fds = doc.GetFixedDocumentSequence();

                    string s = _previewWindowXaml;
                    s = s.Replace("@@TITLE", title.Replace("'", "&apos;"));

                    using (var reader = new System.Xml.XmlTextReader(new StringReader(s)))
                    {
                        Window preview = System.Windows.Markup.XamlReader.Load(reader) as Window;

                        DocumentViewer dv1 = LogicalTreeHelper.FindLogicalNode(preview, "dv1") as DocumentViewer;
                        dv1.Document = fds as IDocumentPaginatorSource;


                        preview.ShowDialog();
                    }
                }
            }
            finally
            {
                if (File.Exists(fileName))
                {
                    try
                    {
                        File.Delete(fileName);
                    }
                    catch
                    {
                    }
                }
            }
        }

        private void btnLogoManager_Click(object sender, RoutedEventArgs e)
        {
            LogoManager logoMan = new LogoManager();
            logoMan.ShowDialog();
        } 
    }
}
