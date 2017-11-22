using HyperionScreenCap.Model;
using log4net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HyperionScreenCap
{
    public partial class ServerPropertiesForm : Form
    {
        private static readonly ILog LOG = LogManager.GetLogger(typeof(ServerPropertiesForm));

        public HyperionTaskConfiguration TaskConfiguration { get; private set; }
        public bool SaveRequested { get; private set; }

        public ServerPropertiesForm(HyperionTaskConfiguration taskConfiguration)
        {
            this.TaskConfiguration = taskConfiguration;
            this.Text = $"{this.Text} - {taskConfiguration.Id}";
            InitializeComponent();
            InitFormFields();
        }

        private void InitFormFields()
        {
            EnableRelevantDxFields(TaskConfiguration.CaptureMethod);

            SelectValueFromComboBox(cbDx11AdapterIndex, TaskConfiguration.Dx11AdapterIndex); // TODO check item list for each combo box
            SelectValueFromComboBox(cbDx11MonitorIndex, TaskConfiguration.Dx11MonitorIndex);
            tbDx11FrameCaptureTimeout.Text = TaskConfiguration.Dx11FrameCaptureTimeout.ToString();
            SelectValueFromComboBox(cbDx11ImageScalingFactor, TaskConfiguration.Dx11ImageScalingFactor);
            tbDx11MaxFps.Text = TaskConfiguration.Dx11MaxFps.ToString();
            SelectValueFromComboBox(cbDx9MonitorIndex, TaskConfiguration.Dx9MonitorIndex);
            tbDx9CaptureWidth.Text = TaskConfiguration.Dx9CaptureWidth.ToString();
            tbDx9CaptureHeight.Text = TaskConfiguration.Dx9CaptureHeight.ToString();
            tbDx9CaptureInterval.Text = TaskConfiguration.Dx9CaptureInterval.ToString();

            var hyperionServersBindingList = new BindingList<HyperionServer>(TaskConfiguration.HyperionServers);
            var hyperionServersDataSource = new BindingSource(hyperionServersBindingList, null);
            dgHyperionAddress.DataSource = hyperionServersDataSource;
        }

        private void EnableRelevantDxFields(CaptureMethod captureMethod)
        {
            switch(captureMethod)
            {
                case CaptureMethod.DX11:
                    rbcmDx11.Checked = true;
                    cbDx9MonitorIndex.Enabled = false;
                    tbDx9CaptureWidth.Enabled = false;
                    tbDx9CaptureHeight.Enabled = false;
                    tbDx9CaptureInterval.Enabled = false;
                    cbDx11AdapterIndex.Enabled = true;
                    cbDx11MonitorIndex.Enabled = true;
                    tbDx11FrameCaptureTimeout.Enabled = true;
                    cbDx11ImageScalingFactor.Enabled = true;
                    tbDx11MaxFps.Enabled = true;
                    break;

                case CaptureMethod.DX9:
                    rbcmDx9.Checked = true;
                    cbDx11AdapterIndex.Enabled = false;
                    cbDx11MonitorIndex.Enabled = false;
                    tbDx11FrameCaptureTimeout.Enabled = false;
                    cbDx11ImageScalingFactor.Enabled = false;
                    tbDx11MaxFps.Enabled = false;
                    cbDx9MonitorIndex.Enabled = true;
                    tbDx9CaptureWidth.Enabled = true;
                    tbDx9CaptureHeight.Enabled = true;
                    tbDx9CaptureInterval.Enabled = true;
                    break;

                default:
                    throw new NotImplementedException($"The capture method {captureMethod} is not supported");
            }
        }

        private static void SelectValueFromComboBox(ComboBox comboBox, Object value)
        {
            var valueAsString = value.ToString();
            int indexToSelect = 0;
            foreach ( object obj in comboBox.Items )
            {
                if ( obj.Equals(valueAsString) )
                {
                    comboBox.SelectedIndex = indexToSelect;
                    return;
                }
                indexToSelect++;
            }
            LOG.Error($"Unable to select value {value} from comboBox {comboBox.Name}");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // TODO validate all fields
            SaveRequested = true;
            Close();
        }

        private void ServerPropertiesForm_Shown(object sender, EventArgs e)
        {
            SaveRequested = false;
        }

        private void dgHyperionAddress_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(PreventNonNumeric_KeyPressEventHandler);
            // Only columnIndex 0 is allowed to have non-numeric characters
            if ( dgHyperionAddress.CurrentCell.ColumnIndex > 0 )
            {
                e.Control.KeyPress += new KeyPressEventHandler(PreventNonNumeric_KeyPressEventHandler);
            }
        }

        private void PreventNonNumeric_KeyPressEventHandler(object sender, KeyPressEventArgs e)
        {
            if ( !char.IsDigit(e.KeyChar) )
            {
                e.Handled = true;
            }
        }

        private void dgHyperionAddress_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            HyperionServer defaultServerConfiguration = HyperionServer.BuildUsingDefaultSettings();
            e.Row.Cells[0].Value = defaultServerConfiguration.Host;
            e.Row.Cells[1].Value = defaultServerConfiguration.Port;
            e.Row.Cells[2].Value = defaultServerConfiguration.Priority;
            e.Row.Cells[3].Value = defaultServerConfiguration.MessageDuration;
        }

        private void rbcmDx11_CheckedChanged(object sender, EventArgs e)
        {
            if ( rbcmDx11.Checked )
                EnableRelevantDxFields(CaptureMethod.DX11);
            else
                EnableRelevantDxFields(CaptureMethod.DX9);
        }

    }
}
