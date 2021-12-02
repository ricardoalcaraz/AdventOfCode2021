using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Utilities;

namespace TestCases.Solutions;

public class Day2
{
    [Test]
    public void MoveForward_ShouldMove5()
    {
        var rawMovement = new string[]
        {
            "forward 5",
            "down 5",
            "forward 8",
            "up 3",
            "down 8",
            "forward 2"
        };
        var movements = rawMovement.ConvertToMovement().ToArray();
        var sub = new Submarine();
        
        sub.Move(movements[0]);
        Assert.AreEqual(5, sub.Horizontal);
        
        sub.Move(movements[1]);
        Assert.AreEqual(5, sub.Vertical);
        Assert.AreEqual(5, sub.Horizontal);
        
        sub.Move(movements[2]);
        Assert.AreEqual(13, sub.Horizontal);
        Assert.AreEqual(5, sub.Vertical);
        
        sub.Move(movements[3]);
        Assert.AreEqual(13, sub.Horizontal);
        Assert.AreEqual(2, sub.Vertical);

        sub.Move(movements[4]);
        Assert.AreEqual(13, sub.Horizontal);
        Assert.AreEqual(10, sub.Vertical);
        
        sub.Move(movements[5]);
        Assert.AreEqual(15, sub.Horizontal);
        Assert.AreEqual(10, sub.Vertical);
        
        Assert.AreEqual(150, sub.Vertical * sub.Horizontal);
    }

    [Test]
    public void GetFinalAnswer()
    {
        var directions = File.ReadAllLines("Inputs/Day2.txt").ConvertToMovement();

        var sub = new Submarine();
        foreach (var direction in directions)
        {
            sub.Move(direction);
        }
        
        Assert.Pass("Final position is {0}", sub.Depth);
    }

    [Test]
    public void SubmarineWithAim_Example()
    {
        var rawMovement = new string[]
        {
            "forward 5",
            "down 5",
            "forward 8",
            "up 3",
            "down 8",
            "forward 2"
        };

        var movements = rawMovement.ConvertToMovement().ToArray();
        var sub = new SubmarineWithAim();
        
        sub.Move(movements[0]);
        Assert.AreEqual(5, sub.Horizontal);
        Assert.AreEqual(0, sub.Depth);
        Assert.AreEqual(0, sub.Vertical);
        
        sub.Move(movements[1]);
        Assert.AreEqual(5, sub.Vertical);
        Assert.AreEqual(5, sub.Horizontal);
        Assert.AreEqual(0, sub.Depth);

        sub.Move(movements[2]);
        Assert.AreEqual(13, sub.Horizontal);
        Assert.AreEqual(5, sub.Vertical);
        Assert.AreEqual(40, sub.Depth);

        sub.Move(movements[3]);
        Assert.AreEqual(13, sub.Horizontal);
        Assert.AreEqual(2, sub.Vertical);
        Assert.AreEqual(40, sub.Depth);

        sub.Move(movements[4]);
        Assert.AreEqual(13, sub.Horizontal);
        Assert.AreEqual(10, sub.Vertical);
        Assert.AreEqual(40, sub.Depth);

        sub.Move(movements[5]);
        Assert.AreEqual(15, sub.Horizontal);
        Assert.AreEqual(10, sub.Vertical);
        Assert.AreEqual(60, sub.Depth);
        
        Assert.AreEqual(900, sub.Horizontal * sub.Depth);
    }
    
    [Test]
    public void GetFinalAnswer_Part2()
    {
        var directions = File.ReadAllLines("Inputs/Day2.txt").ConvertToMovement();

        var sub = new SubmarineWithAim();
        foreach (var direction in directions)
        {
            sub.Move(direction);
        }
        
        Assert.Pass("Final position is {0}", sub.Depth * sub.Horizontal);
    }
}

public class SubmarineWithAim : Submarine
{
    private int _depth = 0;
    
    public override void MoveForward(int units)
    {
        _depth += units * Vertical;

        base.MoveForward(units);
    }

    public override void MoveDown(int units)
    {
        base.MoveDown(units);
    }

    public override void MoveUp(int units)
    {
        base.MoveUp(units);
    }

    public override int Depth => _depth;
}

public class Submarine
{
    public int Horizontal { get; private set; }
    public int Vertical { get; private set; }
    public virtual int Depth => Horizontal * Vertical;

    public void Move(Movement movement)
    {
        switch (movement.Direction)
        {
            case Direction.Forward:
                MoveForward(movement.Units);
                break;
            case Direction.Down:
                MoveDown(movement.Units);
                break;
            case Direction.Up:
                MoveUp(movement.Units);
                break;
            case Direction.Invalid:
            default:
                throw new InvalidOperationException();
        }
    }
    
    public virtual void MoveForward(int units) => Horizontal += units;
    public virtual void MoveDown(int units) => Vertical += units;
    public virtual void MoveUp(int units) => Vertical = Math.Max(Vertical - units, 0);
}