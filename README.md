# GAME: FOX & LAPIN PRINCESS 🦊🐰

**Tugas UAS Proyek Fase 3 - Pengembangan Fitur**

**Pengembang:**
* **Nama:** Ghizabella Nurania
* **Nama:** Mochammad Arya Aprilian Pratama
* **Nama:** Raden Satria Wiratama

* **Kelas:** 3A Pendidikan Multimedia - UPI Kampus di Cibiru

---

## 🎮 Deskripsi Game
**Fox & Lapin Princess** adalah game *2D Pixel Art Platformer* yang menceritakan petualangan seekor Rubah pemberani. Pemain harus melewati hutan yang penuh rintangan, duri, dan musuh untuk menyelamatkan Putri Lapin yang hilang. Game ini menuntut ketangkasan pemain dalam melompat dan menghindari bahaya.

---

## 🚀 Fitur Fase 3 (Full Implementation)
Pada fase ini, pengembangan telah mencapai tahap **Fitur Lengkap** sesuai dengan persyaratan UAS Fase 3, meliputi:

### 1. Game Mechanics (Mekanik Permainan) ✅
* **Character Movement:** Sistem gerak fisika yang halus (Jalan Kanan/Kiri, Lompat).
* **Collision System:** Deteksi tabrakan yang akurat untuk tanah (*Ground Check*), musuh, dan item.
* **Hazard & Death:** Pemain akan mati jika menyentuh musuh, duri, atau jatuh ke air.
* **Respawn System:** Pemain hidup kembali di titik *Checkpoints* terakhir tanpa me-reset *progress* skor.

### 2. User Interface (UI) System ✅
* **Main Menu:** Tombol Start, Options, dan Quit yang berfungsi.
* **HUD (Heads-Up Display):** Tampilan skor *real-time* di layar permainan.
* **Pause System:** Game bisa dijeda, menampilkan panel Pause dengan opsi Resume/Back to Menu.
* **Game Over & Win Panels:** Tampilan interaktif saat pemain kalah atau berhasil menyelesaikan level.
* **Scene Flow:** Terdapat *Splash Screen* (Opening) dan *Intro Story* sebelum masuk ke permainan.

### 3. Level Design (Complete Stage) ✅
* **Level 1 (Forest):** Satu level utuh dari titik *Start* hingga *Finish Line*.
* Terdapat variasi rintangan (*Platforming*, Jurang, Musuh).
* Transisi otomatis ke level selanjutnya saat menyentuh titik akhir.

### 4. Scoring System ✅
* Mekanik pengumpulan item (Buah Cherry).
* Skor bertambah saat item diambil dan tersimpan secara statis.
* Skor tidak hilang saat pemain melakukan *Respawn*.

### 5. Audio Implementation ✅
* **Background Music (BGM):** Musik *seamless* (tidak terputus) antar-scene menggunakan pola *Singleton*.
* **Sound Effects (SFX):** Efek suara lengkap untuk:
    * Tombol UI (Klik).
    * Lompat (Jump).
    * Ambil Item (Collect).
    * Kalah (Game Over).
    * Menang (Level Complete).
* **Volume Control:** Fitur pengaturan volume menggunakan Slider di menu Options.

---

## 🕹️ Cara Bermain (Controls)

| Tombol | Fungsi |
| :--- | :--- |
| **Panah Kanan / D** | Bergerak ke Kanan |
| **Panah Kiri / A** | Bergerak ke Kiri |
| **Spasi (Space)** | Melompat |
| **Mouse Klik** | Interaksi UI |

---

## 🛠️ Cara Menjalankan Project

1.  **Clone/Download** repository ini.
2.  Buka menggunakan **Unity Hub** (Versi 2022.3.13f1 atau yang setara).
3.  Buka Scene **`Opening`** (atau `Main_Menu`) di dalam folder `Assets/Scenes`.
4.  Tekan tombol **Play**.

---

*Disusun untuk memenuhi Tugas UAS Mata Kuliah Pengembangan Game Pendidikan.*
