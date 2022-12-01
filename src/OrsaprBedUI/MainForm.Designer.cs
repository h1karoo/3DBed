
namespace OrsaprBedUI
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonBuildBed = new System.Windows.Forms.Button();
            this.labelLength = new System.Windows.Forms.Label();
            this.textBoxLength = new System.Windows.Forms.TextBox();
            this.textBoxWidth = new System.Windows.Forms.TextBox();
            this.labelWidth = new System.Windows.Forms.Label();
            this.textBoxHeight = new System.Windows.Forms.TextBox();
            this.labelHeight = new System.Windows.Forms.Label();
            this.textBoxThickness = new System.Windows.Forms.TextBox();
            this.labelThickness = new System.Windows.Forms.Label();
            this.textBoxDistance = new System.Windows.Forms.TextBox();
            this.labelDistance = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonBuildBed
            // 
            this.buttonBuildBed.Location = new System.Drawing.Point(257, 201);
            this.buttonBuildBed.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonBuildBed.Name = "buttonBuildBed";
            this.buttonBuildBed.Size = new System.Drawing.Size(142, 22);
            this.buttonBuildBed.TabIndex = 0;
            this.buttonBuildBed.Text = "Начертить кровать";
            this.buttonBuildBed.UseVisualStyleBackColor = true;
            this.buttonBuildBed.Click += new System.EventHandler(this.buttonBuildBed_Click);
            // 
            // labelLength
            // 
            this.labelLength.AutoSize = true;
            this.labelLength.Location = new System.Drawing.Point(36, 32);
            this.labelLength.Name = "labelLength";
            this.labelLength.Size = new System.Drawing.Size(215, 15);
            this.labelLength.TabIndex = 1;
            this.labelLength.Text = "Длина кровати L (от 1800 до 2100 мм):";
            // 
            // textBoxLength
            // 
            this.textBoxLength.Location = new System.Drawing.Point(497, 27);
            this.textBoxLength.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxLength.Name = "textBoxLength";
            this.textBoxLength.Size = new System.Drawing.Size(110, 23);
            this.textBoxLength.TabIndex = 2;
            this.textBoxLength.Leave += new System.EventHandler(this.TextBoxLeave);
            // 
            // textBoxWidth
            // 
            this.textBoxWidth.Location = new System.Drawing.Point(497, 55);
            this.textBoxWidth.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxWidth.Name = "textBoxWidth";
            this.textBoxWidth.Size = new System.Drawing.Size(110, 23);
            this.textBoxWidth.TabIndex = 4;
            this.textBoxWidth.Leave += new System.EventHandler(this.TextBoxLeave);
            // 
            // labelWidth
            // 
            this.labelWidth.AutoSize = true;
            this.labelWidth.Location = new System.Drawing.Point(36, 60);
            this.labelWidth.Name = "labelWidth";
            this.labelWidth.Size = new System.Drawing.Size(225, 15);
            this.labelWidth.TabIndex = 3;
            this.labelWidth.Text = "Ширина кровати S (от 1000 до 2100 мм):";
            // 
            // textBoxHeight
            // 
            this.textBoxHeight.Location = new System.Drawing.Point(497, 83);
            this.textBoxHeight.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxHeight.Name = "textBoxHeight";
            this.textBoxHeight.Size = new System.Drawing.Size(110, 23);
            this.textBoxHeight.TabIndex = 6;
            this.textBoxHeight.Leave += new System.EventHandler(this.TextBoxLeave);
            // 
            // labelHeight
            // 
            this.labelHeight.AutoSize = true;
            this.labelHeight.Location = new System.Drawing.Point(36, 88);
            this.labelHeight.Name = "labelHeight";
            this.labelHeight.Size = new System.Drawing.Size(217, 15);
            this.labelHeight.TabIndex = 5;
            this.labelHeight.Text = "Высота кровати H (от 400 до 1200 мм):";
            // 
            // textBoxThickness
            // 
            this.textBoxThickness.Location = new System.Drawing.Point(497, 117);
            this.textBoxThickness.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxThickness.Name = "textBoxThickness";
            this.textBoxThickness.Size = new System.Drawing.Size(110, 23);
            this.textBoxThickness.TabIndex = 12;
            this.textBoxThickness.Leave += new System.EventHandler(this.TextBoxLeave);
            // 
            // labelThickness
            // 
            this.labelThickness.AutoSize = true;
            this.labelThickness.Location = new System.Drawing.Point(36, 122);
            this.labelThickness.Name = "labelThickness";
            this.labelThickness.Size = new System.Drawing.Size(267, 15);
            this.labelThickness.TabIndex = 11;
            this.labelThickness.Text = "Толщина материала корпуса w (от 8 до 14 мм):";
            // 
            // textBoxDistance
            // 
            this.textBoxDistance.Location = new System.Drawing.Point(497, 144);
            this.textBoxDistance.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxDistance.Name = "textBoxDistance";
            this.textBoxDistance.Size = new System.Drawing.Size(110, 23);
            this.textBoxDistance.TabIndex = 14;
            this.textBoxDistance.TextChanged += new System.EventHandler(this.textBoxDistance_TextChanged);
            this.textBoxDistance.Leave += new System.EventHandler(this.TextBoxLeave);
            // 
            // labelDistance
            // 
            this.labelDistance.AutoSize = true;
            this.labelDistance.Location = new System.Drawing.Point(36, 150);
            this.labelDistance.Name = "labelDistance";
            this.labelDistance.Size = new System.Drawing.Size(388, 15);
            this.labelDistance.TabIndex = 13;
            this.labelDistance.Text = "Расстояние от каркаса до верхней части кровати h (от 100 до 250мм):";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 249);
            this.Controls.Add(this.textBoxDistance);
            this.Controls.Add(this.labelDistance);
            this.Controls.Add(this.textBoxThickness);
            this.Controls.Add(this.labelThickness);
            this.Controls.Add(this.textBoxHeight);
            this.Controls.Add(this.labelHeight);
            this.Controls.Add(this.textBoxWidth);
            this.Controls.Add(this.labelWidth);
            this.Controls.Add(this.textBoxLength);
            this.Controls.Add(this.labelLength);
            this.Controls.Add(this.buttonBuildBed);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "Плагин Кровать";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonBuildBed;
        private System.Windows.Forms.Label labelLength;
        private System.Windows.Forms.TextBox textBoxLength;
        private System.Windows.Forms.TextBox textBoxWidth;
        private System.Windows.Forms.Label labelWidth;
        private System.Windows.Forms.TextBox textBoxHeight;
        private System.Windows.Forms.Label labelHeight;
        private System.Windows.Forms.TextBox textBoxThickness;
        private System.Windows.Forms.TextBox textBoxDistance;
        private System.Windows.Forms.Label labelDistance;
        private System.Windows.Forms.Label labelThickness;
    }
}

