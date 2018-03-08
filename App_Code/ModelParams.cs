using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


    public class ModelParams
    {
        //Parametry wewnetrzne maszyny
        public double Maint { get; set; }   //indukcyjnosc twornika wewnetrzna
        public double Mfint { get; set; }   //
        public double Jrint { get; set; }
        public double Raint { get; set; }
        public double Rfint { get; set; }
        public double Drint { get; set; }
        public double Gaf { get; set; }
        //Parametry zewnetrzne obwodu elektromechnicznego
        public double Maext { get; set; }
        public double Mfext { get; set; }
        public double Jrext { get; set; }
        public double Raext { get; set; }
        public double Rfext { get; set; }
        public double Drext { get; set; }
        //Parametry czasu - nazwy zachowac
        public double TimeStart { get; set; }
        public double TimeStop { get; set; }
        public int PtsResults { get; set; }
        //Parametry napiec zasilajacych i momentu zewnetrznego
        public double Uarma { get; set; }   //napiecie twornika
        public double Uflux { get; set; }   //napiecie wzbudzenia
        public double Textern { get; set; } //moment zewnetrzny
        public double Textern_t1 { get; set; } //moment zewnętrzny wartość początkowa
        public double Textern_t2 { get; set; } //moment zewnętrzny wartość końcowa
        //------
        private int size;   //rozmiar ukladu
        public int Size { get { return size; } }
        //wektor warunkow poczatkowych
        public double[] InitCondit { get; set; }
        public ModelParams()
        {
            //Inicjalizacja napiec i momentu zewnetrznego
            this.Uarma = 230;
            this.Uflux = 230;
            this.Textern = 0;
            this.Textern_t1 = 0;
            this.Textern_t2 = 0;
            //Inicjalizacja parametrow wewnetrznych
            this.Maint = 0.069;
            this.Mfint = 72.0;
            this.Jrint = 0.07;
            this.Raint = 5.0;
            this.Rfint = 474.0;
            this.Drint = 0.011;
            this.Gaf = 4.91;
            //Inicjalizacja parametrow zewnetrznych
            this.Maext = 0;
            this.Mfext = 0;
            this.Jrext = 0;
            this.Raext = 36.3;
            this.Rfext = 0;
            this.Drext = 0;
            //Inicjalizacja parametrow czasu i liczby wynikow
            this.TimeStart = 0;
            this.TimeStop = 0.5; //0.05 ; moje 3.7436
            PtsResults = 25; //20 ; moje 9360
            //Warunki poczatkowe
            this.size = 4;
            InitCondit = new double[size];
            InitCondit[0] = 0;      //ia
            InitCondit[1] = 0.485;  //if
            InitCondit[2] = 0;      //omega
            InitCondit[3] = 0;      //angle
        }
    }

