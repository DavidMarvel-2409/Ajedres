using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Ajedres
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D _texture;
        private Texture2D _tex_peon;

        private Table tb;
        private Peon PP;

        private Color cP1, cP2;

        private string[][] tab = new string[8][];
        private int[][] tabP = new int[8][];

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            Window.Title = "AjejeDress";
        }

        protected override void Initialize()
        {
            redim(1080);
            Vector2 or = new Vector2((GraphicsDevice.Viewport.Width / 2) - (GraphicsDevice.Viewport.Height * 0.8f / 2), (GraphicsDevice.Viewport.Height / 2) - (GraphicsDevice.Viewport.Height * 0.8f / 2));
            Vector2 dim = new Vector2(GraphicsDevice.Viewport.Height * 0.8f, GraphicsDevice.Viewport.Height * 0.8f);

            tb = new Table(or, dim, new Color[] { new Color(204f / 255f, 204f / 255f, 204f / 255f), new Color(42f / 255f, 42f / 255f, 42f / 255f) });

            for (int y = 0; y < 8; y++)
            {
                tab[y] = new string[8];
                tabP[y] = new int[8];
                for (int x = 0; x < 8; x++)
                {
                    tab[y][x] = ""+y;
                    tabP[y][x] = 0;
                }
            }

            for (int i = 0; i < 8; i++)
            {
                Console.Write("     ");
                for (int j = 0; j < 8; j++)
                {
                    Console.Write(" " + tab[j][i] + " " + tabP[j][i]);
                }
                Console.Write("\n");
            }

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _texture = new Texture2D(GraphicsDevice, 1, 1);
            _texture.SetData(new[] { Color.White });
            _tex_peon = Content.Load<Texture2D>("peon");

            cP1 = new Color(194f / 255f, 212f / 255f, 183f / 255f);

            PP = new Peon(new Vector2((GraphicsDevice.Viewport.Width / 2), (GraphicsDevice.Viewport.Height / 2)), new Vector2(((GraphicsDevice.Viewport.Height * 0.8f) / 8) * 0.9f, (GraphicsDevice.Viewport.Height * 0.8f) / 8) * 0.9f, _tex_peon, cP1, true);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();
            tb.dr(_texture, _spriteBatch);

            PP.dr(_spriteBatch);
            _spriteBatch.End();

            base.Draw(gameTime);
        }

        private void redim(int H)
        {
            int W = (H * 16) / 9;
            _graphics.PreferredBackBufferHeight = H;
            _graphics.PreferredBackBufferWidth = W;
            _graphics.ApplyChanges();
        }

        public class Table
        {
            private Rectangle Box, Little_box;
            private Vector2 Origen;
            private Color ColorA, ColorB;

            public Table(Vector2 origen,Vector2 dim, Color[] Colors)
            {
                Origen = origen;
                Box = new Rectangle((int)Origen.X, (int)Origen.Y, (int)dim.X, (int)dim.Y);
                ColorA = Colors[0];
                ColorB = Colors[1];
                Little_box = new Rectangle((int)Origen.X, (int)Origen.Y, (int)dim.X / 8, (int)dim.Y / 8);

            }

            public void dr(Texture2D _tx, SpriteBatch _sb)
            {
                _sb.Draw(_tx, Box, ColorA);
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        Little_box.X = (int)(Origen.X + (Little_box.Width * i));
                        Little_box.Y = (int)(Origen.Y + (Little_box.Height * j));
                        if (i % 2 == 0 && j % 2 != 0)
                        {
                            _sb.Draw(_tx, Little_box, ColorB);
                        }
                        else if (i % 2 != 0 && j % 2 == 0)
                        {
                            _sb.Draw(_tx, Little_box, ColorB);
                        }

                    }
                }
            }

        }//EndTable

        public class Piece
        {
            private Rectangle Box;
            private Vector2 Origen;
            private Texture2D _tex;
            private Color color;
            private bool is_active = false;
            private List<Vector2> mov_op;

            public Vector2 Pos;
            public char type;

            public Piece(Vector2 OR, Vector2 DIM, Texture2D te, Color co)
            {
                Box = new Rectangle((int)(OR.X + (DIM.X / 8)), (int)(OR.Y + (DIM.Y / 8)), (int)DIM.X, (int)DIM.Y);
                Origen = OR;
                _tex = te;
                color = co;
                mov_op = new List<Vector2>();
            }


            public void dr(SpriteBatch _sb)
            {
                _sb.Draw(_tex, Box, color);
            }

        }//EndPiece

        public class Peon : Piece
        {
            private bool up, first;
            public Peon(Vector2 os, Vector2 dim, Texture2D tx, Color cl, bool _up) : base(os, dim, tx, cl)
            {
                first = true;
                up = _up;
                type = 'p';
            }

            public void update()
            {

            }

        }//EndPeon
        public class Torre : Piece
        {
            public Torre(Vector2 os, Vector2 dim, Texture2D tx, Color cl) : base(os, dim, tx, cl)
            {
                type = 't';
            }
        }//EndTorre
        public class Caballo : Piece
        {
            public Caballo(Vector2 os, Vector2 dim, Texture2D tx, Color cl) : base(os, dim, tx, cl)
            {
                type = 'c';
            }
        }//EndCaballo
        public class Arfil : Piece
        {
            public Arfil(Vector2 os, Vector2 dim, Texture2D tx, Color cl) : base(os, dim, tx, cl)
            {
                type = 'a';
            }
        }//EndArfil
        public class Rey : Piece
        {
            public Rey(Vector2 os, Vector2 dim, Texture2D tx, Color cl) : base(os, dim, tx, cl)
            {
                type = 'k';
            }
        }//EndRey
        public class Reina : Piece
        {
            public Reina(Vector2 os, Vector2 dim, Texture2D tx, Color cl) : base(os, dim, tx, cl)
            {
                type = 'q';
            }
        }//EndReina

    }
}
