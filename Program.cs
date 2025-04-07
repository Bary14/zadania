using System;
using System.Collections.Generic;

// Lista produktów w magazynie
List<Produkt> magazyn = new();

// Główna pętla programu
while (true)
{
    Console.WriteLine("Wybierz opcję:");
    Console.WriteLine("1. Dodaj produkt");
    Console.WriteLine("2. Usuń produkt");
    Console.WriteLine("3. Wyświetl listę produktów");
    Console.WriteLine("4. Aktualizuj produkt");
    Console.WriteLine("5. Oblicz wartość magazynu");
    Console.WriteLine("6. Wyjście");

    string opcja = Console.ReadLine();

    switch (opcja)
    {
        case "1": DodajProdukt(); break;
        case "2": UsunProdukt(); break;
        case "3": WyswietlListeProduktow(); break;
        case "4": AktualizujProdukt(); break;
        case "5": ObliczWartoscMagazynu(); break;
        case "6": Console.WriteLine("Koniec programu."); return;
        default: Console.WriteLine("Nieprawidłowa opcja. Spróbuj ponownie."); break;
    }
}

// Funkcja dodawania produktu
void DodajProdukt()
{
    Console.Write("Podaj nazwę produktu: ");
    string nazwa = Console.ReadLine();
    Console.Write("Podaj ilość: ");
    int ilosc = int.Parse(Console.ReadLine());
    Console.Write("Podaj cenę jednostkową: ");
    double cena = double.Parse(Console.ReadLine());
    Console.Write("Podaj kod kreskowy ");
    string kodKreskowy = Console.ReadLine();

    if (kodKreskowy.ToUpper() == "AUTO")
    {
        kodKreskowy = GenerujKodKreskowy(nazwa);
    }

    magazyn.Add(new Produkt(nazwa, ilosc, cena, kodKreskowy));
    Console.WriteLine($"Produkt dodany pomyślnie Kod kreskowy:{kodKreskowy}");
}

// Funkcja usuwania produktu
void UsunProdukt()
{
    Console.Write("Podaj nazwę produktu do usunięcia: ");
    string nazwa = Console.ReadLine();

    Produkt? produktDoUsuniecia = magazyn.Find(p => p.Nazwa == nazwa);
    if (produktDoUsuniecia != null)
    {
        magazyn.Remove(produktDoUsuniecia);
        Console.WriteLine("Produkt usunięty pomyślnie.");
    }
    else Console.WriteLine("Nie znaleziono produktu.");
}

// Funkcja wyświetlania listy produktów
void WyswietlListeProduktow()
{
    Console.WriteLine("Lista produktów:");
    foreach (var produkt in magazyn)
    {
        Console.WriteLine($"Nazwa: {produkt.Nazwa}, Ilość: {produkt.Ilosc}, Cena jednostkowa: {produkt.CenaJednostkowa}");
        Console.WriteLine($"Kod kreskowy:\n{produkt.KodKreskowy}");
    }
}

// Funkcja aktualizacji produktu
void AktualizujProdukt()
{
    Console.Write("Podaj nazwę produktu do aktualizacji: ");
    string nazwa = Console.ReadLine();

    Produkt? produktDoAktualizacji = magazyn.Find(p => p.Nazwa == nazwa);
    if (produktDoAktualizacji != null)
    {
        Console.Write("Podaj nową ilość (lub ENTER, aby pominąć): ");
        string nowaIlosc = Console.ReadLine();
        if (!string.IsNullOrEmpty(nowaIlosc))
            produktDoAktualizacji.Ilosc = int.Parse(nowaIlosc);

        Console.Write("Podaj nową cenę jednostkową (lub ENTER, aby pominąć): ");
        string nowaCena = Console.ReadLine();
        if (!string.IsNullOrEmpty(nowaCena))
            produktDoAktualizacji.CenaJednostkowa = double.Parse(nowaCena);

        Console.WriteLine("Produkt zaktualizowany pomyślnie.");
    }
    else Console.WriteLine("Nie znaleziono produktu.");
}

// Funkcja obliczania wartości magazynu
void ObliczWartoscMagazynu()
{
    double wartoscMagazynu = 0;
    foreach (var produkt in magazyn)
        wartoscMagazynu += produkt.Ilosc * produkt.CenaJednostkowa;

    Console.WriteLine($"Całkowita wartość magazynu: {wartoscMagazynu}");
}

// Funkcja generowania prostego kodu kreskowego (pisemnego)
string GenerujKodKreskowy(string tekst)
{
    return $"|{new string('|', tekst.Length)}|"; // Tworzenie prostego kodu kreskowego bazującego na długości nazwy
}

// Klasa Produkt definiująca strukturę danych
class Produkt(string nazwa, int ilosc, double cenaJednostkowa, string kodKreskowy)
{
    public string Nazwa { get; set; } = nazwa;
    public int Ilosc { get; set; } = ilosc;
    public double CenaJednostkowa { get; set; } = cenaJednostkowa;
    public string KodKreskowy { get; set; } = kodKreskowy;
}

