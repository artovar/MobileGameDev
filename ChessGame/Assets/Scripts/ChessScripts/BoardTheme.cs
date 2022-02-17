using UnityEngine;

namespace Chess.Game
{
    using UnityEngine;

    [CreateAssetMenu(menuName = "ChessGame/BoardTheme")]
    public class BoardTheme : ScriptableObject
    {
        public SquareColours lightSquares;
        public SquareColours darkSquares;

        [System.Serializable]
        public struct SquareColours
        {
            public Color normal;
            public Color legal;

            public Color selected;

            public Color moveFromHighlight;
            public Color moveToHighlight;
        }
    }
}