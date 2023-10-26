using System;

class Program
{
    static char[,] board = new char[8, 8]; 
    static bool isWhiteTurn = true; 
    static string currentPlayer = "Rojo"; 

    static void Main()
    {
        InitializeBoard();
        PrintBoard();

        while (true)
        {
            Console.WriteLine($"{currentPlayer}, es tu turno.");
            Console.WriteLine("Ingrese la coordenada de cual pieza quieres que se mueva:");
            string source = Console.ReadLine();
            Console.WriteLine("Ingrese la coordenada de a donde quieres que se mueva la pieza:");
            string destination = Console.ReadLine();

            if (IsValidMove(source, destination))
            {
                MovePiece(source, destination);
                isWhiteTurn = !isWhiteTurn;
                currentPlayer = isWhiteTurn ? "Rojo" : "Azul";
                PrintBoard();
            }
            else
            {
                Console.WriteLine("El movimiento es incorrecto");
            }
        }
    }

    static void InitializeBoard()
    {
        for (int i = 0; i < 8; i++)
        {
            board[1, i] = 'P'; 
            board[6, i] = 'p'; 
        }
    }

    static bool IsValidMove(string source, string destination)
    {
        int sourceX = source[0] - 'a';
        int sourceY = 8 - (source[1] - '0');
        int destX = destination[0] - 'a';
        int destY = 8 - (destination[1] - '0');
        char piece = board[sourceY, sourceX];

        if (piece == '\0')
        {
            return false; 
        }

        if (isWhiteTurn)
        {
            if (destY == sourceY - 1 && destX == sourceX && board[destY, destX] == '\0')
            {
                return true;
            }
            else if (sourceY == 6 && destY == sourceY - 2 && destX == sourceX && board[destY, destX] == '\0' && board[sourceY - 1, destX] == '\0')
            {
                return true;
            }
            else if (destY == sourceY - 1 && Math.Abs(destX - sourceX) == 1 && board[destY, destX] != '\0' && char.IsUpper(board[destY, destX]))
            {
                return true; 
            }
        }
        else
        {
            if (destY == sourceY + 1 && destX == sourceX && board[destY, destX] == '\0')
            {
                return true;
            }
            else if (sourceY == 1 && destY == sourceY + 2 && destX == sourceX && board[destY, destX] == '\0' && board[sourceY + 1, destX] == '\0')
            {
                return true;
            }
            else if (destY == sourceY + 1 && Math.Abs(destX - sourceX) == 1 && board[destY, destX] != '\0' && char.IsLower(board[destY, destX]))
            {
                return true; 
            }
        }

        return false; 
    }


    static void MovePiece(string source, string destination)
    {
        int sourceX = source[0] - 'a';
        int sourceY = 8 - (source[1] - '0');
        int destX = destination[0] - 'a';
        int destY = 8 - (destination[1] - '0');

        board[destY, destX] = board[sourceY, sourceX];
        board[sourceY, sourceX] = '\0';
    }

    static void PrintBoard()
    {
        Console.Clear();
        Console.WriteLine("  a b c d e f g h");

        for (int i = 0; i < 8; i++)
        {
            Console.Write(8 - i);
            Console.Write(" ");

            for (int j = 0; j < 8; j++)
            {
                char piece = board[i, j];

                if (piece == '\0')
                {
                    Console.Write("- ");
                }
                else
                {
                    ConsoleColor pieceColor = (char.IsUpper(piece)) ? ConsoleColor.Blue : ConsoleColor.Red;
                    Console.ForegroundColor = pieceColor;
                    Console.Write(piece + " ");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }

            Console.WriteLine(8 - i);
        }

        Console.WriteLine("  a b c d e f g h");
    }
}
