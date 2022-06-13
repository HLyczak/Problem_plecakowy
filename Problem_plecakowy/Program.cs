using System;

namespace ConsoleApp3
{
    internal class Program
    {
        private static int iloscProb = 1000;
        private static int pojemnoscPlecaka = 2500;
        private static Random r = new Random();

        private static void Main(string[] args)
        {
            int[] parent = new int[100];
            int[] child = new int[100];
            int sumaParent, sumaChild;

            for (int i = 0; i < parent.Length; i++)
            {
                parent[i] = r.Next(0, 2);
            }
            copy(parent, child);

            for (int i = 0; i < iloscProb; i++)
            {
                sumaParent = suma(parent);
                if (sumaParent == pojemnoscPlecaka)
                {
                    drukuj(parent, i);
                    return;
                }

                sumaChild = suma(child);
                if (sumaChild == pojemnoscPlecaka)
                {
                    drukuj(child, i);
                    return;
                }

                if (Math.Abs(pojemnoscPlecaka - sumaChild) < Math.Abs(pojemnoscPlecaka - sumaParent))
                {
                    copy(child, parent);
                }
                podmien(child);
            }

            sumaParent = suma(parent);
            sumaChild = suma(child);
            if (Math.Abs(pojemnoscPlecaka - sumaChild) < Math.Abs(pojemnoscPlecaka - sumaParent))
            {
                drukuj(child, iloscProb);
            }
            else
            {
                drukuj(parent, iloscProb);
            }
        }

        private static void drukuj(int[] arr, int i)
        {
            Console.WriteLine("iteracja: " + i + "/" + iloscProb + " suma: " + suma(arr));
            Console.WriteLine(string.Join(' ', arr));
        }

        private static void copy(int[] parent, int[] child)
        {
            for (int i = 0; i < parent.Length; i++)
            {
                child[i] = parent[i];
            }
        }

        private static int suma(int[] child)
        {
            int suma2 = 0;
            for (int i = 0; i < child.Length; i++)
            {
                if (child[i] == 1)
                {
                    suma2 += i + 1;
                }
            }
            return suma2;
        }

        private static int podmien(int[] child)
        {
            int index = r.Next(0, maxValue: child.Length);
            if (child[index] == 0)
            {
                child[index] = 1;
            }
            else
            {
                child[index] = 0;
            }

            return index;
        }
    }
}