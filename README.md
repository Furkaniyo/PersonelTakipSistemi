# Personel Takip Sistemi

Bu proje, kurum içi personel yönetim süreçlerini dijitalleştirmek ve veri takibini kolaylaştırmak amacıyla geliştirilmiş bir masaüstü otomasyon uygulamasıdır.
Doğuş Üniversitesi Görsel Programlama dersi dönem sonu projesi kapsamında geliştirilmiştir.

## 📌 Projenin Amacı ve Kapsamı
Personel Takip Sistemi, işletmelerin insan kaynakları departmanlarında ihtiyaç duyulan temel veri yönetim işlemlerini hızlı, güvenli ve kullanıcı dostu bir arayüz ile gerçekleştirmesini sağlar.
Uygulama, yöneticilere ve personellere farklı yetkilendirme seviyeleri sunarak güvenli bir veri akışı hedefler.

## 🚀 Temel Özellikler
* **Yetkilendirme Sistemi:** Admin (Yönetici) ve Standart Kullanıcı olmak üzere iki farklı rol yapısı.
* **CRUD İşlemleri:** Personel verilerinin sisteme eklenmesi, listelenmesi, güncellenmesi ve silinmesi.
* **Gelişmiş Arama ve Filtreleme:** Kimlik No. ve Ada göre hızlı personel sorgulama.
* **Şifre Güvenliği Kontrolü:** Yeni kullanıcı eklerken şifre zorluk derecesini anlık olarak ölçen algoritma.
* **Excel'e Dışa Aktarma:** Veritabanındaki personel listesini tek tıkla Microsoft Excel formatında dışa aktarma.
* **Veri Güvenliği:** Form ekranlarında hatalı veri girişini engelleyen try-catch kontrol kodu sorgu mimarisi kullanılmıştır.

## 🛠️ Kullanılan Teknolojiler
* **Programlama Dili:** C#
* **Platform:** Windows Forms
* **Veritabanı:** Microsoft Access
* **Ek Kütüphaneler:** Microsoft Excel Interop

## ⚠️ Sistem Gereksinimleri
Uygulamanın sorunsuz çalışabilmesi için şu programların kurulu olması gerekir:
* **Visual Studio** (.NET Masaüstü Geliştirme paketi ile)
* **Microsoft Access Database Engine 2010** veya 2016 (Veritabanı bağlantısı için zorunludur)
* **Microsoft Excel** (Excel'e aktarma özelliği için)

## ⚙️ Kurulum ve Çalıştırma
1. Bu depoyu yerel bilgisayarınıza klonlayın veya `.zip` olarak indirin.
2. Visual Studio üzerinden `PersonelTakipSistemi.sln` dosyasını açın.
3. Çözümü derleyin (Build) ve projeyi başlatın (F5).
4. *Not: Microsoft Access veritabanı dosyası ve resimler proje dizini içerisinde entegre olarak çalışmaktadır, harici bir sunucu kurulumu gerektirmez. Proje derlendiğinde dosyalar otomatik olarak çalışma dizinine kopyalanır.*

## 🔑 Test Ortamı Giriş Bilgileri
Sistemin modüllerini ve yetkilendirme altyapısını test edebilmeniz için örnek hesap bilgileri aşağıda sunulmuştur:

**Yönetici (Admin) Girişi:**
* **Kullanıcı Adı:** admin123
* **Şifre:** 1234

**Standart Kullanıcı Girişi:**
* **Kullanıcı Adı:** mehmet13
* **Şifre:** mehmet4747

---
**Geliştirici:** Furkan Akan
