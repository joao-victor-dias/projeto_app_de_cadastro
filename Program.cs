using System;
using Dio.Serie.Classes;

namespace Dio.Serie
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuário = ObterOpcaoUsusario();

            while (opcaoUsuário!= "7")
            {
                switch (opcaoUsuário)
                {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VisualizarSerie();
                        break;
                    case "6":
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Opção Inválida!");
                        break;                                        
                }
                opcaoUsuário = ObterOpcaoUsusario();
            }
            Console.WriteLine("Obrigado por utilizar nosso gerenciador de séries.");
            Console.ReadLine();            
        }

         private static void ListarSeries()
        {
            Console.WriteLine("Listar séries");
            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada");
                return;
            }
            foreach (var serie in lista)
            {
                var excluido = serie.retornaExcluido();

                Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluido*" : ""));
            }
        }

        private static void InserirSerie()
        {
            Console.WriteLine("Inserir nova série");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Escolha o gênero e digite a numeração correspondente:");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o título da série:");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o ano de lançamento da série:");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição da série:");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);
            repositorio.Insere(novaSerie);
        }

        private static void AtualizarSerie()
        {
            Console.WriteLine("Séries cadastradas");
            ListarSeries();
            Console.WriteLine();
            
            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Escolha o gênero e digite a numeração correspondente:");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o título da série:");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o ano de lançamento da série:");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição da série:");
            string entradaDescricao = Console.ReadLine();

            Serie atualizaSerie = new Serie(id: indiceSerie,
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);
            repositorio.Atualiza(indiceSerie, atualizaSerie);
        }

        private static void ExcluirSerie()
        {
            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            repositorio.Exclui(indiceSerie);
        }

        private static void VisualizarSerie()
        {
            Console.Write("Digite o id da série");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornoPorId(indiceSerie);

            Console.WriteLine(serie);
        }

         private static string ObterOpcaoUsusario()
        {
            Console.WriteLine();
            Console.WriteLine("Gerenciador de Séries");
            Console.WriteLine();
            Console.WriteLine("Escolha a opção desejada");
            Console.WriteLine();

            Console.WriteLine("1 - Listar séries");
            Console.WriteLine("2 - Inserir nova série");
            Console.WriteLine("3 - Atualizar série");
            Console.WriteLine("4 - Excluir série");
            Console.WriteLine("5 - Visualizar série");
            Console.WriteLine("6 - Limpar Tela");
            Console.WriteLine("7 - Sair");
            Console.WriteLine();

            Console.Write("Digite o número da opção desejada: ");
            string opcaoUsuario = Console.ReadLine();
            Console.WriteLine();            
            return opcaoUsuario;
        }
    }
}
