using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Linsta_do_ibge_sobre_internet
{
	class Program
	{
		static void Main(string[] args)
		{
			int TotalMoveisBrasil = 0;
			int TotalAcessoSul = 0;
			int[] TotalMovelRegional = new int[5];
			
			StreamReader leitor = new StreamReader("../../ibge.csv");
			leitor.ReadLine();
			while (!leitor.EndOfStream)
			{
				IBGE dados = new IBGE();
				string linha = leitor.ReadLine();
				string[] DadosIbge = linha.Split(';');
				dados.estado = DadosIbge[0];
				dados.movel = int.Parse(DadosIbge[2].Replace(" ", ""));
				dados.total = int.Parse(DadosIbge[1].Replace(" ", ""));

				switch (dados.estado.ToUpper())
				{
					//Regiao Norte
					case "ROND�NIA":
					case "ACRE":
					case "AMAZONAS":
					case "RORAIMA":
					case "PAR�":
					case "AMAP�":
					case "TOCANTINS":
						TotalMovelRegional[0] += dados.movel;
						break;
					//Nordeste
					case "MARANH�O":
					case "PIAU�":
					case "CEAR�":
					case "RIO GRANDE DO NORTE":
					case "PARA�BA":
					case "PERNAMBUCO":
					case "ALAGOAS":
					case "SERGIPE":
					case "BAHIA":
						TotalMovelRegional[1] += dados.movel;
						break;
					//Sudeste
					case "MINAS GERAIS":
					case "ESP�RITO SANTO":
					case "RIO DE JANEIRO":
					case "S�O PAULO":
						TotalMovelRegional[2] += dados.movel;
						break;
					//Sul
					case "PARAN�":
					case "SANTA CATARINA":
					case "RIO GRANDE DO SUL":
						TotalMovelRegional[3] += dados.movel;
						TotalAcessoSul = dados.total;
						break;
					//Centro Oeste
					case "MATO GROSSO DO SUL":
					case "MATO GROSSO":
					case "GOI�S":
					case "DISTRITO FEDERAL":
						TotalMovelRegional[4] += dados.movel;
						break;
				}
				TotalMoveisBrasil += dados.movel;
			}
			Console.WriteLine("Total de Acesso no Sul com todos os dispositivos : " + TotalAcessoSul);
			Console.WriteLine("Total de Acesso moveis no Centro Oeste : " + TotalMovelRegional[4] + "\n");
			
			Console.ReadKey();
			Console.WriteLine("Total de Acesso moveis no Centro Oeste : " + TotalMovelRegional[4]);
			Console.WriteLine("Total de Acesso moveis no Sul : " + TotalMovelRegional[3]);
			Console.WriteLine("Total de Acesso moveis no Sudeste : " + TotalMovelRegional[2]);
			Console.WriteLine("Total de Acesso moveis no Nordeste : " + TotalMovelRegional[1]);
			Console.WriteLine("Total de Acesso moveis no Norte : " + TotalMovelRegional[0]);
			Console.WriteLine("Total de Acesso por disposivos moveis no Brasil : " + TotalMoveisBrasil);

			Console.ReadKey();

		}
	}
}
