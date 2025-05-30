﻿///////////////////////////////////////////////////////////////////////////////
//
//    (C) Copyright 2011 EaseFilter Technologies
//    All Rights Reserved
//
//    This software is part of a licensed software product and may
//    only be used or copied in accordance with the terms of that license.
//
//    NOTE:  THIS MODULE IS UNSUPPORTED SAMPLE CODE
//
//    This module contains sample code provided for convenience and
//    demonstration purposes only,this software is provided on an 
//    "AS-IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, 
//     either express or implied.  
//
///////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using EaseFilter.FilterControl;

namespace EaseFilter.CommonObjects
{
    public partial class FilterRuleForm : Form
    {
        FileFilter fileFilter = null;
        bool isNewFileFilter = true;

        public FilterRuleForm()
        {
            //create a new filter rule as the default filter rule.
            fileFilter = new FileFilter("c:\\test\\*");
            
            fileFilter.FileChangeEventFilter = (FilterAPI.FileChangedEvents.NotifyFileWasCreated | FilterAPI.FileChangedEvents.NotifyFileWasDeleted | FilterAPI.FileChangedEvents.NotifyFileInfoWasChanged
                | FilterAPI.FileChangedEvents.NotifyFileWasRenamed | FilterAPI.FileChangedEvents.NotifyFileWasWritten | FilterAPI.FileChangedEvents.NotifyFileSecurityWasChanged | FilterAPI.FileChangedEvents.NotifyFileWasRead);

            fileFilter.EnableMonitorEventBuffer = true;
            fileFilter.EncryptWriteBufferSize = 1048576;

            InitializeFilterRuleForm();
        }

        public FilterRuleForm(FileFilter _fileFilter)
        {
            isNewFileFilter = false;
            fileFilter = _fileFilter;
            InitializeFilterRuleForm();
        }

        private void InitializeFilterRuleForm()
        {
            InitializeComponent();

            textBox_IncludeFilterMask.Text = fileFilter.IncludeFileFilterMask;
            textBox_ExcludeFilterMask.Text = fileFilter.ExcludeFileFilterMaskString;
            textBox_SelectedEvents.Text = ((uint)fileFilter.FileChangeEventFilter).ToString();
            textBox_IncludePID.Text = fileFilter.IncludeProcessIdString;
            textBox_ExcludePID.Text = fileFilter.ExcludeProcessIdString;
            textBox_ExcludeProcessNames.Text = fileFilter.ExcludeProcessNameString;
            textBox_IncludeProcessNames.Text = fileFilter.IncludeProcessNameString;
            textBox_ExcludeUserNames.Text = fileFilter.ExcludeUserNameString;
            textBox_IncludeUserNames.Text = fileFilter.IncludeUserNameString;
            textBox_MonitorIO.Text = fileFilter.MonitorFileIOEventFilter.ToString();
            textBox_FilterDesiredAccess.Text = fileFilter.FilterDesiredAccess.ToString();
            textBox_FilterDisposition.Text = fileFilter.FilterDisposition.ToString();
            textBox_FilterCreateOptions.Text = fileFilter.FilterCreateOptions.ToString();
            checkBox_MonitorEventBuffer.Checked = fileFilter.EnableMonitorEventBuffer;

            if (GlobalConfig.filterType == FilterAPI.FilterType.MONITOR_FILTER)
            {
                button_ControlSettings.Visible = false;
            }
        }

