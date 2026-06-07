# Servis Talep Yonetim Sistemi

Servis Talep Yonetim Sistemi, teknik servis taleplerini kaydetmek, listelemek, aramak, filtrelemek ve durumlarini guncellemek icin hazirlanmis basit bir full-stack uygulamasidir.

Proje iki ana bolumden olusur:

- `ServisTalep.Api`: ASP.NET Core Web API backend
- `frontend`: HTML, CSS ve JavaScript ile hazirlanmis statik frontend

## Ozellikler

- Yeni servis talebi olusturma
- Servis taleplerini listeleme
- Musteri adi, cihaz adi veya aciklama alanlarinda arama
- Duruma gore filtreleme
- Sayfalama destegi
- Talep detayini ID ile getirme
- Talep durumunu guncelleme
- Talep silme
- SQLite veritabani ile kalici veri saklama
- Swagger UI ile API dokumantasyonu ve test imkani

## Kullanilan Teknolojiler

Backend:

- .NET 8
- ASP.NET Core Web API
- Entity Framework Core
- SQLite
- Swagger / Swashbuckle

Frontend:

- HTML
- CSS
- JavaScript
- Fetch API

## Proje Yapisi

```text
ServisTalep/
+-- ServisTalep.Api/
|   +-- Controllers/
|   |   +-- RequestController.cs
|   +-- Data/
|   |   +-- AppDbContext.cs
|   +-- DTOs/
|   +-- Migrations/
|   +-- Models/
|   |   +-- ServiceRequest.cs
|   +-- Services/
|   +-- Program.cs
|   +-- appsettings.json
|   +-- ServisTalep.Api.csproj
+-- frontend/
|   +-- index.html
|   +-- style.css
|   +-- app.js
+-- README.md
```

## Gereksinimler

- .NET 8 SDK
- Modern bir web tarayicisi
- Visual Studio, Visual Studio Code veya benzeri bir editor

## Kurulum ve Calistirma

Once backend projesinin klasorune girin:

```bash
cd ServisTalep.Api
```

NuGet paketlerini yukleyin:

```bash
dotnet restore
```

Veritabani migration dosyalarini uygulayin:

```bash
dotnet ef database update
```

API'yi calistirin:

```bash
dotnet run
```

Varsayilan HTTP adresi:

```text
http://localhost:5279
```

Swagger arayuzu:

```text
http://localhost:5279/swagger
```

Frontend'i calistirmak icin `frontend/index.html` dosyasini tarayicida acin. Frontend, API'ye su adres uzerinden istek atacak sekilde ayarlanmistir:

```javascript
const API_URL = "http://localhost:5279/api/requests";
```

API farkli bir portta calisirsa `frontend/app.js` dosyasindaki `API_URL` degerini guncelleyin.

## Veritabani

Uygulama SQLite kullanir. Baglanti bilgisi `ServisTalep.Api/appsettings.json` dosyasindadir:

```json
"ConnectionStrings": {
  "DefaultConnection": "Data Source=servistalep.db"
}
```

Veritabani dosyasi backend klasorunde `servistalep.db` olarak olusturulur.

## API Endpointleri

Base URL:

```text
http://localhost:5279/api/requests
```

### Talep Olusturma

```http
POST /api/requests
Content-Type: application/json
```

Ornek istek:

```json
{
  "customerName": "Ahmet Yilmaz",
  "deviceName": "Laptop",
  "description": "Cihaz acilmiyor"
}
```

### Talepleri Listeleme

```http
GET /api/requests
```

Query parametreleri:

- `search`: Musteri adi, cihaz adi veya aciklama icinde arama yapar
- `status`: Duruma gore filtreler
- `page`: Sayfa numarasi
- `pageSize`: Sayfa basina kayit sayisi

Ornek:

```http
GET /api/requests?search=laptop&status=New&page=1&pageSize=5
```

### ID ile Talep Getirme

```http
GET /api/requests/{id}
```

### Talep Durumu Guncelleme

```http
PUT /api/requests/{id}/status
Content-Type: application/json
```

Ornek istek:

```json
{
  "status": "InProgress"
}
```

Gecerli durum degerleri:

- `New`
- `InProgress`
- `Completed`
- `Cancelled`

### Talep Silme

```http
DELETE /api/requests/{id}
```

## Frontend Kullanimi

Frontend ekraninda:

- Yeni talep formu ile musteri adi, cihaz adi ve ariza aciklamasi girilebilir.
- Talep listesi tablo olarak goruntulenir.
- Arama kutusu ile kayitlar filtrelenebilir.
- Durum secimi ile talepler durumuna gore filtrelenebilir.
- Onceki ve sonraki butonlari ile sayfalar arasinda gezilebilir.

## Notlar

- API gelistirme modunda Swagger UI acilir.
- CORS politikasi frontend isteklerine izin verecek sekilde ayarlanmistir.
- Projede servis katmani kullanilarak controller ve veri erisimi ayrilmistir.
