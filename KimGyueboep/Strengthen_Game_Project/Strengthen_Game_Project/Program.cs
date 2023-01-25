namespace Strengthen_Game_Project
{
	class Program
	{
		static void Main()
		{
			Console.ResetColor();
			Console.CursorVisible = false;
			Console.Title = "강화 게임";
			Console.BackgroundColor = ConsoleColor.White;
			Console.ForegroundColor = ConsoleColor.Black;
			Console.Clear();

			int selectPointX = 29;
			int selectPointY = 4;

			int shopPointX = 5;
			int shopPointY = 3;

			int shield = 1;
			int money = 100000000;
			int count = 0;
			int shop = 3;
			int strengthen = 4;
			int sell = 5; // 위치 
			int save = 0;
			int stage = 0;
			Random random = new Random();

			HSJ[] hsjs = new HSJ[]
			{
				new HSJ(){Id = 1, Name = "+0 낡은 홍성재", Weight = 100, strengthenedPrice = 300, sellingPrice = 0},
				new HSJ(){Id = 2, Name = "+1 쓸만한 홍성재", Weight = 100, strengthenedPrice = 300, sellingPrice = 150},
				new HSJ(){Id = 3, Name = "+2 견고한 홍성재", Weight = 100, strengthenedPrice = 500, sellingPrice = 400},
				new HSJ(){Id = 4, Name = "+3 강철 홍성재", Weight = 95, strengthenedPrice = 500, sellingPrice = 600},
				new HSJ(){Id = 5, Name = "+4 날렵한 홍성재", Weight = 90, strengthenedPrice = 1000, sellingPrice = 800},
				new HSJ(){Id = 6, Name = "+5 불타는 홍성재", Weight = 85, strengthenedPrice = 1500, sellingPrice = 1600},
				new HSJ(){Id = 7, Name = "+6 냉기의 홍성재", Weight = 80, strengthenedPrice = 2000, sellingPrice = 3500},
				new HSJ(){Id = 8, Name = "+7 날렵한 홍성재", Weight = 75, strengthenedPrice = 2000, sellingPrice = 6100},
				new HSJ(){Id = 9, Name = "+8 마력의 홍성재", Weight = 70, strengthenedPrice = 3000, sellingPrice = 10000},
				new HSJ(){Id = 10, Name = "+9 빛나는 홍성재", Weight = 65, strengthenedPrice = 5000, sellingPrice = 20000},
				new HSJ(){Id = 11, Name = "+10 폭풍의 홍성재", Weight = 60, strengthenedPrice = 10900, sellingPrice = 35100},
				new HSJ(){Id = 12, Name = "+11 피묻은 홍성재", Weight = 55, strengthenedPrice = 20000, sellingPrice = 160000},
				new HSJ(){Id = 13, Name = "+12 화염의 홍성재", Weight = 50, strengthenedPrice = 35000, sellingPrice = 350000},
				new HSJ(){Id = 14, Name = "+13 지옥의 홍성재", Weight = 45, strengthenedPrice = 55000, sellingPrice = 1000000},
				new HSJ(){Id = 15, Name = "+14 마검을 든 홍성재", Weight = 40, strengthenedPrice = 100000, sellingPrice = 3000000},
				new HSJ(){Id = 16, Name = "+15 데몬 홍성재", Weight = 35, strengthenedPrice = 180000, sellingPrice = 7500000},
				new HSJ(){Id = 17, Name = "+16 원한을 품은 홍성재", Weight = 30, strengthenedPrice = 300000, sellingPrice = 14200000},
				new HSJ(){Id = 18, Name = "+17 깨달은 홍성재", Weight = 25, strengthenedPrice = 300000, sellingPrice = 20000000},
				new HSJ(){Id = 19, Name = "+18 태초의 홍성재", Weight = 20, strengthenedPrice = 500000, sellingPrice = 30000000},
				new HSJ(){Id = 20, Name = "+19 궁극의 홍성재", Weight = 10, strengthenedPrice = 800000, sellingPrice = 47500000},
				new HSJ(){Id = 21, Name = "+20 GOD성재", Weight = 5, strengthenedPrice = 1500000, sellingPrice = 68300000}
			};

			Shop[] itemShop = new Shop[]
			{
				new Shop(){ Id = 1, Name = "방지권 1개", price = 1000000},
				new Shop(){ Id = 2, Name = "방지권 3개", price = 2500000},
				new Shop(){ Id = 3, Name = "방지권 5개", price = 4000000},
			};


			while (true)
			{
				// Render
				switch (stage)
				{
					case 0:
						RenderMap();

						RenderTitle(selectPointX, selectPointY, "→");
						RenderTitle(15, 2, "성재 강화 하기");
						RenderTitle(8, 4, $"강화 비용:{hsjs[count].strengthenedPrice}");
						RenderTitle(8, 5, $"판매 가격:{hsjs[count].sellingPrice}");
						RenderTitle(17, 13, $"성공률 {hsjs[count].Weight}%");
						RenderTitle(34, 13, $"{money}원");
						RenderTitle(4, 13, $"방지권:{shield}");
						RenderTitle(30, 3, "상점");
						RenderTitle(30, 4, "강화하기");
						RenderTitle(30, 5, "판매하기");
						RenderTitle(50, 5, $"{save}");
						RenderTitle(15, 8, hsjs[count].Name);
						break;
					case 1:
						Console.Clear();
						RenderMap();

						RenderTitle(shopPointX, shopPointY, "→");
						RenderTitle(6, 3, "방지권 1개:1,000,000원");
						RenderTitle(6, 6, "방지권 3개:2,500,000원");
						RenderTitle(6, 9, "방지권 5개:4,000,000원");
						RenderTitle(17, 13, $"방지권:{shield}");
						RenderTitle(6, 12, "나가기");
						RenderTitle(34, 13, $"{money}원");
						break;
					case 2:
						ShieldUsingSelection();

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
					selectPointY = Math.Max(shop, selectPointY - 1);
				}
				if (key == ConsoleKey.DownArrow)
				{
					selectPointY = Math.Min(selectPointY + 1, sell);
				}
				if (key == ConsoleKey.UpArrow)
				{
					shopPointY = Math.Max(3, shopPointY - 3);
				}
				if (key == ConsoleKey.DownArrow)
				{
					shopPointY = Math.Min(shopPointY + 3, 12);
				}

				if (key == ConsoleKey.Y)
				{
					// 실패 방지권 
					if (stage == 2) // 사용할경우
					{
						shield--;
						count = save;
						stage = 0;
					}
				}

				if (key == ConsoleKey.N)
				{
					// 실패 방지권
					if (stage == 2)// 사용안했을 경우
					{
						stage = 0;
						count = 0;
						save = 0;
					}
				}
				if (key == ConsoleKey.Spacebar)
				{
					if (stage == 1)
					{
						// 방지권 구매
						if (shopPointY == 3 && money - itemShop[0].price >= 0)
						{
							money -= itemShop[0].price;
							shield++;
						}
						if (shopPointY == 6 && money - itemShop[1].price >= 0)
						{
							money -= itemShop[1].price;
							shield += 3;
						}
						if (shopPointY == 9 && money - itemShop[2].price >= 0)
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
						if (selectPointY == strengthen)
						{
							if (hsjs[count].Weight > result) // 뽑은수가 가중치보다 작으면 강화 성공
							{
								money -= hsjs[count].strengthenedPrice;
								count++; // 강화가 성공할때 카운트상승
								save++; // 강화가 성공할때 세이브포인트 상승
							}
							else
							{
								count = 0; // 실패하면 카운트 0 
								if (shield <= 0 && count == 0)
								{
									shield = 0;
									save = 0;
								}
							}

							if ((count == 0 && shield > 0) && (selectPointY != 3 && selectPointY != 5))
							{
								// 방지권 사용할 유무 창 뜨게하기
								stage += 2;
							}

							if (money < 0)
							{
								// 소지금이 0원보다 적을때 게임오버
								Console.Clear();
								Console.WriteLine("이걸 실패하네 넌 성재보다도 못하다");
								break;
							} 
						}

						// 판매하기
						if (selectPointY == sell)
						{
							money += hsjs[count].sellingPrice;
							count = 0;
							save = 0;
						}
						// 상점입장
						if (selectPointY == shop)
						{
							stage++;
							if (shopPointY != 3)
								shopPointY = 3;
						}
					}

					// 상점 탈출
					if (stage == 1)
					{
						// 상점나가기
						if (shopPointY == 12)
						{
							stage--;
							if (selectPointY != 3)
								selectPointY = 3;
						}
					}
				}

				if (count == hsjs.Length)
				{
					Console.Clear();
					Console.WriteLine("이걸 성공하네 축하한다.");
					break;
				}
			}

			void RenderTitle(int x, int y, string Text)
			{
				Console.SetCursorPosition(x, y);
				Console.WriteLine(Text);
			}

			void RenderMap()
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

			void ShieldUsingSelection()
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
}