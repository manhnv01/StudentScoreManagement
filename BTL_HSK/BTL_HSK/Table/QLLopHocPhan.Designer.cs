
namespace BTL_HSK
{
    partial class QLLopHocPhan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QLLopHocPhan));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtTenGV = new System.Windows.Forms.Label();
            this.txtMaLHP = new System.Windows.Forms.TextBox();
            this.txtMaGV = new System.Windows.Forms.ComboBox();
            this.txtMaMon = new System.Windows.Forms.ComboBox();
            this.txtThoiGianKetThuc = new System.Windows.Forms.DateTimePicker();
            this.txtThoiGianBatDau = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnTaiLai = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tbLopHocPhan = new System.Windows.Forms.DataGridView();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbLopHocPhan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.txtTenGV);
            this.groupBox1.Controls.Add(this.txtMaLHP);
            this.groupBox1.Controls.Add(this.txtMaGV);
            this.groupBox1.Controls.Add(this.txtMaMon);
            this.groupBox1.Controls.Add(this.txtThoiGianKetThuc);
            this.groupBox1.Controls.Add(this.txtThoiGianBatDau);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(289, 403);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nhập Liệu";
            // 
            // txtTenGV
            // 
            this.txtTenGV.AutoSize = true;
            this.txtTenGV.Location = new System.Drawing.Point(44, 202);
            this.txtTenGV.Name = "txtTenGV";
            this.txtTenGV.Size = new System.Drawing.Size(111, 17);
            this.txtTenGV.TabIndex = 5;
            this.txtTenGV.Text = "Tên Giảng Viên:";
            // 
            // txtMaLHP
            // 
            this.txtMaLHP.Location = new System.Drawing.Point(47, 54);
            this.txtMaLHP.Name = "txtMaLHP";
            this.txtMaLHP.Size = new System.Drawing.Size(189, 22);
            this.txtMaLHP.TabIndex = 1;
            this.txtMaLHP.Validating += new System.ComponentModel.CancelEventHandler(this.txtMaLHP_Validating);
            // 
            // txtMaGV
            // 
            this.txtMaGV.FormattingEnabled = true;
            this.txtMaGV.Location = new System.Drawing.Point(47, 175);
            this.txtMaGV.Name = "txtMaGV";
            this.txtMaGV.Size = new System.Drawing.Size(189, 24);
            this.txtMaGV.TabIndex = 3;
            this.txtMaGV.TextChanged += new System.EventHandler(this.txtMaGV_TextChanged);
            this.txtMaGV.Validating += new System.ComponentModel.CancelEventHandler(this.txtMaGV_Validating);
            // 
            // txtMaMon
            // 
            this.txtMaMon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtMaMon.FormattingEnabled = true;
            this.txtMaMon.Location = new System.Drawing.Point(47, 113);
            this.txtMaMon.Name = "txtMaMon";
            this.txtMaMon.Size = new System.Drawing.Size(189, 24);
            this.txtMaMon.TabIndex = 2;
            this.txtMaMon.Validating += new System.ComponentModel.CancelEventHandler(this.txtMaMon_Validating);
            // 
            // txtThoiGianKetThuc
            // 
            this.txtThoiGianKetThuc.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtThoiGianKetThuc.Location = new System.Drawing.Point(47, 323);
            this.txtThoiGianKetThuc.MaxDate = new System.DateTime(3333, 12, 31, 0, 0, 0, 0);
            this.txtThoiGianKetThuc.MinDate = new System.DateTime(2022, 1, 1, 0, 0, 0, 0);
            this.txtThoiGianKetThuc.Name = "txtThoiGianKetThuc";
            this.txtThoiGianKetThuc.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtThoiGianKetThuc.Size = new System.Drawing.Size(189, 22);
            this.txtThoiGianKetThuc.TabIndex = 6;
            // 
            // txtThoiGianBatDau
            // 
            this.txtThoiGianBatDau.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtThoiGianBatDau.Location = new System.Drawing.Point(47, 262);
            this.txtThoiGianBatDau.MaxDate = new System.DateTime(2222, 12, 31, 0, 0, 0, 0);
            this.txtThoiGianBatDau.MinDate = new System.DateTime(2022, 1, 1, 0, 0, 0, 0);
            this.txtThoiGianBatDau.Name = "txtThoiGianBatDau";
            this.txtThoiGianBatDau.Size = new System.Drawing.Size(189, 22);
            this.txtThoiGianBatDau.TabIndex = 5;
            this.txtThoiGianBatDau.Value = new System.DateTime(2022, 2, 25, 0, 0, 0, 0);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(44, 303);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(135, 17);
            this.label5.TabIndex = 0;
            this.label5.Text = "Thời Gian Kết Thúc:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(44, 241);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "Thời Gian Bắt Đầu:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Mã Giảng Viên:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Môn Học:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã Lớp Học Phần:";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.btnXoa);
            this.groupBox2.Controls.Add(this.btnTaiLai);
            this.groupBox2.Controls.Add(this.btnSua);
            this.groupBox2.Controls.Add(this.btnTimKiem);
            this.groupBox2.Controls.Add(this.btnThem);
            this.groupBox2.Location = new System.Drawing.Point(12, 422);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(289, 244);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Chức Năng";
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(48, 170);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 32);
            this.btnXoa.TabIndex = 9;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnTaiLai
            // 
            this.btnTaiLai.Location = new System.Drawing.Point(149, 112);
            this.btnTaiLai.Name = "btnTaiLai";
            this.btnTaiLai.Size = new System.Drawing.Size(88, 32);
            this.btnTaiLai.TabIndex = 11;
            this.btnTaiLai.Text = "Tải Lại";
            this.btnTaiLai.UseVisualStyleBackColor = true;
            this.btnTaiLai.Click += new System.EventHandler(this.btnTaiLai_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(48, 112);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 32);
            this.btnSua.TabIndex = 8;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(149, 52);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(88, 32);
            this.btnTimKiem.TabIndex = 10;
            this.btnTimKiem.Text = "Tìm Kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(48, 52);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 32);
            this.btnThem.TabIndex = 7;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.tbLopHocPhan);
            this.groupBox3.Location = new System.Drawing.Point(308, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1090, 654);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Thông Tin";
            // 
            // tbLopHocPhan
            // 
            this.tbLopHocPhan.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbLopHocPhan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tbLopHocPhan.BackgroundColor = System.Drawing.Color.White;
            this.tbLopHocPhan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tbLopHocPhan.Location = new System.Drawing.Point(55, 34);
            this.tbLopHocPhan.Name = "tbLopHocPhan";
            this.tbLopHocPhan.RowHeadersVisible = false;
            this.tbLopHocPhan.RowHeadersWidth = 51;
            this.tbLopHocPhan.RowTemplate.Height = 24;
            this.tbLopHocPhan.Size = new System.Drawing.Size(983, 578);
            this.tbLopHocPhan.TabIndex = 13;
            this.tbLopHocPhan.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tbLopHocPhan_CellClick);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // QLLopHocPhan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1410, 678);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1428, 725);
            this.Name = "QLLopHocPhan";
            this.Text = "Lớp Hoc Phần";
            this.Load += new System.EventHandler(this.QLLopHocPhan_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tbLopHocPhan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnTaiLai;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.DataGridView tbLopHocPhan;
        private System.Windows.Forms.DateTimePicker txtThoiGianKetThuc;
        private System.Windows.Forms.DateTimePicker txtThoiGianBatDau;
        private System.Windows.Forms.ComboBox txtMaGV;
        private System.Windows.Forms.ComboBox txtMaMon;
        private System.Windows.Forms.TextBox txtMaLHP;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label txtTenGV;
    }
}