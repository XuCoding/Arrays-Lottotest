namespace Lotto_Zahlen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Teil1

            //Lottozahlen
            //Erstellen Sie ein int[] lottozahlen mit der Länge 49.
            //Schreiben Sie dann einen Code der dieses Array automatisch mit den Zahlen 1 - 49 befüllt.

            //Teil2

            //Ziehung der Lottozahlen
            //Aus dem Array unserer Lottozahlen sollen nun sechs Zahlen zufällig gezogen werden.
            //Diese sechs Zahlen müssen in einem neuen Array abgelegt werden. 
            //Verwenden Sie auch wieder Random für die Zufällige Ziehung.
            //Bei den gezogenen Zahlen darf es zu keiner Dopplung kommen.

            //Teil3

            //User-Eingabe und Gewinnausgabe
            //Der User soll in der Lage sein, sechs Zahlen einzugeben.
            //Diese werden in einem Array abgelegt.
            //Danach soll überprüft werden, wieviele Zahlen der User im Vergleich zu den gezogenen Lottozahlen richtig getippt hat.
            //Geben Sie in der Konsole aus, wieviele Richtige getippt wurden.

            //Sollten Sie in der vorherigen Aufgabe zu keiner Lösung gekommen sein, schreiben Sie von Hand ein Array mit gezogenen Zahlen.


            // Teil 1: 

            int[] lottozahlen = new int[49];
            for (int i = 0; i < lottozahlen.Length; i++)
            {
                lottozahlen[i] = i + 1; 
            }

            // Teil 2: 

            Console.WriteLine("Geben Sie Ihre sechs Tipps ein (Zahlen zwischen 1 und 49):");
            int[] userTipps = new int[6];
            for (int i = 0; i < userTipps.Length; i++)
            {
                while (true)
                {
                    Console.Write($"Tipp {i + 1}: ");
                    if (int.TryParse(Console.ReadLine(), out int tipp) && tipp >= 1 && tipp <= 49 && !userTipps.Contains(tipp))
                    {
                        userTipps[i] = tipp;
                        break;
                    }
                    Console.WriteLine("Ungültige Eingabe. Bitte geben Sie eine Zahl zwischen 1 und 49 ein, die noch nicht gewählt wurde.");
                }
            }

            // Teil 3: 

            Random random = new Random();
            int[] gezogeneZahlen = new int[6];
            for (int i = 0; i < gezogeneZahlen.Length; i++) //solange i kleiner 6 (gZ) erhöhe i um eins (i++)
            {
                int zufallszahl;
                do
                {
                    zufallszahl = lottozahlen[random.Next(0, lottozahlen.Length)];  // Verhindert Dopplungen
                } while (gezogeneZahlen.Contains(zufallszahl)); 
               

                gezogeneZahlen[i] = zufallszahl;
            }

            
            Console.WriteLine("\nDie gezogenen Lottozahlen sind: " + string.Join(", ", gezogeneZahlen));

            
            int treffer = gezogeneZahlen.Intersect(userTipps).Count();
            Console.WriteLine($"Sie haben {treffer} Treffer!");



        }
    }
}
