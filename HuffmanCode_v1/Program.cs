//Created by Rıza Berkay AYÇELEBİ,Deparment Of computer Engineering
//Advisor Lecturer: Asst.Prof.Dr. Hakan KUTUCU
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Threading;
using System.Diagnostics;


namespace HuffmanCode_v1
{   
    class Program
    {

        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            Console.WriteLine("Enter input text to be compressed by Huffman Code");
            string input = Console.ReadLine();

            stopwatch.Start();
            HuffmanTree huffmanTree = new HuffmanTree();
            
            // Build the Huffman tree
            huffmanTree.Build(input);
            stopwatch.Stop();
            Console.WriteLine("--------- Statistics for Huffman Compression-------");
            Console.WriteLine("Time elapsed to build huffman tree in ms: " + stopwatch.ElapsedMilliseconds);
            // Encode
            
            stopwatch.Start();
            BitArray encoded = huffmanTree.Encode(input);
            stopwatch.Stop();
            Console.WriteLine("Time elapsed to encode in ms: " + stopwatch.ElapsedMilliseconds);

            
            Console.WriteLine("Number of Bits used to encode: " + encoded.Count);
            // Decode
            stopwatch.Start();
            string decoded = huffmanTree.Decode(encoded);
            stopwatch.Stop();
            Console.WriteLine("Time elapsed to decode in ms: " + stopwatch.ElapsedMilliseconds);
            Console.WriteLine("Decoded String lenght in bits: " + 8 * decoded.Count());
            Console.WriteLine("Compression Ratio : " + (double)((double)encoded.Count / (double) (8 * decoded.Count())));
            int consoleInput = 4;
           
           
            while (consoleInput != 0)
            {
                Console.WriteLine("-----------------------------------------------------------");
                Console.WriteLine("Press 1 to see input string");
                Console.WriteLine("Press 2 to see encoded bits");
                Console.WriteLine("Press 3 to see decoded string");
                Console.WriteLine("Press 0 to exit");
                int.TryParse(Console.ReadLine(), out consoleInput);

                if (consoleInput == 1)
                {
                    Console.WriteLine("Input String : " + input);
                }
                else if (consoleInput == 2)
                {
                    Console.Write("Encoded bits: ");
                    foreach (bool bit in encoded)
                    {
                        Console.Write((bit ? 1 : 0) + "");
                    }
                    Console.WriteLine();
                }
                else if (consoleInput == 3)
                {
                    Console.WriteLine("Decoded: " + decoded);
                }
                else if (consoleInput == 0)
                {
                    Environment.Exit(0);                    
                }
            }
        }
    }
}