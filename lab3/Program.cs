using lab3.DB;
using lab3.DB.Repository;
using lab3.DB.Repository.Base;
using lab3.DB.Services;
using lab3.DB.Services.Base;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
namespace lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            DbContext context= new DbContext();
            
            IAccountService accountService = new AccountService(context);
            IGameService gameService = new GameService(context);
            gameService.ReadPlayerGamesByPlayerId(2);//looking for a player id in games played
            gameService.ReadPlayerGamesByPlayerId(8);//player id was not found in db Games
            
            gameService.CreateGame(1, 2, "Standart",100.0);
            gameService.CreateGame(1, 3, "Training", 11.0);
            gameService.CreateGame(2, 2, "Standart", 100.0);// same player game 
            gameService.CreateGame(1, 3, "sfdsdf", 11.0);// invalid gametype

            accountService.ReadAccountById(1);
            Console.WriteLine();
            accountService.ReadAccountById(8);//no account with id 8
            Console.WriteLine();
            accountService.ReadAccounts();
            Console.WriteLine();

            gameService.ReadGames();
            accountService.CreateAccount();
            accountService.ReadAccounts();
           

        }

    }
}