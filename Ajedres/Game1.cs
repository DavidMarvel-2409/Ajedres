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
        private Texture2D _tex_torre;
        private Texture2D _tex_caballo;
        private Texture2D _tex_arfil;

        private Table tb;
        private Peon PP;

        private List<Piece> ps;

        private Color cP1, cP2;

        private Player p1, p2;

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



            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _texture = new Texture2D(GraphicsDevice, 1, 1);
            _texture.SetData(new[] { Color.White });
            _tex_peon = Content.Load<Texture2D>("peon");
            _tex_torre = Content.Load<Texture2D>("torre");
            _tex_caballo = Content.Load<Texture2D>("Caballo");
            _tex_arfil = Content.Load<Texture2D>("arfil");

            cP1 = new Color(194f / 255f, 212f / 255f, 183f / 255f);
            cP2 = new Color(63f / 255f, 54f / 255f, 59f / 255f);
            Vector2 or = new Vector2((GraphicsDevice.Viewport.Width / 2) - (GraphicsDevice.Viewport.Height * 0.8f / 2), (GraphicsDevice.Viewport.Height / 2) - (GraphicsDevice.Viewport.Height * 0.8f / 2));
            Vector2 dim = new Vector2(GraphicsDevice.Viewport.Height * 0.8f, GraphicsDevice.Viewport.Height * 0.8f);
            tb = new Table(or, dim, new Color[] { new Color(204f / 255f, 204f / 255f, 204f / 255f), new Color(42f / 255f, 42f / 255f, 42f / 255f) });

            //PP = new Peon(new Vector2((GraphicsDevice.Viewport.Width / 2), (GraphicsDevice.Viewport.Height / 2)), new Vector2(((GraphicsDevice.Viewport.Height * 0.8f) / 8) * 0.9f, (GraphicsDevice.Viewport.Height * 0.8f) / 8) * 0.9f, _tex_peon, cP1, true);
            ps = new List<Piece>();

            for (int y = 0; y < 8; y++)
            {
                tab[y] = new string[8];
                tabP[y] = new int[8];
                for (int x = 0; x < 8; x++)
                {
                    if (y == 1 || y == 6)
                    {
                        tab[y][x] = "pe";
                        Peon ppp;
                        if (y == 1)
                            ppp = new Peon(new Vector2(tb.Box.X, tb.Box.Y), new Vector2(x, y + 1), new Vector2(tb.Little_box.Width, tb.Little_box.Height), _tex_peon, cP1, true);
                        else
                            ppp = new Peon(new Vector2(tb.Box.X, tb.Box.Y), new Vector2(x, y + 1), new Vector2(tb.Little_box.Width, tb.Little_box.Height), _tex_peon, cP2, true);
                        ps.Add(ppp);
                        //tabP[][]
                    }
                    else
                    {
                        if (y == 0 || y == 7)
                        {
                            if (x == 0 || x == 7)
                            {
                                tab[y][x] = "to";
                                Torre tt;
                                if (y == 0)
                                    tt = new Torre(new Vector2(tb.Box.X, tb.Box.Y), new Vector2(x, y + 1), new Vector2(tb.Little_box.Width, tb.Little_box.Height), _tex_torre, cP1);
                                else
                                    tt = new Torre(new Vector2(tb.Box.X, tb.Box.Y), new Vector2(x, y + 1), new Vector2(tb.Little_box.Width, tb.Little_box.Height), _tex_torre, cP2);
                                ps.Add(tt);
                            }
                            if (x == 1 || x == 6)
                            {
                                tab[y][x] = "ca";
                                Caballo cc;
                                if (y == 0)
                                    cc = new Caballo(new Vector2(tb.Box.X, tb.Box.Y), new Vector2(x, y + 1), new Vector2(tb.Little_box.Width, tb.Little_box.Height), _tex_caballo, cP1);
                                else
                                    cc = new Caballo(new Vector2(tb.Box.X, tb.Box.Y), new Vector2(x, y + 1), new Vector2(tb.Little_box.Width, tb.Little_box.Height), _tex_caballo, cP2);
                                ps.Add(cc);
                            }
                            if (x == 2 || x == 5)
                            {
                                tab[y][x] = "ar";
                                Arfil ar;
                                if (y == 0)
                                    ar = new Arfil(new Vector2(tb.Box.X, tb.Box.Y), new Vector2(x, y + 1), new Vector2(tb.Little_box.Width, tb.Little_box.Height), _tex_arfil, cP1);
                                else
                                    ar = new Arfil(new Vector2(tb.Box.X, tb.Box.Y), new Vector2(x, y + 1), new Vector2(tb.Little_box.Width, tb.Little_box.Height), _tex_arfil, cP2);
                                ps.Add(ar);
                            }

                        }
                        else
                        {
                            tab[y][x] = "" + y + " ";
                            tabP[y][x] = 0;
                        }
                    }
                }
            }

            List<Piece> p1_p = new List<Piece>();
            List<Piece> p2_p = new List<Piece>();

            for (int i = 0; i < ps.Count; i++)
            {
                if (i < 8)
                    p1_p.Add(ps[i]);
                else if (i < 10)
                    p1_p.Add(ps[i]);
                else if (i < 12)
                    p1_p.Add(ps[i]);
                else if (i < 14)
                    p1_p.Add(ps[i]);
                else if (i < 22)
                    p2_p.Add(ps[i]);
                else if (i < 24)
                    p2_p.Add(ps[i]);
                else if (i < 26)
                    p2_p.Add(ps[i]);
                else if (i < 28)
                    p2_p.Add(ps[i]);
            }

            p1 = new Player(p1_p, true);
            p2 = new Player(p2_p, true);

            for (int i = 0; i < 8; i++)
            {
                Console.Write("     ");
                for (int j = 0; j < 8; j++)
                {
                    Console.Write(" " + tab[i][j] /*+ " " + tabP[i][j]*/);

                }
                Console.Write("\n");
            }
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

            //PP.dr(_spriteBatch);
            p1.dr(_spriteBatch);
            p2.dr(_spriteBatch);

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
            public Rectangle Box, Little_box;
            private Vector2 Origen;
            private Color ColorA, ColorB;

            public Table(Vector2 origen, Vector2 dim, Color[] Colors)
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

        public class Player
        {
            private float poins;
            public bool is_my_turn;
            public List<Piece> piesas;
            public bool is_white;

            public Player(List<Piece> _piesas, bool _is_white)
            {
                piesas = _piesas;
                is_white = _is_white;
            }

            public void update()
            {
                var mouse = Mouse.GetState();
                for (int i = 0; i < piesas.Count; i++)
                {
                    if (piesas[i].Box.Contains(mouse.Position) && mouse.LeftButton == ButtonState.Pressed)
                        piesas[i].is_active = true;
                    else
                        piesas[i].is_active = false;
                }
            }
            public void dr(SpriteBatch _sb)
            {
                for (int i = 0; i < piesas.Count; i++)
                {
                    piesas[i].dr(_sb);
                }
            }

        }//EndPlayer

        public class Piece
        {
            public Rectangle Box;
            private Vector2 Origen;
            private Texture2D _tex;
            private Color color;
            public bool is_active = false;
            private List<Vector2> mov_op;

            public Vector2 Pos;
            public char type;

            public Piece(Vector2 OR, Vector2 _coor, Vector2 DIM, Texture2D te, Color co)
            {
                Pos = _coor;
                Box = new Rectangle((int)(OR.X + (Pos.X * DIM.X)), (int)(Pos.Y + (Pos.Y * DIM.Y)), (int)DIM.X, (int)DIM.Y);
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
            public Peon(Vector2 os, Vector2 pos, Vector2 dim, Texture2D tx, Color cl, bool _up) : base(os, pos, dim, tx, cl)
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
            public Torre(Vector2 os, Vector2 pos, Vector2 dim, Texture2D tx, Color cl) : base(os, pos, dim, tx, cl)
            {
                type = 't';
            }
        }//EndTorre
        public class Caballo : Piece
        {
            public Caballo(Vector2 os, Vector2 pos, Vector2 dim, Texture2D tx, Color cl) : base(os, pos, dim, tx, cl)
            {
                type = 'c';
            }
        }//EndCaballo
        public class Arfil : Piece
        {
            public Arfil(Vector2 os, Vector2 pos, Vector2 dim, Texture2D tx, Color cl) : base(os, pos, dim, tx, cl)
            {
                type = 'a';
            }
        }//EndArfil
        public class Rey : Piece
        {
            public Rey(Vector2 os, Vector2 pos, Vector2 dim, Texture2D tx, Color cl) : base(os, pos, dim, tx, cl)
            {
                type = 'k';
            }
        }//EndRey
        public class Reina : Piece
        {
            public Reina(Vector2 os, Vector2 pos, Vector2 dim, Texture2D tx, Color cl) : base(os, pos, dim, tx, cl)
            {
                type = 'q';
            }
        }//EndReina

    }
}
