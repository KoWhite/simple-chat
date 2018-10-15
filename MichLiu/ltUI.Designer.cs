namespace MichLiu
{
    partial class ltUI
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.sc = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // sc
            // 
            this.sc.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.sc.Location = new System.Drawing.Point(23, 16);
            this.sc.Multiline = true;
            this.sc.Name = "sc";
            this.sc.Size = new System.Drawing.Size(224, 43);
            this.sc.TabIndex = 0;
            // 
            // ltUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImage = global::MichLiu.Properties.Resources.lt2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.sc);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ltUI";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Size = new System.Drawing.Size(271, 76);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ltUI_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox sc;

    }
}
