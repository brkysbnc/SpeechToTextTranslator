using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Net.Http;
using Newtonsoft.Json;

namespace SpeechToTextTranslator
{
    /// <summary>
    /// Ana form sınıfı - Konuşma-metin dönüştürme ve çeviri işlevlerini içerir
    /// </summary>
    public partial class Form1 : Form
    {
        private SpeechRecognitionEngine speechRecognizer;
        private SpeechSynthesizer speechSynthesizer;
        private bool isRecording = false;
        private HttpClient httpClient;

        /// <summary>
        /// Form constructor - Başlangıç ayarlarını yapar
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            InitializeSpeechComponents();
            InitializeLanguageComboBoxes();
            InitializeHttpClient();
        }

        /// <summary>
        /// Konuşma tanıma ve sentez bileşenlerini başlatır
        /// </summary>
        private void InitializeSpeechComponents()
        {
            try
            {
                // Konuşma tanıma motorunu başlat
                speechRecognizer = new SpeechRecognitionEngine();
                
                // Türkçe ve İngilizce dil desteği ekle
                var turkishGrammar = new GrammarBuilder();
                turkishGrammar.Culture = new System.Globalization.CultureInfo("tr-TR");
                speechRecognizer.LoadGrammar(new Grammar(turkishGrammar));

                var englishGrammar = new GrammarBuilder();
                englishGrammar.Culture = new System.Globalization.CultureInfo("en-US");
                speechRecognizer.LoadGrammar(new Grammar(englishGrammar));

                // Konuşma tanıma olaylarını bağla
                speechRecognizer.SpeechRecognized += SpeechRecognizer_SpeechRecognized;
                speechRecognizer.SpeechDetected += SpeechRecognizer_SpeechDetected;
                speechRecognizer.SpeechHypothesized += SpeechRecognizer_SpeechHypothesized;

                // Konuşma sentez motorunu başlat
                speechSynthesizer = new SpeechSynthesizer();
                speechSynthesizer.SetOutputToDefaultAudioDevice();

                lblStatus.Text = "Konuşma bileşenleri hazır";
                lblStatus.ForeColor = Color.Green;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Konuşma bileşenleri başlatılamadı: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblStatus.Text = "Konuşma bileşenleri başlatılamadı";
                lblStatus.ForeColor = Color.Red;
            }
        }

        /// <summary>
        /// Dil seçim kutularını başlatır
        /// </summary>
        private void InitializeLanguageComboBoxes()
        {
            // Kaynak dil seçenekleri
            cmbSourceLanguage.Items.AddRange(new object[] {
                "Türkçe",
                "İngilizce"
            });
            cmbSourceLanguage.SelectedIndex = 0; // Türkçe varsayılan

            // Hedef dil seçenekleri
            cmbTargetLanguage.Items.AddRange(new object[] {
                "İngilizce",
                "Türkçe"
            });
            cmbTargetLanguage.SelectedIndex = 0; // İngilizce varsayılan
        }

        /// <summary>
        /// HTTP istemcisini başlatır
        /// </summary>
        private void InitializeHttpClient()
        {
            httpClient = new HttpClient();
            httpClient.Timeout = TimeSpan.FromSeconds(30);
        }

