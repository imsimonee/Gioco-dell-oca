
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gioco_dell_oca
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string sceltaMod = ""; //Scegli se giocare contro utente o pc
            string pedinaUno = ""; //Pedina del giocatore 1
            string pedinaDue = ""; //Pedina del giocatore 2/PC
            int sceltaGiocatoreUno = 0; //Scelta del giocatore 1
            int sceltaGiocatoreDue = 0; //Scelta del giocatore 2/PC
            int posizioneUno = 0; //Posizione player 1
            int posizioneDue = 0; //Posizione player 2
            int[] campo = new int[64]; //Vettore del campo di gioco
            int dadoUno = 0; //Dado 1
            int dadoDue = 0; //Dado 2
            bool turno = false; //Turno dei player
            int tiro = 0; //Tiro del dado
            int casellemancanti = 0; //Caselle mancanti per vincere
            int rimbalzo = 0; //Rimbalzo del player
            bool fine = false; //Boleano per il ciclo while
            string[] campoStr = new string[64]; // Vettore di stringhe per il campo di gioco
            Random rnd = new Random(); //Funzione RANDOM

            //Richiamo tutte le varie funzioni
            Menù(sceltaGiocatoreUno, sceltaGiocatoreDue, ref pedinaUno, ref pedinaDue);
            RiempiCampoStringa(campoStr ,posizioneUno, posizioneDue,  pedinaUno, pedinaDue);          
            DadoEdAvanzamento(campoStr, pedinaUno,pedinaDue,dadoUno, dadoDue, rimbalzo, fine, turno, tiro, campo, ref posizioneUno, ref posizioneDue);

            Console.ReadKey();
        }

        /// <summary>
        /// Mostra il menù iniziale e gestisce l'avvio della partita
        /// </summary>
        /// <param name="sceltaGiocatoreUno">scelta del giocatore 1</param>
        /// <param name="sceltaGiocatoreDue">scelta del giocatore 2</param>
        /// <param name="pedinaUno">pedina del giocatore 1</param>
        /// <param name="pedinaDue">pedina del giocatore 2</param>
        static void Menù(int sceltaGiocatoreUno, int sceltaGiocatoreDue, ref string pedinaUno, ref string pedinaDue)
        {
            //Dichiaro la variabile "scelta" opzione per giocare(si/no)
            string scelta;

            //Sfondo del menù
            Console.WriteLine("                                          \r\n                                          \r\n        :+-#*--                           \r\n    :..::+    =:                          \r\n           ##*+-                          \r\n           #==*.                          \r\n          *:=-.                           \r\n       :-:++-                             \r\n      *:: .:*                             \r\n     #.=  =-###**==*##.*#.                \r\n    :#.: .:.-*=**==*=#-=#-=#-.            \r\n     #.    +.*-+:=**:#*#--*.#*++*         \r\n     =##*.:.: -++*=.=:#--+*###*=+####-    \r\n      .###==  :-.-:-= =-=######-+-+..     \r\n        -###*=-=.+  + .*:==..+*           \r\n          :#####++.-# =--+*+#:            \r\n               +##***#+**=                \r\n               =#    *#.                  \r\n               ==    -.                   \r\n               -+ .:=#                    \r\n          *#+*.++:*=#                     \r\n                                          \r\n                                          ");

            //Menù con opzione per giocare
            Console.WriteLine(".___.__            .__                          .___     .__  .__/\\                      \r\n|   |  |      ____ |__| ____   ____  ____     __| _/____ |  | |  )/  ____   ____ _____   \r\n|   |  |     / ___\\|  |/  _ \\_/ ___\\/  _ \\   / __ _/ __ \\|  | |  |  /  _ \\_/ ___\\\\__  \\  \r\n|   |  |__  / /_/  |  (  <_> \\  \\__(  <_> ) / /_/ \\  ___/|  |_|  |_(  <_> \\  \\___ / __ \\_\r\n|___|____/  \\___  /|__|\\____/ \\___  \\____/  \\____ |\\___  |____|____/\\____/ \\___  (____  /\r\n           /_____/                \\/             \\/    \\/                      \\/     \\/  \n\nvuoi giocare?(si)/(no)");
            scelta = Console.ReadLine();

            if (scelta == "si")
            {
                //Entrata nella partita
                Console.WriteLine("\nBenvenuto nella partita!");
                Modalità(ref pedinaUno, ref pedinaDue, ref sceltaGiocatoreUno, ref sceltaGiocatoreDue);
            }
            else if (scelta == "no")
            {
                //Uscita dalla partita
                Console.WriteLine("Arivederci!");
            }
        }

        /// <summary>
        /// Permette di scegliere se giocare contro il PC o contro un altro giocatore
        /// </summary>
        /// <param name="pedinaUno">pedina del giocatore 1</param>
        /// <param name="pedinaDue">pedina del giocatore 2</param>
        /// <param name="sceltaGiocatoreUno">scelta giocatore 1</param>
        /// <param name="sceltaGiocatoreDue">scelta giocatore 2</param>
        static void Modalità(ref string pedinaUno, ref string pedinaDue, ref int sceltaGiocatoreUno, ref int sceltaGiocatoreDue)
        {
            int sceltaModalità = 0;
            
            Console.WriteLine("vuoi giocare contro il pc o contro un giocatore?(1(giocatore vs pc))/(2(giocatore vs giocatore))");
            sceltaModalità = Convert.ToInt32(Console.ReadLine());

            //Sfondo giocatore vs pc           
            if (sceltaModalità == 1)
            {
                Console.WriteLine("                                                                  \r\n                                                                  \r\n                                                                  \r\n                                                                  \r\n                                                                  \r\n                                                                  \r\n                                                                  \r\n                                                                  \r\n                                                                  \r\n                                                                  \r\n                .:==============================:.                \r\n                :*+----------------------------+*:                \r\n                :*=.                          .-*:                \r\n                :*=.                          .-*:                \r\n                :*=.                          .-*:                \r\n                :*=.                          .-*:                \r\n                :*=.                          .-*:                \r\n                :*=.                          .-*:                \r\n                :*=.                          .-*:                \r\n                :*+::::::::::::::::::::::::::::+*:                \r\n                .-#%%%%%%%%%%%%%%%%%%%%%%%%%%%%#-.                \r\n               .*#*+++++=#=++=#=++=#=++=*=+++++*#*:               \r\n            .:*%%##%####%###*++==+=++*%##%####%##%%*:.            \r\n          .:*%%%%%%%%%%%%%%*:.........+%%%%%%%%%%%%%%*:.          \r\n          =%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%=          \r\n          :++++++++++++++++++++++++++++++++++++++++++++:          \r\n                                                                  \r\n                                                                  \r\n                                                                  \r\n                                                                  \r\n                                                                  \r\n                                                                  \r\n                                                                  \r\n                                                                  \r\n                                                                  \r\n                                                                  ");
                Console.WriteLine("È tempo di sfidare il computer!");
                SceltaPedinaPc(ref pedinaUno, ref pedinaDue, ref sceltaGiocatoreUno, ref sceltaGiocatoreDue);
            }
            //Sfondo giocatore vs giocatore
            else if (sceltaModalità == 2)
            {
                Console.WriteLine("          .-@@@@@@@@-..               \r\n        .*@++@@@@@@*+@#.              \r\n       :@*%@@@@@@@@@@%*@.             \r\n       *@%@@@@@@@@@@@@@%#             \r\n      .@%@@@@@# *@@@@@@@%.            \r\n      =@@@*...   .:**#@@@=            \r\n      =@@@=.@@-  -@@.-@@@=            \r\n      =@@@=          -@@@=            \r\n      =*.@+  .-..:.  =@-+=            \r\n      =* *@=..*%%*. =@*.+=            \r\n      .%  -@@*:..:*@@-..%.            \r\n       .%@++@##%%#*@*+@#.             \r\n        ..:=@+    =@=:..:#@@@@@@#..   \r\n    .+%@@@@@@@-..-@@@**@@@%::::%@@@+. \r\n .+@@@@@@@@@@@@@@@@@#=@@*@@*::#@@-#@- \r\n:@@@@@@+@@@@@@@@@@@@-@@@=@@@@@@@@-#@@:\r\n%@@@@@@:@@@@@@@@@@@=#@%@@@%....@@@@%@*\r\n%%%%%%%:%%%%%%%%%%%:@%.@@@:    -@@@:@@\r\n                   .*@@@@=.    .=@@@@+");
                Console.WriteLine("È tempo di sfidare un altro giocatore!");
                SceltaPedine(ref pedinaUno, ref pedinaDue, ref sceltaGiocatoreUno, ref sceltaGiocatoreDue);
            }
        }

        /// <summary>
        /// Permette ai giocatori di scegliere le proprie pedine
        /// </summary>
        /// <param name="pedinaUno">pedina del giocatore 1</param>
        /// <param name="pedinaDue">pedina del giocatore 2</param>
        /// <param name="sceltaGiocatoreUno">scelta del giocatore 1</param>
        /// <param name="sceltaGiocatoreDue">scelta del giocatore 2</param>
        static void SceltaPedine(ref string pedinaUno, ref string pedinaDue, ref int sceltaGiocatoreUno, ref int sceltaGiocatoreDue)
        {
            //Comando che permette di visualizzare le pedine (in ascii) nella console 
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            //Pedine disponibili
            string tipoUno = "☺";
            string tipoDue = "♥";
            string tipoTre = "♦";
            string tipoQuattro = "♣";
            string tipoCinque = "♠";
            string tipoSei = "♫";
            string tipoSette = "☼";

            //Scelta pedina player 1
            Console.WriteLine("Giocatore 1,scegli la tua pedina, tra le seguenti: " + " 1) " + tipoUno + " 2) " + tipoDue + " 3) " + tipoTre + " 4) " + tipoQuattro + " 5) " + tipoCinque + " 6) " + tipoSei + " 7) " + tipoSette);
            sceltaGiocatoreUno = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"\nGiocatore 1: hai scleto la pedina {sceltaGiocatoreUno}");

            //Scelta pedina giocatore 1
            switch (sceltaGiocatoreUno)
            {
                case (1):
                    pedinaUno = tipoUno;
                    break;
                case (2):
                    pedinaUno = tipoDue;
                    break;
                case (3):
                    pedinaUno = tipoTre;
                    break;
                case (4):
                    pedinaUno = tipoQuattro;
                    break;
                case (5):
                    pedinaUno = tipoCinque;
                    break;
                case (6):
                    pedinaUno = tipoSei;
                    break;
                case (7):
                    pedinaUno = tipoSette;
                    break;
                default:
                    Console.WriteLine("hai inserito un valore non valido");
                    break;
            }

            //Scelta pedina player 2
            Console.WriteLine("Giocatore 2,scegli la tua pedina, tra le seguenti:" + "1) " + tipoUno + "2) " + tipoDue + "3) " + tipoTre + "4) " + tipoQuattro + "5) " + tipoCinque + "6) " + tipoSei + "7) " + tipoSette);
            sceltaGiocatoreDue = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"\nGiocatore 2: hai scleto la pedina {sceltaGiocatoreDue}");

            //Scelta pedina player 2
            switch (sceltaGiocatoreDue)
            {
                case (1):
                    pedinaDue = tipoUno;
                    break;
                case (2):
                    pedinaDue = tipoDue;
                    break;
                case (3):
                    pedinaDue = tipoTre;
                    break;
                case (4):
                    pedinaDue = tipoQuattro;
                    break;
                case (5):
                    pedinaDue = tipoCinque;
                    break;
                case (6):
                    pedinaDue = tipoSei;
                    break;
                case (7):
                    pedinaDue = tipoSette;
                    break;
                default:
                    Console.WriteLine("hai inserito un valore non valido");
                    break;
            }
        }

        /// <summary>
        /// Permette al giocatore di scegliere una pedina, il PC sceglie casualmente
        /// </summary>
        /// <param name="pedinaUno">pedina del giocatore</param>
        /// <param name="pedinaDue">pedina del PC</param>
        /// <param name="sceltaGiocatoreUno">scelta giocatore</param>
        /// <param name="sceltaGiocatoreDue">scelta del PC</param>
        static void SceltaPedinaPc(ref string pedinaUno, ref string pedinaDue, ref int sceltaGiocatoreUno, ref int sceltaGiocatoreDue)
        {
            //Comando che permette di visualizzare le pedine (in ascii) nella console
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            //Pedine disponibili
            string tipoUno = "☺";
            string tipoDue = "♥";
            string tipoTre = "♦";
            string tipoQuattro = "♣";
            string tipoCinque = "♠";
            string tipoSei = "♫";
            string tipoSette = "☼";

            //Scelta pedina player 1
            Console.WriteLine("Giocatore 1,scegli la tua pedina, tra le seguenti: " + " 1) " + tipoUno + " 2) " + tipoDue + " 3) " + tipoTre + " 4) " + tipoQuattro + " 5) " + tipoCinque + " 6) " + tipoSei + " 7) " + tipoSette);
            sceltaGiocatoreUno = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"\nHai scleto la pedina {sceltaGiocatoreUno}");

            //Scelta pedina player 1
            switch (sceltaGiocatoreUno)
            {
                case (1):
                    pedinaUno = tipoUno;
                    break;
                case (2):
                    pedinaUno = tipoDue;
                    break;
                case (3):
                    pedinaUno = tipoTre;
                    break;
                case (4):
                    pedinaUno = tipoQuattro;
                    break;
                case (5):
                    pedinaUno = tipoCinque;
                    break;
                case (6):
                    pedinaUno = tipoSei;
                    break;
                case (7):
                    pedinaUno = tipoSette;
                    break;
                default:
                    Console.WriteLine("hai inserito un valore non valido");
                    break;
            }

            //Scelta pedina PC (Random)
            Random rnd = new Random();

            //Impedisce al PC di scegliere la stessa pedina del player 1
            do
            {
                sceltaGiocatoreDue = rnd.Next(1, 8);
            } 
            while (sceltaGiocatoreDue == sceltaGiocatoreUno);

            //Scelta della pedina del PC
            switch (sceltaGiocatoreDue)
            {
                case (1):
                    pedinaDue = tipoUno;
                    break;
                case (2):
                    pedinaDue = tipoDue;
                    break;
                case (3):
                    pedinaDue = tipoTre;
                    break;
                case (4):
                    pedinaDue = tipoQuattro;
                    break;
                case (5):
                    pedinaDue = tipoCinque;
                    break;
                case (6):
                    pedinaDue = tipoSei;
                    break;
                case (7):
                    pedinaDue = tipoSette;
                    break;
                default:
                    break;
            }

            Console.WriteLine("il Pc ha scelto la pedina " + sceltaGiocatoreDue + "\n");
        }

        /// <summary>
        /// Riempie il tabellone con le posizioni dei giocatori e stampa a video
        /// </summary>
        /// <param name="campoStr">vettore di stringhe del tabellone</param>
        /// <param name="posizioneUno">posizione attuale del giocatore 1</param>
        /// <param name="posizioneDue">posizione attuale del giocatore 2</param>
        /// <param name="pedinaUno">pedina del giocatore 1</param>
        /// <param name="pedinaDue">pedina del giocatore 2</param>
        static void RiempiCampoStringa(string[] campoStr, int posizioneUno, int posizioneDue, string pedinaUno, string pedinaDue)
        {
            //Comando che permette di visualizzare le pedine (in ascii) nella console
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            for (int i = 0; i < campoStr.Length; i++)
            {
                if (i == posizioneUno && i == posizioneDue)
                {
                    campoStr[i] = "[X]"; //Entrambi i player sulla stessa casella
                }
                else if (i == posizioneUno)
                {
                    campoStr[i] = "[" + pedinaUno + "]"; //Posizione del player 1
                }
                else if (i == posizioneDue)
                {
                    campoStr[i] = "[" + pedinaDue + "]"; //Posizione del player 2
                }
                else
                {
                    campoStr[i] = "[" + i + "]"; //Casella normale
                }

                Console.Write(campoStr[i]);
            }
        }

        /// <summary>
        /// Applica bonus e malus in base alla posizione attuale dei giocatori
        /// </summary>
        /// <param name="posizioneUno">posizione giocatore 1</param>
        /// <param name="posizioneDue">posizione giocatore 2</param>
        /// <param name="dadoUno">valore del primo dado</param>
        /// <param name="dadoDue">valore del secondo dado</param>
        static void BonusEMalus(ref int posizioneUno, ref int posizioneDue, ref int dadoUno, ref int dadoDue)
        {
            //Casella ponte avanza alla casella 12
            if (posizioneUno == 6)
            {
                Console.WriteLine("\r\n\r\n  .  .. ..  .  .. ..  .  .. ..  .  .. ..   @@@@@@@@@@@@@@ ..  .  .. ..  .  .. ..  .  .. ..  .  .. ..\r\n.. ..  .  .. ..  .  .. ..  .  .. ..  .@@@@@@@  .  .. ..@@@@@@@...  .  .. ..  .  .. ..  .  .. ..  .  \r\n  .  .. ..  .  .. ..  .  .. ..  . @@@@@.  .  .. ..  .  .. .. @@@@@. ..  .  .. ..  .  .. ..  .  .. ..\r\n................................@@@@............................@@@@ ...............................\r\n.. ..  .  .. ..  .  .. ..  .  @@@..  .  .. ..  .  .. ..  .  .. ..  @@@.. ..  .  .. ..  .  .. ..  .  \r\n  .  .. ..  .  .. ..  .  .. @@@ .  .. ..  .  .. ..  .  .. ..  .  .. .@@@.  .. ..  .  .. ..  .  .. ..\r\n.. ..  .  .. ..  .  .. ..  @@#.. ..  .  .. ..  .  .. ..  .  .. ..  .  #@@..  .  .. ..  .  .. ..  .  \r\n  .  .. ..  .  .. ..  .  @@@..  .  .. -+  .  .. ..  .  .. ..+-.  .. ..  @@@.. ..  .  .. ..  .  .. ..\r\n.. ..  .  .. ..  .  .. .@@@.  .. ..@@@@@@@@@.  .  .. .. @@@@@@@@@  .  .. @@@ .  .. ..  .  .. ..  .  \r\n  .  .. ..  .  .. ..  ..@@. ..  . @@= ..  @@@.. ..  .  @@@..  .=@@. ..  . @@: ..  .  .. ..  .  .. ..\r\n.. ..  .  .. ..  .  .. @@  .  .. @@@ .  .. @@  .  .. ..@@.  .. .@@@.  .. ..@@.  .. ..  .  .. ..  .  \r\n.. ..  .  .. ..  .  ..@@@  .  .. ..  .  .. ..  .  .. ..  .  .. ..  .  .. ..@@@  .. ..  .  .. ..  .  \r\n  .  .. ..  .  .. ..  @@ .. ..  .  .. ..  .  .. ..  .  .. ..  .  .. ..  .   @@..  .  .. ..  .  .. ..\r\n.. ..  .  .. ..  .  ..@@.  .  .. ..  .  .. ..  .  .. ..  .  .. ..  .  .. .. @@  .. ..  .  .. ..  .  \r\n  .  .. ..  .  .. ..  @@ .. .@@ .  .. ..  .  .. ..  .  .. ..  .  .. .@@ .  .@@..  .  .. ..  .  .. ..\r\n.. ..  .  .. ..  .  ..@@.  . @@. ..  .  .. ..  .  .. ..  .  .. ..  . @@. .. @@  .. ..  .  .. ..  .  \r\n  .  .. ..  .  .. ..  @@ .. .@@ .  .. ..  .  .. ..  .  .. ..  .  .. .@@ .  .@@..  .  .. ..  .  .. ..\r\n.. ..  .  .. ..  .  ..@@   . @@@ ..  .  .. ..  .  .. ..  .  .. ..  .@@@. .. @@  .. ..  .  .. ..  .  \r\n.. ..  .  .. ..  .  ..@@@  .  @@ ..  .  .. ..  .  .. ..  .  .. ..  .@@.. ..@@@  .. ..  .  .. ..  .  \r\n  .  .. ..  .  .. ..  .@@.. ..@@@  .. ..  .  .. ..  .  .. ..  .  ..@@@  .  @@ ..  .  .. ..  .  .. ..\r\n.. ..  .  .. ..  .  .. :@@ .  .@@@.  .  .. ..  .  .. ..  .  .. .. @@@ .. .@@..  .. ..  .  .. ..  .  \r\n  .  .. ..  .  .. ..  . @@@ ..   @@@. ..  .  .. ..  .  .. ..  . @@@ ..  .@@@. ..  .  .. ..  .  .. ..\r\n.. ..  .  .. ..  .  .. ..@@@  .. .@@@+  .. ..  .  .. ..  .  ..+@@@ .  ..@@@  .  .. ..  .  .. ..  .  \r\n  .  .. ..  .  .. ..  .  ..@@#  .  .@@@@  .  .. ..  .  .. ..@@@@ .. ..#@@  .. ..  .  .. ..  .  .. ..\r\n.. ..  .  .. ..  .  .. ..  .@@@. ..  .-@@@@@.  .  .. .. @@@@@- ..  . @@@ ..  .  .. ..  .  .. ..  .  \r\n............................. @@@.........@@@@@@@@@@@@@@@@.........@@@..............................\r\n  .  .. ..  .  .. ..  .  .. ..  @@@@. ..  .  .. ..  .  .. ..  . @@@@..  .  .. ..  .  .. ..  .  .. ..\r\n.. ..  .  .. ..  .  .. ..  .  .. .@@@@@ .. ..  .  .. ..  .  .@@@@@ .  .. ..  .  .. ..  .  .. ..  .  \r\n  .  .. ..  .  .. ..  .  .. ..  .  ..:@@@@@@@.. ..  .  @@@@@@@:  .. ..  .  .. ..  .  .. ..  .  .. ..\r\n.. ..  .  .. ..  .  .. ..  .  .. ..  .  ...@@@@@@@@@@@@@@.  .. ..  .  .. ..  .  .. ..  .  .. ..  .  \r\n\r\n");
                Console.WriteLine("BONUS:sei sulla casella ponte:avanzi fino alla casella 12!");
                Console.WriteLine();
                posizioneUno = 12;
            }
            else if (posizioneDue == 6)
            {
                Console.WriteLine("\r\n\r\n  .  .. ..  .  .. ..  .  .. ..  .  .. ..   @@@@@@@@@@@@@@ ..  .  .. ..  .  .. ..  .  .. ..  .  .. ..\r\n.. ..  .  .. ..  .  .. ..  .  .. ..  .@@@@@@@  .  .. ..@@@@@@@...  .  .. ..  .  .. ..  .  .. ..  .  \r\n  .  .. ..  .  .. ..  .  .. ..  . @@@@@.  .  .. ..  .  .. .. @@@@@. ..  .  .. ..  .  .. ..  .  .. ..\r\n................................@@@@............................@@@@ ...............................\r\n.. ..  .  .. ..  .  .. ..  .  @@@..  .  .. ..  .  .. ..  .  .. ..  @@@.. ..  .  .. ..  .  .. ..  .  \r\n  .  .. ..  .  .. ..  .  .. @@@ .  .. ..  .  .. ..  .  .. ..  .  .. .@@@.  .. ..  .  .. ..  .  .. ..\r\n.. ..  .  .. ..  .  .. ..  @@#.. ..  .  .. ..  .  .. ..  .  .. ..  .  #@@..  .  .. ..  .  .. ..  .  \r\n  .  .. ..  .  .. ..  .  @@@..  .  .. -+  .  .. ..  .  .. ..+-.  .. ..  @@@.. ..  .  .. ..  .  .. ..\r\n.. ..  .  .. ..  .  .. .@@@.  .. ..@@@@@@@@@.  .  .. .. @@@@@@@@@  .  .. @@@ .  .. ..  .  .. ..  .  \r\n  .  .. ..  .  .. ..  ..@@. ..  . @@= ..  @@@.. ..  .  @@@..  .=@@. ..  . @@: ..  .  .. ..  .  .. ..\r\n.. ..  .  .. ..  .  .. @@  .  .. @@@ .  .. @@  .  .. ..@@.  .. .@@@.  .. ..@@.  .. ..  .  .. ..  .  \r\n.. ..  .  .. ..  .  ..@@@  .  .. ..  .  .. ..  .  .. ..  .  .. ..  .  .. ..@@@  .. ..  .  .. ..  .  \r\n  .  .. ..  .  .. ..  @@ .. ..  .  .. ..  .  .. ..  .  .. ..  .  .. ..  .   @@..  .  .. ..  .  .. ..\r\n.. ..  .  .. ..  .  ..@@.  .  .. ..  .  .. ..  .  .. ..  .  .. ..  .  .. .. @@  .. ..  .  .. ..  .  \r\n  .  .. ..  .  .. ..  @@ .. .@@ .  .. ..  .  .. ..  .  .. ..  .  .. .@@ .  .@@..  .  .. ..  .  .. ..\r\n.. ..  .  .. ..  .  ..@@.  . @@. ..  .  .. ..  .  .. ..  .  .. ..  . @@. .. @@  .. ..  .  .. ..  .  \r\n  .  .. ..  .  .. ..  @@ .. .@@ .  .. ..  .  .. ..  .  .. ..  .  .. .@@ .  .@@..  .  .. ..  .  .. ..\r\n.. ..  .  .. ..  .  ..@@   . @@@ ..  .  .. ..  .  .. ..  .  .. ..  .@@@. .. @@  .. ..  .  .. ..  .  \r\n.. ..  .  .. ..  .  ..@@@  .  @@ ..  .  .. ..  .  .. ..  .  .. ..  .@@.. ..@@@  .. ..  .  .. ..  .  \r\n  .  .. ..  .  .. ..  .@@.. ..@@@  .. ..  .  .. ..  .  .. ..  .  ..@@@  .  @@ ..  .  .. ..  .  .. ..\r\n.. ..  .  .. ..  .  .. :@@ .  .@@@.  .  .. ..  .  .. ..  .  .. .. @@@ .. .@@..  .. ..  .  .. ..  .  \r\n  .  .. ..  .  .. ..  . @@@ ..   @@@. ..  .  .. ..  .  .. ..  . @@@ ..  .@@@. ..  .  .. ..  .  .. ..\r\n.. ..  .  .. ..  .  .. ..@@@  .. .@@@+  .. ..  .  .. ..  .  ..+@@@ .  ..@@@  .  .. ..  .  .. ..  .  \r\n  .  .. ..  .  .. ..  .  ..@@#  .  .@@@@  .  .. ..  .  .. ..@@@@ .. ..#@@  .. ..  .  .. ..  .  .. ..\r\n.. ..  .  .. ..  .  .. ..  .@@@. ..  .-@@@@@.  .  .. .. @@@@@- ..  . @@@ ..  .  .. ..  .  .. ..  .  \r\n............................. @@@.........@@@@@@@@@@@@@@@@.........@@@..............................\r\n  .  .. ..  .  .. ..  .  .. ..  @@@@. ..  .  .. ..  .  .. ..  . @@@@..  .  .. ..  .  .. ..  .  .. ..\r\n.. ..  .  .. ..  .  .. ..  .  .. .@@@@@ .. ..  .  .. ..  .  .@@@@@ .  .. ..  .  .. ..  .  .. ..  .  \r\n  .  .. ..  .  .. ..  .  .. ..  .  ..:@@@@@@@.. ..  .  @@@@@@@:  .. ..  .  .. ..  .  .. ..  .  .. ..\r\n.. ..  .  .. ..  .  .. ..  .  .. ..  .  ...@@@@@@@@@@@@@@.  .. ..  .  .. ..  .  .. ..  .  .. ..  .  \r\n\r\n");
                Console.WriteLine("BONUS:sei sulla casella ponte:avanzi fino alla casella 12!");
                Console.WriteLine();
                posizioneDue = 12;
            }

            //Casella oca avanza dello stesso numero di caselle di prima
            if (posizioneUno == 5 || posizioneUno == 10 || posizioneUno == 15 || posizioneUno == 20 || posizioneUno == 25 || posizioneUno == 30 || posizioneUno == 35 || posizioneUno == 40 || posizioneUno == 45 || posizioneUno == 50 || posizioneUno == 55 || posizioneUno == 60)
            {
                Console.WriteLine("\r\n\r\n  .  .. ..  .  .. ..  .  .. ..  .  .. ..   @@@@@@@@@@@@@@ ..  .  .. ..  .  .. ..  .  .. ..  .  .. ..\r\n.. ..  .  .. ..  .  .. ..  .  .. ..  .@@@@@@@  .  .. ..@@@@@@@...  .  .. ..  .  .. ..  .  .. ..  .  \r\n  .  .. ..  .  .. ..  .  .. ..  . @@@@@.  .  .. ..  .  .. .. @@@@@. ..  .  .. ..  .  .. ..  .  .. ..\r\n................................@@@@............................@@@@ ...............................\r\n.. ..  .  .. ..  .  .. ..  .  @@@..  .  .. ..  .  .. ..  .  .. ..  @@@.. ..  .  .. ..  .  .. ..  .  \r\n  .  .. ..  .  .. ..  .  .. @@@ .  .. ..  .  .. ..  .  .. ..  .  .. .@@@.  .. ..  .  .. ..  .  .. ..\r\n.. ..  .  .. ..  .  .. ..  @@#.. ..  .  .. ..  .  .. ..  .  .. ..  .  #@@..  .  .. ..  .  .. ..  .  \r\n  .  .. ..  .  .. ..  .  @@@..  .  .. -+  .  .. ..  .  .. ..+-.  .. ..  @@@.. ..  .  .. ..  .  .. ..\r\n.. ..  .  .. ..  .  .. .@@@.  .. ..@@@@@@@@@.  .  .. .. @@@@@@@@@  .  .. @@@ .  .. ..  .  .. ..  .  \r\n  .  .. ..  .  .. ..  ..@@. ..  . @@= ..  @@@.. ..  .  @@@..  .=@@. ..  . @@: ..  .  .. ..  .  .. ..\r\n.. ..  .  .. ..  .  .. @@  .  .. @@@ .  .. @@  .  .. ..@@.  .. .@@@.  .. ..@@.  .. ..  .  .. ..  .  \r\n.. ..  .  .. ..  .  ..@@@  .  .. ..  .  .. ..  .  .. ..  .  .. ..  .  .. ..@@@  .. ..  .  .. ..  .  \r\n  .  .. ..  .  .. ..  @@ .. ..  .  .. ..  .  .. ..  .  .. ..  .  .. ..  .   @@..  .  .. ..  .  .. ..\r\n.. ..  .  .. ..  .  ..@@.  .  .. ..  .  .. ..  .  .. ..  .  .. ..  .  .. .. @@  .. ..  .  .. ..  .  \r\n  .  .. ..  .  .. ..  @@ .. .@@ .  .. ..  .  .. ..  .  .. ..  .  .. .@@ .  .@@..  .  .. ..  .  .. ..\r\n.. ..  .  .. ..  .  ..@@.  . @@. ..  .  .. ..  .  .. ..  .  .. ..  . @@. .. @@  .. ..  .  .. ..  .  \r\n  .  .. ..  .  .. ..  @@ .. .@@ .  .. ..  .  .. ..  .  .. ..  .  .. .@@ .  .@@..  .  .. ..  .  .. ..\r\n.. ..  .  .. ..  .  ..@@   . @@@ ..  .  .. ..  .  .. ..  .  .. ..  .@@@. .. @@  .. ..  .  .. ..  .  \r\n.. ..  .  .. ..  .  ..@@@  .  @@ ..  .  .. ..  .  .. ..  .  .. ..  .@@.. ..@@@  .. ..  .  .. ..  .  \r\n  .  .. ..  .  .. ..  .@@.. ..@@@  .. ..  .  .. ..  .  .. ..  .  ..@@@  .  @@ ..  .  .. ..  .  .. ..\r\n.. ..  .  .. ..  .  .. :@@ .  .@@@.  .  .. ..  .  .. ..  .  .. .. @@@ .. .@@..  .. ..  .  .. ..  .  \r\n  .  .. ..  .  .. ..  . @@@ ..   @@@. ..  .  .. ..  .  .. ..  . @@@ ..  .@@@. ..  .  .. ..  .  .. ..\r\n.. ..  .  .. ..  .  .. ..@@@  .. .@@@+  .. ..  .  .. ..  .  ..+@@@ .  ..@@@  .  .. ..  .  .. ..  .  \r\n  .  .. ..  .  .. ..  .  ..@@#  .  .@@@@  .  .. ..  .  .. ..@@@@ .. ..#@@  .. ..  .  .. ..  .  .. ..\r\n.. ..  .  .. ..  .  .. ..  .@@@. ..  .-@@@@@.  .  .. .. @@@@@- ..  . @@@ ..  .  .. ..  .  .. ..  .  \r\n............................. @@@.........@@@@@@@@@@@@@@@@.........@@@..............................\r\n  .  .. ..  .  .. ..  .  .. ..  @@@@. ..  .  .. ..  .  .. ..  . @@@@..  .  .. ..  .  .. ..  .  .. ..\r\n.. ..  .  .. ..  .  .. ..  .  .. .@@@@@ .. ..  .  .. ..  .  .@@@@@ .  .. ..  .  .. ..  .  .. ..  .  \r\n  .  .. ..  .  .. ..  .  .. ..  .  ..:@@@@@@@.. ..  .  @@@@@@@:  .. ..  .  .. ..  .  .. ..  .  .. ..\r\n.. ..  .  .. ..  .  .. ..  .  .. ..  .  ...@@@@@@@@@@@@@@.  .. ..  .  .. ..  .  .. ..  .  .. ..  .  \r\n\r\n");
                Console.WriteLine("BONUS:sei sulla casella oca:avanzi dello stesso numero di caselle di prima");
                Console.WriteLine();
                posizioneUno += dadoUno;
                posizioneUno += dadoDue;
            }
            else if (posizioneDue == 5 || posizioneDue == 10 || posizioneDue == 15 || posizioneDue == 20 || posizioneDue == 25 || posizioneDue == 30 || posizioneDue == 35 || posizioneDue == 40 || posizioneDue == 45 || posizioneDue == 50 || posizioneDue == 55 || posizioneDue == 60)
            {

                Console.WriteLine("\r\n\r\n  .  .. ..  .  .. ..  .  .. ..  .  .. ..   @@@@@@@@@@@@@@ ..  .  .. ..  .  .. ..  .  .. ..  .  .. ..\r\n.. ..  .  .. ..  .  .. ..  .  .. ..  .@@@@@@@  .  .. ..@@@@@@@...  .  .. ..  .  .. ..  .  .. ..  .  \r\n  .  .. ..  .  .. ..  .  .. ..  . @@@@@.  .  .. ..  .  .. .. @@@@@. ..  .  .. ..  .  .. ..  .  .. ..\r\n................................@@@@............................@@@@ ...............................\r\n.. ..  .  .. ..  .  .. ..  .  @@@..  .  .. ..  .  .. ..  .  .. ..  @@@.. ..  .  .. ..  .  .. ..  .  \r\n  .  .. ..  .  .. ..  .  .. @@@ .  .. ..  .  .. ..  .  .. ..  .  .. .@@@.  .. ..  .  .. ..  .  .. ..\r\n.. ..  .  .. ..  .  .. ..  @@#.. ..  .  .. ..  .  .. ..  .  .. ..  .  #@@..  .  .. ..  .  .. ..  .  \r\n  .  .. ..  .  .. ..  .  @@@..  .  .. -+  .  .. ..  .  .. ..+-.  .. ..  @@@.. ..  .  .. ..  .  .. ..\r\n.. ..  .  .. ..  .  .. .@@@.  .. ..@@@@@@@@@.  .  .. .. @@@@@@@@@  .  .. @@@ .  .. ..  .  .. ..  .  \r\n  .  .. ..  .  .. ..  ..@@. ..  . @@= ..  @@@.. ..  .  @@@..  .=@@. ..  . @@: ..  .  .. ..  .  .. ..\r\n.. ..  .  .. ..  .  .. @@  .  .. @@@ .  .. @@  .  .. ..@@.  .. .@@@.  .. ..@@.  .. ..  .  .. ..  .  \r\n.. ..  .  .. ..  .  ..@@@  .  .. ..  .  .. ..  .  .. ..  .  .. ..  .  .. ..@@@  .. ..  .  .. ..  .  \r\n  .  .. ..  .  .. ..  @@ .. ..  .  .. ..  .  .. ..  .  .. ..  .  .. ..  .   @@..  .  .. ..  .  .. ..\r\n.. ..  .  .. ..  .  ..@@.  .  .. ..  .  .. ..  .  .. ..  .  .. ..  .  .. .. @@  .. ..  .  .. ..  .  \r\n  .  .. ..  .  .. ..  @@ .. .@@ .  .. ..  .  .. ..  .  .. ..  .  .. .@@ .  .@@..  .  .. ..  .  .. ..\r\n.. ..  .  .. ..  .  ..@@.  . @@. ..  .  .. ..  .  .. ..  .  .. ..  . @@. .. @@  .. ..  .  .. ..  .  \r\n  .  .. ..  .  .. ..  @@ .. .@@ .  .. ..  .  .. ..  .  .. ..  .  .. .@@ .  .@@..  .  .. ..  .  .. ..\r\n.. ..  .  .. ..  .  ..@@   . @@@ ..  .  .. ..  .  .. ..  .  .. ..  .@@@. .. @@  .. ..  .  .. ..  .  \r\n.. ..  .  .. ..  .  ..@@@  .  @@ ..  .  .. ..  .  .. ..  .  .. ..  .@@.. ..@@@  .. ..  .  .. ..  .  \r\n  .  .. ..  .  .. ..  .@@.. ..@@@  .. ..  .  .. ..  .  .. ..  .  ..@@@  .  @@ ..  .  .. ..  .  .. ..\r\n.. ..  .  .. ..  .  .. :@@ .  .@@@.  .  .. ..  .  .. ..  .  .. .. @@@ .. .@@..  .. ..  .  .. ..  .  \r\n  .  .. ..  .  .. ..  . @@@ ..   @@@. ..  .  .. ..  .  .. ..  . @@@ ..  .@@@. ..  .  .. ..  .  .. ..\r\n.. ..  .  .. ..  .  .. ..@@@  .. .@@@+  .. ..  .  .. ..  .  ..+@@@ .  ..@@@  .  .. ..  .  .. ..  .  \r\n  .  .. ..  .  .. ..  .  ..@@#  .  .@@@@  .  .. ..  .  .. ..@@@@ .. ..#@@  .. ..  .  .. ..  .  .. ..\r\n.. ..  .  .. ..  .  .. ..  .@@@. ..  .-@@@@@.  .  .. .. @@@@@- ..  . @@@ ..  .  .. ..  .  .. ..  .  \r\n............................. @@@.........@@@@@@@@@@@@@@@@.........@@@..............................\r\n  .  .. ..  .  .. ..  .  .. ..  @@@@. ..  .  .. ..  .  .. ..  . @@@@..  .  .. ..  .  .. ..  .  .. ..\r\n.. ..  .  .. ..  .  .. ..  .  .. .@@@@@ .. ..  .  .. ..  .  .@@@@@ .  .. ..  .  .. ..  .  .. ..  .  \r\n  .  .. ..  .  .. ..  .  .. ..  .  ..:@@@@@@@.. ..  .  @@@@@@@:  .. ..  .  .. ..  .  .. ..  .  .. ..\r\n.. ..  .  .. ..  .  .. ..  .  .. ..  .  ...@@@@@@@@@@@@@@.  .. ..  .  .. ..  .  .. ..  .  .. ..  .  \r\n\r\n");
                Console.WriteLine("BONUS:sei sulla casella oca:avanzi dello stesso numero di caselle di prima");
                Console.WriteLine();
                posizioneDue += dadoUno;
                posizioneDue += dadoDue;
            }

            //Casella locanda perdi un turno
            if (posizioneUno == 19)
            {
                posizioneUno += 0;
                Console.WriteLine("\r\n\r\n                                                                                                    \r\n                                                                                                    \r\n                                                                                                    \r\n                                                                                                    \r\n                                                                                                    \r\n                                         .-*@@@@@@@@@@@@*-                                          \r\n                                   .-@@@@@@@@@@@@@@@@@@@@@@@@@@-.                                   \r\n                               .:@@@@@@@#-                -%@@@@@@@:                                \r\n                             .@@@@@%-                          -%@@@@@.                             \r\n                           -@@@@%.                                .%@@@@-                           \r\n                         :@@@@=                                      =@@@@:                         \r\n                       .%@@@-                                          -@@@%.                       \r\n                      :@@@*                                              *@@@:                      \r\n                     +@@@:                                                :@@@+                     \r\n                    *@@@.                                                  .@@@*                    \r\n                   =@@@.                                                    .@@@=                   \r\n                  .@@@                                                        @@@.                  \r\n                  @@@-                                                        :@@@                  \r\n                 =@@@                                                          %@@=                 \r\n                 @@@-                                                          :@@@                 \r\n                :@@@.                                                           @@@:                \r\n                +@@#                                                            #@@*                \r\n                #@@+                                                            =@@#                \r\n                #@@-          .*@@@@@%-                      :%@@@@@*.          -@@%                \r\n                #@@-         @@@@@@@@@@@:                  :@@@@@@@@@@@         :@@%                \r\n                #@@-       .@@@@@@@@@@@@@:                :@@@@@@@@@@@@@.       -@@#                \r\n                #@@+       %@@@@@@@@@@@@@@                @@@@@@@@@@@@@@%       =@@#                \r\n                *@@*      .@@@@@@@@@@@@@@@                @@@@@@@@@@@@@@@.      *@@*                \r\n                -@@#      .@@@@@@@@@@@@@@@                @@@@@@@@@@@@@@@.      #@@=                \r\n                .@@@.      =@@@@@@@@@@@@@.                .@@@@@@@@@@@@@=      .@@@:                \r\n                 @@@:       =@@@@@@@@@@%.       .++.       .%@@@@@@@@@@=       :@@@                 \r\n                 @@@=         =@@@@@@#         *@@@@*         #@@@@@@=         =@@@                 \r\n                -@@%                          =@@@@@@+                          %@@-                \r\n                *@@*                         .@@@@@@@@.                         *@@*                \r\n                +@@#                         +@@@@@@@@+                         *@@*                \r\n                :@@@                         %@@@@@@@@%                         %@@:                \r\n                 @@@+                        .@@@::@@@.                        +@@@                 \r\n                  @@@@                                                        @@@@                  \r\n                   +@@@@*.                                                .*@@@@*                   \r\n                     =@@@@@+.                                          .+@@@@@=                     \r\n                        =@@@@*                                        +@@@@=                        \r\n                          .@@@%                                      %@@@.                          \r\n                           .@@@.      @@%.      -@@-      .%@@      .@@@.                           \r\n                           .%@@:     .@@@.      *@@*      .@@@.     :@@%                            \r\n                            *@@#     *@@+       *@@*       *@@*     #@@*                            \r\n                             @@@@:   @@@-       *@@*       -@@@   :@@@@                             \r\n                              =@@@@@@@@@.       *@@*       .@@@@@@@@@=                              \r\n                                :#@@@@@@@.      #@@#      .@@@@@@@#:                                \r\n                                      +@@@@@@@@@@@@@@@@@@@@@@+                                      \r\n                                        .@@@@@@*.  .*@@@@@@.                                        \r\n                                                                                                    \r\n                                                                                                    \r\n                                                                                                    \r\n                                                                                                    \r\n                                                                                                    \r\n\r\n");
                Console.WriteLine("MALUS:sei sulla casella locanda:resti fermo un turno!");
                Console.WriteLine();
            }
            else if (posizioneDue == 19)
            {
                Console.WriteLine("\r\n\r\n                                                                                                    \r\n                                                                                                    \r\n                                                                                                    \r\n                                                                                                    \r\n                                                                                                    \r\n                                         .-*@@@@@@@@@@@@*-                                          \r\n                                   .-@@@@@@@@@@@@@@@@@@@@@@@@@@-.                                   \r\n                               .:@@@@@@@#-                -%@@@@@@@:                                \r\n                             .@@@@@%-                          -%@@@@@.                             \r\n                           -@@@@%.                                .%@@@@-                           \r\n                         :@@@@=                                      =@@@@:                         \r\n                       .%@@@-                                          -@@@%.                       \r\n                      :@@@*                                              *@@@:                      \r\n                     +@@@:                                                :@@@+                     \r\n                    *@@@.                                                  .@@@*                    \r\n                   =@@@.                                                    .@@@=                   \r\n                  .@@@                                                        @@@.                  \r\n                  @@@-                                                        :@@@                  \r\n                 =@@@                                                          %@@=                 \r\n                 @@@-                                                          :@@@                 \r\n                :@@@.                                                           @@@:                \r\n                +@@#                                                            #@@*                \r\n                #@@+                                                            =@@#                \r\n                #@@-          .*@@@@@%-                      :%@@@@@*.          -@@%                \r\n                #@@-         @@@@@@@@@@@:                  :@@@@@@@@@@@         :@@%                \r\n                #@@-       .@@@@@@@@@@@@@:                :@@@@@@@@@@@@@.       -@@#                \r\n                #@@+       %@@@@@@@@@@@@@@                @@@@@@@@@@@@@@%       =@@#                \r\n                *@@*      .@@@@@@@@@@@@@@@                @@@@@@@@@@@@@@@.      *@@*                \r\n                -@@#      .@@@@@@@@@@@@@@@                @@@@@@@@@@@@@@@.      #@@=                \r\n                .@@@.      =@@@@@@@@@@@@@.                .@@@@@@@@@@@@@=      .@@@:                \r\n                 @@@:       =@@@@@@@@@@%.       .++.       .%@@@@@@@@@@=       :@@@                 \r\n                 @@@=         =@@@@@@#         *@@@@*         #@@@@@@=         =@@@                 \r\n                -@@%                          =@@@@@@+                          %@@-                \r\n                *@@*                         .@@@@@@@@.                         *@@*                \r\n                +@@#                         +@@@@@@@@+                         *@@*                \r\n                :@@@                         %@@@@@@@@%                         %@@:                \r\n                 @@@+                        .@@@::@@@.                        +@@@                 \r\n                  @@@@                                                        @@@@                  \r\n                   +@@@@*.                                                .*@@@@*                   \r\n                     =@@@@@+.                                          .+@@@@@=                     \r\n                        =@@@@*                                        +@@@@=                        \r\n                          .@@@%                                      %@@@.                          \r\n                           .@@@.      @@%.      -@@-      .%@@      .@@@.                           \r\n                           .%@@:     .@@@.      *@@*      .@@@.     :@@%                            \r\n                            *@@#     *@@+       *@@*       *@@*     #@@*                            \r\n                             @@@@:   @@@-       *@@*       -@@@   :@@@@                             \r\n                              =@@@@@@@@@.       *@@*       .@@@@@@@@@=                              \r\n                                :#@@@@@@@.      #@@#      .@@@@@@@#:                                \r\n                                      +@@@@@@@@@@@@@@@@@@@@@@+                                      \r\n                                        .@@@@@@*.  .*@@@@@@.                                        \r\n                                                                                                    \r\n                                                                                                    \r\n                                                                                                    \r\n                                                                                                    \r\n                                                                                                    \r\n\r\n");
                Console.WriteLine("MALUS:sei sulla casella locanda:resti fermo un turno!");
                Console.WriteLine();
                posizioneDue += 0;
            }

            //Casella labirinto torna alla casella 39
            if (posizioneUno == 42)
            {
                Console.WriteLine("\r\n\r\n                                                                                                    \r\n                                                                                                    \r\n                                                                                                    \r\n                                                                                                    \r\n                                                                                                    \r\n                                         .-*@@@@@@@@@@@@*-                                          \r\n                                   .-@@@@@@@@@@@@@@@@@@@@@@@@@@-.                                   \r\n                               .:@@@@@@@#-                -%@@@@@@@:                                \r\n                             .@@@@@%-                          -%@@@@@.                             \r\n                           -@@@@%.                                .%@@@@-                           \r\n                         :@@@@=                                      =@@@@:                         \r\n                       .%@@@-                                          -@@@%.                       \r\n                      :@@@*                                              *@@@:                      \r\n                     +@@@:                                                :@@@+                     \r\n                    *@@@.                                                  .@@@*                    \r\n                   =@@@.                                                    .@@@=                   \r\n                  .@@@                                                        @@@.                  \r\n                  @@@-                                                        :@@@                  \r\n                 =@@@                                                          %@@=                 \r\n                 @@@-                                                          :@@@                 \r\n                :@@@.                                                           @@@:                \r\n                +@@#                                                            #@@*                \r\n                #@@+                                                            =@@#                \r\n                #@@-          .*@@@@@%-                      :%@@@@@*.          -@@%                \r\n                #@@-         @@@@@@@@@@@:                  :@@@@@@@@@@@         :@@%                \r\n                #@@-       .@@@@@@@@@@@@@:                :@@@@@@@@@@@@@.       -@@#                \r\n                #@@+       %@@@@@@@@@@@@@@                @@@@@@@@@@@@@@%       =@@#                \r\n                *@@*      .@@@@@@@@@@@@@@@                @@@@@@@@@@@@@@@.      *@@*                \r\n                -@@#      .@@@@@@@@@@@@@@@                @@@@@@@@@@@@@@@.      #@@=                \r\n                .@@@.      =@@@@@@@@@@@@@.                .@@@@@@@@@@@@@=      .@@@:                \r\n                 @@@:       =@@@@@@@@@@%.       .++.       .%@@@@@@@@@@=       :@@@                 \r\n                 @@@=         =@@@@@@#         *@@@@*         #@@@@@@=         =@@@                 \r\n                -@@%                          =@@@@@@+                          %@@-                \r\n                *@@*                         .@@@@@@@@.                         *@@*                \r\n                +@@#                         +@@@@@@@@+                         *@@*                \r\n                :@@@                         %@@@@@@@@%                         %@@:                \r\n                 @@@+                        .@@@::@@@.                        +@@@                 \r\n                  @@@@                                                        @@@@                  \r\n                   +@@@@*.                                                .*@@@@*                   \r\n                     =@@@@@+.                                          .+@@@@@=                     \r\n                        =@@@@*                                        +@@@@=                        \r\n                          .@@@%                                      %@@@.                          \r\n                           .@@@.      @@%.      -@@-      .%@@      .@@@.                           \r\n                           .%@@:     .@@@.      *@@*      .@@@.     :@@%                            \r\n                            *@@#     *@@+       *@@*       *@@*     #@@*                            \r\n                             @@@@:   @@@-       *@@*       -@@@   :@@@@                             \r\n                              =@@@@@@@@@.       *@@*       .@@@@@@@@@=                              \r\n                                :#@@@@@@@.      #@@#      .@@@@@@@#:                                \r\n                                      +@@@@@@@@@@@@@@@@@@@@@@+                                      \r\n                                        .@@@@@@*.  .*@@@@@@.                                        \r\n                                                                                                    \r\n                                                                                                    \r\n                                                                                                    \r\n                                                                                                    \r\n                                                                                                    \r\n\r\n");
                Console.WriteLine("MALUS:sei sulla casella labirinto: torni alla casella 39");
                Console.WriteLine();
                posizioneUno -= 3;
            }
            else if (posizioneDue == 42)
            {
                Console.WriteLine("\r\n\r\n                                                                                                    \r\n                                                                                                    \r\n                                                                                                    \r\n                                                                                                    \r\n                                                                                                    \r\n                                         .-*@@@@@@@@@@@@*-                                          \r\n                                   .-@@@@@@@@@@@@@@@@@@@@@@@@@@-.                                   \r\n                               .:@@@@@@@#-                -%@@@@@@@:                                \r\n                             .@@@@@%-                          -%@@@@@.                             \r\n                           -@@@@%.                                .%@@@@-                           \r\n                         :@@@@=                                      =@@@@:                         \r\n                       .%@@@-                                          -@@@%.                       \r\n                      :@@@*                                              *@@@:                      \r\n                     +@@@:                                                :@@@+                     \r\n                    *@@@.                                                  .@@@*                    \r\n                   =@@@.                                                    .@@@=                   \r\n                  .@@@                                                        @@@.                  \r\n                  @@@-                                                        :@@@                  \r\n                 =@@@                                                          %@@=                 \r\n                 @@@-                                                          :@@@                 \r\n                :@@@.                                                           @@@:                \r\n                +@@#                                                            #@@*                \r\n                #@@+                                                            =@@#                \r\n                #@@-          .*@@@@@%-                      :%@@@@@*.          -@@%                \r\n                #@@-         @@@@@@@@@@@:                  :@@@@@@@@@@@         :@@%                \r\n                #@@-       .@@@@@@@@@@@@@:                :@@@@@@@@@@@@@.       -@@#                \r\n                #@@+       %@@@@@@@@@@@@@@                @@@@@@@@@@@@@@%       =@@#                \r\n                *@@*      .@@@@@@@@@@@@@@@                @@@@@@@@@@@@@@@.      *@@*                \r\n                -@@#      .@@@@@@@@@@@@@@@                @@@@@@@@@@@@@@@.      #@@=                \r\n                .@@@.      =@@@@@@@@@@@@@.                .@@@@@@@@@@@@@=      .@@@:                \r\n                 @@@:       =@@@@@@@@@@%.       .++.       .%@@@@@@@@@@=       :@@@                 \r\n                 @@@=         =@@@@@@#         *@@@@*         #@@@@@@=         =@@@                 \r\n                -@@%                          =@@@@@@+                          %@@-                \r\n                *@@*                         .@@@@@@@@.                         *@@*                \r\n                +@@#                         +@@@@@@@@+                         *@@*                \r\n                :@@@                         %@@@@@@@@%                         %@@:                \r\n                 @@@+                        .@@@::@@@.                        +@@@                 \r\n                  @@@@                                                        @@@@                  \r\n                   +@@@@*.                                                .*@@@@*                   \r\n                     =@@@@@+.                                          .+@@@@@=                     \r\n                        =@@@@*                                        +@@@@=                        \r\n                          .@@@%                                      %@@@.                          \r\n                           .@@@.      @@%.      -@@-      .%@@      .@@@.                           \r\n                           .%@@:     .@@@.      *@@*      .@@@.     :@@%                            \r\n                            *@@#     *@@+       *@@*       *@@*     #@@*                            \r\n                             @@@@:   @@@-       *@@*       -@@@   :@@@@                             \r\n                              =@@@@@@@@@.       *@@*       .@@@@@@@@@=                              \r\n                                :#@@@@@@@.      #@@#      .@@@@@@@#:                                \r\n                                      +@@@@@@@@@@@@@@@@@@@@@@+                                      \r\n                                        .@@@@@@*.  .*@@@@@@.                                        \r\n                                                                                                    \r\n                                                                                                    \r\n                                                                                                    \r\n                                                                                                    \r\n                                                                                                    \r\n\r\n");
                Console.WriteLine("MALUS:sei sulla casella labirinto: torni alla casella 39");
                Console.WriteLine();
                posizioneDue -= 3;
            }

            //Casella scheletro ritorna all'inizio
            if (posizioneUno == 58)
            {
                Console.WriteLine("\r\n\r\n                                                                                                    \r\n                                                                                                    \r\n                                                                                                    \r\n                                                                                                    \r\n                                                                                                    \r\n                                         .-*@@@@@@@@@@@@*-                                          \r\n                                   .-@@@@@@@@@@@@@@@@@@@@@@@@@@-.                                   \r\n                               .:@@@@@@@#-                -%@@@@@@@:                                \r\n                             .@@@@@%-                          -%@@@@@.                             \r\n                           -@@@@%.                                .%@@@@-                           \r\n                         :@@@@=                                      =@@@@:                         \r\n                       .%@@@-                                          -@@@%.                       \r\n                      :@@@*                                              *@@@:                      \r\n                     +@@@:                                                :@@@+                     \r\n                    *@@@.                                                  .@@@*                    \r\n                   =@@@.                                                    .@@@=                   \r\n                  .@@@                                                        @@@.                  \r\n                  @@@-                                                        :@@@                  \r\n                 =@@@                                                          %@@=                 \r\n                 @@@-                                                          :@@@                 \r\n                :@@@.                                                           @@@:                \r\n                +@@#                                                            #@@*                \r\n                #@@+                                                            =@@#                \r\n                #@@-          .*@@@@@%-                      :%@@@@@*.          -@@%                \r\n                #@@-         @@@@@@@@@@@:                  :@@@@@@@@@@@         :@@%                \r\n                #@@-       .@@@@@@@@@@@@@:                :@@@@@@@@@@@@@.       -@@#                \r\n                #@@+       %@@@@@@@@@@@@@@                @@@@@@@@@@@@@@%       =@@#                \r\n                *@@*      .@@@@@@@@@@@@@@@                @@@@@@@@@@@@@@@.      *@@*                \r\n                -@@#      .@@@@@@@@@@@@@@@                @@@@@@@@@@@@@@@.      #@@=                \r\n                .@@@.      =@@@@@@@@@@@@@.                .@@@@@@@@@@@@@=      .@@@:                \r\n                 @@@:       =@@@@@@@@@@%.       .++.       .%@@@@@@@@@@=       :@@@                 \r\n                 @@@=         =@@@@@@#         *@@@@*         #@@@@@@=         =@@@                 \r\n                -@@%                          =@@@@@@+                          %@@-                \r\n                *@@*                         .@@@@@@@@.                         *@@*                \r\n                +@@#                         +@@@@@@@@+                         *@@*                \r\n                :@@@                         %@@@@@@@@%                         %@@:                \r\n                 @@@+                        .@@@::@@@.                        +@@@                 \r\n                  @@@@                                                        @@@@                  \r\n                   +@@@@*.                                                .*@@@@*                   \r\n                     =@@@@@+.                                          .+@@@@@=                     \r\n                        =@@@@*                                        +@@@@=                        \r\n                          .@@@%                                      %@@@.                          \r\n                           .@@@.      @@%.      -@@-      .%@@      .@@@.                           \r\n                           .%@@:     .@@@.      *@@*      .@@@.     :@@%                            \r\n                            *@@#     *@@+       *@@*       *@@*     #@@*                            \r\n                             @@@@:   @@@-       *@@*       -@@@   :@@@@                             \r\n                              =@@@@@@@@@.       *@@*       .@@@@@@@@@=                              \r\n                                :#@@@@@@@.      #@@#      .@@@@@@@#:                                \r\n                                      +@@@@@@@@@@@@@@@@@@@@@@+                                      \r\n                                        .@@@@@@*.  .*@@@@@@.                                        \r\n                                                                                                    \r\n                                                                                                    \r\n                                                                                                    \r\n                                                                                                    \r\n                                                                                                    \r\n\r\n");
                Console.WriteLine("MALUS:sei sulla casella scheletro: torni alla casella 1");
                Console.WriteLine();
                posizioneUno = 1;
            }
            else if (posizioneDue == 58)
            {
                Console.WriteLine("\r\n\r\n                                                                                                    \r\n                                                                                                    \r\n                                                                                                    \r\n                                                                                                    \r\n                                                                                                    \r\n                                         .-*@@@@@@@@@@@@*-                                          \r\n                                   .-@@@@@@@@@@@@@@@@@@@@@@@@@@-.                                   \r\n                               .:@@@@@@@#-                -%@@@@@@@:                                \r\n                             .@@@@@%-                          -%@@@@@.                             \r\n                           -@@@@%.                                .%@@@@-                           \r\n                         :@@@@=                                      =@@@@:                         \r\n                       .%@@@-                                          -@@@%.                       \r\n                      :@@@*                                              *@@@:                      \r\n                     +@@@:                                                :@@@+                     \r\n                    *@@@.                                                  .@@@*                    \r\n                   =@@@.                                                    .@@@=                   \r\n                  .@@@                                                        @@@.                  \r\n                  @@@-                                                        :@@@                  \r\n                 =@@@                                                          %@@=                 \r\n                 @@@-                                                          :@@@                 \r\n                :@@@.                                                           @@@:                \r\n                +@@#                                                            #@@*                \r\n                #@@+                                                            =@@#                \r\n                #@@-          .*@@@@@%-                      :%@@@@@*.          -@@%                \r\n                #@@-         @@@@@@@@@@@:                  :@@@@@@@@@@@         :@@%                \r\n                #@@-       .@@@@@@@@@@@@@:                :@@@@@@@@@@@@@.       -@@#                \r\n                #@@+       %@@@@@@@@@@@@@@                @@@@@@@@@@@@@@%       =@@#                \r\n                *@@*      .@@@@@@@@@@@@@@@                @@@@@@@@@@@@@@@.      *@@*                \r\n                -@@#      .@@@@@@@@@@@@@@@                @@@@@@@@@@@@@@@.      #@@=                \r\n                .@@@.      =@@@@@@@@@@@@@.                .@@@@@@@@@@@@@=      .@@@:                \r\n                 @@@:       =@@@@@@@@@@%.       .++.       .%@@@@@@@@@@=       :@@@                 \r\n                 @@@=         =@@@@@@#         *@@@@*         #@@@@@@=         =@@@                 \r\n                -@@%                          =@@@@@@+                          %@@-                \r\n                *@@*                         .@@@@@@@@.                         *@@*                \r\n                +@@#                         +@@@@@@@@+                         *@@*                \r\n                :@@@                         %@@@@@@@@%                         %@@:                \r\n                 @@@+                        .@@@::@@@.                        +@@@                 \r\n                  @@@@                                                        @@@@                  \r\n                   +@@@@*.                                                .*@@@@*                   \r\n                     =@@@@@+.                                          .+@@@@@=                     \r\n                        =@@@@*                                        +@@@@=                        \r\n                          .@@@%                                      %@@@.                          \r\n                           .@@@.      @@%.      -@@-      .%@@      .@@@.                           \r\n                           .%@@:     .@@@.      *@@*      .@@@.     :@@%                            \r\n                            *@@#     *@@+       *@@*       *@@*     #@@*                            \r\n                             @@@@:   @@@-       *@@*       -@@@   :@@@@                             \r\n                              =@@@@@@@@@.       *@@*       .@@@@@@@@@=                              \r\n                                :#@@@@@@@.      #@@#      .@@@@@@@#:                                \r\n                                      +@@@@@@@@@@@@@@@@@@@@@@+                                      \r\n                                        .@@@@@@*.  .*@@@@@@.                                        \r\n                                                                                                    \r\n                                                                                                    \r\n                                                                                                    \r\n                                                                                                    \r\n                                                                                                    \r\n\r\n");
                Console.WriteLine("MALUS:sei sulla casella scheletro: torni alla casella 1");
                Console.WriteLine();
                posizioneDue = 1;
            }
        }

        /// <summary>
        /// Gestisce il tiro dei dadi e l'avanzamento dei giocatori
        /// </summary>
        /// <param name="campoStr">campo stringa</param>
        /// <param name="pedinaUno">pedina del giocatore 1</param>
        /// <param name="pedinaDue">pedina del giocatore 2</param>
        /// <param name="dadoUno">valore primo dado</param>
        /// <param name="dadoDue">valore secondo dado</param>
        /// <param name="rimbalzo">caselle di rimbalzo oltre il traguardo</param>
        /// <param name="fine">fine partita</param>
        /// <param name="turno">turno dei giocatori</param>
        /// <param name="tiro">somma dadi</param>
        /// <param name="campo">vettore campo</param>
        /// <param name="posizioneUno">posizione attuale player 1</param>
        /// <param name="posizioneDue">posizione attuale player 2</param>
        static void DadoEdAvanzamento(string[] campoStr,string pedinaUno,string pedinaDue,int dadoUno, int dadoDue, int rimbalzo, bool fine, bool turno, int tiro, int[] campo, ref int posizioneUno, ref int posizioneDue)
        {
            //Ciclo per spostarsi di caselle
            while (!fine)
            {               
                //Turno del player 1
                if (turno == false)
                {
                    //Istruzioni
                    Console.WriteLine("\n\nTurno del Giocatore 1");
                    Console.WriteLine("premi INVIO per tirare il dado");
                    Console.ReadLine();
                    Console.Clear();

                    //Lancio dei due dadi (6 facce)
                    Random rnd = new Random();
                    dadoUno = rnd.Next(1, 7);
                    dadoDue = rnd.Next(1, 7);
                    tiro = dadoUno + dadoDue;

                    //Tiro
                    Console.WriteLine("Hai tirato: " + dadoUno + " + " + dadoDue + " = " + tiro);

                    posizioneUno += tiro;

                    //Se il tiro dei dadi è uguale alle caselle il player 1 ha vinto
                    if (posizioneUno == 63)
                    {
                        //Il Giocatore 1 ha vinto
                        fine = true;
                        Console.WriteLine("\nIl Giocatore 1 ha vinto!");
                    }
                    //Se il tiro dei dadi è maggiore delle caselle il player 1 rimbalza indietro 
                    else if (posizioneUno > 63)
                    {
                        //Rimbalzo indietro
                        rimbalzo = posizioneUno - 63;
                        posizioneUno = 63 - rimbalzo;
                        Console.WriteLine($"Hai superato la casella 63! Rimbalzi indietro di {rimbalzo} caselle");
                    }

                    //Posizione del giocatore 1
                    Console.WriteLine("Posizione Giocatore 1: " + posizioneUno);
                    Console.WriteLine();
                    turno = true;
                }

                //Turno del player 2
                else
                {
                    //Istruzioni
                    Console.WriteLine("\n\nTurno del Giocatore 2");
                    Console.WriteLine("premi INVIO per tirare il dado");
                    Console.ReadLine();
                    Console.Clear();

                    //Lancio dei due dadi (6 facce)
                    Random rnd = new Random();
                    dadoUno = rnd.Next(1, 7);
                    dadoDue = rnd.Next(1, 7);
                    tiro = dadoUno + dadoDue;

                    //Tiro
                    Console.WriteLine("\nHai tirato: " + dadoUno + " + " + dadoDue + " = " + tiro);
                    posizioneDue += tiro;

                    //Se il tiro dei dadi è uguale alle caselle il player 2 ha vinto
                    if (posizioneDue == 63)
                    {
                        //Il Giocatore 2 ha vinto
                        fine = true;
                        Console.WriteLine("\nIl Giocatore 2 ha vinto!");
                    }
                    else
                    {                       
                        //Se il tiro dei dadi è maggiore delle caselle il player 2 rimbalza indietro                        
                        if (posizioneDue > 63)
                        {
                            //Rimbalzo indietro
                            rimbalzo = posizioneDue - 63;
                            posizioneDue = 63 - rimbalzo;
                            Console.WriteLine($"Hai superato la casella 63! Rimbalzi indietro di {rimbalzo} caselle");
                        }
                    }

                    //Posizione del giocatore 2
                    Console.WriteLine("Posizione Giocatore 2: " + posizioneDue);
                    turno = false;
                }
                
                BonusEMalus(ref posizioneUno, ref posizioneDue, ref dadoUno, ref dadoDue);
                RiempiCampoStringa(campoStr, posizioneUno, posizioneDue, pedinaUno, pedinaDue);              
            }
        }        
    }
}