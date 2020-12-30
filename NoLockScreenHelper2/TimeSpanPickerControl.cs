using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoLockScreenHelper2
{
    public partial class TimeSpanPickerControl : UserControl
    {
        public TimeSpanPickerControl()
        {
            InitializeComponent();
        }

        public TimeSpan TimeSpan
        {
            get { return new TimeSpan((int)numericUpDownHours.Value, (int)numericUpDownMinutes.Value, (int)numericUpDownSeconds.Value); } 
            set {
                int hrs = (int)value.TotalHours;
                numericUpDownHours.Value = hrs < 1000 ? hrs : 999;
                numericUpDownMinutes.Value = value.Minutes;
                numericUpDownSeconds.Value = value.Seconds;
            }
        }

        public string LabelHours { get { return labelHours.Text; } set { labelHours.Text = value; } }
        public string LabelMinutes { get { return labelMinutes.Text; } set { labelMinutes.Text = value; } }
        public string LabelSeconds { get { return labelSeconds.Text; } set { labelSeconds.Text = value; } }
    }
}
