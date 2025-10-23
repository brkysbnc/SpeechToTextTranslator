# 🎤 Konuşma-Metin Çevirici (Speech-to-Text Translator)

Bu proje, Windows Forms C# ile geliştirilmiş bir konuşma-metin dönüştürme ve çeviri uygulamasıdır. Google Translate benzeri özellikler sunar ve Türkçe-İngilizce çeviri yapabilir.

## 🌟 Özellikler

### 🎯 Ana Özellikler
- **Konuşma Tanıma**: Mikrofon ile konuşulan metni otomatik olarak metne dönüştürür
- **Gerçek Zamanlı Çeviri**: Türkçe ve İngilizce arasında anlık çeviri
- **Metin Seslendirme**: Çevrilen metni sesli olarak dinleyebilme
- **Kullanıcı Dostu Arayüz**: Modern ve sezgisel Windows Forms arayüzü
- **Dil Seçimi**: Kaynak ve hedef dil seçimi için dropdown menüler

### 🔧 Teknik Özellikler
- **.NET 9.0** ile geliştirilmiş
- **System.Speech** kütüphanesi ile konuşma işleme
- **Self-contained** exe dosyası (bağımsız çalışma)
- **Windows x64** platformu için optimize edilmiş
- **Asenkron** çeviri işlemleri

## 📋 Gereksinimler

### Sistem Gereksinimleri
- **İşletim Sistemi**: Windows 10/11 (64-bit)
- **Mikrofon**: Ses girişi için mikrofon gerekli
- **Hoparlör/Kulaklık**: Ses çıkışı için ses cihazı gerekli
- **RAM**: En az 4GB RAM
- **Disk Alanı**: En az 100MB boş alan

### Yazılım Gereksinimleri
- **.NET 9.0 Runtime** (self-contained build ile dahil)
- **Windows Speech Recognition** servisi aktif olmalı
- **Türkçe ve İngilizce dil paketleri** yüklü olmalı

## 🚀 Kurulum ve Çalıştırma

### Hazır Exe Dosyası ile Çalıştırma
1. `bin/Release/net9.0-windows/win-x64/publish/SpeechToTextTranslator.exe` dosyasını indirin
2. Dosyayı çift tıklayarak çalıştırın
3. Mikrofon izni verin (Windows tarafından istenecek)

### Kaynak Koddan Derleme
```bash
# Projeyi klonlayın
git clone https://github.com/kullaniciadi/SpeechToTextTranslator.git
cd SpeechToTextTranslator

# Bağımlılıkları yükleyin
dotnet restore

# Projeyi derleyin
dotnet build

# Release modunda derleyin
dotnet publish -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true
```

## 📖 Kullanım Kılavuzu

### 1. Dil Seçimi
- **Kaynak Dil**: Konuşacağınız dili seçin (Türkçe/İngilizce)
- **Hedef Dil**: Çeviri yapılacak dili seçin (İngilizce/Türkçe)

### 2. Konuşma Kaydı
1. **"🎤 Kayıt Başlat"** butonuna tıklayın
2. Mikrofonunuzu açık tutarak konuşun
3. **"⏹️ Kayıt Durdur"** butonuna tıklayın
4. Konuşmanız otomatik olarak metne dönüştürülecek

### 3. Çeviri İşlemi
- Konuşma tanındıktan sonra otomatik çeviri yapılır
- Manuel çeviri için **"🔄 Çevir"** butonunu kullanabilirsiniz
- Kaynak metin kutusuna manuel olarak metin girebilirsiniz

### 4. Seslendirme
- Çevrilen metni dinlemek için **"🔊 Seslendir"** butonuna tıklayın
- Ses, hedef dile uygun olarak çalınacak

## 🎨 Arayüz Özellikleri

### Renk Kodlaması
- **🟢 Yeşil**: Kayıt başlatma butonu
- **🔴 Kırmızı**: Kayıt durdurma butonu
- **🔵 Mavi**: Çeviri butonu
- **🟡 Sarı**: Seslendirme butonu

### Durum Göstergeleri
- **Mavi**: Hazır durum
- **Yeşil**: Başarılı işlem
- **Kırmızı**: Kayıt aktif
- **Turuncu**: İşlem devam ediyor
- **Mor**: Seslendirme aktif

