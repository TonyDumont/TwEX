using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TwEX_API.Controls
{
    public partial class DBPreferenceControl : UserControl
    {
        #region Initialize
        public DBPreferenceControl()
        {
            InitializeComponent();
        }
        private void DBPreferenceControl_Load(object sender, EventArgs e)
        {
            checkBox_UseDB.Checked = PreferenceManager.preferences.UseDB;
            tableLayoutPanel.Enabled = PreferenceManager.preferences.UseDB;
            textBox_DBSource.Text = PreferenceManager.preferences.DBSource;
            textBox_DBName.Text = PreferenceManager.preferences.DBName;
            textBox_DBID.Text = PreferenceManager.preferences.DBID;
            textBox_DBPassword.Text = PreferenceManager.preferences.DBPassword;
        }

        private void checkBox_UseDB_Click(object sender, EventArgs e)
        {
            PreferenceManager.preferences.UseDB = !PreferenceManager.preferences.UseDB;
            PreferenceManager.UpdatePreferenceFile();
            tableLayoutPanel.Enabled = PreferenceManager.preferences.UseDB;
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            PreferenceManager.preferences.DBSource = textBox_DBSource.Text;
            PreferenceManager.preferences.DBName = textBox_DBName.Text;
            PreferenceManager.preferences.DBID = textBox_DBID.Text;
            PreferenceManager.preferences.DBPassword = textBox_DBPassword.Text;
            PreferenceManager.UpdatePreferenceFile();

        }
        #endregion

    }
}
