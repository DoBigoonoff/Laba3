using System.Text.Json;

public class Sequence
{
    public int[] Seq { get; set; }

    
    public void Write()
    {
        foreach (var item in Seq)
        {
            Console.Write(item + "  ");
        }
        Console.WriteLine();
    }
    private void Serialization()
    {
            string json = JsonSerializer.Serialize(Seq);
            string path = "/Users/dobbgoonoff/Downloads/1.txt";

            using (StreamWriter writer = new StreamWriter(path))
            {
                writer.WriteLine(json);
            }
    }
    private void Deserialization(string file)
    {
        string json;
        using (StreamReader reader = new StreamReader(file))
        {
            json = reader.ReadToEnd();
            int[] seq = JsonSerializer.Deserialize<int[]>(json);
            this.Seq = seq;
        }
    }
    public void Type()
    {
        if(CheckDescending())
        {
            Console.WriteLine("спадна");
        }
        else
        {
            if (CheckIncreasing())
            {
                Console.WriteLine("зростаюча");
            }
            else
            {
                Console.WriteLine("незростаюча і неспадна");
            }
        }
        if(CheckGeometricProgression())
        {
            Console.WriteLine("геометрична прогресія");
        } else Console.WriteLine("не геометрична прогресія");
        if (CheckArithmeticProgression())
        {
            Console.WriteLine("арифметична прогресія");
        }
        else Console.WriteLine("не арифметична прогресія");
    }
    public void Element(int element)
    {
        if(Seq.Contains(element))
        {
            Console.WriteLine($"елемент {element} належить послідовності");
        } else Console.WriteLine($"елемент {element} не належить послідовності");
    }
    public void Equality(int[] array)
    {
        if (Seq.Length != array.Length)
        {
            Console.WriteLine("різна кількість елементів в послідовностях");
        } else
        {
            int a = 0;
            for (int i = 0; i < Seq.Length; i++)
            {
                if (Seq[i] == array[i]) a += 1;
            }
            if (a == Seq.Length) Console.WriteLine("послідовності рівні");
            else Console.WriteLine("послідовності не рівні");
        }
    }
    public void Max()
    {
        int a = Seq[0];
        for (int i = 0; i < Seq.Length; i++)
        {
            if (Seq[i] > a) a = Seq[i];
        }
        Console.WriteLine("максимальне значення: " + a);
    }
    public void Min()
    {
        int a = Seq[0];
        for (int i = 0; i < Seq.Length; i++)
        {
            if (Seq[i] < a) a = Seq[i];
        }
        Console.WriteLine("мінімальне значення: " + a);
    }
    public void SeparateMax(out int[] array1, out int[] array2)
    {
        int a = Seq.Max();
        int b = Array.IndexOf(Seq, a) + 1;
        int[] arr1 = new int[b];
        int[] arr2 = new int[Seq.Length - b];
        for (int i = 0; i < Array.IndexOf(Seq, a) + 1; i++)
        {
            arr1[i] = Seq[i];
        }
        int summ1 = 0;
        for (int i = 0; i < arr1.Length; i++)
        {
            summ1 += arr1[i];
        }
        for (int i = Array.IndexOf(Seq, a) + 1; i < Seq.Length; i++)
        {
            arr2[i - (Array.IndexOf(Seq, a) + 1)] = Seq[i];
        }
        int summ2 = 0;
        for (int i = 0; i < arr1.Length; i++)
        {
            summ2 += arr1[i];
        }
        if (summ1 == summ2) Console.WriteLine("підпослідовності рівні");
        else if (summ1 > summ2) Console.WriteLine("перша підпослідовність більша за другу");
        else Console.WriteLine("друга підпослідовність більша за першу");
        array1 = arr1;
        array2 = arr2;
    }
    public void SeparateMin(out int[] array1, out int[] array2)
    {
        int a = Seq.Min();
        int b = Array.IndexOf(Seq, a) + 1;
        int[] arr1 = new int[b];
        int[] arr2 = new int[Seq.Length - b];
        for (int i = 0; i < Array.IndexOf(Seq, a) + 1; i++)
        {
            arr1[i] = Seq[i];
        }
        int summ1 = 0;
        for (int i = 0; i < arr1.Length; i++)
        {
            summ1 += arr1[i];
        }
        for (int i = Array.IndexOf(Seq, a) + 1; i < Seq.Length; i++)
        {
            arr2[i - (Array.IndexOf(Seq, a) + 1)] = Seq[i];
        }
        int summ2 = 0;
        for (int i = 0; i < arr2.Length; i++)
        {
            summ2 += arr2[i];
        }
        if (summ1 == summ2) Console.WriteLine("підпослідовності рівні");
        else if (summ1 > summ2) Console.WriteLine("перша підпослідовність більша за другу");
        else Console.WriteLine("друга підпослідовність більша за першу");
        array1 = arr1;
        array2 = arr2;
    }
    private bool CheckGeometricProgression()
    {
        int count = 0;
        double q = (double) Seq[1] / Seq[0];
        for (int i = 0; i < Seq.Length - 1; i++)
        {
            if ((double) Seq[i + 1] / Seq[i] == q)
            {
                count += 1;
            }
            if (count == Seq.Length - 1)
            {
                return true;
            }
        }
        return false;
    }
    private bool CheckArithmeticProgression()
    {
        int count = 0;
        int d = Seq[1] - Seq[0];
        for (int i = 0; i < Seq.Length - 1; i++)
        {
            if (Seq[i + 1] - Seq[i] == d)
            {
                count += 1;
            }
            if (count == Seq.Length - 1)
            {
                return true;
            }
        }
        return false;
    }
    private bool CheckDescending()
    {
        int count = 0;
        for (int i = 0; i < Seq.Length - 1; i++)
        {
            if (Seq[i + 1] < Seq[i])
            {
                count += 1;
            }
            if (count == Seq.Length - 1)
            {
                return true;
            }
        }
        return false;
    }
    private bool CheckIncreasing()
    {
        int count = 0;
        for (int i = 0; i < Seq.Length - 1; i++)
        {
            if (Seq[i + 1] > Seq[i])
            {
                count += 1;
            }
            if (count == Seq.Length - 1)
            {
                return true;
            }
        }
        return false;
    }
    public Sequence(int[] seq)
    {
        this.Seq = seq;
    }
    public Sequence(int count, int low, int high)
    {
        int[] seq = new int[count];
        Random rnd = new Random();
        for (int i = 0; i < count; i++)
        {
            seq[i] = rnd.Next(low, high + 1);
        }
        this.Seq = seq;
    }
    public Sequence()
    {
    }
}


