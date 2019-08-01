using ConsoleTester.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeifenLuo.WinFormsUI.Docking;

namespace ConsoleTester.UI
{
    public class ControlConfigUI : DockContent, IControlConfig
    {
        public static Logger Logger { get; } = new Logger(MainForm.LogControl);

        public virtual bool IsVisibleInReleaseMode()
        {
            return true;
        }

        public virtual void CreateNewWS()
        {
            // TO IMPLEMENT in each ControlConfig
        }


        public virtual void CreateWS(FileInfo item)
        {
            // TO IMPLEMENT in each ControlConfig
            throw new NotImplementedException();
        }

        public virtual void SaveWorkspace()
        {
            Helper.SaveWorkspace(GetWorkspaceFilename(), GetConfigFromUI());
        }

        public virtual string GetDefaultWorkspaceFilename()
        {
            throw new NotImplementedException();
        }

        public virtual string GetWorkspaceFilename()
        {
            throw new NotImplementedException();
        }
        public virtual void SetWorkspaceFilename(string filename)
        {
            throw new NotImplementedException();
        }

        public virtual IConfigService GetConfigFromUI()
        {
            throw new NotImplementedException();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // ControlConfig
            // 
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Name = "ControlConfig";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ControlConfig_FormClosing);
            this.ResumeLayout(false);

        }

        private void ControlConfig_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            SaveWorkspace();
        }
    }
}