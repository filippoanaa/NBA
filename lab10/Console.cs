using lab10.domain;
using lab10.repository;
using lab10.service;

namespace lab10;

public class ConsoleUI
{
    private PlayerService playerService;
    private TeamService teamService;
    private ActivePlayerService activePlayerService;
    private GameService gameService;

    public ConsoleUI()
    {
        string teamsFile = "teams.txt";
        IRepository<int, Team> teamRepo = new TeamRepository(teamsFile);
        this.teamService = new TeamService(teamRepo);
        
        string playersFile = "players.txt";
        IRepository<int, Player> playerRepo = new PlayerRepo(playersFile);
        this.playerService = new PlayerService(playerRepo);

        string activePlayersFile = "activePlayers.txt";
        IRepository<Tuple<int, int>, ActivePlayer> activePlayerRepo = new ActivePlayerRepo(activePlayersFile);
        this.activePlayerService = new ActivePlayerService(activePlayerRepo, playerRepo);
        
        string gamesFile = "games.txt";
        IRepository<int, Game> gameRepo = new GameRepo(gamesFile);
        this.gameService = new GameService(gameRepo);

    
    }
    
    private void PrintMenu()
    {
        
        Console.WriteLine("\n************");
        Console.WriteLine("Menu");
        Console.WriteLine("0.Exit");
        Console.WriteLine("1. Display players from a team.");
        Console.WriteLine("2. Display active players.");
        Console.WriteLine("3. Display games from a period.");
        Console.WriteLine("4. Display score from a game.");

    }

    private void DisplayPlayersOfATeam()
    {
        Console.WriteLine("Enter the name of the team you want to display.");
        string teamName = Console.ReadLine();
        try
        {
            Team team = teamService.GetTeamByName(teamName);
            
            List<Player> players = playerService.GetPlayersByTeam(team).ToList();
            
            players.ForEach(player => Console.WriteLine(player));
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        
    }

    private void displayActivePlayers()
    {
        Console.WriteLine("Enter a game(team1,team2).");
        string game = Console.ReadLine();
        Console.WriteLine("Enter the name of the team.");
        string teamName = Console.ReadLine();
        
        string[] teams = game.Split(',');

        try
        {
            Game gameFound = gameService.GetGameByTeamNames(teams[0], teams[1]);
            Team fromTeam = teamService.GetTeamByName(teamName);

            List<ActivePlayer> activePlayers =
                activePlayerService.GetActivePlayersByGameAndTeam(gameFound, fromTeam).ToList();
            activePlayers.ForEach(player => Console.WriteLine(player));
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
  
        
        
    }

    void DisplayGamesFromAPeriod()
    {
        Console.WriteLine("Enter first date: ");
        string first = Console.ReadLine();
        Console.WriteLine("Enter second date: ");
        string second = Console.ReadLine();
        
        bool parse1 = DateTime.TryParse(first, out DateTime firstDate);
        bool parse2 = DateTime.TryParse(second, out DateTime secondDate);

        if (!parse1 || !parse2)
        {
            Console.WriteLine("Invalid date. try mm/dd/yyyy.");
            return;
        }
        
        if(firstDate.CompareTo(secondDate) >0)
        {
            Console.WriteLine("First date cannot be greater than second date.");
            return;
        }
        
        List<Game> games = gameService.GetAllFromPeriod(firstDate, secondDate).ToList();
        games.ForEach(game => Console.WriteLine(game));
        
        
    }


    void DisplayScoreFromGame()
    {
        Console.WriteLine("Enter a game(team1,team2).");
        string input = Console.ReadLine();
        
        string[] teams = input.Split(',');

        try
        {
            Game game = gameService.GetGameByTeamNames(teams[0], teams[1]);
            Tuple<int, int> score = activePlayerService.GetScoreFromAGame(game);

            Console.WriteLine(score.Item1 + " - " + score.Item2);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    public void Run()
    {
        while (true)
        {
            PrintMenu();
            Console.WriteLine("Your option: ");
            string input = Console.ReadLine();
            if (input == "0")
            {
                Console.WriteLine("Goodbye!");
                break;
            }
            else if (input == "1")
            {
                DisplayPlayersOfATeam();
                continue;
            }
            else if (input == "2")
            {
                displayActivePlayers();
                continue;
            }
            else if (input == "3")
            {
                DisplayGamesFromAPeriod();
                continue;
            }
            else if (input == "4")
            {
                DisplayScoreFromGame();
                continue;
            }
            else
            {
                Console.WriteLine("Please enter a valid option.");
                continue;
            }
            
        }
    }
    
    
}