## 🔧 Teknik Detaylar

### Kullanılan Teknolojiler
- **C# 12.0** - Programlama dili
- **Windows Forms** - GUI framework
- **System.Speech** - Konuşma tanıma ve sentez
- **Newtonsoft.Json** - JSON işleme
- **HttpClient** - HTTP istekleri
- **.NET 9.0** - Runtime framework

### Mimari Yapı
```
SpeechToTextTranslator/
├── Form1.cs              # Ana form sınıfı
├── Form1.Designer.cs     # UI tasarım dosyası
├── Program.cs            # Uygulama giriş noktası
├── SpeechToTextTranslator.csproj  # Proje dosyası
└── README.md            # Bu dosya
```

### Ana Sınıflar ve Metodlar
- **Form1**: Ana form sınıfı
  - `InitializeSpeechComponents()`: Konuşma bileşenlerini başlatır
  - `TranslateText()`: Metin çevirisi yapar
  - `btnStartRecording_Click()`: Kayıt başlatır
  - `btnStopRecording_Click()`: Kayıt durdurur
  - `btnTranslate_Click()`: Çeviri işlemi
  - `btnSpeak_Click()`: Seslendirme işlemi

## 🌍 Desteklenen Diller

### Mevcut Dil Desteği
- **Türkçe** (tr-TR)
- **İngilizce** (en-US)

### Gelecek Sürümlerde Eklenecek
- Almanca (de-DE)
- Fransızca (fr-FR)
- İspanyolca (es-ES)
- Arapça (ar-SA)

## 🐛 Bilinen Sorunlar

1. **Mikrofon İzni**: İlk çalıştırmada Windows mikrofon izni isteyebilir
2. **Dil Paketleri**: Türkçe/İngilizce dil paketleri yüklü olmalı
3. **Ses Kalitesi**: Düşük kaliteli mikrofonlarda tanıma doğruluğu azalabilir
4. **Çeviri Sözlüğü**: Şu anda sınırlı kelime sözlüğü kullanılıyor

## 🔮 Gelecek Geliştirmeler

### Planlanan Özellikler
- [ ] Google Translate API entegrasyonu
- [ ] Daha fazla dil desteği
- [ ] Ses kaydetme özelliği
- [ ] Çeviri geçmişi
- [ ] Favori çeviriler
- [ ] Karanlık tema
- [ ] Klavye kısayolları
- [ ] Çoklu pencere desteği

### Teknik İyileştirmeler
- [ ] Null reference uyarılarının giderilmesi
- [ ] Unit testlerin eklenmesi
- [ ] Logging sistemi
- [ ] Hata yönetimi iyileştirmeleri
- [ ] Performans optimizasyonları

## 🤝 Katkıda Bulunma

Bu proje açık kaynaklıdır ve katkılarınızı bekliyoruz!

### Katkı Yöntemleri
1. **Fork** yapın
2. **Feature branch** oluşturun (`git checkout -b feature/AmazingFeature`)
3. **Commit** yapın (`git commit -m 'Add some AmazingFeature'`)
4. **Push** yapın (`git push origin feature/AmazingFeature`)
5. **Pull Request** oluşturun

### Katkı Kuralları
- Kod standartlarına uyun
- Açıklayıcı commit mesajları yazın
- Test yazın (mümkünse)
- README'yi güncelleyin

## 📄 Lisans

Bu proje MIT lisansı altında lisanslanmıştır. Detaylar için `LICENSE` dosyasına bakın.

## 👨‍💻 Geliştirici

**Berka** - Proje geliştiricisi
- GitHub: [@berka](https://github.com/berka)
- Email: berka@example.com

## 🙏 Teşekkürler

- **Microsoft** - .NET ve Windows Forms framework'ü için
- **System.Speech** - Konuşma işleme kütüphanesi için
- **Newtonsoft** - JSON işleme için
- **GitHub** - Proje hosting için

## 📞 İletişim

Sorularınız, önerileriniz veya hata raporları için:
- **GitHub Issues**: [Issues sayfası](https://github.com/kullaniciadi/SpeechToTextTranslator/issues)
- **Email**: berka@example.com
- **Discord**: berka#1234

---

⭐ **Bu projeyi beğendiyseniz yıldız vermeyi unutmayın!** ⭐
