namespace importExelWO
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.dataGridView_WO = new System.Windows.Forms.DataGridView();
            this.lbRodape = new System.Windows.Forms.Label();
            this.lbTotalItens = new System.Windows.Forms.Label();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbtime = new System.Windows.Forms.Label();
            this.btParar = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbt461B = new System.Windows.Forms.RadioButton();
            this.rbt461A = new System.Windows.Forms.RadioButton();
            this.rbt451R = new System.Windows.Forms.RadioButton();
            this.rbt451U = new System.Windows.Forms.RadioButton();
            this.rbt451F = new System.Windows.Forms.RadioButton();
            this.rbt451T = new System.Windows.Forms.RadioButton();
            this.lbData = new System.Windows.Forms.Label();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.pictureBoxCarregando = new System.Windows.Forms.PictureBox();
            this.lbStatus = new System.Windows.Forms.Label();
            this.timerCount = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_WO)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCarregando)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_WO
            // 
            this.dataGridView_WO.AllowUserToAddRows = false;
            this.dataGridView_WO.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_WO.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_WO.Location = new System.Drawing.Point(3, 167);
            this.dataGridView_WO.Name = "dataGridView_WO";
            this.dataGridView_WO.RowHeadersVisible = false;
            this.dataGridView_WO.Size = new System.Drawing.Size(638, 282);
            this.dataGridView_WO.TabIndex = 0;
            // 
            // lbRodape
            // 
            this.lbRodape.AutoSize = true;
            this.lbRodape.BackColor = System.Drawing.Color.Transparent;
            this.lbRodape.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRodape.ForeColor = System.Drawing.Color.White;
            this.lbRodape.Location = new System.Drawing.Point(-3, 541);
            this.lbRodape.Name = "lbRodape";
            this.lbRodape.Size = new System.Drawing.Size(51, 20);
            this.lbRodape.TabIndex = 10;
            this.lbRodape.Text = "label1";
            // 
            // lbTotalItens
            // 
            this.lbTotalItens.AutoSize = true;
            this.lbTotalItens.BackColor = System.Drawing.Color.Transparent;
            this.lbTotalItens.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotalItens.ForeColor = System.Drawing.Color.Blue;
            this.lbTotalItens.Location = new System.Drawing.Point(251, 149);
            this.lbTotalItens.Name = "lbTotalItens";
            this.lbTotalItens.Size = new System.Drawing.Size(77, 13);
            this.lbTotalItens.TabIndex = 14;
            this.lbTotalItens.Text = "TOTAL ITENS";
            // 
            // btnSalvar
            // 
            this.btnSalvar.BackColor = System.Drawing.SystemColors.Control;
            this.btnSalvar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSalvar.Image = global::importExelWO.Properties.Resources.conect_iloveimg_resized_iloveimg_resized;
            this.btnSalvar.Location = new System.Drawing.Point(11, 20);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(113, 72);
            this.btnSalvar.TabIndex = 12;
            this.btnSalvar.UseVisualStyleBackColor = false;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.dataGridView_WO);
            this.panel1.Controls.Add(this.lbTotalItens);
            this.panel1.Location = new System.Drawing.Point(-2, 89);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(658, 449);
            this.panel1.TabIndex = 15;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbtime);
            this.groupBox1.Controls.Add(this.btParar);
            this.groupBox1.Controls.Add(this.btnRefresh);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.lbData);
            this.groupBox1.Controls.Add(this.txtDescricao);
            this.groupBox1.Controls.Add(this.pictureBoxCarregando);
            this.groupBox1.Controls.Add(this.btnSalvar);
            this.groupBox1.Controls.Add(this.lbStatus);
            this.groupBox1.Location = new System.Drawing.Point(3, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(638, 130);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Baixar Wo - SAP";
            // 
            // lbtime
            // 
            this.lbtime.AutoSize = true;
            this.lbtime.BackColor = System.Drawing.Color.Transparent;
            this.lbtime.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbtime.Location = new System.Drawing.Point(217, 58);
            this.lbtime.Name = "lbtime";
            this.lbtime.Size = new System.Drawing.Size(27, 17);
            this.lbtime.TabIndex = 34;
            this.lbtime.Text = "0:s";
            // 
            // btParar
            // 
            this.btParar.BackColor = System.Drawing.Color.Transparent;
            this.btParar.Image = ((System.Drawing.Image)(resources.GetObject("btParar.Image")));
            this.btParar.Location = new System.Drawing.Point(234, 20);
            this.btParar.Name = "btParar";
            this.btParar.Size = new System.Drawing.Size(48, 35);
            this.btParar.TabIndex = 33;
            this.btParar.UseVisualStyleBackColor = false;
            this.btParar.Click += new System.EventHandler(this.btParar_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.Transparent;
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.Location = new System.Drawing.Point(180, 20);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(48, 35);
            this.btnRefresh.TabIndex = 32;
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbt461B);
            this.groupBox2.Controls.Add(this.rbt461A);
            this.groupBox2.Controls.Add(this.rbt451R);
            this.groupBox2.Controls.Add(this.rbt451U);
            this.groupBox2.Controls.Add(this.rbt451F);
            this.groupBox2.Controls.Add(this.rbt451T);
            this.groupBox2.Location = new System.Drawing.Point(340, 15);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(133, 92);
            this.groupBox2.TabIndex = 24;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "PLANTA";
            // 
            // rbt461B
            // 
            this.rbt461B.AutoSize = true;
            this.rbt461B.Location = new System.Drawing.Point(74, 42);
            this.rbt461B.Name = "rbt461B";
            this.rbt461B.Size = new System.Drawing.Size(50, 17);
            this.rbt461B.TabIndex = 27;
            this.rbt461B.Text = "461B";
            this.rbt461B.UseVisualStyleBackColor = true;
            // 
            // rbt461A
            // 
            this.rbt461A.AutoSize = true;
            this.rbt461A.Location = new System.Drawing.Point(74, 19);
            this.rbt461A.Name = "rbt461A";
            this.rbt461A.Size = new System.Drawing.Size(50, 17);
            this.rbt461A.TabIndex = 26;
            this.rbt461A.Text = "461A";
            this.rbt461A.UseVisualStyleBackColor = true;
            // 
            // rbt451R
            // 
            this.rbt451R.AutoSize = true;
            this.rbt451R.Location = new System.Drawing.Point(74, 65);
            this.rbt451R.Name = "rbt451R";
            this.rbt451R.Size = new System.Drawing.Size(51, 17);
            this.rbt451R.TabIndex = 25;
            this.rbt451R.Text = "451R";
            this.rbt451R.UseVisualStyleBackColor = true;
            // 
            // rbt451U
            // 
            this.rbt451U.AutoSize = true;
            this.rbt451U.Location = new System.Drawing.Point(6, 65);
            this.rbt451U.Name = "rbt451U";
            this.rbt451U.Size = new System.Drawing.Size(51, 17);
            this.rbt451U.TabIndex = 5;
            this.rbt451U.Text = "451U";
            this.rbt451U.UseVisualStyleBackColor = true;
            // 
            // rbt451F
            // 
            this.rbt451F.AutoSize = true;
            this.rbt451F.Checked = true;
            this.rbt451F.Location = new System.Drawing.Point(6, 19);
            this.rbt451F.Name = "rbt451F";
            this.rbt451F.Size = new System.Drawing.Size(49, 17);
            this.rbt451F.TabIndex = 3;
            this.rbt451F.TabStop = true;
            this.rbt451F.Text = "451F";
            this.rbt451F.UseVisualStyleBackColor = true;
            // 
            // rbt451T
            // 
            this.rbt451T.AutoSize = true;
            this.rbt451T.Location = new System.Drawing.Point(6, 42);
            this.rbt451T.Name = "rbt451T";
            this.rbt451T.Size = new System.Drawing.Size(50, 17);
            this.rbt451T.TabIndex = 4;
            this.rbt451T.Text = "451T";
            this.rbt451T.UseVisualStyleBackColor = true;
            // 
            // lbData
            // 
            this.lbData.AutoSize = true;
            this.lbData.Location = new System.Drawing.Point(487, 22);
            this.lbData.Name = "lbData";
            this.lbData.Size = new System.Drawing.Size(113, 13);
            this.lbData.TabIndex = 23;
            this.lbData.Text = "DATA - YYYY-MM-DD";
            // 
            // txtDescricao
            // 
            this.txtDescricao.Location = new System.Drawing.Point(490, 38);
            this.txtDescricao.MaximumSize = new System.Drawing.Size(130, 80);
            this.txtDescricao.MaxLength = 10;
            this.txtDescricao.Multiline = true;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(130, 41);
            this.txtDescricao.TabIndex = 22;
            // 
            // pictureBoxCarregando
            // 
            this.pictureBoxCarregando.Image = global::importExelWO.Properties.Resources.carregando1;
            this.pictureBoxCarregando.Location = new System.Drawing.Point(209, 96);
            this.pictureBoxCarregando.Name = "pictureBoxCarregando";
            this.pictureBoxCarregando.Size = new System.Drawing.Size(56, 29);
            this.pictureBoxCarregando.TabIndex = 21;
            this.pictureBoxCarregando.TabStop = false;
            // 
            // lbStatus
            // 
            this.lbStatus.AutoSize = true;
            this.lbStatus.BackColor = System.Drawing.Color.Transparent;
            this.lbStatus.ForeColor = System.Drawing.Color.MediumBlue;
            this.lbStatus.Location = new System.Drawing.Point(170, 80);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(133, 13);
            this.lbStatus.TabIndex = 18;
            this.lbStatus.Text = "CONECTANDO AO SAP...";
            // 
            // timerCount
            // 
            this.timerCount.Interval = 1000;
            this.timerCount.Tick += new System.EventHandler(this.timerCount_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::importExelWO.Properties.Resources.foxconn_logo_icon_EDTMF5_iloveimg_resized4;
            this.ClientSize = new System.Drawing.Size(639, 570);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbRodape);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IMPORT - WO   V1.0.0.7  AUTO";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_WO)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCarregando)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_WO;
        private System.Windows.Forms.Label lbRodape;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Label lbTotalItens;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Timer timerCount;
        private System.Windows.Forms.Label lbStatus;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBoxCarregando;
        private System.Windows.Forms.Label lbData;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbt451F;
        private System.Windows.Forms.RadioButton rbt451T;
        private System.Windows.Forms.RadioButton rbt451U;
        private System.Windows.Forms.RadioButton rbt451R;
        private System.Windows.Forms.RadioButton rbt461B;
        private System.Windows.Forms.RadioButton rbt461A;
        private System.Windows.Forms.Button btParar;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label lbtime;
    }
}

