using System;
using System.Linq;

namespace IR_Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
			//--------------------Input---------------------------
			Console.Write("Enter the number of plays: ");
			int x = Convert.ToInt32(Console.ReadLine());

			Console.Write("Enter the number of words: ");
			int y = Convert.ToInt32(Console.ReadLine()) + 1;

			var array = new object[x, y];

			for (int p = 0; p < x; p++)
			{
				var pn = p + 1;
				Console.Write("Enter the name of the play number " + pn + " : ");
				array[p, 0] = Console.ReadLine();
				for (int w = 1; w < y; w++)
				{
					Console.Write("Enter the word number " + w + " of the play number " + pn + " : ");
					array[p, w] = Console.ReadLine();
				}
			}

			//maxlen for spacing
			int maxlen = 0;
			for (int f = 0; f < x; f++)
			{
				for (int s = 0; s < y; s++)
				{
					string tos = (string)array[f, s];
					if (maxlen < tos.Length)
					{
						maxlen = tos.Length;
					}
				}
			}

			string onespace = string.Concat(Enumerable.Repeat(" ", maxlen - 1));

			//check for uniqueness
			var words = new object[((y - 1) * x)];
			int ind = 0;
			Console.Write(" *");
			Console.Write(onespace);
			Console.Write(" | ");
			for (int pm = 0; pm < x; pm++)
			{
				for (int wm = 1; wm < y; wm++)
				{
					bool test = false;
					string tword = (string)array[pm, wm];
					foreach (string word in words)
					{
						if (tword == word)
						{
							test = false;
							break;
						}
						else
						{
							test = true;
						}
					}
					if (test)
					{
						//print first row
						Console.Write(tword);
						string space = string.Concat(Enumerable.Repeat(" ", maxlen - tword.Length));
						Console.Write(space);
						Console.Write(" | ");
						words[ind] = tword;
						ind++;
					}
				}
			}

			Console.WriteLine();

			//-----------------Outputing--------------------
			for (int pm = 0; pm < x; pm++)
			{
				string pname = (string)array[pm, 0];
				string space = string.Concat(Enumerable.Repeat(" ", maxlen - pname.Length));
				Console.Write(" " + pname);
				Console.Write(space);
				Console.Write(" | ");
				foreach (string word in words)
				{
					bool test = false;
					for (int wm = 1; wm < y; wm++)
					{
						string tword = (string)array[pm, wm];
						if (word == tword)
						{
							test = true;
							Console.Write(1);
							Console.Write(onespace);
							Console.Write(" | ");
							break;
						}
					}
					if (test == false && word != null)
					{
						Console.Write(0);
						Console.Write(onespace);
						Console.Write(" | ");
					}

				}
				Console.WriteLine();
			}



			Console.ReadLine();
		}
    }
}
