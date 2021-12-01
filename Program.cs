using System;
using Dio.Serie.Classes;


namespace Dio.Serie
{
    class Program
    {
        static SerieRepositorio repositorioserie = new SerieRepositorio();
        static FilmeRepositorio repositoriofilme = new FilmeRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuário = ObterOpcaoUsuario();

            while (opcaoUsuário!= "8")
            {
                switch (opcaoUsuário)
                {
                    case "1":
                        Filmes();
                        break;                    
                    case "2":
                        Series();
                        break;
                    case "3":
                        Cadastro();
                        break;
                    case "4":
                        Atualizar();
                        break;
                    case "5":
                        Excluir();
                        break;
                    case "6":
                        Visualizar();
                        break;
                    case "7":
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Opção Inválida!");
                        break;                                        
                }
                opcaoUsuário = ObterOpcaoUsuario();
            }
            Console.WriteLine("Obrigado por utilizar nosso gerenciador.");
            Console.ReadLine();            
        }

         
         
         private static void Filmes()
        {
            Console.WriteLine("Filmes Cadastrados");
            var listafilme = repositoriofilme.Lista();

            if (listafilme.Count == 0)
            {
                Console.WriteLine("Nenhum filme cadastrado");
                return;
            }
            foreach (var serie in listafilme)
            {
                var excluido = serie.retornaExcluidoFilme();

                Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaIdFilme(), serie.retornaTituloFilme(), (excluido ? "*Excluido*" : ""));
            }
        }
         
         
         
         private static void Series()
        {
            Console.WriteLine("Séries Cadastradas");
            var listaserie = repositorioserie.Lista();

            if (listaserie.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada");
                return;
            }
            foreach (var serie in listaserie)
            {
                var excluido = serie.retornaExcluidoSerie();

                Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaIdSerie(), serie.retornaTituloSerie(), (excluido ? "*Excluido*" : ""));
            }
        }

        private static void Cadastro()
        {
            Console.WriteLine("Cadastro");
            Console.WriteLine("");
            int entradaCategoria = ObterCategoria();

            switch (entradaCategoria)
            {
                case 1:
                    Console.WriteLine("Gêneros");
                    foreach (int i in Enum.GetValues(typeof(Genero)))
                    {
                        Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
                    }
                    Console.WriteLine("");
                    Console.Write("Escolha o gênero e digite a numeração correspondente: ");
                    int entradaGeneroFilme = int.Parse(Console.ReadLine());

                    Console.Write("Digite o título: ");
                    string entradaTituloFilme = Console.ReadLine();

                    Console.Write("Digite o ano de lançamento: ");
                    int entradaAnoFilme = int.Parse(Console.ReadLine());

                    Console.Write("Digite a descrição: ");
                    string entradaDescricaoFilme = Console.ReadLine();

                    Filme novoFilme = new Filme(id: repositoriofilme.ProximoId(),
                                        categoria: (Categoria)entradaCategoria,
                                        genero: (Genero)entradaGeneroFilme,
                                        titulo: entradaTituloFilme,
                                        ano: entradaAnoFilme,
                                        descricao: entradaDescricaoFilme);
                    repositoriofilme.Insere(novoFilme);
                    break;

                case 2:
                    Console.WriteLine("Gêneros");
                    foreach (int i in Enum.GetValues(typeof(Genero)))
                    {
                        Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
                    }
                    Console.WriteLine("");
                    Console.Write("Escolha o gênero e digite a numeração correspondente: ");
                    int entradaGeneroSerie = int.Parse(Console.ReadLine());

                    Console.Write("Digite o título: ");
                    string entradaTituloSerie = Console.ReadLine();

                    Console.Write("Digite o ano de lançamento: ");
                    int entradaAnoSerie = int.Parse(Console.ReadLine());

                    Console.Write("Digite a descrição: ");
                    string entradaDescricaoSerie = Console.ReadLine();

                    Serie novaSerie = new Serie(id: repositorioserie.ProximoId(),
                                        categoria: (Categoria)entradaCategoria,
                                        genero: (Genero)entradaGeneroSerie,
                                        titulo: entradaTituloSerie,
                                        ano: entradaAnoSerie,
                                        descricao: entradaDescricaoSerie);
                    repositorioserie.Insere(novaSerie);
                    break;

                default:
                    Console.WriteLine("");
                    Console.WriteLine("Opção incorreta.");
                    Cadastro();
                    break;
            }
        }

        

        private static void Atualizar()
        {
                      
            int entradaCategoria = ObterCategoria(); 
            Console.WriteLine("");

             switch(entradaCategoria)
            {
                case 1:
                    Console.WriteLine("Filmes Cadastrados");
                    Filmes();
                    Console.WriteLine();
            
                    Console.Write("Digite o id da série: ");
                    int indiceFilme = int.Parse(Console.ReadLine());

                           
                    foreach (int i in Enum.GetValues(typeof(Genero)))
                    {
                        Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
                    }
                    Console.Write("Escolha o gênero e digite a numeração correspondente:");
                    int entradaGeneroFilme = int.Parse(Console.ReadLine());

                    Console.Write("Digite o título da série:");
                    string entradaTituloFilme = Console.ReadLine();

                    Console.Write("Digite o ano de lançamento da série:");
                    int entradaAnoFilme = int.Parse(Console.ReadLine());

                    Console.Write("Digite a descrição da série:");
                    string entradaDescricaoFilme = Console.ReadLine();

                    Filme atualizaFilme = new Filme(id: indiceFilme,
                                                categoria : (Categoria)entradaCategoria,
                                                genero: (Genero)entradaGeneroFilme,
                                                titulo: entradaTituloFilme,
                                                ano: entradaAnoFilme,
                                                descricao: entradaDescricaoFilme);
                    repositoriofilme.Atualiza(indiceFilme, atualizaFilme);
                    break;

                case 2:
                    Console.WriteLine("Séries cadastradas");
                    Series();
                    Console.WriteLine();
            
                    Console.Write("Digite o id da série: ");
                    int indiceSerie = int.Parse(Console.ReadLine());

                    foreach (int i in Enum.GetValues(typeof(Genero)))
                    {
                        Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
                    }
                    Console.Write("Escolha o gênero e digite a numeração correspondente:");
                    int entradaGeneroSerie = int.Parse(Console.ReadLine());

                    Console.Write("Digite o título da série:");
                    string entradaTituloSerie = Console.ReadLine();

                    Console.Write("Digite o ano de lançamento da série:");
                    int entradaAnoSerie = int.Parse(Console.ReadLine());

                    Console.Write("Digite a descrição da série:");
                    string entradaDescricaoSerie = Console.ReadLine();

                    Serie atualizaSerie = new Serie(id: indiceSerie,
                                                categoria : (Categoria)entradaCategoria,
                                                genero: (Genero)entradaGeneroSerie,
                                                titulo: entradaTituloSerie,
                                                ano: entradaAnoSerie,
                                                descricao: entradaDescricaoSerie);
                    repositorioserie.Atualiza(indiceSerie, atualizaSerie);
                    break;

                default:
                    Console.WriteLine("");
                    Console.WriteLine("Opção incorreta.");
                    Atualizar();
                    break;
            }     
            
        }

        private static void Excluir()
        {
            int entradaCategoria = ObterCategoria(); 
            Console.WriteLine("");

            switch(entradaCategoria)
            {
                case 1:
                    Filmes();
                    Console.Write("Digite o id do filme: ");
                    int indiceFilme = int.Parse(Console.ReadLine());
                    repositoriofilme.Exclui(indiceFilme);
                    break;

                case 2:
                    Series();
                    Console.Write("Digite o id da série: ");
                    int indiceSerie = int.Parse(Console.ReadLine());
                    repositorioserie.Exclui(indiceSerie);                    
                    break;

                default:
                    Console.WriteLine("");
                    Console.WriteLine("Opção incorreta.");
                    Excluir();
                    break;
            }
        }

        private static void Visualizar()
        {
            int entradaCategoria = ObterCategoria(); 
            Console.WriteLine("");
            switch(entradaCategoria)
            {
                case 1:
                    Filmes();
                    Console.Write("Digite o id do filme: ");
                    int indiceFilme = int.Parse(Console.ReadLine());
                    var filme = repositoriofilme.RetornoPorId(indiceFilme);
                    Console.WriteLine(filme); 
                    break;  

                case 2:
                    Series();
                    Console.Write("Digite o id da série: ");
                    int indiceSerie = int.Parse(Console.ReadLine());
                    var serie = repositorioserie.RetornoPorId(indiceSerie);
                    Console.WriteLine(serie); 
                    break;  

                default:
                    Console.WriteLine("");
                    Console.WriteLine("Opção incorreta.");
                    Visualizar();
                    break;
            }
        }
        
        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Gerenciador de Séries e Filmes");
            Console.WriteLine();
            Console.WriteLine("Escolha a opção desejada");
            Console.WriteLine();

            Console.WriteLine("1 - Listar Filmes");
            Console.WriteLine("2 - Listar Séries");
            Console.WriteLine("3 - Cadastro (Filme ou Série)");
            Console.WriteLine("4 - Atualização(Filme ou Série)");
            Console.WriteLine("5 - Excluir (Filme ou Série)");
            Console.WriteLine("6 - Visualizar (Filme ou Série)");
            Console.WriteLine("7 - Limpar Tela");
            Console.WriteLine("8 - Sair");
            Console.WriteLine();

            Console.Write("Digite o número da opção desejada: ");
            string opcaoUsuario = Console.ReadLine();
            Console.WriteLine();            
            return opcaoUsuario;
        }

        private static int ObterCategoria()
        {
            Console.WriteLine("Categorias");
            foreach (int i in Enum.GetValues(typeof(Categoria)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Categoria), i));
            }
            Console.Write("Escolha a categoria e digite a numeração correspondente: ");
            int entradaCategoria = int.Parse(Console.ReadLine());
            Console.WriteLine("");
            return entradaCategoria;
        }

        
    }
}



