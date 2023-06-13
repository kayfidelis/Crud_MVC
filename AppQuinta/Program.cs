
using bModel;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bDB;
using System.Security.Cryptography.X509Certificates;

namespace AppBanco
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Banco db = new Banco();
            UsuarioDAO objDao = new UsuarioDAO();
            Usuario objUsuario = new Usuario();
            List<Usuario> ListUsuario = new List<Usuario>();
            

           
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Informe um Id para identificação:");
            objUsuario.IdUsu = int.Parse(Console.ReadLine());
            string dado = objDao.SelectDado(objUsuario.IdUsu);
            Console.Clear();
            Console.WriteLine($"Olá senhor(a) {dado}, escolha uma opção no menu");
            Console.WriteLine();
            Console.ResetColor();
            
            Console.ForegroundColor = ConsoleColor.DarkGreen;

            bool MostrarMenu = true;
            while (MostrarMenu)
            {
               MostrarMenu = Menu();
            }

            bool Menu()
            {
                Console.WriteLine("|---------------------------------|");
                Console.WriteLine("|            MENU  DE             |");
                Console.WriteLine("|             OPÇÕES              |");
                Console.WriteLine("|---------------------------------|");
                Console.WriteLine("| 1 Cadastrar Usuário             |");
                Console.WriteLine("| 2 Atualizar Cadastro do Usuário |");
                Console.WriteLine("| 3 Apagar Registro do Usuário    |");
                Console.WriteLine("| 4 Listar Todos Os Usuários      |");
                Console.WriteLine("| 5 Sair                          |");
                Console.WriteLine("|---------------------------------|");
                Console.WriteLine();
                Console.WriteLine("Digite uma opção:");
                Console.ResetColor();
                string n = Console.ReadLine();
                
                Console.Clear();

                switch (n)
                {
                    case "1":
                        
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine($"Usuário:  {dado}");
                        Console.WriteLine();
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("Insira um novo registro");
                        Console.WriteLine();
                        Console.WriteLine("Digite o nome:");
                        Console.ResetColor();
                        objUsuario.NomeUsu = Console.ReadLine();

                        Console.ForegroundColor = ConsoleColor.DarkGreen;

                        Console.WriteLine("Digite o cargo:");
                        Console.ResetColor();
                        objUsuario.Cargo = Console.ReadLine();

                        Console.ForegroundColor = ConsoleColor.DarkGreen;

                        Console.WriteLine("Digite a data de nascimento:");
                        Console.ResetColor();
                        objUsuario.DataNasc = DateTime.Parse(Console.ReadLine());
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.DarkGreen;

                        objDao.Insert(objUsuario);

                        Console.WriteLine("Usuários Cadastrados:");
                        Console.WriteLine();
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        ListUsuario = objDao.SelectList();
                        foreach (var item in ListUsuario)
                        {
                            Console.WriteLine("Código = {0} | Nome = {1} | Cargo = {2} | Data de Nascimento = {3}",
                                item.IdUsu, item.NomeUsu, item.Cargo, item.DataNasc);
                        }
                        Console.WriteLine();

                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("Pressione qualquer tecla para retornar ao menu");
                        Console.ReadKey();
                        Console.Clear();
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine($"Usuario: {dado}");
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        return true;
                        

                    case "2":
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine($"Usuario: {dado}");
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("Usuários Cadastrados:");
                        Console.WriteLine();
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        ListUsuario = objDao.SelectList();
                        foreach (var item in ListUsuario)
                        {
                            Console.WriteLine("Código = {0} | Nome = {1} | Cargo = {2} | Data de Nascimento = {3}",
                                item.IdUsu, item.NomeUsu, item.Cargo, item.DataNasc);
                        }
                        Console.WriteLine();
                        Console.ResetColor();
                        

                        Console.ForegroundColor = ConsoleColor.Magenta;
                        

                        Console.ResetColor();
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("Atualize o registro");

                        Console.WriteLine();

                        Console.WriteLine("Digite o nome");
                        Console.ResetColor();
                        objUsuario.NomeUsu = Console.ReadLine();
                        Console.ForegroundColor = ConsoleColor.DarkGreen;

                        Console.WriteLine("Digite o  cargo:"); 
                        Console.ResetColor();

                        objUsuario.Cargo = Console.ReadLine();

                        Console.ForegroundColor = ConsoleColor.DarkGreen;


                        Console.WriteLine("Digite a data de nascimento:");
                        Console.ResetColor();

                        objUsuario.DataNasc = DateTime.Parse(Console.ReadLine());
                        Console.ForegroundColor = ConsoleColor.DarkGreen;


                        Console.WriteLine("Informe o id deve ser atualizado  ");
                        Console.ResetColor();

                        objUsuario.IdUsu = int.Parse(Console.ReadLine());
                        objDao.Update(objUsuario);
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("Usuários Cadastrados:");
                        Console.WriteLine();
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        ListUsuario = objDao.SelectList();
                        foreach (var item in ListUsuario)
                        {
                            Console.WriteLine("Código = {0} | Nome = {1} | Cargo = {2} | Data de Nascimento = {3}",
                                item.IdUsu, item.NomeUsu, item.Cargo, item.DataNasc);
                        }

                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("Pressione qualquer tecla para retornar ao menu");
                        Console.ReadKey();
                        Console.Clear();
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine($"Usuario: {dado}");
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.DarkGreen; ;


                        return true;




                    case "3":

                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine($"Usuario:{dado}");
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("Usuários Cadastrados:");
                        Console.WriteLine();
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        ListUsuario = objDao.SelectList();
                        foreach (var item in ListUsuario)
                        {
                            Console.WriteLine("Código = {0} | Nome = {1} | Cargo = {2} | Data de Nascimento = {3}",
                                item.IdUsu, item.NomeUsu, item.Cargo, item.DataNasc);
                        }
                        Console.WriteLine();
                        Console.ResetColor();

                        Console.ForegroundColor = ConsoleColor.DarkGreen;

                        Console.WriteLine("Apagando um registro");
                        Console.WriteLine();
                        Console.WriteLine("Informe o código do usuário a ser apagado: ");
                        Console.ResetColor();
                        int Id = int.Parse(Console.ReadLine());
                        objDao.Delete(Id);
                        Console.WriteLine();

                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("Usuários Cadastrados:");
                        Console.WriteLine();
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        ListUsuario = objDao.SelectList();
                        foreach (var item in ListUsuario)
                        {
                            Console.WriteLine("Código = {0} | Nome = {1} | Cargo = {2} | Data de Nascimento = {3}",
                                item.IdUsu, item.NomeUsu, item.Cargo, item.DataNasc);
                        }
                        Console.WriteLine();
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("Pressione qualquer tecla para retornar ao menu");
                        Console.ReadKey();
                        Console.Clear();
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine($"Usuario: {dado}");
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.DarkGreen;


                        return true;

                    case "4":

                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine($"Usuario: {dado}");
                        Console.WriteLine();
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("Usuários Cadastrados:");
                        Console.WriteLine();
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        ListUsuario = objDao.SelectList();
                        foreach (var item in ListUsuario)
                        {
                            Console.WriteLine("Código = {0} | Nome = {1} | Cargo = {2} | Data de Nascimento = {3}",
                                item.IdUsu, item.NomeUsu, item.Cargo, item.DataNasc);
                        }
                        Console.WriteLine();
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("Pressione qualquer tecla para retornar ao menu");
                        Console.ReadKey();
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine($"Usuario: {dado}");
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.DarkGreen;


                        return true;

                    case "5":

                        Environment.Exit(0);

                        return true;


                    default:
                        Console.Clear();
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine($"Usuario: {dado}");
                        Console.ResetColor();
                        Console.ForegroundColor= ConsoleColor.DarkRed;
                        Console.WriteLine("Digite 1, 2, 3, 4 ou 5 ");
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.DarkGreen;

                        return true;
                }
            }
            Console.ReadLine();
        }
    }
}









