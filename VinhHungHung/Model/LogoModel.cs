using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace VinhHungHung.Model
{
    public class LogoModel: INotifyPropertyChanged
    {
        private string param_1;
        private string param_2;

        public string Param_2
        {
            get { return param_2; }
            set { param_2 = value; }
        }
        private string param_3;

        public string Param_3
        {
            get { return param_3; }
            set { param_3 = value; }
        }
        private string param_4;

        public string Param_4
        {
            get { return param_4; }
            set { param_4 = value; }
        }
        private string param_5;

        public string Param_5
        {
            get { return param_5; }
            set { param_5 = value; }
        }
        private string param_6;

        public string Param_6
        {
            get { return param_6; }
            set { param_6 = value; }
        }

        public string Param_1
        {
            get { return param_1; }
            set { param_1 = value; }
        }

        public event PropertyChangedEventHandler PropertyChanged;

    }
}
