namespace ResolutionPolynomes
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtb_res = new System.Windows.Forms.TextBox();
            this.txtb_deg3 = new System.Windows.Forms.TextBox();
            this.txtb_deg2 = new System.Windows.Forms.TextBox();
            this.txtb_deg1 = new System.Windows.Forms.TextBox();
            this.txtb_deg0 = new System.Windows.Forms.TextBox();
            this.btn_calcul = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtb_res
            // 
            this.txtb_res.Enabled = false;
            this.txtb_res.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtb_res.HideSelection = false;
            this.txtb_res.Location = new System.Drawing.Point(61, 170);
            this.txtb_res.Multiline = true;
            this.txtb_res.Name = "txtb_res";
            this.txtb_res.Size = new System.Drawing.Size(342, 249);
            this.txtb_res.TabIndex = 0;
            // 
            // txtb_deg3
            // 
            this.txtb_deg3.Location = new System.Drawing.Point(207, 30);
            this.txtb_deg3.Name = "txtb_deg3";
            this.txtb_deg3.Size = new System.Drawing.Size(85, 21);
            this.txtb_deg3.TabIndex = 1;
            // 
            // txtb_deg2
            // 
            this.txtb_deg2.Location = new System.Drawing.Point(365, 30);
            this.txtb_deg2.Name = "txtb_deg2";
            this.txtb_deg2.Size = new System.Drawing.Size(59, 21);
            this.txtb_deg2.TabIndex = 3;
            // 
            // txtb_deg1
            // 
            this.txtb_deg1.Location = new System.Drawing.Point(497, 30);
            this.txtb_deg1.Name = "txtb_deg1";
            this.txtb_deg1.Size = new System.Drawing.Size(56, 21);
            this.txtb_deg1.TabIndex = 5;
            // 
            // txtb_deg0
            // 
            this.txtb_deg0.Location = new System.Drawing.Point(623, 30);
            this.txtb_deg0.Name = "txtb_deg0";
            this.txtb_deg0.Size = new System.Drawing.Size(65, 21);
            this.txtb_deg0.TabIndex = 7;
            // 
            // btn_calcul
            // 
            this.btn_calcul.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_calcul.Location = new System.Drawing.Point(14, 18);
            this.btn_calcul.Name = "btn_calcul";
            this.btn_calcul.Size = new System.Drawing.Size(177, 41);
            this.btn_calcul.TabIndex = 10;
            this.btn_calcul.Text = "Lancer le calcul";
            this.btn_calcul.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.HideSelection = false;
            this.textBox1.Location = new System.Drawing.Point(425, 170);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(346, 249);
            this.textBox1.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ResolutionPolynomes.Properties.Resources.FondAppli2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(856, 462);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btn_calcul);
            this.Controls.Add(this.txtb_deg0);
            this.Controls.Add(this.txtb_deg1);
            this.Controls.Add(this.txtb_deg2);
            this.Controls.Add(this.txtb_deg3);
            this.Controls.Add(this.txtb_res);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Symbol", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Résolution d\'équations polynomiales";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtb_res;
        private System.Windows.Forms.TextBox txtb_deg3;
        private System.Windows.Forms.TextBox txtb_deg2;
        private System.Windows.Forms.TextBox txtb_deg1;
        private System.Windows.Forms.TextBox txtb_deg0;
        private System.Windows.Forms.Button btn_calcul;
        private System.Windows.Forms.TextBox textBox1;

    }
}

