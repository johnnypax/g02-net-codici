namespace GC02_02_Diagnostica_GC
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            GC.AddMemoryPressure(1024 * 1000 * 100);

            Console.WriteLine("Inizio simulazione, premi ENTER");
            Console.ReadLine();

            Thread.Sleep(1000);

            OggettiTemporanei();

            Thread.Sleep(3000);

            OggettiLungaDurata();

            Thread.Sleep(3000);

            GC.RemoveMemoryPressure(1024 * 1000 * 100);
            GC.Collect();

            Console.WriteLine("--------- Memoria --------");
            Console.WriteLine($"Memoria totale allocata: {GC.GetTotalMemory(false) / 1024 / 1000} MB");
            Console.WriteLine($"Collezioni Gen 0: {GC.CollectionCount(0)}");
            Console.WriteLine($"Collezioni Gen 1: {GC.CollectionCount(1)}");
            Console.WriteLine($"Collezioni Gen 2: {GC.CollectionCount(2)}\n");

        }

        static void OggettiTemporanei()
        {
            Console.WriteLine("Allocazione degli oggetti temporanei Gen0,1 - START");
            for (int i = 0; i < 1000; i++)
            {
                byte[] bytes = new byte[1024];  // 1KB per ogni oggetto
            }
            Console.WriteLine("Allocazione degli oggetti temporanei Gen0,1 - END");
        }

        static void OggettiLungaDurata()
        {
            Console.WriteLine("Allocazione degli oggetti a linga durata Gen2 - START");
            List<byte[]> lista = new List<byte[]>();
            for (int i = 0; i < 10; i++)
            {
                lista.Add(new byte[1024 * 1000 * 10]);
                Thread.Sleep(1500);
            }
            Console.WriteLine("Allocazione degli oggetti a linga durata Gen2 - END");
        }
    }
}
