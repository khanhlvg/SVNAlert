﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SVNAlert.UI
{
    public partial class LoadingForm : Form
    {

        public LoadingForm()
        {
            InitializeComponent();
        }

        public LoadingForm(String message)
            : this()
        {
            this.messageLabel.Text = message;
        }
    }
}
