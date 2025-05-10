using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceInvaders
{
    public class MoveRightCommand : ICommand
    {
        PlayerMove playerMove;

        public MoveRightCommand(PlayerMove playerMove)
        {
            this.playerMove = playerMove;
        }
        public void Execute()
        {

            playerMove.MoveRight();
        }
    }
}