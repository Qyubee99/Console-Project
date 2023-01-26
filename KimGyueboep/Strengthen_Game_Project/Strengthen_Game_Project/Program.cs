using System.Diagnostics;
using System.Media;

namespace Strengthen_Game_Project
{
	class Program
	{
		static void Main()
		{
			Console.ResetColor();
			Console.CursorVisible = false;
			Console.Title = "홍성재 강화 게임";
			Console.BackgroundColor = ConsoleColor.White;
			Console.ForegroundColor = ConsoleColor.Black;
			Console.Clear();

			// 수치들
			int money = 100000;
			int startStrengthen = 4;
			int shield = 0;
			int strengthenCount = 0;
			int strengthenSave = 0;
			int stage = 0;

			Random random = new Random();
			Map maps = new Map();
			Arrow selectArrow = new Arrow
			{
				selectPointX = 29,
				selectPointY = 4,
				shopPointX = 5,
				shopPointY = 3
			};


			HSJ[] hsjs = new HSJ[]
			{
				new HSJ(){Id = 1, Name = "+0 낡은 홍성재", Weight = 100, strengthenedPrice = 300, sellingPrice = 0},
				new HSJ(){Id = 2, Name = "+1 부러진 홍성재", Weight = 100, strengthenedPrice = 300, sellingPrice = 1000},
				new HSJ(){Id = 3, Name = "+2 다시붙인 홍성재", Weight = 100, strengthenedPrice = 500, sellingPrice = 1500},
				new HSJ(){Id = 4, Name = "+3 쓸만한 홍성재", Weight = 95, strengthenedPrice = 500, sellingPrice = 1600},
				new HSJ(){Id = 5, Name = "+4 견고한 홍성재", Weight = 90, strengthenedPrice = 1000, sellingPrice = 2500},
				new HSJ(){Id = 6, Name = "+5 강철 홍성재", Weight = 90, strengthenedPrice = 1500, sellingPrice = 3000},
				new HSJ(){Id = 7, Name = "+6 불타는 홍성재", Weight = 85, strengthenedPrice = 2000, sellingPrice = 4500},
				new HSJ(){Id = 8, Name = "+7 냉기의 홍성재", Weight = 80, strengthenedPrice = 2000, sellingPrice = 7100},
				new HSJ(){Id = 9, Name = "+8 날렵한 홍성재", Weight = 80, strengthenedPrice = 3000, sellingPrice = 10000},
				new HSJ(){Id = 10, Name = "+9 빛나는 홍성재", Weight = 75, strengthenedPrice = 6000, sellingPrice = 20000},
				new HSJ(){Id = 11, Name = "+10 폭풍의 홍성재", Weight = 70, strengthenedPrice = 20900, sellingPrice = 85100},
				new HSJ(){Id = 12, Name = "+11 피묻은 홍성재", Weight = 65, strengthenedPrice = 30000, sellingPrice = 160000},
				new HSJ(){Id = 13, Name = "+12 화염의 홍성재", Weight = 55, strengthenedPrice = 45000, sellingPrice = 350000},
				new HSJ(){Id = 14, Name = "+13 지옥의 홍성재", Weight = 50, strengthenedPrice = 75000, sellingPrice = 1000000},
				new HSJ(){Id = 15, Name = "+14 원한을 품은 홍성재", Weight = 45, strengthenedPrice = 100000, sellingPrice = 2000000},
				new HSJ(){Id = 16, Name = "+15 친일파 홍성재", Weight = 40, strengthenedPrice = 180000, sellingPrice = 5500000},
				new HSJ(){Id = 17, Name = "+16 깨달은 홍성재", Weight = 35, strengthenedPrice = 300000, sellingPrice = 11000000},
				new HSJ(){Id = 18, Name = "+17 국군 홍성재", Weight = 30, strengthenedPrice = 300000, sellingPrice = 20000000},
				new HSJ(){Id = 19, Name = "+18 태초의 홍성재", Weight = 25, strengthenedPrice = 500000, sellingPrice = 30000000},
				new HSJ(){Id = 20, Name = "+19 궁극의 홍성재", Weight = 20, strengthenedPrice = 800000, sellingPrice = 47500000},
				new HSJ(){Id = 21, Name = "+20 GOD성재", Weight = 5, strengthenedPrice = 1500000, sellingPrice = 63000000},
			};

			Shop[] itemShop = new Shop[]
			{
				new Shop(){ Id = 1, Name = "방지권 1개", price = 1000000},
				new Shop(){ Id = 2, Name = "방지권 3개", price = 2500000},
				new Shop(){ Id = 3, Name = "방지권 5개", price = 4300000},
			};


			while (true)
			{
				// Render
				switch (stage)
				{
					case 0:
						maps.RenderMap();

						RenderTitle(selectArrow.selectPointX, selectArrow.selectPointY, "→");
						RenderTitle(15, 2, "성재 강화 하기");
						RenderTitle(8, 4, $"강화 비용:{hsjs[strengthenCount].strengthenedPrice}원");
						RenderTitle(8, 5, $"판매 가격:{hsjs[strengthenCount].sellingPrice}원");
						RenderTitle(17, 13, $"성공률 {hsjs[strengthenCount].Weight}%");
						RenderTitle(34, 13, $"{money}원");
						RenderTitle(4, 13, $"방지권:{shield}");
						RenderTitle(30, 3, "상점");
						RenderTitle(30, 4, "강화하기");
						RenderTitle(30, 5, "판매하기");
						RenderTitle(15, 8, hsjs[strengthenCount].Name);
						RenderTitle(45, 2, "Warning 소지금을 잘보고 강화해주세요!!!!!!!!!!!!!!!!!");
						RenderTitle(45, 3, "Warning 소지금을 잘보고 강화해주세요!!!!!!!!!!!!!!!!!");
						RenderTitle(45, 4, "Warning 소지금을 잘보고 강화해주세요!!!!!!!!!!!!!!!!!");
						RenderTitle(45, 5, "Warning 소지금을 잘보고 강화해주세요!!!!!!!!!!!!!!!!!");
						RenderTitle(45, 6, "Warning 소지금을 잘보고 강화해주세요!!!!!!!!!!!!!!!!!");
						RenderTitle(45, 7, "Warning 소지금을 잘보고 강화해주세요!!!!!!!!!!!!!!!!!");
						RenderTitle(45, 8, "Warning 소지금을 잘보고 강화해주세요!!!!!!!!!!!!!!!!!");
						RenderTitle(45, 9, "Warning 소지금을 잘보고 강화해주세요!!!!!!!!!!!!!!!!!");
						RenderTitle(45, 10, "Warning 소지금을 잘보고 강화해주세요!!!!!!!!!!!!!!!!!");
						RenderTitle(45, 11, "Warning 소지금을 잘보고 강화해주세요!!!!!!!!!!!!!!!!!");
						RenderTitle(45, 12, "Warning 소지금을 잘보고 강화해주세요!!!!!!!!!!!!!!!!!");
						break;
					case 1:
						Console.Clear();
						maps.RenderMap();

						RenderTitle(selectArrow.shopPointX, selectArrow.shopPointY, "→");
						RenderTitle(6, 3, $"방지권 1개:{itemShop[0].price}원");
						RenderTitle(6, 6, $"방지권 3개:{itemShop[1].price}원");
						RenderTitle(6, 9, $"방지권 5개:{itemShop[2].price}원");
						RenderTitle(17, 13, $"방지권:{shield}");
						RenderTitle(6, 12, "나가기");
						RenderTitle(34, 13, $"{money}원");
						break;
					case 2:
						maps.ShieldUsingSelection();

						RenderTitle(10, 3, "방지권을 사용하시겠습니까?");
						RenderTitle(18, 4, "YES / NO");
						RenderTitle(13, 5, "Y 또는 N을 눌러주세요");
						break;
					default:
						Console.Clear();
						Console.WriteLine("[Error]");
						break;
				}

				// ProcessInput

				ConsoleKeyInfo keyInfo = Console.ReadKey();
				ConsoleKey key = keyInfo.Key;

				// Update

				if (key == ConsoleKey.UpArrow)
				{
					selectArrow.selectPointY = Math.Max(3, selectArrow.selectPointY - 1);
				}
				if (key == ConsoleKey.DownArrow)
				{
					selectArrow.selectPointY = Math.Min(selectArrow.selectPointY + 1, 5);
				}
				if (key == ConsoleKey.UpArrow)
				{
					selectArrow.shopPointY = Math.Max(3, selectArrow.shopPointY - 3);
				}
				if (key == ConsoleKey.DownArrow)
				{
					selectArrow.shopPointY = Math.Min(selectArrow.shopPointY + 3, 12);
				}

				if (key == ConsoleKey.Y)
				{
					// 실패 방지권 
					if (stage == 2) // 사용할경우
					{
						shield--;
						strengthenCount = strengthenSave;
						stage = 0;
					}
				}

				if (key == ConsoleKey.N)
				{
					// 실패 방지권
					if (stage == 2)// 사용안했을 경우
					{
						stage = 0;
						strengthenCount = 0;
						strengthenSave = 0;
					}
				}
				if (key == ConsoleKey.Spacebar)
				{
					if (stage == 1)
					{
						// 방지권 구매
						if (selectArrow.shopPointY == 3 && money - itemShop[0].price >= 0)
						{
							money -= itemShop[0].price;
							shield++;
						}
						if (selectArrow.shopPointY == 6 && money - itemShop[1].price >= 0)
						{
							money -= itemShop[1].price;
							shield += 3;
						}
						if (selectArrow.shopPointY == 9 && money - itemShop[2].price >= 0)
						{
							money -= itemShop[2].price;
							shield += 5;
						}
					}

					if (stage == 0)
					{
						// 0 부터 99까지 수중 하나를 추출
						int result = random.Next(0, 100);
						// 강화 하기
						if (selectArrow.selectPointY == startStrengthen)
						{
							if (hsjs[strengthenCount].Weight > result) // 뽑은수가 가중치보다 작으면 강화 성공
							{
								money -= hsjs[strengthenCount].strengthenedPrice;
								strengthenCount++; // 강화가 성공할때 카운트상승
								strengthenSave++; // 강화가 성공할때 세이브포인트 상승
							}
							else
							{
								strengthenCount = 0; // 실패하면 카운트 0 
								if (shield <= 0 && strengthenCount == 0)
								{
									shield = 0;
									strengthenSave = 0;
								}
							}

							if ((strengthenCount == 0 && shield > 0) && (selectArrow.selectPointY != 3 && selectArrow.selectPointY != 5))
							{
								// 방지권 사용할 유무 창 뜨게하기
								stage += 2;
							}

							if (money < 0)
							{
								// 소지금이 0원보다 적을때 게임오버
								Console.Clear();
								Console.WriteLine("홍성재 : 이걸 실패하네 넌 나보다도 못하다 이 쓰레기야");
								break;
							} 
						}

						// 판매하기
						if (selectArrow.selectPointY == 5)
						{
							money += hsjs[strengthenCount].sellingPrice;
							strengthenCount = 0;
							strengthenSave = 0;
						}
						// 상점입장
						if (selectArrow.selectPointY == 3)
						{
							stage++;
							if (selectArrow.shopPointY != 3)
								selectArrow.shopPointY = 3;
						}
					}
					
					// 상점 탈출
					if (stage == 1)
					{
						// 상점나가기
						if (selectArrow.shopPointY == 12)
						{
							stage--;
							if (selectArrow.selectPointY != 3)
								selectArrow.selectPointY = 3;
						}
					}
				}

				if (strengthenCount == hsjs.Length)
				{
					Console.Clear();
					Console.WriteLine("홍성재 : 머저리 주제에 이걸 성공하네 축하한다.");
					break;
				}
			}

			void RenderTitle(int x, int y, string Text)
			{
				Console.SetCursorPosition(x, y);
				Console.WriteLine(Text);
			}
		}
	}
}