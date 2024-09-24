- [Uçuş Arama Uygulaması (Backend)](#uçuş-arama-uygulaması-backend)
  - [Özellikler](#özellikler)
  - [Gereksinimler](#gereksinimler)
  - [Kurulum](#kurulum)

# Uçuş Arama Uygulaması (Backend)

Bu proje, uçuş arama işlemlerini SOAP servisleri ile gerçekleştiren bir **.NET Core Web API** uygulamasıdır. Kullanıcıların uçuş arama taleplerini alır ve SOAP tabanlı bir uçuş sağlayıcısına istek yaparak sonuçları JSON formatında döndürür.

## Özellikler

- POST API ile uçuş arama
- SOAP servis entegrasyonu
- JSON formatında uçuş sonuçlarını döndürme
- CORS (Cross-Origin Resource Sharing) desteği
- Health check API'si

## Gereksinimler

- **.NET SDK** v8.0 veya üzeri

## Kurulum

Projeyi klonladıktan sonra şu adımları izleyin:

1. **Bağımlılıkları Yükleyin**:

   Proje dizinine gidin ve bağımlılıkları yüklemek için şu komutu çalıştırın:

   ```bash
   dotnet restore
   ```
