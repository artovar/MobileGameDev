using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chess.Game
{
    public class Move : MonoBehaviour
    {
        Coord origin;

        Coord target;

        public Move(Coord origin, Coord target)
        {
            this.origin = origin;
            this.target = target;
        }
    }
}