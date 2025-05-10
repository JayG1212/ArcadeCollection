using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceInvaders
{
    public class MoveLeftCommand : ICommand
    {
        PlayerMove playerMove;

        public MoveLeftCommand(PlayerMove playerMove)
        {
            this.playerMove = playerMove;
        }
        public void Execute()
        {
            playerMove.MoveLeft();
        }
    }
}