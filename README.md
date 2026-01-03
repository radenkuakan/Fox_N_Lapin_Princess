# GAME: FOX & LAPIN PRINCESS 🦊🐰

**Tugas UAS Proyek Fase 5 - Final Build & Deployment (Android)**

**Pengembang (Kelompok 6):**
* **Nama:** Ghizabella Nurania
* **Nama:** Mochammad Arya Aprilian Pratama
* **Nama:** Raden Satria Wiratama

**Kelas:** 3A Pendidikan Multimedia - UPI Kampus di Cibiru

---

## 🎮 Deskripsi Game
**Fox & Lapin Princess** adalah game *2D Pixel Art Platformer* berbasis **Android (Mobile)** yang menceritakan petualangan seekor Rubah pemberani. Pemain harus melewati hutan yang penuh rintangan, duri, dan musuh untuk menyelamatkan Putri Lapin yang hilang.

Berbeda dengan versi sebelumnya, versi final ini telah dioptimalkan untuk layar sentuh, memiliki sistem profil pemain, dan narasi yang personal.

---

## 🚀 Update Fase 5 (Final Build & Android Porting)
Fase ini adalah tahap penyelesaian akhir di mana game dikonversi sepenuhnya dari PC ke Android, berikut fitur utamanya:

### 1. Android Porting & Optimization 📱
* **Touchscreen Controls:** Implementasi tombol virtual (On-Screen UI) untuk Kiri, Kanan, dan Lompat.
* **Resolution Scaling:** UI menyesuaikan berbagai ukuran layar HP (Responsive Canvas).
* **Performance:** Game dikunci pada **60 FPS** dan VSync dinonaktifkan untuk performa baterai yang efisien.

### 2. Profile & Save System 💾
* **Input Nama Pemain:** Fitur baru di awal permainan untuk memasukkan nama (Nickname).
* **Data Persistence:** Nama dan Skor tersimpan permanen menggunakan *PlayerPrefs* (tidak hilang walau aplikasi ditutup).
* **Fitur "Ganti Nama":** Opsi di menu pengaturan untuk mereset identitas pemain.

### 3. Personalized Narrative 📜
* **Smart Prologue:** Teks cerita intro secara otomatis menyisipkan nama pemain ke dalam dialog (Contoh: *"RADEN, BANTU DIA..."*), membuat pengalaman bermain lebih imersif.

### 4. Final Polish ✨
* **Tirai Hitam (Fade):** Menutupi *glitch* visual saat memuat data profil.
* **Warning System:** Notifikasi jika pemain lupa mengisi nama saat setup awal.

---

## 🧩 Fitur Lengkap

### 1. Game Mechanics (Mekanik Permainan)
* **Character Movement:** Fisika karakter yang responsif terhadap input sentuhan.
* **AI Enemy:** Musuh berpatroli (Opossum & Eagle) yang memberikan *damage* saat disentuh.
* **Hazard System:** Duri dan Jurang yang mematikan.
* **Checkpoint:** Respawn di titik aman terakhir.

### 2. User Interface (UI) System
* **Profile Setup Panel:** Panel awal untuk registrasi nama.
* **Main Menu:** Menampilkan sapaan personal ("Hi, [Nama]").
* **Virtual Gamepad:** Tombol kontrol transparan di layar permainan.
* **Flow Panels:** Pause, Game Over, dan Level Complete.

### 3. Level Design
* **Level 1 (The Forest):** Level lengkap dengan kurva kesulitan bertahap (Tutorial -> Tantangan -> Finish).

### 4. Audio Implementation
* **Dynamic Audio:** BGM yang berbeda tiap scene dan SFX lengkap.

---

## 🕹️ Cara Bermain (Android Controls)

| Tombol di Layar | Fungsi |
| :--- | :--- |
| **Tombol Panah Kanan (➡️)** | Bergerak Maju |
| **Tombol Panah Kiri (⬅️)** | Bergerak Mundur |
| **Tombol Panah Atas (⬆️)** | Melompat (*Jump*) |
| **Tap Layar / Tombol UI** | Interaksi Menu |

---

## 📥 Cara Mengunduh & Memainkan Game (APK)

Game ini sudah tersedia dalam format **.APK** yang bisa diinstal di HP Android.
1. Masuk ke tab **Releases** di sebelah kanan halaman GitHub ini.
2. Pilih versi terbaru.
3. Download file **`Fox N Lapin Princess v1.0.5.apk`**.
4. Install di HP Android kamu dan mainkan!

---

## 🛠️ Cara Menggunakan Project Ini (Untuk Developer)

Jika ingin membuka *source code* game ini di Unity Editor:

1. **Clone Repository:**
   ```bash
   git clone [https://github.com/radenkuakan/Fox_N_Lapin_Princess.git](https://github.com/radenkuakan/Fox_N_Lapin_Princess.git)
