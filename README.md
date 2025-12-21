# GAME: FOX & LAPIN PRINCESS 🦊🐰

**Tugas UAS Proyek Fase 4 - Polish & Optimization**

**Pengembang (Kelompok 6):**
* **Nama:** Ghizabella Nurania
* **Nama:** Mochammad Arya Aprilian Pratama
* **Nama:** Raden Satria Wiratama

**Kelas:** 3A Pendidikan Multimedia - UPI Kampus di Cibiru

---

## 🎮 Deskripsi Game
**Fox & Lapin Princess** adalah game *2D Pixel Art Platformer* yang menceritakan petualangan seekor Rubah pemberani. Pemain harus melewati hutan yang penuh rintangan, duri, dan musuh untuk menyelamatkan Putri Lapin yang hilang. Game ini menuntut ketangkasan pemain dalam melompat dan menghindari bahaya.

---

## 🚀 Update Fase 4 (Polish & Optimization)
Pada fase ini, pengembangan difokuskan pada perbaikan *bug*, penyeimbangan permainan (*balancing*), serta peningkatan kualitas visual dan audio:

### 1. Bug Fixing & Optimization 🛠️
* Perbaikan *colliders* pada tilemap agar pemain tidak tersangkut.
* Optimasi skrip untuk performa yang lebih ringan.
* Perbaikan logika *respawn* dan *scene management*.

### 2. Game Balancing ⚖️
* Penyesuaian tata letak rintangan dan musuh agar tingkat kesulitan lebih adil (*fair*).
* Penyesuaian *gravity* dan *jump force* karakter agar kontrol terasa lebih responsif.

### 3. Visual Polish ✨
* **Particles:** Penambahan efek partikel (debu saat lari/lompat, efek saat mengambil item).
* **Animations:** Memperhalus transisi animasi karakter (Idle ke Run, Jump ke Fall).
* **Transitions:** Penambahan transisi *Fade In/Fade Out* antar *scene* agar perpindahan tidak kaku.

### 4. Audio Polish 🎵
* *Mixing* ulang volume BGM dan SFX agar seimbang.
* Penambahan efek suara yang sebelumnya kurang (seperti suara *footsteps* atau *landing*).

---

## 🧩 Fitur Lengkap (Fase 3 & Sebelumnya)

### 1. Game Mechanics (Mekanik Permainan) ✅
* **Character Movement:** Sistem gerak fisika yang halus (Jalan Kanan/Kiri, Lompat).
* **Collision System:** Deteksi tabrakan yang akurat untuk tanah (*Ground Check*), musuh, dan item.
* **Hazard & Death:** Pemain akan mati jika menyentuh musuh, duri, atau jatuh ke jurang.
* **Respawn System:** Pemain hidup kembali di titik *Checkpoints* terakhir tanpa me-reset skor.

### 2. User Interface (UI) System ✅
* **Main Menu:** Tombol Start, Options, dan Quit yang berfungsi.
* **HUD (Heads-Up Display):** Tampilan skor *real-time* di layar permainan.
* **Pause System:** Game bisa dijeda, menampilkan panel Pause dengan opsi Resume/Back to Menu.
* **Game Over & Win Panels:** Tampilan interaktif saat pemain kalah atau berhasil menyelesaikan level.
* **Scene Flow:** Terdapat *Splash Screen* (Opening) dan *Intro Story*.

### 3. Level Design (Complete Stage) ✅
* **Level 1 (Forest):** Satu level utuh dari titik *Start* hingga *Finish Line*.
* Terdapat variasi rintangan (*Platforming*, Jurang, Musuh).
* Transisi otomatis ke level selanjutnya saat menyentuh titik akhir.

### 4. Scoring System ✅
* Mekanik pengumpulan item (Buah Cherry).
* Skor bertambah saat item diambil dan tersimpan secara statis.

### 5. Audio Implementation ✅
* **Background Music (BGM):** Musik *seamless* antar-scene menggunakan pola *Singleton*.
* **Sound Effects (SFX):** Lengkap (Tombol, Lompat, Collect, Kalah, Menang).
* **Volume Control:** Pengaturan volume menggunakan Slider di menu Options.

---

## 🕹️ Cara Bermain (Controls)

| Tombol | Fungsi |
| :--- | :--- |
| **Panah Kanan / D** | Bergerak ke Kanan |
| **Panah Kiri / A** | Bergerak ke Kiri |
| **Spasi (Space)** | Melompat |
| **Mouse Klik** | Interaksi UI |

---
*Disusun untuk memenuhi Tugas UAS Mata Kuliah Pemograman Berbasis Objek.*
