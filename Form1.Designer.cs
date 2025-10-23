namespace SpeechToTextTranslator;

partial class Form1
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
        this.txtSourceText = new System.Windows.Forms.TextBox();
        this.txtTranslatedText = new System.Windows.Forms.TextBox();
        this.btnRecord = new System.Windows.Forms.Button();
        this.btnTranslate = new System.Windows.Forms.Button();
        this.btnSpeak = new System.Windows.Forms.Button();
        this.cmbSourceLanguage = new System.Windows.Forms.ComboBox();
        this.cmbTargetLanguage = new System.Windows.Forms.ComboBox();
        this.lblSourceLanguage = new System.Windows.Forms.Label();
        this.lblTargetLanguage = new System.Windows.Forms.Label();
        this.lblSourceText = new System.Windows.Forms.Label();
        this.lblTranslatedText = new System.Windows.Forms.Label();
        this.lblStatus = new System.Windows.Forms.Label();
        this.SuspendLayout();
        
        // 
        // txtSourceText
        // 
        this.txtSourceText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
        this.txtSourceText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.txtSourceText.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.txtSourceText.ForeColor = System.Drawing.Color.White;
        this.txtSourceText.Location = new System.Drawing.Point(20, 80);
        this.txtSourceText.Multiline = true;
        this.txtSourceText.Name = "txtSourceText";
        this.txtSourceText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
        this.txtSourceText.Size = new System.Drawing.Size(350, 150);
        this.txtSourceText.TabIndex = 0;
        
        // 
        // txtTranslatedText
        // 
        this.txtTranslatedText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
        this.txtTranslatedText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.txtTranslatedText.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.txtTranslatedText.ForeColor = System.Drawing.Color.White;
        this.txtTranslatedText.Location = new System.Drawing.Point(400, 80);
        this.txtTranslatedText.Multiline = true;
        this.txtTranslatedText.Name = "txtTranslatedText";
        this.txtTranslatedText.ReadOnly = true;
        this.txtTranslatedText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
        this.txtTranslatedText.Size = new System.Drawing.Size(350, 150);
        this.txtTranslatedText.TabIndex = 1;
        
        // 
        // btnRecord
        // 
        this.btnRecord.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
        this.btnRecord.FlatAppearance.BorderSize = 0;
        this.btnRecord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnRecord.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
        this.btnRecord.ForeColor = System.Drawing.Color.White;
        this.btnRecord.Location = new System.Drawing.Point(20, 250);
        this.btnRecord.Name = "btnRecord";
        this.btnRecord.Size = new System.Drawing.Size(200, 50);
        this.btnRecord.TabIndex = 2;
        this.btnRecord.Text = "🎤 KONUŞMAYA BAŞLA";
        this.btnRecord.UseVisualStyleBackColor = false;
        this.btnRecord.Click += new System.EventHandler(this.btnRecord_Click);
        
        // 
        // btnTranslate
        // 
        this.btnTranslate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
        this.btnTranslate.FlatAppearance.BorderSize = 0;
        this.btnTranslate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnTranslate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
        this.btnTranslate.ForeColor = System.Drawing.Color.White;
        this.btnTranslate.Location = new System.Drawing.Point(240, 250);
        this.btnTranslate.Name = "btnTranslate";
        this.btnTranslate.Size = new System.Drawing.Size(150, 50);
        this.btnTranslate.TabIndex = 4;
        this.btnTranslate.Text = "🔄 ÇEVİR";
        this.btnTranslate.UseVisualStyleBackColor = false;
        this.btnTranslate.Click += new System.EventHandler(this.btnTranslate_Click);
        
        // 
        // btnSpeak
        // 
        this.btnSpeak.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(7)))));
        this.btnSpeak.FlatAppearance.BorderSize = 0;
        this.btnSpeak.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnSpeak.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
        this.btnSpeak.ForeColor = System.Drawing.Color.White;
        this.btnSpeak.Location = new System.Drawing.Point(410, 250);
        this.btnSpeak.Name = "btnSpeak";
        this.btnSpeak.Size = new System.Drawing.Size(150, 50);
        this.btnSpeak.TabIndex = 5;
        this.btnSpeak.Text = "🔊 SESLENDİR";
        this.btnSpeak.UseVisualStyleBackColor = false;
        this.btnSpeak.Click += new System.EventHandler(this.btnSpeak_Click);
        
        // 
        // cmbSourceLanguage
        // 
        this.cmbSourceLanguage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
        this.cmbSourceLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.cmbSourceLanguage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.cmbSourceLanguage.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.cmbSourceLanguage.ForeColor = System.Drawing.Color.White;
        this.cmbSourceLanguage.FormattingEnabled = true;
        this.cmbSourceLanguage.Location = new System.Drawing.Point(20, 40);
        this.cmbSourceLanguage.Name = "cmbSourceLanguage";
        this.cmbSourceLanguage.Size = new System.Drawing.Size(150, 25);
        this.cmbSourceLanguage.TabIndex = 6;
        
        // 
        // cmbTargetLanguage
        // 
        this.cmbTargetLanguage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
        this.cmbTargetLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.cmbTargetLanguage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.cmbTargetLanguage.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.cmbTargetLanguage.ForeColor = System.Drawing.Color.White;
        this.cmbTargetLanguage.FormattingEnabled = true;
        this.cmbTargetLanguage.Location = new System.Drawing.Point(200, 40);
        this.cmbTargetLanguage.Name = "cmbTargetLanguage";
        this.cmbTargetLanguage.Size = new System.Drawing.Size(150, 25);
        this.cmbTargetLanguage.TabIndex = 7;
        
        // 
        // lblSourceLanguage
        // 
        this.lblSourceLanguage.AutoSize = true;
        this.lblSourceLanguage.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        this.lblSourceLanguage.ForeColor = System.Drawing.Color.White;
        this.lblSourceLanguage.Location = new System.Drawing.Point(20, 20);
        this.lblSourceLanguage.Name = "lblSourceLanguage";
        this.lblSourceLanguage.Size = new System.Drawing.Size(95, 19);
        this.lblSourceLanguage.TabIndex = 8;
        this.lblSourceLanguage.Text = "Kaynak Dil:";
        
        // 
        // lblTargetLanguage
        // 
        this.lblTargetLanguage.AutoSize = true;
        this.lblTargetLanguage.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        this.lblTargetLanguage.ForeColor = System.Drawing.Color.White;
        this.lblTargetLanguage.Location = new System.Drawing.Point(200, 20);
        this.lblTargetLanguage.Name = "lblTargetLanguage";
        this.lblTargetLanguage.Size = new System.Drawing.Size(80, 19);
        this.lblTargetLanguage.TabIndex = 9;
        this.lblTargetLanguage.Text = "Hedef Dil:";
        
        // 
        // lblSourceText
        // 
        this.lblSourceText.AutoSize = true;
        this.lblSourceText.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        this.lblSourceText.ForeColor = System.Drawing.Color.White;
        this.lblSourceText.Location = new System.Drawing.Point(20, 65);
        this.lblSourceText.Name = "lblSourceText";
        this.lblSourceText.Size = new System.Drawing.Size(95, 19);
        this.lblSourceText.TabIndex = 10;
        this.lblSourceText.Text = "Kaynak Metin:";
        
        // 
        // lblTranslatedText
        // 
        this.lblTranslatedText.AutoSize = true;
        this.lblTranslatedText.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        this.lblTranslatedText.ForeColor = System.Drawing.Color.White;
        this.lblTranslatedText.Location = new System.Drawing.Point(400, 65);
        this.lblTranslatedText.Name = "lblTranslatedText";
        this.lblTranslatedText.Size = new System.Drawing.Size(80, 19);
        this.lblTranslatedText.TabIndex = 11;
        this.lblTranslatedText.Text = "Çeviri:";
        
        // 
        // lblStatus
        // 
        this.lblStatus.AutoSize = true;
        this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.lblStatus.ForeColor = System.Drawing.Color.Lime;
        this.lblStatus.Location = new System.Drawing.Point(20, 320);
        this.lblStatus.Name = "lblStatus";
        this.lblStatus.Size = new System.Drawing.Size(100, 19);
        this.lblStatus.TabIndex = 12;
        this.lblStatus.Text = "Hazır - Kayıt bekleniyor";
        
        // 
        // Form1
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
        this.ClientSize = new System.Drawing.Size(780, 360);
        this.Controls.Add(this.lblStatus);
        this.Controls.Add(this.lblTranslatedText);
        this.Controls.Add(this.lblSourceText);
        this.Controls.Add(this.lblTargetLanguage);
        this.Controls.Add(this.lblSourceLanguage);
        this.Controls.Add(this.cmbTargetLanguage);
        this.Controls.Add(this.cmbSourceLanguage);
        this.Controls.Add(this.btnSpeak);
        this.Controls.Add(this.btnTranslate);
        this.Controls.Add(this.btnRecord);
        this.Controls.Add(this.txtTranslatedText);
        this.Controls.Add(this.txtSourceText);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        this.MaximizeBox = false;
        this.Name = "Form1";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "🎤 Konuşma-Metin Çevirici v2.0 - Dark Mode";
        this.ResumeLayout(false);
        this.PerformLayout();
    }

    #endregion

    private System.Windows.Forms.TextBox txtSourceText;
    private System.Windows.Forms.TextBox txtTranslatedText;
    private System.Windows.Forms.Button btnRecord;
    private System.Windows.Forms.Button btnTranslate;
    private System.Windows.Forms.Button btnSpeak;
    private System.Windows.Forms.ComboBox cmbSourceLanguage;
    private System.Windows.Forms.ComboBox cmbTargetLanguage;
    private System.Windows.Forms.Label lblSourceLanguage;
    private System.Windows.Forms.Label lblTargetLanguage;
    private System.Windows.Forms.Label lblSourceText;
    private System.Windows.Forms.Label lblTranslatedText;
    private System.Windows.Forms.Label lblStatus;
}
