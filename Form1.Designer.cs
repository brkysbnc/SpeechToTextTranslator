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
        this.btnStartRecording = new System.Windows.Forms.Button();
        this.btnStopRecording = new System.Windows.Forms.Button();
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
        this.txtSourceText.Location = new System.Drawing.Point(20, 80);
        this.txtSourceText.Multiline = true;
        this.txtSourceText.Name = "txtSourceText";
        this.txtSourceText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
        this.txtSourceText.Size = new System.Drawing.Size(350, 150);
        this.txtSourceText.TabIndex = 0;
        
        // 
        // txtTranslatedText
        // 
        this.txtTranslatedText.Location = new System.Drawing.Point(400, 80);
        this.txtTranslatedText.Multiline = true;
        this.txtTranslatedText.Name = "txtTranslatedText";
        this.txtTranslatedText.ReadOnly = true;
        this.txtTranslatedText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
        this.txtTranslatedText.Size = new System.Drawing.Size(350, 150);
        this.txtTranslatedText.TabIndex = 1;
        
        // 
        // btnStartRecording
        // 
        this.btnStartRecording.BackColor = System.Drawing.Color.LightGreen;
        this.btnStartRecording.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
        this.btnStartRecording.Location = new System.Drawing.Point(20, 250);
        this.btnStartRecording.Name = "btnStartRecording";
        this.btnStartRecording.Size = new System.Drawing.Size(120, 40);
        this.btnStartRecording.TabIndex = 2;
        this.btnStartRecording.Text = "🎤 Kayıt Başlat";
        this.btnStartRecording.UseVisualStyleBackColor = false;
        this.btnStartRecording.Click += new System.EventHandler(this.btnStartRecording_Click);
        
        // 
        // btnStopRecording
        // 
        this.btnStopRecording.BackColor = System.Drawing.Color.LightCoral;
        this.btnStopRecording.Enabled = false;
        this.btnStopRecording.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
        this.btnStopRecording.Location = new System.Drawing.Point(150, 250);
        this.btnStopRecording.Name = "btnStopRecording";
        this.btnStopRecording.Size = new System.Drawing.Size(120, 40);
        this.btnStopRecording.TabIndex = 3;
        this.btnStopRecording.Text = "⏹️ Kayıt Durdur";
        this.btnStopRecording.UseVisualStyleBackColor = false;
        this.btnStopRecording.Click += new System.EventHandler(this.btnStopRecording_Click);
        
        // 
        // btnTranslate
        // 
        this.btnTranslate.BackColor = System.Drawing.Color.LightBlue;
        this.btnTranslate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
        this.btnTranslate.Location = new System.Drawing.Point(300, 250);
        this.btnTranslate.Name = "btnTranslate";
        this.btnTranslate.Size = new System.Drawing.Size(120, 40);
        this.btnTranslate.TabIndex = 4;
        this.btnTranslate.Text = "🔄 Çevir";
        this.btnTranslate.UseVisualStyleBackColor = false;
        this.btnTranslate.Click += new System.EventHandler(this.btnTranslate_Click);
        
        // 
        // btnSpeak
        // 
        this.btnSpeak.BackColor = System.Drawing.Color.LightYellow;
        this.btnSpeak.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
        this.btnSpeak.Location = new System.Drawing.Point(630, 250);
        this.btnSpeak.Name = "btnSpeak";
        this.btnSpeak.Size = new System.Drawing.Size(120, 40);
        this.btnSpeak.TabIndex = 5;
        this.btnSpeak.Text = "🔊 Seslendir";
        this.btnSpeak.UseVisualStyleBackColor = false;
        this.btnSpeak.Click += new System.EventHandler(this.btnSpeak_Click);
        
        // 
        // cmbSourceLanguage
        // 
        this.cmbSourceLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.cmbSourceLanguage.FormattingEnabled = true;
        this.cmbSourceLanguage.Location = new System.Drawing.Point(20, 40);
        this.cmbSourceLanguage.Name = "cmbSourceLanguage";
        this.cmbSourceLanguage.Size = new System.Drawing.Size(150, 23);
        this.cmbSourceLanguage.TabIndex = 6;
        
        // 
        // cmbTargetLanguage
        // 
        this.cmbTargetLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.cmbTargetLanguage.FormattingEnabled = true;
        this.cmbTargetLanguage.Location = new System.Drawing.Point(200, 40);
        this.cmbTargetLanguage.Name = "cmbTargetLanguage";
        this.cmbTargetLanguage.Size = new System.Drawing.Size(150, 23);
        this.cmbTargetLanguage.TabIndex = 7;
        
        // 
        // lblSourceLanguage
        // 
        this.lblSourceLanguage.AutoSize = true;
        this.lblSourceLanguage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
        this.lblSourceLanguage.Location = new System.Drawing.Point(20, 20);
        this.lblSourceLanguage.Name = "lblSourceLanguage";
        this.lblSourceLanguage.Size = new System.Drawing.Size(95, 15);
        this.lblSourceLanguage.TabIndex = 8;
        this.lblSourceLanguage.Text = "Kaynak Dil:";
        
        // 
        // lblTargetLanguage
        // 
        this.lblTargetLanguage.AutoSize = true;
        this.lblTargetLanguage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
        this.lblTargetLanguage.Location = new System.Drawing.Point(200, 20);
        this.lblTargetLanguage.Name = "lblTargetLanguage";
        this.lblTargetLanguage.Size = new System.Drawing.Size(80, 15);
        this.lblTargetLanguage.TabIndex = 9;
        this.lblTargetLanguage.Text = "Hedef Dil:";
        
        // 
        // lblSourceText
        // 
        this.lblSourceText.AutoSize = true;
        this.lblSourceText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
        this.lblSourceText.Location = new System.Drawing.Point(20, 65);
        this.lblSourceText.Name = "lblSourceText";
        this.lblSourceText.Size = new System.Drawing.Size(95, 15);
        this.lblSourceText.TabIndex = 10;
        this.lblSourceText.Text = "Kaynak Metin:";
        
        // 
        // lblTranslatedText
        // 
        this.lblTranslatedText.AutoSize = true;
        this.lblTranslatedText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
        this.lblTranslatedText.Location = new System.Drawing.Point(400, 65);
        this.lblTranslatedText.Name = "lblTranslatedText";
        this.lblTranslatedText.Size = new System.Drawing.Size(80, 15);
        this.lblTranslatedText.TabIndex = 11;
        this.lblTranslatedText.Text = "Çeviri:";
        
        // 
        // lblStatus
        // 
        this.lblStatus.AutoSize = true;
        this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
        this.lblStatus.ForeColor = System.Drawing.Color.Blue;
        this.lblStatus.Location = new System.Drawing.Point(20, 310);
        this.lblStatus.Name = "lblStatus";
        this.lblStatus.Size = new System.Drawing.Size(100, 15);
        this.lblStatus.TabIndex = 12;
        this.lblStatus.Text = "Hazır - Kayıt bekleniyor";
        
        // 
        // Form1
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(780, 350);
        this.Controls.Add(this.lblStatus);
        this.Controls.Add(this.lblTranslatedText);
        this.Controls.Add(this.lblSourceText);
        this.Controls.Add(this.lblTargetLanguage);
        this.Controls.Add(this.lblSourceLanguage);
        this.Controls.Add(this.cmbTargetLanguage);
        this.Controls.Add(this.cmbSourceLanguage);
        this.Controls.Add(this.btnSpeak);
        this.Controls.Add(this.btnTranslate);
        this.Controls.Add(this.btnStopRecording);
        this.Controls.Add(this.btnStartRecording);
        this.Controls.Add(this.txtTranslatedText);
        this.Controls.Add(this.txtSourceText);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        this.MaximizeBox = false;
        this.Name = "Form1";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "Konuşma-Metin Çevirici";
        this.ResumeLayout(false);
        this.PerformLayout();
    }

    #endregion

    private System.Windows.Forms.TextBox txtSourceText;
    private System.Windows.Forms.TextBox txtTranslatedText;
    private System.Windows.Forms.Button btnStartRecording;
    private System.Windows.Forms.Button btnStopRecording;
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
