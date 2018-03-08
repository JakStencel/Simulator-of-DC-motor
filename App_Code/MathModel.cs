using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


    public class MathModel
    {
        private int size;
        //---
        public double[,] Msys { get; set; }
        public double[] Usys { get; set; }
        public double[,] Rsys { get; set; }
        public double[,] Gsys { get; set; }
        public double Telem { get; set; }
        //---
        ModelParams modParams;
        //------
        public MathModel(ModelParams modParams, double time, double[] vars)
        {
            this.modParams = modParams;
            this.size = modParams.Size;
            Msys = new double[size, size];
            Usys = new double[size];
            Rsys = new double[size, size];
            Gsys = new double[size, size];
            //---
            SetMsys(time, vars);
            SetGsys(time, vars);
            SetRsys(time, vars);
            SetUsys(time, vars);
        }
        //------
        //Nie edytowac
        public void SetModel(double time, double[] vars)
        {
            SetMsys(time, vars);
            SetGsys(time, vars);
            SetRsys(time, vars);
            SetUsys(time, vars);
        }
        //------
        private void SetMsys(double time, double[] vars)
        {
            double fi = vars[size - 1];
            //---
            Msys[0, 0] = modParams.Maint + modParams.Maext;
            Msys[0, 1] = 0;
            Msys[0, 2] = 0;
            Msys[0, 3] = 0;
            //---
            Msys[1, 0] = 0;
            Msys[1, 1] = modParams.Mfint + modParams.Mfext; ;
            Msys[1, 2] = 0;
            Msys[1, 3] = 0;
            //---
            Msys[2, 0] = 0;
            Msys[2, 1] = 0;
            Msys[2, 2] = modParams.Jrint + modParams.Jrext;
            Msys[2, 3] = 0;
            //---
            Msys[3, 0] = 0;
            Msys[3, 1] = 0;
            Msys[3, 2] = 0;
            Msys[3, 3] = 1;
        }
        //------
        private void SetUsys(double time, double[] vars)
        {
            SetTelem(time, vars);
            //---
            Usys[0] = modParams.Uarma;
            Usys[1] = modParams.Uflux;
            Usys[2] = modParams.Textern + Telem;
            Usys[3] = vars[size - 2];
        }
        //------
        private void SetTelem(double time, double[] vars)
        {
            Telem = modParams.Gaf * vars[0] * vars[1];
        }
        //------
        private void SetRsys(double time, double[] vars)
        {
            Rsys[0, 0] = modParams.Raint + modParams.Raext;
            Rsys[0, 1] = 0;
            Rsys[0, 2] = 0;
            Rsys[0, 3] = 0;
            //---
            Rsys[1, 0] = 0;
            Rsys[1, 1] = modParams.Rfint + modParams.Rfext;
            Rsys[1, 2] = 0;
            Rsys[1, 3] = 0;
            //---
            Rsys[2, 0] = 0;
            Rsys[2, 1] = 0;
            Rsys[2, 2] = modParams.Drint + modParams.Drext;
            Rsys[2, 3] = 0;
            //---
            Rsys[3, 0] = 0;
            Rsys[3, 1] = 0;
            Rsys[3, 2] = 0;
            Rsys[3, 3] = 0;
        }
        //------
        private void SetGsys(double time, double[] vars)
        {
            double fi = vars[size - 1];
            //---
            Gsys[0, 0] = 0;
            Gsys[0, 1] = modParams.Gaf;
            Gsys[0, 2] = 0;
            Gsys[0, 3] = 0;
            //---
            Gsys[1, 0] = 0;
            Gsys[1, 1] = 0;
            Gsys[1, 2] = 0;
            Gsys[1, 3] = 0;
            //---
            Gsys[2, 0] = 0;
            Gsys[2, 1] = 0;
            Gsys[2, 2] = 0;
            Gsys[2, 3] = 0;
            //---
            Gsys[3, 0] = 0;
            Gsys[3, 1] = 0;
            Gsys[3, 2] = 0;
            Gsys[3, 3] = 0;
        }
    }

