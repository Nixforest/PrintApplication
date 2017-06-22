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
using VinhHungHung.Model;

namespace VinhHungHung.CustomControl
{
    /// <summary>
    /// Interaction logic for Logo.xaml
    /// </summary>
    public partial class Logo : UserControl
    {
        /// <summary>
        /// Flag is edit
        /// </summary>
        private bool isEdit = false;

        public bool IsEdit
        {
            get { return isEdit; }
            set { isEdit = value; }
        }
        LogoModel model = new LogoModel()
        {
            Param_1 = "20/3",
            Param_2 = "5000M",
            Param_3 = "Tkt No",
            Param_4 = "120",
            Param_5 = "CS6504"
        };

        public LogoModel Model
        {
            get { return model; }
            set { model = value; }
        }
        public Logo()
        {
            InitializeComponent();
            //this.DataContext = model;
            this.Param1 = model.Param_1;
            this.Param2 = model.Param_2;
            this.Param3 = model.Param_3;
            this.Param4 = model.Param_4;
            this.Param5 = model.Param_5;
            LayoutRoot.DataContext = this;
        }
        public Logo(Logo copy)
        {
            InitializeComponent();
            this.Param1 = copy.Param1;
            this.Param2 = copy.Param2;
            this.Param3 = copy.Param3;
            this.Param4 = copy.Param4;
            this.Param5 = copy.Param5;
            LayoutRoot.DataContext = this;
        }
        #region Dependency Properties
        // <summary>
        /// Identified the Param1 dependency property
        /// </summary>
        public static readonly DependencyProperty Param1Property =
            DependencyProperty.Register("Param1", typeof(String),
            typeof(Logo), new PropertyMetadata(""));
        /// <summary>
        /// Gets or sets the Label which is displayed next to the field
        /// </summary>
        public String Param1
        {
            get { return (String)GetValue(Param1Property); }
            set { SetValue(Param1Property, value); }
        }
        // <summary>
        /// Identified the Param2 dependency property
        /// </summary>
        public static readonly DependencyProperty Param2Property =
            DependencyProperty.Register("Param2", typeof(String),
            typeof(Logo), new PropertyMetadata(""));
        /// <summary>
        /// Gets or sets the Label which is displayed next to the field
        /// </summary>
        public String Param2
        {
            get { return (String)GetValue(Param2Property); }
            set { SetValue(Param2Property, value); }
        }
        // <summary>
        /// Identified the Param3 dependency property
        /// </summary>
        public static readonly DependencyProperty Param3Property =
            DependencyProperty.Register("Param3", typeof(String),
            typeof(Logo), new PropertyMetadata(""));
        /// <summary>
        /// Gets or sets the Label which is displayed next to the field
        /// </summary>
        public String Param3
        {
            get { return (String)GetValue(Param3Property); }
            set { SetValue(Param3Property, value); }
        }
        // <summary>
        /// Identified the Param4 dependency property
        /// </summary>
        public static readonly DependencyProperty Param4Property =
            DependencyProperty.Register("Param4", typeof(String),
            typeof(Logo), new PropertyMetadata(""));
        /// <summary>
        /// Gets or sets the Label which is displayed next to the field
        /// </summary>
        public String Param4
        {
            get { return (String)GetValue(Param4Property); }
            set { SetValue(Param4Property, value); }
        }
        // <summary>
        /// Identified the Param5 dependency property
        /// </summary>
        public static readonly DependencyProperty Param5Property =
            DependencyProperty.Register("Param5", typeof(String),
            typeof(Logo), new PropertyMetadata(""));
        /// <summary>
        /// Gets or sets the Label which is displayed next to the field
        /// </summary>
        public String Param5
        {
            get { return (String)GetValue(Param5Property); }
            set { SetValue(Param5Property, value); }
        }
        // <summary>
        /// Identified the isEditable dependency property
        /// </summary>
        public static readonly DependencyProperty IsEditableProperty =
            DependencyProperty.Register("IsEditable", typeof(Boolean),
            typeof(Logo), new PropertyMetadata(null));
        /// <summary>
        /// Gets or sets the Label which is displayed next to the field
        /// </summary>
        public Boolean IsEditable
        {
            get { return (Boolean)GetValue(IsEditableProperty); }
            set
            {
                SetValue(IsEditableProperty, value);
                if (IsEditable)
                {
                    btnEdit.Visibility = Visibility.Visible;
                }
                else
                {
                    btnEdit.Visibility = Visibility.Hidden;
                }
            }
        }
        // <summary>
        /// Identified the Quantity dependency property
        /// </summary>
        public static readonly DependencyProperty QuantityProperty =
            DependencyProperty.Register("Quantity", typeof(Int16),
            typeof(Logo), new PropertyMetadata(null));
        /// <summary>
        /// Gets or sets the Label which is displayed next to the field
        /// </summary>
        public Int16 Quantity
        {
            get { return (Int16)GetValue(QuantityProperty); }
            set { SetValue(QuantityProperty, value); }
        }
        // <summary>
        /// Identified the CanChangeQty dependency property
        /// </summary>
        public static readonly DependencyProperty CanChangeQtyProperty =
            DependencyProperty.Register("CanChangeQty", typeof(Boolean),
            typeof(Logo), new PropertyMetadata(null));
        /// <summary>
        /// Gets or sets the Label which is displayed next to the field
        /// </summary>
        public Boolean CanChangeQty
        {
            get { return (Boolean)GetValue(CanChangeQtyProperty); }
            set
            {
                SetValue(CanChangeQtyProperty, value);
                if (CanChangeQty)
                {
                    tbxQty.Visibility = Visibility.Visible;
                }
                else
                {
                    tbxQty.Visibility = Visibility.Hidden;
                }
            }
        }
        #endregion

