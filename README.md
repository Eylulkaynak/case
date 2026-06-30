Bu proje, Unity 2D kullanılarak geliştirilen bir aksiyon oyununun temel mekaniklerini içermektedir. 
Temel Özellikler
Gelişmiş Skor ve Rekor Sistemi: PlayerPrefs kullanılarak cihaz hafızasına kaydedilen, oyun kapatılsa bile silinmeyen kalıcı rekor sistemi.
(R tuşu ile skor sıfırlanabilir)


Karakterin animasyonu ve atış yönünün değişmesi
 Belirli aralıklarla rastgele konumlarda düşman üreten ve bu düşmanların anında oyuncuyu bularak peşine düşmesini sağlayan sistem.

GameManager.cs

IDamageable.cs

PlayerMovement.cs
Bullet.cs: 
EnemyHealth.cs: 
EnemyMovement.cs: 
EnemySpawner.cs: 
Kontroller ve Kısayollar
A / D veya Yön Tuşları: Sağa ve sola hareket.

Space (Boşluk): Zıplama.

Left Shift: Koşma.

R Tuşu: Kaydedilmiş en yüksek skoru (High Score) ve mevcut skoru anında sıfırlama.
enemy sprites ı ve background craftpix sayfasından alınmıştır.
background: https://craftpix.net/freebies/free-pixel-art-fantasy-2d-battlegrounds/
enemy: https://craftpix.net/freebies/free-shinobi-sprites-pixel-art/
