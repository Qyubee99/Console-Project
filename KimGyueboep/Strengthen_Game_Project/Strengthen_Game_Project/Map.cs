using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strengthen_Game_Project
{
	class Map
	{
		public void RenderMap()
		{
			Console.Clear();

			Console.WriteLine("   ※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※");
			Console.WriteLine("   ※                                      ※");
			Console.WriteLine("   ※                                      ※");
			Console.WriteLine("   ※                                      ※");
			Console.WriteLine("   ※                                      ※");
			Console.WriteLine("   ※                                      ※");
			Console.WriteLine("   ※                                      ※");
			Console.WriteLine("   ※                                      ※");
			Console.WriteLine("   ※                                      ※");
			Console.WriteLine("   ※                                      ※");
			Console.WriteLine("   ※                                      ※");
			Console.WriteLine("   ※                                      ※");
			Console.WriteLine("   ※                                      ※");
			Console.WriteLine("   ※                                      ※");
			Console.WriteLine("   ※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※"); // for문
		}

		public void ShieldUsingSelection()
		{
			Console.SetCursorPosition(8, 1);
			Console.WriteLine("※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※");
			Console.SetCursorPosition(8, 2);
			Console.WriteLine("※                            ※");
			Console.SetCursorPosition(8, 3);
			Console.WriteLine("※                            ※");
			Console.SetCursorPosition(8, 4);
			Console.WriteLine("※                            ※");
			Console.SetCursorPosition(8, 5);
			Console.WriteLine("※                            ※");
			Console.SetCursorPosition(8, 6);
			Console.WriteLine("※                            ※");
			Console.SetCursorPosition(8, 7);
			Console.WriteLine("※                            ※");
			Console.SetCursorPosition(8, 8);
			Console.WriteLine("※                            ※");
			Console.SetCursorPosition(8, 9);
			Console.WriteLine("※※※※※※※※※※※※※※※※※※※※※※※※※※※※※※");
		}
	}
}
