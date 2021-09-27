using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Automat
{
    public partial class Form1 : Form
    {

        String text;
        char[] tekst;
        int Stan = 0;
        bool[] on;

        private List<obiekt> obiekty = new List<obiekt>();

        public Form1()
        {
            InitializeComponent();
            generuj_strzalki();
            generuj_luki();
        }

        private void wypisznastepna(int c)
        {
            label1.Text += tekst[c];
            label1.Refresh();
            Thread.Sleep(500);
        }

        private bool end(int charnr)
        {
            if (charnr == tekst.Length)
                return true;
            else
                return false;
        }

        private void wylacz(int i)
        {
            for(int x = i; x < obiekty.Count; x++)
            {
                if (on[x] == true)
                {
                    strzalka(x);
                }
            }
        }

        private void slowo()
        {
            int time = 500;
            tekst = text.ToCharArray();
            //
            int charnr = -1;
            while(charnr < tekst.Length)
            {
            Q0:
                Stan = 0; //q0
                charnr++;

                if (end(charnr))
                    goto end;

                wypisznastepna(charnr);

                if (tekst[charnr].Equals('a'))
                {
                    
                    strzalka(4);
                    Thread.Sleep(time);
                    strzalka(4);
                    Thread.Sleep(time);

                    goto Q0;
                }
                else
                {
                //q1
                Q1:
                    Stan = 1;
                    if (on[0] == false)
                        strzalka(0);
                    Thread.Sleep(time);
                    charnr++;

                    if (end(charnr))
                        goto end;

                    wypisznastepna(charnr);

                    if (tekst[charnr].Equals('a'))
                    {
                        strzalka(7);
                        Thread.Sleep(time);
                        wylacz(0);
                        Thread.Sleep(time);
                        goto Q0;
                        
                    }
                    else
                    {
                    //q2
                    Q2:
                        Stan = 2;
                        if (on[1] == false)
                            strzalka(1);
                        Thread.Sleep(time);
                        charnr++;

                        if (end(charnr))
                            goto end;

                        wypisznastepna(charnr);

                        if (tekst[charnr].Equals('b'))
                        {
                            strzalka(6);
                            Thread.Sleep(time);
                            strzalka(6);
                            Thread.Sleep(time);
                            goto Q2;
                        }
                        else
                        {
                            Stan = 3;
                            strzalka(2);
                            Thread.Sleep(time);
                            charnr++;

                            if (end(charnr))
                                goto end;

                            wypisznastepna(charnr);
                            if (tekst[charnr].Equals('b'))
                            {
                                strzalka(8);
                                Thread.Sleep(time);
                                wylacz(1);
                                Thread.Sleep(time);
                                goto Q1;
                                
                            }
                            else
                            {
                                Stan = 4;
                                strzalka(3);
                                Thread.Sleep(time);
                                charnr++;
                                
                                if (end(charnr))
                                    goto end;

                                wypisznastepna(charnr);
                                if (tekst[charnr].Equals('b'))
                                {
                                    strzalka(5);
                                    Thread.Sleep(time);
                                    wylacz(1);
                                    Thread.Sleep(time);
                                    goto Q1;
                                }
                                else
                                {
                                    strzalka(9);
                                    Thread.Sleep(time);
                                    wylacz(0);
                                    Thread.Sleep(time);
                                    goto Q0;
                                }


                            }
                        }



                    }

                }
            }
        end:
            
            //to się dzieje na koniec
            if (Stan == 4)
            {
                label3.Text = "Słowo należy do alfabetu!";
            }
            else
            {
                label3.Text = "Słowo nie należy do alfabetu!";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            text = textBox1.Text;

            wylacz(0);

            label1.Text = "";

            label1.Refresh();

            label3.Text = "";

            label3.Refresh();

            panel1.Refresh();
            /*
            strzalka(0);

            panel1.Refresh();
            Thread.Sleep(500);
            for (int i =1; i < 5; i++)
            {
                strzalka(i);
                strzalka(i-1);
                panel1.Refresh();
                Thread.Sleep(500);
            }

            strzalka(4);

            panel1.Refresh();
            Thread.Sleep(500);
            */
            /*
            for (int i = 0; i < obiekty.Count; i++)
            {
                strzalka(i);
            }
            panel1.Refresh();
            */
            slowo();

        }

        private void generuj_strzalki()
        {
            //strzalki od lewa
            Point P1 = new Point(110, 175);
            Strzalka s1 = new Strzalka(Brushes.White, P1, Pens.White, "b");
            obiekty.Add(s1);

            Point P2 = new Point(270, 175);
            Strzalka s2 = new Strzalka(Brushes.White, P2, Pens.White, "b");
            obiekty.Add(s2);

            Point P3 = new Point(440, 175);
            Strzalka s3 = new Strzalka(Brushes.White, P3, Pens.White, "a");
            obiekty.Add(s3);

            Point P4 = new Point(600, 175);
            Strzalka s4 = new Strzalka(Brushes.White, P4, Pens.White, "a");
            obiekty.Add(s4);
        }

        private void generuj_luki()
        {
            //górne
            Rectangle R1 = new Rectangle(50, 100, 50, 50);
            float startAngle = 140.0F;
            float sweepAngle = 270.0F;
            Point s = new Point(60, 145);
            Point e = new Point(55, 135);
            Łuk L1 = new Łuk(Brushes.White, Pens.White, R1, startAngle, sweepAngle, s, e, "a");
            obiekty.Add(L1);
            //długa góra
            Rectangle R2 = new Rectangle(220, 40,510, 200);
            float startAngle2 = 180.0F;
            float sweepAngle2 = 180.0F;
            Point s2 = new Point(225, 145);
            Point e2 = new Point(220, 135);
            Łuk L2 = new Łuk(Brushes.White, Pens.White, R2, startAngle2, sweepAngle2, s2, e2, "b");
            obiekty.Add(L2);

            Rectangle R3 = new Rectangle(375, 100, 50, 50);
            float startAngle3 = 140.0F;
            float sweepAngle3 = 270.0F;
            Point s3 = new Point(385, 145);
            Point e3 = new Point(380, 135);
            Łuk L3 = new Łuk(Brushes.White, Pens.White, R3, startAngle3, sweepAngle3, s3, e3, "b");
            obiekty.Add(L3);

            //dolne

            Rectangle R4 = new Rectangle(80, 180, 150, 65);
            float startAngle4 = 180.0F;
            float sweepAngle4 = -180.0F;
            Point s4 = new Point(82, 210);
            Point e4 = new Point(78, 220);
            Łuk L4 = new Łuk(Brushes.White, Pens.White, R4, startAngle4, sweepAngle4, s4, e4, "a");
            obiekty.Add(L4);

            Rectangle R5 = new Rectangle(240, 160, 340, 100);
            float startAngle5 = 180.0F;
            float sweepAngle5 = -180.0F;
            Point s5 = new Point(242, 209);
            Point e5 = new Point(238, 219);
            Łuk L5 = new Łuk(Brushes.White, Pens.White, R5, startAngle5, sweepAngle5, s5, e5, "b");
            obiekty.Add(L5);

            //gługa dół
            Rectangle R6 = new Rectangle(70, 110, 660, 200);
            float startAngle6 = 180.0F;
            float sweepAngle6 = -180.0F;
            Point s6 = new Point(72, 209);
            Point e6 = new Point(68, 219);
            Łuk L6 = new Łuk(Brushes.White, Pens.White, R6, startAngle6, sweepAngle6, s6, e6, "a");
            obiekty.Add(L6);

            on = new bool[10];

            for (int i = 0; i < obiekty.Count; i++)
            {
                on[i] = false;
            }

        }

        private void strzalka(int i)
        {


            if (obiekty[i].pen != Pens.White)
            {
                obiekty[i].pen = (Pens.White);
                obiekty[i].brush = Brushes.White;
                on[i] = false;
                panel1.Refresh();
            }
            else
            {
                obiekty[i].pen = (Pens.Black);
                obiekty[i].brush = Brushes.Black;
                on[i] = true;
                panel1.Refresh();
            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            int sizex = 60;
            int sizey = 60;
            int ballh = 145;
            Pen blackPen = new Pen(Color.Black, 2);

            // Create rectangle.
            Rectangle S1 = new Rectangle(50, ballh, sizex, sizey);
            Rectangle S2 = new Rectangle(210, ballh, sizex, sizey);
            Rectangle S3 = new Rectangle(375, ballh, sizex, sizey);
            Rectangle S4 = new Rectangle(540, ballh, sizex, sizey);
            Rectangle S5 = new Rectangle(700, ballh, sizex, sizey);
            Rectangle S5e = new Rectangle(705, ballh+5, sizex-10, sizey-10);

            // Draw rectangle to screen.
            e.Graphics.DrawEllipse(blackPen, S1);
            e.Graphics.DrawEllipse(blackPen, S2);
            e.Graphics.DrawEllipse(blackPen, S3);
            e.Graphics.DrawEllipse(blackPen, S4);
            e.Graphics.DrawEllipse(blackPen, S5);
            e.Graphics.DrawEllipse(blackPen, S5e);

            Font drawFont = new Font("Arial", 16);
            SolidBrush drawBrush = new SolidBrush(Color.Black);

            // Create point for upper-left corner of drawing.



            // Set format of string.
            StringFormat drawFormat = new StringFormat();


            // Draw string to screen.
            e.Graphics.DrawString("q0", drawFont, drawBrush, 50 + 15, ballh+15, drawFormat);
            e.Graphics.DrawString("q1", drawFont, drawBrush, 210 + 15, ballh + 15, drawFormat);
            e.Graphics.DrawString("q2", drawFont, drawBrush, 375 + 15, ballh + 15, drawFormat);
            e.Graphics.DrawString("q3", drawFont, drawBrush, 540 + 15, ballh + 15, drawFormat);
            e.Graphics.DrawString("q4", drawFont, drawBrush, 700 + 15, ballh + 15, drawFormat);

            e.Graphics.DrawLine(blackPen, 0, 175, 50, 175);
            e.Graphics.DrawLine(blackPen, 50, 175, 40, 175 + 10);
            e.Graphics.DrawLine(blackPen, 50, 175, 40, 175 - 10);

            foreach (obiekt o in obiekty)
                o.Namaluj(e.Graphics);


        }
    }

    abstract class obiekt
    {
        protected String text;
        protected Point point;
        protected Point point1;
        public Pen pen;
        public Brush brush;
        protected Rectangle rect;
        protected float startAngle;
        protected float sweepAngle;

        public obiekt(Brush brush, Pen pen, Rectangle rect, float startAngle, float sweepAngle, Point point, Point point1, String text)
        {
            this.brush = brush;
            this.point = point;
            this.point1 = point1;
            this.pen = pen;
            this.rect = rect;
            this.startAngle = startAngle;
            this.sweepAngle = sweepAngle;
            this.text = text;
        }

        protected obiekt(Brush brush, Point point, Pen pen, String text)
        {
            this.brush = brush;
            this.point = point;
            this.pen = pen;
            this.text = text;
        }

        abstract public void Namaluj(Graphics g);

    }

    class Strzalka : obiekt
    {


        public Strzalka(Brush brush, Point point, Pen pen, String text) : base(brush, point, pen, text)
        { }
        override
        public void Namaluj(Graphics g)

        {
            Font drawFont = new Font("Arial", 16);
            
            StringFormat drawFormat = new StringFormat();

            g.DrawLine(pen, point.X, point.Y, point.X + 100, point.Y);
            g.DrawLine(pen, point.X + 100, point.Y, point.X + 90, point.Y + 10);
            g.DrawLine(pen, point.X + 100, point.Y, point.X + 90, point.Y - 10);

            g.DrawString(text, drawFont, brush, point.X + 50, point.Y - 20, drawFormat);

        }

    }

    class Łuk : obiekt
    {

        public Łuk(Brush brush, Pen pen, Rectangle rect, float startAngle, float sweepAngle, Point point, Point point1, String text) : base(brush, pen, rect, startAngle, sweepAngle, point, point1, text)
        { }
        override
        public void Namaluj(Graphics g)
        {
            int x = 0;
            if (sweepAngle > 0)
            {
                x = -1;
            }
            else
            {
                x = 1;
            }

            Font drawFont = new Font("Arial", 16);

            StringFormat drawFormat = new StringFormat();

            g.DrawArc(pen, rect, startAngle, sweepAngle);
            g.DrawLine(pen, point.X, point.Y, point1.X-10, point1.Y);
            g.DrawLine(pen, point.X, point.Y, point1.X+10, point1.Y);

            int wysokosc = rect.Y + rect.Height * x;
            if (wysokosc < 0)
                wysokosc = 0;

            g.DrawString(text, drawFont, brush, rect.X + rect.Width/2, wysokosc - (20*x), drawFormat);
        }
    }
    }
