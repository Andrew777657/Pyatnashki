using NUnit.Framework;

namespace Pyatnaski;

public class Tests
{
    private PyatnaskiMain pyatnaski;

    [SetUp]
    public void Setup()
    {
        pyatnaski = new PyatnaskiMain();
    }

    [Test]
    public void Test_Win()
    {
        pyatnaski.FillGameField();
        if (pyatnaski.CheckWin())
        {
            Assert.Pass();
        }
        else
        {
            Assert.Fail();
        }
    }

    [Test]
    public void Test_HasEmptyCell()
    {
        pyatnaski.FillGameField();
        pyatnaski.ShuffleField();
        foreach (var cell in pyatnaski.gameField)
        {
            if (cell == "")
            {
                Assert.Pass();
            }
        }

        Assert.Fail();
    }

    [Test]
    public void Test_FindIndex()
    {
        pyatnaski.gameField = new[]
        {
            "1", "2", "3", "4",
            "5", "6", "", "7",
            "8", "9", "10", "11",
            "12", "13", "14", "15"
        };
        pyatnaski.FindIndex();
        if (pyatnaski.index == 6)
        {
            Assert.Pass();
        }
        else
        {
            Assert.Fail();
        }
    }

    [Test]
    public void Test_TurnLeftArrow()
    {
        checkTurn(ConsoleKey.LeftArrow, new[]
        {
            "1", "2", "3", "4",
            "5", "", "6", "7",
            "8", "9", "10", "11",
            "12", "13", "14", "15"
        });
    }

    [Test]
    public void Test_TurnRightArrow()
    {
        checkTurn(ConsoleKey.RightArrow, new[]
        {
            "1", "2", "3", "4",
            "5", "6", "7", "",
            "8", "9", "10", "11",
            "12", "13", "14", "15"
        });
    }

    [Test]
    public void Test_TurnDownArrow()
    {
        checkTurn(ConsoleKey.DownArrow, new[]
        {
            "1", "2", "3", "4",
            "5", "6", "10", "7",
            "8", "9", "", "11",
            "12", "13", "14", "15"
        });
    }

    [Test]
    public void Test_TurnUpArrow()
    {
        checkTurn(ConsoleKey.UpArrow, new[]
        {
            "1", "2", "", "4",
            "5", "6", "3", "7",
            "8", "9", "10", "11",
            "12", "13", "14", "15"
        });
    }

    private void checkTurn(ConsoleKey key, string[] newArray)
    {
        pyatnaski.gameField = new[]
        {
            "1", "2", "3", "4",
            "5", "6", "", "7",
            "8", "9", "10", "11",
            "12", "13", "14", "15"
        };

        pyatnaski.Turn(false, key);

        if (checkArrays(pyatnaski.gameField, newArray))
        {
            Assert.Pass();
        }
        else
        {
            Assert.Fail();
        }
    }

    private bool checkArrays(string[] gameField, string[] newArray)
    {
        if (gameField.Length != newArray.Length) return false;
        int counter = 0;
        for (var i = 0; i < gameField.Length; i++)
        {
            if (gameField[i] == newArray[i]) counter++;
        }

        return counter == gameField.Length;
    }
}