        private void button_SaveFilter_Click(object sender, EventArgs e)
        {
            if (textBox_IncludeFilterMask.Text.Trim().Length == 0)
            {
                MessageBoxHelper.PrepToCenterMessageBoxOnForm(this);
                MessageBox.Show("The include filter mask can't be empty.", "Add Filter Rule", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(!isNewFileFilter)
            {
                GlobalConfig.RemoveFileFilter(fileFilter.IncludeFileFilterMask);
            }

            //include filter mask must be unique, but it can have multiple exclude filter masks associate to the same include filter mask.
            fileFilter.IncludeFileFilterMask = textBox_IncludeFilterMask.Text;
            fileFilter.ExcludeFileFilterMaskString = textBox_ExcludeFilterMask.Text;
            fileFilter.IncludeProcessNameString = textBox_IncludeProcessNames.Text;
            fileFilter.ExcludeProcessNameString = textBox_ExcludeProcessNames.Text;
            fileFilter.IncludeUserNameString = textBox_IncludeUserNames.Text;
            fileFilter.ExcludeUserNameString = textBox_ExcludeUserNames.Text;
            fileFilter.IncludeProcessIdString = textBox_IncludePID.Text;
            fileFilter.ExcludeProcessIdString = textBox_ExcludePID.Text;
            fileFilter.FileChangeEventFilter = (FilterAPI.FileChangedEvents)uint.Parse(textBox_SelectedEvents.Text);
            fileFilter.MonitorFileIOEventFilter = (MonitorFileIOEvents)ulong.Parse(textBox_MonitorIO.Text);
            fileFilter.FilterDesiredAccess = uint.Parse(textBox_FilterDesiredAccess.Text);
            fileFilter.FilterDisposition = uint.Parse(textBox_FilterDisposition.Text);
            fileFilter.FilterCreateOptions = uint.Parse(textBox_FilterCreateOptions.Text);
            fileFilter.EnableMonitorEventBuffer = checkBox_MonitorEventBuffer.Checked;

            GlobalConfig.AddFileFilter(fileFilter);

            this.Close();
        }


        private void button_SelectIncludePID_Click(object sender, EventArgs e)
        {

            OptionForm optionForm = new OptionForm(OptionForm.OptionType.ProccessId, textBox_IncludePID.Text);

            if (optionForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBox_IncludePID.Text = optionForm.ProcessId;
            }
        }

        private void button_SelectExcludePID_Click(object sender, EventArgs e)
        {

            OptionForm optionForm = new OptionForm(OptionForm.OptionType.ProccessId, textBox_ExcludePID.Text);

            if (optionForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBox_ExcludePID.Text = optionForm.ProcessId;
            }
        }

        private void button_SelectedEvents_Click(object sender, EventArgs e)
        {
            OptionForm optionForm = new OptionForm(OptionForm.OptionType.MonitorFileEvents, textBox_SelectedEvents.Text);

            if (optionForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBox_SelectedEvents.Text = optionForm.MonitorFileEvents.ToString();
            }
        }

        private void button_RegisterMonitorIO_Click(object sender, EventArgs e)
        {
            OptionForm optionForm = new OptionForm(OptionForm.OptionType.MonitorFileIOEvents, textBox_MonitorIO.Text,true);

            if (optionForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBox_MonitorIO.Text = optionForm.MonitorIOEvents.ToString();
            }
        }

        private void button_FilterDesiredAccess_Click(object sender, EventArgs e)
        {
            OptionForm optionForm = new OptionForm(OptionForm.OptionType.FilterDesiredAccess, textBox_FilterDesiredAccess.Text);

            if (optionForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBox_FilterDesiredAccess.Text = optionForm.FilterDesiredAccess.ToString();
            }
        }

        private void button_FilterDisposition_Click(object sender, EventArgs e)
        {
            OptionForm optionForm = new OptionForm(OptionForm.OptionType.FilterDisposition, textBox_FilterDisposition.Text);

            if (optionForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBox_FilterDisposition.Text = optionForm.FilterDisposition.ToString();
            }
        }

        private void button_FilterCreateOptions_Click(object sender, EventArgs e)
        {
            OptionForm optionForm = new OptionForm(OptionForm.OptionType.FilterCreateOptions, textBox_FilterCreateOptions.Text);

            if (optionForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBox_FilterCreateOptions.Text = optionForm.FilterCreateOptions.ToString();
            }
        }      


        private void button_ControlSettings_Click(object sender, EventArgs e)
        {
            ControlFilterRuleSettigs controlSettingForm = new ControlFilterRuleSettigs(fileFilter);

            if (controlSettingForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                fileFilter = controlSettingForm.fileFilter;
            }
        }

        private void button_InfoFilterMask_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Input managed file filter mask with wild card character '*', it is unique index of the filter rule, to filter map drive file, you can use the filter mask like this: '*\\192.168.1.1\\shareName\\foldername\\*'");
        }

        private void button_InfoExcludeFileFilterMask_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Skip all the I/Os which the file name matches the exclude file filter mask, seperated with ';' for multiple exclude file filter masks.");
        }

        private void button_InfoIncludeProcessName_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Only the IOs which were initiated by the process of the include process name list will be monitored or controlled by the filter driver for this filter rule.");
        }

        private void button_InfoExcludeProcessName_Click(object sender, EventArgs e)
        {
            MessageBox.Show("All the IOs which were initiated by the process of the exclude process name list will be skipped by the filter driver for this filter rule.");
        }

        private void button_InfoIncludeUserName_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Only the IOs which were initiated by the user of the include user name list will be monitored or controlled by the filter driver for this filter rule.");
        }

        private void button_InfoExcludeUserName_Click(object sender, EventArgs e)
        {
            MessageBox.Show("All the IOs which were initiated by the process of the exclude user name list will be skipped by the filter driver for this filter rule.");
        }

        private void button_InfoDesiredAccess_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Skip the IOs when the CreateFile DesiredAccess doesn't match any bit of the value if the DesiredAccess is not zero.");
        }

        private void button_InfoDisposition_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Skip the IOs when the CreateFile's Disposition doesn't match any bit of the value if the Disposition is not zero.");
        }

        private void button_InfoCreatOptions_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Skip the IOs when the CreateFile's CreatOptions doesn't match any bit of the value if the CreatOptions is not zero.");
        }

        private void button_InfoFileEvents_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Get the notification after the registered file event was fired and the file handle was closed, you will get only one event even the file was read/written many times before it was closed.");
        }

        private void button_InfoMonitorIO_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Get the notfication right after the registered IO was fired, the file handle is not closed, you will get as many events as the times of the file was read/written if it was registered.");
        }

        private void button_MonitorBufferInfo_Click(object sender, EventArgs e)
        {
            string info = "Enable the filter driver to send the monitor events to the user mode service asynchronously,"
                        + "or the filter driver will send the monitor events synchronously, block and wait till the events being picked up.";
            MessageBox.Show(info);
        }

      
    }
}
