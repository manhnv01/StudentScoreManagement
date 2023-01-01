
namespace BTL_HSK
{
    partial class DoiMK
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DoiMK));
            this.btnDoiMK = new System.Windows.Forms.Button();
            this.btnLamTrong = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMatKhauOld = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMatKhauNew = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNhapLaiMatKhauNew = new System.Windows.Forms.TextBox();
            this.cbhienmk = new System.Windows.Forms.CheckBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDoiMK
            // 
            this.btnDoiMK.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnDoiMK.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnDoiMK.ForeColor = System.Drawing.Color.White;
            this.btnDoiMK.Location = new System.Drawing.Point(160, 240);
            this.btnDoiMK.Name = "btnDoiMK";
            this.btnDoiMK.Size = new System.Drawing.Size(156, 37);
            this.btnDoiMK.TabIndex = 4;
            this.btnDoiMK.Text = "Đổi Mật Khẩu";
            this.btnDoiMK.UseVisualStyleBackColor = false;
            this.btnDoiMK.Click += new System.EventHandler(this.btnDoiMK_Click);
            // 
            // btnLamTrong
            // 
            this.btnLamTrong.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnLamTrong.Location = new System.Drawing.Point(424, 240);
            this.btnLamTrong.Name = "btnLamTrong";
            this.btnLamTrong.Size = new System.Drawing.Size(144, 37);
            this.btnLamTrong.TabIndex = 5;
            this.btnLamTrong.Text = "Làm Trống";
            this.btnLamTrong.UseVisualStyleBackColor = true;
            this.btnLamTrong.Click += new System.EventHandler(this.btnLamTrong_Click);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(157, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mật Khẩu Hiện Tại:";
            // 
            // txtMatKhauOld
            // 
            this.txtMatKhauOld.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtMatKhauOld.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtMatKhauOld.Location = new System.Drawing.Point(322, 68);
            this.txtMatKhauOld.Name = "txtMatKhauOld";
            this.txtMatKhauOld.Size = new System.Drawing.Size(246, 22);
            this.txtMatKhauOld.TabIndex = 1;
            this.txtMatKhauOld.UseSystemPasswordChar = true;
            this.txtMatKhauOld.Validating += new System.ComponentModel.CancelEventHandler(this.txtMatKhauOld_Validating);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(157, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "Mật Khẩu Mới:";
            // 
            // txtMatKhauNew
            // 
            this.txtMatKhauNew.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtMatKhauNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtMatKhauNew.Location = new System.Drawing.Point(322, 106);
            this.txtMatKhauNew.Name = "txtMatKhauNew";
            this.txtMatKhauNew.Size = new System.Drawing.Size(246, 22);
            this.txtMatKhauNew.TabIndex = 2;
            this.txtMatKhauNew.UseSystemPasswordChar = true;
            this.txtMatKhauNew.Validating += new System.ComponentModel.CancelEventHandler(this.txtMatKhauNew_Validating);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(157, 146);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(159, 17);
            this.label4.TabIndex = 1;
            this.label4.Text = "Nhập Lại Mật Khẩu Mới:";
            // 
            // txtNhapLaiMatKhauNew
            // 
            this.txtNhapLaiMatKhauNew.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtNhapLaiMatKhauNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtNhapLaiMatKhauNew.Location = new System.Drawing.Point(322, 143);
            this.txtNhapLaiMatKhauNew.Name = "txtNhapLaiMatKhauNew";
            this.txtNhapLaiMatKhauNew.Size = new System.Drawing.Size(246, 22);
            this.txtNhapLaiMatKhauNew.TabIndex = 3;
            this.txtNhapLaiMatKhauNew.UseSystemPasswordChar = true;
            this.txtNhapLaiMatKhauNew.Validating += new System.ComponentModel.CancelEventHandler(this.txtNhapLaiMatKhauNew_Validating);
            // 
            // cbhienmk
            // 
            this.cbhienmk.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbhienmk.AutoSize = true;
            this.cbhienmk.BackColor = System.Drawing.Color.White;
            this.cbhienmk.Location = new System.Drawing.Point(322, 172);
            this.cbhienmk.Name = "cbhienmk";
            this.cbhienmk.Size = new System.Drawing.Size(123, 21);
            this.cbhienmk.TabIndex = 6;
            this.cbhienmk.Text = "Hiện Mật Khẩu";
            this.cbhienmk.UseVisualStyleBackColor = false;
            this.cbhienmk.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackgroundImage = global::BTL_HSK.Properties.Resources.download;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(631, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 104);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // DoiMK
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(743, 366);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.cbhienmk);
            this.Controls.Add(this.txtNhapLaiMatKhauNew);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnDoiMK);
            this.Controls.Add(this.txtMatKhauNew);
            this.Controls.Add(this.txtMatKhauOld);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnLamTrong);
            this.Controls.Add(this.label4);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(761, 413);
            this.Name = "DoiMK";
            this.Text = "Đổi Mật Khẩu";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDoiMK;
        private System.Windows.Forms.Button btnLamTrong;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMatKhauOld;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMatKhauNew;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNhapLaiMatKhauNew;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.CheckBox cbhienmk;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}