        /// <summary>
        /// Konuşma tanıma olayı - Konuşma başarıyla tanındığında çalışır
        /// </summary>
        private void SpeechRecognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => SpeechRecognizer_SpeechRecognized(sender, e)));
                return;
            }

            txtSourceText.Text = e.Result.Text;
            lblStatus.Text = "Konuşma tanındı - Çeviri için hazır";
            lblStatus.ForeColor = Color.Blue;
            
            // Otomatik çeviri
            btnTranslate_Click(null, null);
        }

        /// <summary>
        /// Konuşma algılama olayı - Konuşma başladığında çalışır
        /// </summary>
        private void SpeechRecognizer_SpeechDetected(object sender, SpeechDetectedEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => SpeechRecognizer_SpeechDetected(sender, e)));
                return;
            }

            lblStatus.Text = "Konuşma algılandı - Dinleniyor...";
            lblStatus.ForeColor = Color.Orange;
        }

        /// <summary>
        /// Konuşma hipotezi olayı - Geçici tanıma sonuçları için
        /// </summary>
        private void SpeechRecognizer_SpeechHypothesized(object sender, SpeechHypothesizedEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => SpeechRecognizer_SpeechHypothesized(sender, e)));
                return;
            }

            lblStatus.Text = $"Dinleniyor: {e.Result.Text}...";
            lblStatus.ForeColor = Color.Orange;
        }

        /// <summary>
        /// Kayıt başlatma butonu olayı
        /// </summary>
        private void btnStartRecording_Click(object sender, EventArgs e)
        {
            try
            {
                if (!isRecording)
                {
                    speechRecognizer.RecognizeAsync(RecognizeMode.Multiple);
                    isRecording = true;
                    
                    btnStartRecording.Enabled = false;
                    btnStopRecording.Enabled = true;
                    
                    lblStatus.Text = "Kayıt başladı - Konuşun...";
                    lblStatus.ForeColor = Color.Red;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Kayıt başlatılamadı: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Kayıt durdurma butonu olayı
        /// </summary>
        private void btnStopRecording_Click(object sender, EventArgs e)
        {
            try
            {
                if (isRecording)
                {
                    speechRecognizer.RecognizeAsyncStop();
                    isRecording = false;
                    
                    btnStartRecording.Enabled = true;
                    btnStopRecording.Enabled = false;
                    
                    lblStatus.Text = "Kayıt durduruldu";
                    lblStatus.ForeColor = Color.Blue;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Kayıt durdurulamadı: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Çeviri butonu olayı - Google Translate benzeri çeviri yapar
        /// </summary>
        private async void btnTranslate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSourceText.Text))
            {
                MessageBox.Show("Çevrilecek metin girin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                lblStatus.Text = "Çeviri yapılıyor...";
                lblStatus.ForeColor = Color.Orange;

                string sourceLang = cmbSourceLanguage.SelectedItem.ToString();
                string targetLang = cmbTargetLanguage.SelectedItem.ToString();

                // Basit çeviri sözlüğü (gerçek uygulamada Google Translate API kullanılmalı)
                string translatedText = await TranslateText(txtSourceText.Text, sourceLang, targetLang);
                
                txtTranslatedText.Text = translatedText;
                lblStatus.Text = "Çeviri tamamlandı";
                lblStatus.ForeColor = Color.Green;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Çeviri hatası: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblStatus.Text = "Çeviri hatası";
                lblStatus.ForeColor = Color.Red;
            }
        }

        /// <summary>
        /// Metin çeviri fonksiyonu - Basit sözlük tabanlı çeviri
        /// </summary>
        private async Task<string> TranslateText(string text, string sourceLang, string targetLang)
        {
            // Gerçek uygulamada burada Google Translate API kullanılmalı
            // Şimdilik basit bir sözlük çevirisi yapıyoruz
            
            await Task.Delay(500); // API çağrısını simüle et

            if (sourceLang == "Türkçe" && targetLang == "İngilizce")
            {
                return TranslateTurkishToEnglish(text);
            }
            else if (sourceLang == "İngilizce" && targetLang == "Türkçe")
            {
                return TranslateEnglishToTurkish(text);
            }
            else
            {
                return text; // Aynı dil seçilmişse metni olduğu gibi döndür
            }
        }

        /// <summary>
        /// Türkçe'den İngilizce'ye basit çeviri
        /// </summary>
        private string TranslateTurkishToEnglish(string text)
        {
            var translations = new Dictionary<string, string>
            {
                {"merhaba", "hello"},
                {"selam", "hi"},
                {"nasılsın", "how are you"},
                {"iyiyim", "I'm fine"},
                {"teşekkürler", "thank you"},
                {"lütfen", "please"},
                {"evet", "yes"},
                {"hayır", "no"},
                {"güzel", "beautiful"},
                {"iyi", "good"},
                {"kötü", "bad"},
                {"büyük", "big"},
                {"küçük", "small"},
                {"hızlı", "fast"},
                {"yavaş", "slow"},
                {"sıcak", "hot"},
                {"soğuk", "cold"},
                {"su", "water"},
                {"yemek", "food"},
                {"ev", "house"},
                {"araba", "car"},
                {"kitap", "book"},
                {"okul", "school"},
                {"çalışma", "work"},
                {"aile", "family"},
                {"arkadaş", "friend"},
                {"zaman", "time"},
                {"para", "money"},
                {"ülke", "country"},
                {"şehir", "city"}
            };

            string result = text.ToLower();
            foreach (var translation in translations)
            {
                result = result.Replace(translation.Key, translation.Value);
            }
            return result;
        }

        /// <summary>
        /// İngilizce'den Türkçe'ye basit çeviri
        /// </summary>
        private string TranslateEnglishToTurkish(string text)
        {
            var translations = new Dictionary<string, string>
            {
                {"hello", "merhaba"},
                {"hi", "selam"},
                {"how are you", "nasılsın"},
                {"i'm fine", "iyiyim"},
                {"thank you", "teşekkürler"},
                {"please", "lütfen"},
                {"yes", "evet"},
                {"no", "hayır"},
                {"beautiful", "güzel"},
                {"good", "iyi"},
                {"bad", "kötü"},
                {"big", "büyük"},
                {"small", "küçük"},
                {"fast", "hızlı"},
                {"slow", "yavaş"},
                {"hot", "sıcak"},
                {"cold", "soğuk"},
                {"water", "su"},
                {"food", "yemek"},
                {"house", "ev"},
                {"car", "araba"},
                {"book", "kitap"},
                {"school", "okul"},
                {"work", "çalışma"},
                {"family", "aile"},
                {"friend", "arkadaş"},
                {"time", "zaman"},
                {"money", "para"},
                {"country", "ülke"},
                {"city", "şehir"}
            };

            string result = text.ToLower();
            foreach (var translation in translations)
            {
                result = result.Replace(translation.Key, translation.Value);
            }
            return result;
        }

        /// <summary>
        /// Seslendirme butonu olayı - Çevrilen metni seslendirir
        /// </summary>
        private void btnSpeak_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTranslatedText.Text))
            {
                MessageBox.Show("Seslendirilecek metin yok!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Hedef dile göre ses ayarla
                string targetLang = cmbTargetLanguage.SelectedItem.ToString();
                
                if (targetLang == "Türkçe")
                {
                    speechSynthesizer.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Adult, 0, new System.Globalization.CultureInfo("tr-TR"));
                }
                else
                {
                    speechSynthesizer.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Adult, 0, new System.Globalization.CultureInfo("en-US"));
                }

                speechSynthesizer.SpeakAsync(txtTranslatedText.Text);
                lblStatus.Text = "Metin seslendiriliyor...";
                lblStatus.ForeColor = Color.Purple;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Seslendirme hatası: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Form kapatılırken kaynakları temizle
        /// </summary>
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            try
            {
                if (speechRecognizer != null)
                {
                    speechRecognizer.Dispose();
                }
                if (speechSynthesizer != null)
                {
                    speechSynthesizer.Dispose();
                }
                if (httpClient != null)
                {
                    httpClient.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Kaynaklar temizlenirken hata: {ex.Message}", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
            base.OnFormClosing(e);
        }
    }
}
