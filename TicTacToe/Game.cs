﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class Game
    {
        private readonly IGameConsole console;
        private readonly Board board;
        private char currentPlayerMark = 'X';
        private HumanPlayer humanPlayer;
        private IPlayer computerPlayer;
        private IPlayer computerPlayer2;
        private IPlayer computerPlayer1;

        private IPlayer currentPlayer;
        private IPlayer otherPlayer;

        public Game(IGameConsole console)
        {
            this.console = console;
            board = new Board();
        }

        public Game(Board board, IGameConsole console)
        {
            this.board = board;
            this.console = console;
        }

        public Game(Board board, IGameConsole console, HumanPlayer human, ComputerPlayer computer) : this(board, console)
        {
            currentPlayer = human;
            otherPlayer = computer;

            computerPlayer = computer;
            humanPlayer = human;
        }

        public Game(Board board, IGameConsole console, ComputerPlayer computer1, ComputerPlayer computer2) : this(board, console)
        {
            currentPlayer = computer1;
            otherPlayer = computer2;

            computerPlayer1 = computer1;
            computerPlayer2 = computer2;
        }

        public void Start()
        {
            PlayGame();
            DisplayResult();
        }

        public void AskForInputPosition()
        {
            console.AskForInputPosition();
        }

        public void DisplayResult()
        {
            if (board.IsGameWon())
                console.DisplayGameWonResult(board.GetWinner());
            else
                console.DisplayGameDrawnResult();
        }

        public void PlayMove(int position)
        {
            try
            {
                board.MakeMove(position, currentPlayerMark);
                ToggleCurrentPlayerMark();
                SwitchCurrentPlayer();
            }
            catch (Exception ex) when (ex is ArgumentException || ex is IndexOutOfRangeException)
            {
            }
        }

        private void SwitchCurrentPlayer()
        {
            var tempPlayer = currentPlayer;
            currentPlayer = otherPlayer;
            otherPlayer = tempPlayer;
        }

        public string PositionAt(int position)
        {
            return board.PositionAt(position);
        }

        public int TakePlayerMove()
        {
            if (currentPlayer == null)
            {
                return console.TakePlayerMove() - 1;
            }
            if (currentPlayer == computerPlayer)
            {
                return currentPlayer.GetMove(board);
            }
            return console.TakePlayerMove() - 1;
        }

        private void ToggleCurrentPlayerMark()
        {
            currentPlayerMark = currentPlayerMark == 'X' ? 'O' : 'X';
        }

        private void PlayTurn()
        {
            DisplayBoard();
            AskForInputPosition();
            PlayMove(TakePlayerMove());
        }

        private void DisplayBoard()
        {
            console.DisplayBoard(board);
        }

        private void PlayGame()
        {
            while (IsGameNotOver())
                PlayTurn();
        }

        private bool IsGameNotOver()
        {
            return !board.IsGameOver();
        }

        public object CurrentPlayer()
        {
            return currentPlayer;
        }
    }
}