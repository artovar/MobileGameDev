using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime;

namespace Chess.Game
{
    public class GraphBoard : MonoBehaviour
    {

        public bool whiteIsBottom;

        public BoardTheme boardTheme;
        MeshRenderer[,] squareRenderers;
        SpriteRenderer[,] squarePieceRenderers;


        void Start()
        {
            CreateBoard();
        }


        public void CreateBoard()
        {

            squareRenderers = new MeshRenderer[8, 8];
            squarePieceRenderers = new SpriteRenderer[8, 8];
            Shader squareShader = Shader.Find("Unlit/Color");

            for (int column = 0; column < 8; column++)
            {
                for (int row = 0; row < 8; row++)
                {

                    //Create a square
                    Transform square = GameObject.CreatePrimitive(PrimitiveType.Quad).transform;
                    square.parent = transform;

                    //Asign name, position and color´
                    square.name = SetSquareName(column, row);
                    square.position = SetSquarePosition(column, row);
                    Material squareMaterial = new Material(squareShader);

                    squareRenderers[column, row] = square.GetComponent<MeshRenderer>();
                    squareRenderers[column, row].material = squareMaterial;


                    //Set pieces on Board





                }
            }

            ResetSquareColors();

        }

        private void ResetSquareColors(bool highlight = true)
        {
            transform.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            for (int column = 0; column < 8; column++)
            {
                for (int row = 0; row < 8; row++)
                {

                    SetSquareColor(new Coord(column, row), boardTheme.lightSquares.normal, boardTheme.darkSquares.normal);

                }
            }
        }

        void SetSquareColor(Coord square, Color lightColor, Color darkColor)
        {
            squareRenderers[square.columnIndex, square.rowIndex].material.color = (square.IsLightSquare()) ? lightColor : darkColor;
        }

        private Vector3 SetSquarePosition(int column, int row)
        {
            if (whiteIsBottom)
            {
                return new Vector3(-3.5f + row, -3.5f + column, 0);
            }
            else
            {
                return new Vector3(-3.5f + 7 - row, -3.5f + 7 - column, 0);
            }
        }


        private string SetSquareName(int column, int row)
        {

            return "(" + (column + 1) + ", " + RowLetter(row + 1) + ")";


        }


        private string RowLetter(int row)
        {
            switch (row)
            {
                case 1:
                    return "a";
                case 2:
                    return "b";
                case 3:
                    return "c";
                case 4:
                    return "d";
                case 5:
                    return "e";
                case 6:
                    return "f";
                case 7:
                    return "g";
                case 8:
                    return "h";
                default:
                    return "error";

            }

        }


    }
}