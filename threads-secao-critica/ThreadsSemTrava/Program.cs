using System;
using System.IO;
using System.Threading;

class Program
{
    static int numThreads = 20;
    static int linhasPorThread = 500;
    static string caminhoArquivo = "sem_trava.txt";

    static void Main()
    {
        Thread[] threads = new Thread[numThreads];

        File.WriteAllText(caminhoArquivo, "");

        for (int i = 0; i < numThreads; i++)
        {
            int idThread = i;
            threads[i] = new Thread(() => EscreverSemTrava(idThread));
            threads[i].Start();
        }

        foreach (Thread t in threads)
            t.Join();

        Console.WriteLine("Finalizado SEM seção crítica!");
    }

    static void EscreverSemTrava(int id)
    {
        for (int i = 0; i < linhasPorThread; i++)
        {
            string linha = $"Thread {id} - Linha {i}\n";
            File.AppendAllText(caminhoArquivo, linha);
            Thread.Sleep(1);
        }
    }
}