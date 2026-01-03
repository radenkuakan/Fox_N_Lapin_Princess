using UnityEngine;
using TMPro;
using System.Text.RegularExpressions;

public class PrologPersonalizer : MonoBehaviour
{
    void Start()
    {
        // 1. Ambil komponen teks
        TextMeshProUGUI textComponent = GetComponent<TextMeshProUGUI>();

        if (textComponent != null)
        {
            // 2. Ambil Nama Player
            // Defaultnya "Teman" kalau belum ada data
            string nama = PlayerPrefs.GetString("NamaPlayer", "Teman");

            // --- [BAGIAN YANG DIHAPUS] ---
            // nama = nama.ToUpper(); <--- Ini biang keroknya, saya hapus baris ini.
            // Sekarang nama akan tampil apa adanya (misal: "Raden").

            // 3. MANTRA SAKTI (REGEX)
            string teksAsli = textComponent.text;

            // Logika: Cari kata "bantu dia" (ignore case)
            // Ganti dengan: "Raden, bantu dia" (Pakai huruf kecil biar rapi)
            string teksBaru = Regex.Replace(teksAsli, "bantu dia", nama + ", bantu dia", RegexOptions.IgnoreCase);

            // 4. Masukkan kembali ke layar
            textComponent.text = teksBaru;
        }
    }
}