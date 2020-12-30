using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoLockScreenHelper2
{
    public partial class TimeSpanPicker : Form
    {
        public TimeSpanPicker()
        {
            InitializeComponent();
        }
        public TimeSpanPicker(TimeSpan timeSpan) : this()
        {
            Timespan = timeSpan;
        }
        public TimeSpan Timespan { get { return timeSpanPickerControl1.TimeSpan; } set { timeSpanPickerControl1.TimeSpan = value; } }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
