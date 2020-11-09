namespace Select_Gender_from_Article
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btn_Click = new System.Windows.Forms.Button();
            this.txt_text = new System.Windows.Forms.RichTextBox();
            this.lbl_Gender = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_Click
            // 
            this.btn_Click.Location = new System.Drawing.Point(266, 266);
            this.btn_Click.Name = "btn_Click";
            this.btn_Click.Size = new System.Drawing.Size(178, 33);
            this.btn_Click.TabIndex = 0;
            this.btn_Click.Text = "button1";
            this.btn_Click.UseVisualStyleBackColor = true;
            this.btn_Click.Click += new System.EventHandler(this.btn_Click_Click);
            // 
            // txt_text
            // 
            this.txt_text.Location = new System.Drawing.Point(12, 12);
            this.txt_text.Name = "txt_text";
            this.txt_text.Size = new System.Drawing.Size(691, 248);
            this.txt_text.TabIndex = 1;
            this.txt_text.Text = resources.GetString("txt_text.Text");
            // 
            // lbl_Gender
            // 
            this.lbl_Gender.AutoSize = true;
            this.lbl_Gender.Location = new System.Drawing.Point(332, 325);
            this.lbl_Gender.Name = "lbl_Gender";
            this.lbl_Gender.Size = new System.Drawing.Size(35, 13);
            this.lbl_Gender.TabIndex = 2;
            this.lbl_Gender.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 363);
            this.Controls.Add(this.lbl_Gender);
            this.Controls.Add(this.txt_text);
            this.Controls.Add(this.btn_Click);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Click;
        private System.Windows.Forms.RichTextBox txt_text;
        private System.Windows.Forms.Label lbl_Gender;
    }
}

