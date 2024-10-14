﻿using System;
using System.Collections.Generic;

namespace MSO2
{
    public class Board
    {
        private int[,] board { get; set; } // 2D array of the board (grid)
        public static int boardHeight { get; private set; } // Height of the board.
        public static int boardWidth { get; private set; } // Width of the board.

        private Player player; 

        private static Board _instance; // Singleton instance of the Board.

        // Gets the singleton instance of the Board. Makes sure only one board can be active
        public static Board GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Board();
            }
            return _instance;
        }

        // Constructor to initialize board dimensions and player.
        private Board()
        {
            boardWidth = 100; // Set initial width.
            boardHeight = 100; // Set initial height.
            board = new int[boardHeight, boardWidth]; // Initialize the board.
            player = new Player(); // Create a player instance.
        }

        // Executes a list of commands on the player. And print endstate
        internal void PlayBoard(List<ICommand> commands)
        {
            foreach (ICommand command in commands)
            {
                command.Execute(player);
            }

            player.PrintEndState(); // Print the player's final state.
        }

        // Constrains a position within the board bounds.
        public static (int, int) BoardBounds((int, int) position)
        {
            (int, int) upperBounds = (Math.Min(position.Item1, boardWidth), Math.Min(position.Item2, boardHeight));
            (int, int) lowerBounds = (Math.Max(upperBounds.Item1, 0), Math.Max(upperBounds.Item2, 0));
            return lowerBounds; // Returns the constrained position.
        }
    }
}
