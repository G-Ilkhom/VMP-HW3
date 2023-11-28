using System;

class Project1
{
	static void Min(in int[][] array, out string result)
	{
		result = "";
		for (int i = 0; i < array.Length; i++)
		{
			int min = array[i][0];
			for (int j = 1; j < array[i].Length; j++)
			{
				if (array[i][j] < min)
					min = array[i][j];
			}
			result += $"\nСтрока {i + 1}: {min} ";
		}
	}

	static void Max(in int[][] array, out string result)
	{
		result = "";
		for (int i = 0; i < array.Length; i++)
		{
			int max = array[i][0];
			for (int j = 1; j < array[i].Length; j++)
			{
				if (array[i][j] > max)
					max = array[i][j];
			}
			result += $"\nСтрока {i + 1}: {max} ";
		}
	}

	static void Sum(in int[][] array, ref int[] result)
	{
		int pointer = 0;
		for (int i = 0; i < array.Length; i++)
		{
			int sum = 0;
			for (int j = 0; j < array[i].Length; j++)
				sum += array[i][j];
			result[pointer++] = sum;
		}
	}
	static void Main()
	{
		int n = 0;
		do
		{
			Console.Write("Введите количество строк: ");
			if (int.TryParse(Console.ReadLine(), out n))
			{
				if (n > 0)
				{
					break;
				}
			}
			Console.WriteLine("Некорректный ввод. Попробуйте еще раз.");
		} while (true);

		int pointer = 0;
		int[][] array = new int[n][];


		for (int i = 0; i < n; i++)
		{
			int counter = 0;
			string user_input = Console.ReadLine();
			string line = user_input[0].ToString();

			for (int j = 1; j < user_input.Length; j++)
			{
				if (user_input[j] != ' ' && user_input[j - 1] != ' ' || user_input[j] != ' ' && user_input[j - 1] == ' ')
				{
					line += user_input[j];
					if (j == user_input.Length - 1)
						counter++;
					continue;
				}
				else if (user_input[j] == ' ' && user_input[j - 1] == ' ')
				{
					continue;
				}
				else if (user_input[j] == ' ' && user_input[j - 1] != ' ')
				{
					counter++;
					line = "";
				}
			}

			array[pointer++] = new int[counter];
			line = user_input[0].ToString();
			int array_index = 0;
			for (int j = 1; j < user_input.Length; j++)
			{
				if (user_input[j] != ' ' && user_input[j - 1] != ' ' || user_input[j] != ' ' && user_input[j - 1] == ' ')
				{
					line += user_input[j];
					int number = 0;
					if (j == user_input.Length - 1)
					{
						if (int.TryParse(line, out number))
						{
							array[i][array_index++] = number;
						}
						else
						{
							number = 0;
							array[i][array_index++] = number;
						}
						continue;
					}
				}
				else if (user_input[j] == ' ' && user_input[j - 1] == ' ')
				{
					continue;
				}
				else if (user_input[j] == ' ' && user_input[j - 1] != ' ')
				{
					int number = 0;
					if (int.TryParse(line, out number))
					{
						array[i][array_index++] = number;
					}
					else
					{
						number = 0;
						array[i][array_index++] = number;
					}
					line = "";
				}
			}
		}

		Min(in array, out string result_1);
		Console.WriteLine($"Минимумы: {result_1}");

		Max(in array, out string result_2);
		Console.WriteLine($"Максимумы: {result_2}");

		int[] result_3 = new int[n];
		Sum(in array, ref result_3);
		Console.Write("Суммы: ");
		for (int i = 0; i < n; i++)
			Console.Write($"\nСтрока {i + 1}: {result_3[i]} ");
	}
}