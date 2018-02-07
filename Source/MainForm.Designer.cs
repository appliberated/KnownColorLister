namespace KnownColorLister
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.uiWebBrowser = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // uiWebBrowser
            // 
            this.uiWebBrowser.AllowNavigation = false;
            this.uiWebBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiWebBrowser.IsWebBrowserContextMenuEnabled = false;
            this.uiWebBrowser.Location = new System.Drawing.Point(0, 0);
            this.uiWebBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.uiWebBrowser.Name = "uiWebBrowser";
            this.uiWebBrowser.Size = new System.Drawing.Size(784, 486);
            this.uiWebBrowser.TabIndex = 0;
            this.uiWebBrowser.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.EventUiWebBrowserPreviewKeyDown);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 486);
            this.Controls.Add(this.uiWebBrowser);
            this.MinimumSize = new System.Drawing.Size(640, 300);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KnownColorLister";
            this.Activated += new System.EventHandler(this.EventMainFormActivated);
            this.Load += new System.EventHandler(this.EventMainFormLoad);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser uiWebBrowser;
    }
}

