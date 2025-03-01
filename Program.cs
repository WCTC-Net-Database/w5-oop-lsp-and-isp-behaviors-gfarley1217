using Microsoft.Extensions.DependencyInjection;
using W5_assignment_template.Interfaces;
using W5_assignment_template.Models;
using W5_assignment_template.Services;
using W5_assignment_template.Commands;

namespace W5_assignment_template
{
    class Program
    {
        static void Main(string[] args)
        {
            var character = new Character();
            var goblin = new Goblin();
            var ghost = new Ghost();

            var gameEngine = new GameEngine(character, goblin, ghost);

            gameEngine.AddCommand(new MoveCommand(character));
            gameEngine.AddCommand(new AttackCommand(character, goblin));

            gameEngine.AddCommand(new MoveCommand(goblin));
            gameEngine.AddCommand(new AttackCommand(goblin, character));

            gameEngine.AddCommand(new MoveCommand(ghost));
            gameEngine.AddCommand(new AttackCommand(ghost, character));
            gameEngine.AddCommand(new FlyCommand(ghost));

            gameEngine.ExecuteCommands();
        }
    }
}

public class Character : IEntity
{
    public string Name { get; set; }

    public void Attack(IEntity target)
    {
        Console.WriteLine($"{Name} attacks {target.Name}");
    }

    public void Move()
    {
        Console.WriteLine($"{Name} moves");
    }
}

public class Goblin : IEntity
{
    public string Name { get; set; }

    public void Attack(IEntity target)
    {
        Console.WriteLine($"{Name} attacks {target.Name}");
    }

    public void Move()
    {
        Console.WriteLine($"{Name} moves");
    }
}

public class Ghost : IEntity, IFlyable
{
    public string Name { get; set; }

    public void Attack(IEntity target)
    {
        Console.WriteLine($"{Name} attacks {target.Name}");
    }

    public void Move()
    {
        Console.WriteLine($"{Name} moves");
    }

    public void Fly()
    {
        Console.WriteLine($"{Name} flies");
    }
}

// Implemented commands in Program.cs using the Execute method from ICommand interface
// Copilot did help me implement some of the add ons to the code
// Made sure based on discussion in class to try to fully understand all aspects of AI's code