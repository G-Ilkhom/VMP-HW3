using System;

class Project3
{
	private int[] array;
	private int size;

	public Project3(int n)
	{
		size = n;
		array = new int[n];
	}

	public void InputData()
	{
		Console.WriteLine("Введите значения массива: ");
		for (int i = 0; i < size; i++)
		{
			if (int.TryParse(Console.ReadLine(), out int number))
			{
				array[i] = number;
			}
			else
			{
				i--;
			}
		}
	}

	public void InputDataRandom()
	{
		Console.WriteLine("Случайное задание числами от 0 до 10");
		Random random = new Random();
		for (int i = 0; i < size; i++)
			array[i] = random.Next(0, 10);
	}

	public void Print()
	{
		Console.Write("Массив: ");
		for (int i = 0; i < size; i++)
			Console.Write($"{array[i]} ");
		Console.WriteLine();
	}

	public string FindValue(in int number)
	{
		string result = "Индексы: ";
		int counter = 0;
		for (int i = 0; i < size; i++)
		{
			if (array[i] == number)
			{
				counter++;
				result += $"{i + 1} ";
			}
		}
		return result;
	}

	public void DelValue(int number)
	{
		int counter = 0;
		for (int i = 0; i < size; i++)
		{
			if (array[i] == number)
				counter++;
		}
		if (counter == 0)
		{
			Console.WriteLine("Искомый элемент не найден");
			return;
		}
		int[] new_array = new int[size - counter];
		int index = 0;
		for (int i = 0; i < size; i++)
		{
			if (array[i] == number)
				continue;
			new_array[index++] = array[i];
		}
		array = new_array;
		size -= counter;
	}

	public void FindMax(out int result)
	{
		result = 0;
		foreach (int i in array)
		{
			if (i > result)
				result = i;
		}
	}

	public static void Sort(ref Project3 array)
	{
		for (int i = 0; i < array.size; i++)
		{
			for (int j = i + 1; j < array.size; j++)
			{
				if (array.array[i] > array.array[j])
				{
					int temp = array.array[i];
					array.array[i] = array.array[j];
					array.array[j] = temp;
				}
			}
		}
	}
}

public class Program3
{
	static void Main()
	{
		Project3 array = new Project3(10);
		array.InputDataRandom();
		array.Print();
		Project3.Sort(ref array);
		array.Print();
		array.FindMax(out int result);
		Console.WriteLine($"Макс. элемент: {result}");
		array.DelValue(result);
		array.Print();
		Console.Write("Введите искомое значение: ");
		int number = Convert.ToInt32(Console.ReadLine());
		Console.WriteLine(array.FindValue(in number));
	}
}