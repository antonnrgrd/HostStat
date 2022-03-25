
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace HostStatGuiComponents{
    class HostStatUI{
        private Container components;
        private AutoScaleMode mode;
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.mode = System.Windows.Forms.AutoScaleMode.Font;
        }
        public HostStatUI(){
            InitializeComponent();
        }
    }
}