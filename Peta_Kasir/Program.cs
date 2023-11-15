using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // List untuk menyimpan barang yang dibeli dan harganya
        List<Barang> keranjangBelanja = new List<Barang>();

        while (true)
        {
            Console.WriteLine("1. Tambah Barang");
            Console.WriteLine("2. Lihat Keranjang Belanja");
            Console.WriteLine("3. Selesai Belanja");
            Console.WriteLine("Pilihan Anda: ");
            string pilihan = Console.ReadLine();

            switch (pilihan)
            {
                case "1":
                    TambahBarang(keranjangBelanja);
                    break;
                case "2":
                    LihatKeranjangBelanja(keranjangBelanja);
                    break;
                case "3":
                    SelesaiBelanja(keranjangBelanja);
                    break;
                default:
                    Console.WriteLine("Pilihan tidak valid.");
                    break;
            }
        }
    }

    static void TambahBarang(List<Barang> keranjang)
    {
        Console.WriteLine("Masukkan Nama Barang: ");
        string nama = Console.ReadLine();

        Console.WriteLine("Masukkan Harga Barang: ");
        if (!decimal.TryParse(Console.ReadLine(), out decimal harga))
        {
            Console.WriteLine("Harga tidak valid.");
            return;
        }

        Barang barang = new Barang(nama, harga);
        keranjang.Add(barang);
        Console.WriteLine("Barang berhasil ditambahkan ke keranjang.");
    }

    static void LihatKeranjangBelanja(List<Barang> keranjang)
    {
        Console.WriteLine("Keranjang Belanja:");
        foreach (Barang barang in keranjang)
        {
            Console.WriteLine($"{barang.Nama} - Rp {barang.Harga}");
        }
    }

    static void SelesaiBelanja(List<Barang> keranjang)
    {
        decimal total = 0;
        foreach (Barang barang in keranjang)
        {
            total += barang.Harga;
        }

        Console.WriteLine($"Total Harga: Rp {total}");

        Console.WriteLine("Masukkan Jumlah Uang yang Diberikan: ");
        if (!decimal.TryParse(Console.ReadLine(), out decimal uangDiberikan))
        {
            Console.WriteLine("Jumlah uang tidak valid.");
            return;
        }

        if (uangDiberikan < total)
        {
            Console.WriteLine("Uang yang diberikan kurang.");
            return;
        }

        decimal kembalian = uangDiberikan - total;
        Console.WriteLine($"Kembalian: Rp {kembalian}");

        // Bersihkan keranjang belanja setelah selesai belanja
        keranjang.Clear();
        Environment.Exit(0);
    }
}

class Barang
{
    public string Nama { get; set; }
    public decimal Harga { get; set; }

    public Barang(string nama, decimal harga)
    {
        Nama = nama;
        Harga = harga;
    }
}
