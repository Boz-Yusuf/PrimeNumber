# PrimeNumber

## Seed Data Notu
Sisteme kaydolan herkese admin rolü verilmiyor. Admin rolü için seed data ile oluşturulan 
email: admin@example.com
password: Admin.35
credentials değerlerini kullanbilirsiniz ya da userrole tablosundan yeni kaydolucak kullanıcılar için düzenleme yapabilirsiniz

## Gereksinimler
- Visual Studio
- MsSql

## Kurulum 
- Appsettings dosyasındaki DefaultConnection adresinin düzenlenmesi
- Yeni repository katmanından migration migration oluşturulması => add-migration
- veritabanın oluşturulması => update-database
- Cors hatası için Program.cs dosyasında port düzenlemesi yapılması (projedeki adres => http://127.0.0.1:5500)
- Frontend uygulaması için request adreslerinin düzenlenmesi (projedeki adres => https://localhost:7100)
