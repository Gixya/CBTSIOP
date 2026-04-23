using System;
using System.IO;
using System.Threading;

class Program
{
    static int numThreads = 20;
    static int linhasPorThread = 500;
    static string caminhoArquivo = "com_trava.txt";

    static readonly object trava = new object();

    static void Main()
    {
        Thread[] threads = new Thread[numThreads];

        File.WriteAllText(caminhoArquivo, "");

        for (int i = 0; i < numThreads; i++)
        {
            int idThread = i;
            threads[i] = new Thread(() => EscreverComTrava(idThread));
            threads[i].Start();
        }

        foreach (Thread t in threads)
            t.Join();

        Console.WriteLine("Finalizado COM seção crítica!");
    }

    static void EscreverComTrava(int id)
    {
        for (int i = 0; i < linhasPorThread; i++)
        {
            string linha = $"Thread {id} - Linha {i}\n";

            lock (trava)
            {
                File.AppendAllText(caminhoArquivo, linha);
            }

            Thread.Sleep(1);
        }
    }
}