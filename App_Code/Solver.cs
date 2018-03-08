using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


    public class Solver
    {
        private double[,] drawResults;  //Array of results to draw
        public double[,] Results { get { return drawResults; } }
        private int resRows;            //Number of rows in drawResults
        private int resCols;            //Number of columns in drawResults
        //---
        private double hc;              //Base step of the solver
        private double time;            //The current time of simulation
        private double startTime;
        private double stopTime;
        //---
        private double drawTime;        //Time of drawResults
        private double deltaTime;       //Time step between draw results
        private short drawIndex;        //Index of recorded row
        //---
        private double[] vars1;         //Array of variables in the time=t
        private double[] vars2;         //Array of variables in the time=t+hc
        private double[] derivSys;      //Array of time derivative of variables
        private double[] vecSys;        //Vector of right side of the system  
        private int varSize;            //Size of variable array
        //---
        private MathModel model;        //Model of a machine
        private ModelParams modParams;  //Parametry modelu
        //------
        public Solver(ModelParams modParams, MathModel model)
        {
            this.model = model;
            this.modParams = modParams;
            //---
            this.hc = 0.00001;
            this.varSize = modParams.Size;
            this.vars1 = new double[varSize];
            this.vars2 = new double[varSize];
            this.derivSys = new double[varSize];
            this.vecSys = new double[varSize];
            //copy initial conditions array to vars1 and vars2 arrays
            for (int i = 0; i < varSize; i++)
            {
                vars1[i] = modParams.InitCondit[i];
                vars2[i] = modParams.InitCondit[i];
            }
        }
        //------
        private double[] Add2(double[] array1, double[] array2)
        {
            double[] array = new double[varSize];
            for (int i = 0; i < varSize; i++)
            {
                array[i] = array1[i] + array2[i];
            }
            return array;
        }
        //------
        private double[] Product(double number, double[] array)
        {
            double[] result = new double[varSize];
            for (int i = 0; i < varSize; i++)
            {
                result[i] = number * array[i];
            }
            return result;
        }
        //------
        private double[] ProductMV(double[,] matrix, double[] vector)
        {
            double[] result = new double[varSize];
            double sum = 0;
            for (int i = 0; i < varSize; i++)
            {
                sum = 0;
                for (int j = 0; j < varSize; j++)
                {
                    sum += matrix[i, j] * vector[j];
                }
                result[i] = sum;
            }
            return result;
        }
        //------
        private double[] Add4(double[] array1, double[] array2, double[] array3, double[] array4)
        {
            double[] array = new double[varSize];
            for (int i = 0; i < varSize; i++)
            {
                array[i] = array1[i] + array2[i] + array3[i] + array4[i];
            }
            return array;
        }
        //------
        private void Gaussian(double[,] matrix, double[] vector)
        {
            double[,] Array;
            Array = new double[varSize, varSize + 1];
            //---
            for (int i = 0; i < varSize; i++)
            {
                for (int j = 0; j < varSize; j++)
                {
                    Array[i, j] = matrix[i, j];
                }
                Array[i, varSize] = vector[i];
            }
            //---Direct procedure
            for (int i = 0; i < varSize; i++)
            {
                double elem_ki = Array[i, i];
                for (int j = 0; j < varSize + 1; j++)
                {
                    Array[i, j] = Array[i, j] / elem_ki;
                }
                for (int k = i + 1; k < varSize; k++)
                {
                    elem_ki = Array[k, i];
                    for (int j = 0; j < varSize + 1; j++)
                    {
                        Array[k, j] = Array[k, j] - elem_ki * Array[i, j];
                    }
                }
            }
            //---Reverse procedure
            for (int i = varSize - 1; i >= 0; i--)
            {
                int count = i + 1;
                derivSys[i] = Array[i, varSize];
                while (count < varSize)
                {
                    derivSys[i] -= Array[i, count] * derivSys[count];
                    count++;
                }
            }
        }//Gaussian
        //------
        public void SetVsys(double time, double[] vars)
        {
            double[] emfR = ProductMV(model.Rsys, vars);
            double[] emfG = ProductMV(model.Gsys, vars);
            for (int i = 0; i < varSize; i++)
            {
                emfG[i] = emfG[i] * vars[varSize - 2];
            }
            for (int i = 0; i < this.varSize; i++)
            {
                vecSys[i] = model.Usys[i] - emfR[i] - emfG[i];
            }
            //---
            //int qqq = 0;
        }
        //------
        private void SetDsys(double time, double[] vars)
        {
            SetVsys(time, vars);
            Gaussian(model.Msys, vecSys);
        }
        //------
        public void SolverStart(ModelParams modParams)
        {
            //********************Calculating delta for Textern increment
            double texternDelta = 0;
            if (modParams.Textern_t2 > modParams.Textern_t1)
            {
                texternDelta = modParams.Textern / ((modParams.Textern_t2 - modParams.Textern_t1) / hc);
            }
            double maximalTextern = modParams.Textern;
            modParams.Textern = 0;
            //********************
            //|time|vars[0]|...|vars[size-1|Usys[0]|...|Usys[size-2|Telem|
            this.resCols = 1 + varSize + (varSize - 1) + 1;
            this.resRows = modParams.PtsResults + 1;
            this.drawResults = new double[resRows, resCols];
            //time step between drawResults
            this.deltaTime = (modParams.TimeStop - modParams.TimeStart) / (this.resRows - 1);
            if (deltaTime <= hc)
            {
                hc = deltaTime;
            }
            //---
            startTime = modParams.TimeStart;
            stopTime = modParams.TimeStop;
            time = startTime;
            drawTime = startTime;
            drawIndex = 0;
            //---
            SetDrawResults(1, 0);
            //---
            double[] K1 = new double[varSize];
            double[] K2 = new double[varSize];
            double[] K3 = new double[varSize];
            double[] K4 = new double[varSize];
            //The Runge-Kutta method
            while (time <= stopTime)
            {

                //*************************Zmiana wartości Momentu zewnętrznego.+++++++++++++++++++++++++++++++
                if (time >= modParams.Textern_t1 && time <= modParams.Textern_t2 && modParams.Textern_t1 != modParams.Textern_t2)
                {
                    modParams.Textern += texternDelta;
                    //modParams.Textern = (Text / Text_t1) * (solver.time - Text_t1) + Text;
                }
                else if (time > modParams.Textern_t1 && modParams.Textern_t1 == modParams.Textern_t2)
                {
                    modParams.Textern = maximalTextern;
                }
                //**************************Koniec dodatkowego kodu****************************
                model.SetModel(time, vars1);
                //---
                SetDsys(time, vars1);
                K1 = Product(hc, derivSys);
                SetDsys(time + 0.5 * hc, Add2(vars1, Product(0.5, K1)));
                K2 = Product(hc, derivSys);
                SetDsys(time + 0.5 * hc, Add2(vars1, Product(0.5, K2)));
                K3 = Product(hc, derivSys);
                SetDsys(time + hc, Add2(vars1, K3));
                K4 = Product(hc, derivSys);
                vars2 = Add2(vars1, Product(0.16666, Add4(K1, Product(2, K2), Product(2, K3), K4)));
                //******
                //int qqq = 0;
                if (time < drawTime && drawTime <= time + hc)
                {
                    double dt = drawTime - time;
                    double w1 = 1 - dt / hc;
                    double w2 = dt / hc;
                    if (drawIndex < resRows)
                    {
                        SetDrawResults(w1, w2);
                    }
                }
                //******
                time += hc;
                for (int i = 0; i < varSize; i++)
                {
                    vars1[i] = vars2[i];
                }
            }//while
        }
        //------
        private void SetDrawResults(double w1, double w2)
        {
            int size = this.resCols;
            double[] array1 = new double[size];
            double[] array2 = new double[size];
            array1[0] = drawTime;
            array2[0] = drawTime;
            for (int i = 0; i < varSize; i++)
            {
                array1[i + 1] = vars1[i];
                array2[i + 1] = vars2[i];
            }
            for (int i = 0; i < varSize - 1; i++)
            {
                array1[varSize + 1 + i] = model.Usys[i];
                array2[varSize + 1 + i] = model.Usys[i];
            }
            array1[2 * varSize] = model.Telem;
            array2[2 * varSize] = model.Telem;
            //---
            for (int i = 0; i < size; i++)
            {
                drawResults[drawIndex, i] = array1[i] * w1 + array2[i] * w2;
            }
            drawTime = drawTime + deltaTime;
            drawIndex++;
        }
    }

