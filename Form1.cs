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
        /// Konuşma tanıma ve sentez bileşenlerini başlatır - Mikrofon sorunu çözümü
        /// </summary>
        private void InitializeSpeechComponents()
        {
            try
            {
                // Konuşma sentez motorunu önce başlat (daha güvenilir)
                speechSynthesizer = new SpeechSynthesizer();
                speechSynthesizer.SetOutputToDefaultAudioDevice();
                
                // Mikrofon servisini başlat - Geliştirilmiş versiyon
                InitializeMicrophoneService();
            }
            catch (Exception ex)
            {
                lblStatus.Text = "❌ Ses servisi yok - Manuel giriş kullanın";
                lblStatus.ForeColor = Color.Orange;
                
                // Konuşma sentez motorunu başlat (bu genelde çalışır)
                try
                {
                    speechSynthesizer = new SpeechSynthesizer();
                    speechSynthesizer.SetOutputToDefaultAudioDevice();
                }
                catch
                {
                    // Seslendirme de çalışmazsa sessizce devam et
                }
            }
        }

        /// <summary>
        /// Mikrofon servisini başlatır - Çoklu deneme yöntemi
        /// </summary>
        private void InitializeMicrophoneService()
        {
            try
            {
                // Yöntem 1: Varsayılan recognizer ile dene
                speechRecognizer = new SpeechRecognitionEngine();
                ConfigureSpeechRecognizer();
                lblStatus.Text = "✅ Mikrofon hazır - KONUŞMAYA BAŞLA butonuna basın";
                lblStatus.ForeColor = Color.Lime;
                return;
            }
            catch
            {
                // Yöntem 1 başarısız
            }

            try
            {
                // Yöntem 2: Mevcut recognizer'ları kontrol et
                var recognizers = SpeechRecognitionEngine.InstalledRecognizers();
                if (recognizers.Count > 0)
                {
                    speechRecognizer = new SpeechRecognitionEngine(recognizers[0]);
                    ConfigureSpeechRecognizer();
                    lblStatus.Text = "✅ Mikrofon hazır - KONUŞMAYA BAŞLA butonuna basın";
                    lblStatus.ForeColor = Color.Lime;
                    return;
                }
            }
            catch
            {
                // Yöntem 2 başarısız
            }

            try
            {
                // Yöntem 3: En-US recognizer ile dene
                speechRecognizer = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("en-US"));
                ConfigureSpeechRecognizer();
                lblStatus.Text = "✅ Mikrofon hazır (İngilizce) - KONUŞMAYA BAŞLA butonuna basın";
                lblStatus.ForeColor = Color.Lime;
                return;
            }
            catch
            {
                // Yöntem 3 başarısız
            }

            // Tüm yöntemler başarısız
            lblStatus.Text = "❌ Mikrofon servisi bulunamadı - Manuel giriş kullanın";
            lblStatus.ForeColor = Color.Orange;
        }

        /// <summary>
        /// Speech recognizer'ı yapılandırır
        /// </summary>
        private void ConfigureSpeechRecognizer()
        {
            if (speechRecognizer == null) return;

            try
            {
                // Basit gramer oluştur - Herhangi bir kelimeyi kabul et
                var grammarBuilder = new GrammarBuilder();
                grammarBuilder.AppendWildcard();
                
                // Grameri yükle
                speechRecognizer.LoadGrammar(new Grammar(grammarBuilder));

                // Konuşma tanıma olaylarını bağla
                speechRecognizer.SpeechRecognized += SpeechRecognizer_SpeechRecognized;
                speechRecognizer.SpeechDetected += SpeechRecognizer_SpeechDetected;
                speechRecognizer.SpeechHypothesized += SpeechRecognizer_SpeechHypothesized;
                speechRecognizer.SpeechRecognitionRejected += SpeechRecognizer_SpeechRecognitionRejected;
            }
            catch
            {
                // Gramer yükleme hatası - sessizce devam et
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
            lblStatus.Text = "✅ Konuşma tanındı - Otomatik çeviri yapılıyor...";
            lblStatus.ForeColor = Color.Lime;
            
            // Otomatik çeviri
            btnTranslate_Click(null, null);
            
            // Kayıt durdur
            isRecording = false;
            btnRecord.Text = "🎤 KONUŞMAYA BAŞLA";
            btnRecord.BackColor = Color.FromArgb(0, 120, 215);
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

            lblStatus.Text = "🎤 Konuşma algılandı - Dinleniyor...";
            lblStatus.ForeColor = Color.Yellow;
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

            lblStatus.Text = $"🎤 Dinleniyor: {e.Result.Text}...";
            lblStatus.ForeColor = Color.Yellow;
        }

        /// <summary>
        /// Konuşma tanıma reddedildi olayı
        /// </summary>
        private void SpeechRecognizer_SpeechRecognitionRejected(object sender, SpeechRecognitionRejectedEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => SpeechRecognizer_SpeechRecognitionRejected(sender, e)));
                return;
            }

            lblStatus.Text = "❌ Konuşma anlaşılamadı - Tekrar deneyin";
            lblStatus.ForeColor = Color.Orange;
        }

        /// <summary>
        /// Tek tuş kayıt butonu olayı - Mikrofon sorunu çözümü ile
        /// </summary>
        private void btnRecord_Click(object sender, EventArgs e)
        {
            try
            {
                if (speechRecognizer == null)
                {
                    // Mikrofon servisini tekrar dene
                    InitializeMicrophoneService();
                    
                    if (speechRecognizer == null)
                    {
                        MessageBox.Show("❌ Mikrofon servisi mevcut değil.\\n\\n" +
                                      "🔧 Çözüm önerileri:\\n" +
                                      "1. Windows Mikrofon izinlerini kontrol edin\\n" +
                                      "2. Mikrofonunuzun çalıştığından emin olun\\n" +
                                      "3. Manuel metin girişi kullanın\\n" +
                                      "4. Uygulamayı yönetici olarak çalıştırın", 
                                      "Mikrofon Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                if (!isRecording)
                {
                    // Kayıt başlat
                    speechRecognizer.RecognizeAsync(RecognizeMode.Single);
                    isRecording = true;
                    
                    btnRecord.Text = "⏹️ KAYDI DURDUR";
                    btnRecord.BackColor = Color.FromArgb(220, 53, 69);
                    
                    lblStatus.Text = "🎤 Kayıt başladı - Konuşun...";
                    lblStatus.ForeColor = Color.Red;
                }
                else
                {
                    // Kayıt durdur
                    speechRecognizer.RecognizeAsyncStop();
                    isRecording = false;
                    
                    btnRecord.Text = "🎤 KONUŞMAYA BAŞLA";
                    btnRecord.BackColor = Color.FromArgb(0, 120, 215);
                    
                    lblStatus.Text = "⏹️ Kayıt durduruldu";
                    lblStatus.ForeColor = Color.Blue;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Kayıt hatası: {ex.Message}\\n\\n" +
                              "🔧 Çözüm önerileri:\\n" +
                              "1. Mikrofon izinlerini kontrol edin\\n" +
                              "2. Uygulamayı yönetici olarak çalıştırın\\n" +
                              "3. Manuel metin girişi kullanın", 
                              "Kayıt Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblStatus.Text = "❌ Manuel giriş kullanın";
                lblStatus.ForeColor = Color.Orange;
                
                // Buton durumunu sıfırla
                isRecording = false;
                btnRecord.Text = "🎤 KONUŞMAYA BAŞLA";
                btnRecord.BackColor = Color.FromArgb(0, 120, 215);
            }
        }


        /// <summary>
        /// Çeviri butonu olayı - MyMemory API ile ücretsiz çeviri
        /// </summary>
        private async void btnTranslate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSourceText.Text))
            {
                MessageBox.Show("❌ Çevrilecek metin girin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                lblStatus.Text = "🔄 Çeviri yapılıyor...";
                lblStatus.ForeColor = Color.Yellow;

                string sourceLang = cmbSourceLanguage.SelectedItem?.ToString() ?? "Türkçe";
                string targetLang = cmbTargetLanguage.SelectedItem?.ToString() ?? "İngilizce";

                // MyMemory API ile çeviri
                string translatedText = await TranslateText(txtSourceText.Text, sourceLang, targetLang);
                
                txtTranslatedText.Text = translatedText;
                lblStatus.Text = "✅ Çeviri tamamlandı";
                lblStatus.ForeColor = Color.Lime;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Çeviri hatası: {ex.Message}", "Çeviri Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblStatus.Text = "❌ Çeviri hatası";
                lblStatus.ForeColor = Color.Red;
            }
        }

        /// <summary>
        /// Metin çeviri fonksiyonu - MyMemory API ile ücretsiz çeviri
        /// </summary>
        private async Task<string> TranslateText(string text, string sourceLang, string targetLang)
        {
            try
            {
                // Dil kodlarını belirle
                string sourceCode = sourceLang == "Türkçe" ? "tr" : "en";
                string targetCode = targetLang == "İngilizce" ? "en" : "tr";
                
                // MyMemory API URL'i
                string apiUrl = $"https://api.mymemory.translated.net/get?q={Uri.EscapeDataString(text)}&langpair={sourceCode}|{targetCode}";
                
                // HTTP isteği gönder
                using (var client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromSeconds(10);
                    var response = await client.GetStringAsync(apiUrl);
                    
                    // JSON yanıtını parse et
                    var jsonResponse = JsonConvert.DeserializeObject<dynamic>(response);
                    
                    if (jsonResponse.responseStatus == 200)
                    {
                        string translatedText = jsonResponse.responseData.translatedText;
                        
                        // Çeviri kalitesi kontrolü
                        if (jsonResponse.responseData.match != null && jsonResponse.responseData.match > 0.5)
                        {
                            return translatedText;
                        }
                        else
                        {
                            // Düşük kaliteli çeviri - basit sözlük kullan
                            return GetSimpleTranslation(text, sourceLang, targetLang);
                        }
                    }
                    else
                    {
                        throw new Exception("API yanıt hatası");
                    }
                }
            }
            catch (Exception ex)
            {
                // API hatası durumunda basit sözlük çevirisi kullan
                return GetSimpleTranslation(text, sourceLang, targetLang);
            }
        }

        /// <summary>
        /// Basit sözlük çevirisi (fallback)
        /// </summary>
        private string GetSimpleTranslation(string text, string sourceLang, string targetLang)
        {
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
                return text;
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
        /// Seslendirme butonu olayı - Çevrilen metni seslendirir (Geliştirilmiş versiyon)
        /// </summary>
        private void btnSpeak_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTranslatedText.Text))
            {
                MessageBox.Show("❌ Seslendirilecek metin yok!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // SpeechSynthesizer null kontrolü
                if (speechSynthesizer == null)
                {
                    MessageBox.Show("❌ Seslendirme servisi mevcut değil.\n\nSistem ses ayarlarınızı kontrol edin.", "Seslendirme Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Hedef dile göre ses ayarla
                string targetLang = cmbTargetLanguage.SelectedItem?.ToString() ?? "İngilizce";
                
                try
                {
                    if (targetLang == "Türkçe")
                    {
                        speechSynthesizer.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Adult, 0, new System.Globalization.CultureInfo("tr-TR"));
                    }
                    else
                    {
                        speechSynthesizer.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Adult, 0, new System.Globalization.CultureInfo("en-US"));
                    }
                }
                catch
                {
                    // Ses ayarlama hatası - varsayılan sesle devam et
                }

                // Seslendirme hızını ayarla
                speechSynthesizer.Rate = 0; // Normal hız
                speechSynthesizer.Volume = 100; // Maksimum ses

                speechSynthesizer.SpeakAsync(txtTranslatedText.Text);
                lblStatus.Text = "🔊 Metin seslendiriliyor...";
                lblStatus.ForeColor = Color.Purple;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Seslendirme hatası: {ex.Message}\n\nSistem ses ayarlarınızı kontrol edin.", "Seslendirme Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblStatus.Text = "❌ Seslendirme hatası";
                lblStatus.ForeColor = Color.Red;
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
