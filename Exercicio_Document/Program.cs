using System.Globalization;

namespace Exercicio_Document
{
    internal class Program
    {
        static void Main(string[] args)
        { 
            // ---------------- 1º EXERCÍCIO 

            /*
             
            Console.WriteLine("Informe o nome do arquivo ou sua extenção: ");
            try
            {

                Console.WriteLine("Infome o nome ou o tipo de arquivo que você está procurando");
                string nomeArquivoTipo = Console.ReadLine();

                IEnumerable<string> arquivos = Directory.EnumerateFiles(@"c:\tmp", "*" + nomeArquivoTipo + "*", SearchOption.AllDirectories);
                Console.WriteLine("\n\rArquivos\n\r");
                foreach (var item in arquivos)
                {
                    Console.WriteLine(item);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("\n\rOcorreu um erro\n\r" + e.Message);
            }

            */

            Console.WriteLine("------------------------------------------------");


            // ---------------- 1º EXERCÍCIO

            /*
            Console.WriteLine("Informe o nome do arquivo ou sua extenção: ");
            Console.WriteLine();

            try
            {
                string nomeArquivo = Console.ReadLine();
                Console.WriteLine();
                var arquivos = from arquivo in Directory.EnumerateFiles(@"c:\tmp", "*.*")
                               where arquivo.ToLower().Contains(nomeArquivo)
                               select arquivo;
                Console.WriteLine();

                foreach (var item in arquivos)
                {
                    Console.WriteLine("{0}", item);
                }
                Console.WriteLine();
                Console.WriteLine("{0} Arquivos encontrados.", arquivos.Count<string>().ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine("Ocorreu um erro! " + e.Message);
            }
             */

            Console.WriteLine("------------------------------------------------");

            // ---------------- 2º EXERCÍCIO         
            try
            {
                //Criação da pasta csv
                Directory.CreateDirectory(@"c:\tmp\csv");

                string[] prod = new string[8];

                for (int i = 0; i < 8; i++)
                {
                    Console.WriteLine();
                    Console.WriteLine("Informações do produto: (Nome) (Preço) (Quantidade):");
                    prod[i] = Console.ReadLine();
                }
                
                //Criação do arquivo ItensVendidos.csv
                //Gravação das informações dos produtos dentro do arquivo ItensVendidos.csv
                using (StreamWriter escritorArquivo = File.AppendText(@"c:\tmp\csv\ItensVendidos.csv"))
                {
                    foreach (var item in prod)
                    {
                        string[] campos = item.Split(',');
                        string nome = campos[0];
                        double preco = double.Parse(campos[1], CultureInfo.InvariantCulture);
                        int quantidade = int.Parse(campos[2]);

                        Produto produtos = new Produto(nome, preco, quantidade);

                        escritorArquivo.WriteLine(produtos.Nome + ", " + produtos.Valor.ToString("f2", CultureInfo.InvariantCulture) + ", " + produtos.Qtd);
                    }
                }

                Console.WriteLine();

                //Faz a leitura e mostra o contéudo do arquivo ItensVendidos.csv
                StreamReader leitura = new StreamReader(@"c:\tmp\csv\ItensVendidos.csv");
                string mostrar = leitura.ReadLine();
                while(mostrar != null)
                {
                    Console.WriteLine(mostrar);
                    mostrar = leitura.ReadLine();
                }

                leitura.Close();
                Console.WriteLine();

                // Criação da pasta destino
                Directory.CreateDirectory(@"c:\tmp\destino");

                using (StreamWriter escritorArquivo = File.AppendText(@"c:\tmp\destino\Resumo.csv"))
                {
                    foreach (var item in prod)
                    {
                        string[] campos = item.Split(',');
                        string nome = campos[0];
                        double preco = double.Parse(campos[1], CultureInfo.InvariantCulture);
                        int quantidade = int.Parse(campos[2]);

                        Produto produtos = new Produto(nome, preco, quantidade);

                        escritorArquivo.WriteLine(produtos.Nome + ", " + produtos.Totalizar().ToString("F2"), CultureInfo.InvariantCulture);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Ocorreu um erro!\n\r" + e.Message);
            }

            Console.WriteLine("------------------------------------------------");


        }
    }
}