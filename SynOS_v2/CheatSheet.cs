using System;
using System.Diagnostics;

namespace Lernprojekt.CheatSheet
{
    public class Einleitung
    {
        public string title = "Anwendung";
        public string itemName = "Diamond Sword";
        public string Name = "Justin";

        /*  Seite 1 - Variablen
         *  
         *                  |Schaden, Verteidigung, Name|
         *  Damit Werte wie |Lebenspunkte, Coins usw... | gespeichert werden können, muss vorher eine Variable dafür festgelegt werden.
         *  
         *  Wie legt man eine Variable fest? 
         *  Im ersten Beispiel (class Beispiel_1) stehen ein paar Beispielvariablen.
         *  
         *  (Schritt 1 - Typen)
         *  Es gibt verschiedene Arten von Variablen:
         *  - string = Kann Text speichern.
         *  - int = Kann Zahlen wie: 1,2,-6,100... speichern
         *  - float = Kann Kommazahlen speichern: 1.2343, 76.5, -24.5555
         *  - bool = Kann nur 2 Werte haben: 'true' oder 'false'
         *  
         *  Der Name deiner Variable ist egal. Er sollte aber im Regelfall mit einem kleinbuchstaben beginnen. Dies ist aber keine Pflicht
         *  
         *
         *  Was ist 'public'?
         *  public ist ein Zugriffsmodifikator. Er bestimmt für welche Klassen diese Variable Sichtbar ist.
         *  Wichtig: Für den Anfang solltest du alles auf 'public' deklarieren. Das Thema "Zugriffsmodifikator" wird später erst wichtig.
         * 
         *  Was ist 'string'?
         *  string bestimmt den Typen der Variable (Siehe Einleitung -> Schritt 1)
         */

        public float Gewicht = 50.5f;
        public float Distanz = 10.78f;
        public float Liter = 2.7f;
        /*
         * Was bedeutet das kleine 'f' hinter dem Wert?
         * Wenn du eine float Variable erstellst und ihren Wert zuweist musst du darauf achten ein kleines 'f' dahinter zu schreiben.
         * Das ist eine Regel von C#
         */

        public int Anzahl = 10;
        public int Level = 56;
        public int Leben = 3;

        public bool canEquip = false;
        public bool hasAcces = false;
        public bool MaschieneIstAktiviert = true;
        /*
         * Was ist 'true'?
         * true bedeutet Wahr und false bedeutet Falsch
         */
    }




    /*
     * Seite 2 - Klassen
     * 
     * Nehmen wir an du möchtest ein Monster Programmieren. Dann musst du als erstes eine Klasse erstellen das Monster heißt.
     * Der Name der Klasse ist hier ebenfalls egal. Sollte im Regelfall aber groß geschrieben werden.
     * 
     * Warum eine Klasse erstellen?
     * Eine Klasse ermöglicht es dir alle eigenschaften deines Monsters zu definieren.
     * Wenn es laufen soll musst zu zum Beispiel festlegen wie schnell. Also eine Movement Speed.
     */
    public class Monster
    {
        public string name = "Lavamonster";
        public int attackDamage = 10;
        public int hp = 100;

        /*
         * Seite 3 - Methoden
         * 
         * Bis jetzt hast du einem Monster nur seine Eigenschaften gegeben. Die können aber noch nichts wirklich bewirken als in deinem Code rum zu stehen.
         * Da kommen Methoden ins Spiel. Es sind kleinere Abschnitte sowas wie Codeschnippsel die Ausgeführt werden können.
         */


        // Was ist 'void'?
        // Das ist der "Rückgabetyp". void bedeutet das diese Methode (GetDamage) nichts zurück gibt.
        //      |
        //      |   Alles was innerhalb dieser Methode steht wird ausgeführt sobald sie aufgerufen wird.
        //      |   |
        public void GetDamage()
        {
            // Wenn GetDamage aufgerufen wird, werden 3 von der Variable 'hp' subtrahiert.
            // Genaue erklärung: hp = hp - 3
            //                   |    |    |
            //                   |    |    └ Das was abgezogen wird
            //                   |    └───── Der Basiswert   
            //                   └────────── Die Variable 'hp' wird auf folgenden Wert gesetzt: hp = (...) <- Hier kann auch ein andere Wert stehen: 1,2,3
            // 
            // [i] Mit Variablen kann auch gerechnet werden.

            // Hier wird hp auf (hp minus 3) gesetzt
            hp = hp - 3;
        }
    }

    public class Taschenrechner
    {
        public void Berechne()
        {
            int ersteZahl = 10;
            int zweiteZahl = 5;

            // Was denkst du welcher Wert 'summe' bekommt?
            // Welche Zahl wird sie beinhalten?
            int summe = ersteZahl - zweiteZahl;
            // Du kannst auch andere Variablen mit dem gleichen Wert setzten
            int dritteZahl = ersteZahl - zweiteZahl;

            // Hier wird die Variable 'summe' in der Konsole ausgegeben
            // ersteZahl - zweiteZahl = summe
            Console.WriteLine(summe);

            // Hier ein paar Beispiele:
            dritteZahl -= 5; // Das ist die abkürung für 'dritteZahl = dritteZahl - 5'

            // Hier wird plus 5 auf dritteZahl gerechnet
            dritteZahl += 5;

            // Hier wird dritteZahl mal 2 multipliziert
            dritteZahl *= 2;

            // Hier wird sie durch 2 geteilt
            dritteZahl /= 2;

            Console.WriteLine(dritteZahl);
        }
    }





}