        /// <summary>
        /// Handle show/hide edit controls
        /// </summary>
        /// <param name="isEdit">Flag is edit</param>
        private void showEditControls(bool isEdit = true)
        {
            showTextboxControls(isEdit);
            showLabelControls(!isEdit);
        }

        /// <summary>
        /// Show textbox controls
        /// </summary>
        /// <param name="isShow">Flag is show</param>
        private void showTextboxControls(bool isShow = true)
        {
            if (isShow)
            {
                tbxParam1.Visibility = Visibility.Visible;
                tbxParam2.Visibility = Visibility.Visible;
                tbxParam3.Visibility = Visibility.Visible;
                tbxParam4.Visibility = Visibility.Visible;
                tbxParam5.Visibility = Visibility.Visible;
            }
            else
            {
                tbxParam1.Visibility = Visibility.Hidden;
                tbxParam2.Visibility = Visibility.Hidden;
                tbxParam3.Visibility = Visibility.Hidden;
                tbxParam4.Visibility = Visibility.Hidden;
                tbxParam5.Visibility = Visibility.Hidden;
            }
        }

        /// <summary>
        /// Show label controls
        /// </summary>
        /// <param name="isShow">Flag is show</param>
        private void showLabelControls(bool isShow = true)
        {
            if (isShow)
            {
                lblParam1.Visibility = Visibility.Visible;
                lblParam2.Visibility = Visibility.Visible;
                lblParam3.Visibility = Visibility.Visible;
                lblParam4.Visibility = Visibility.Visible;
                lblParam5.Visibility = Visibility.Visible;
            }
            else
            {
                lblParam1.Visibility = Visibility.Hidden;
                lblParam2.Visibility = Visibility.Hidden;
                lblParam3.Visibility = Visibility.Hidden;
                lblParam4.Visibility = Visibility.Hidden;
                lblParam5.Visibility = Visibility.Hidden;
            }
        }

        /// <summary>
        /// Handle editable
        /// </summary>
        /// <param name="isEdit">Flag is edit</param>
        private void handleEditable(bool isEdit)
        {
            if (isEdit)
            {
                btnEdit.Content = "Lưu";
            }
            else
            {
                btnEdit.Content = "Sửa";
            }
            showEditControls(isEdit);
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (!IsEditable)
            {
                return;
            }
            isEdit = !isEdit;
            handleEditable(isEdit);
        }
        protected override void OnRenderSizeChanged(SizeChangedInfo sizeInfo)
        {
            if (sizeInfo.WidthChanged) this.Width = sizeInfo.NewSize.Height * 1;
            else this.Height = sizeInfo.NewSize.Width / 1;
        }

        private void UserControl_Initialized_1(object sender, EventArgs e)
        {
            if (IsEditable)
            {
                btnEdit.Visibility = Visibility.Visible;
            }
            else
            {
                btnEdit.Visibility = Visibility.Hidden;
            }
            if (CanChangeQty)
            {
                tbxQty.Visibility = Visibility.Visible;
            }
            else
            {
                tbxQty.Visibility = Visibility.Hidden;
            }
        }
    }
}
