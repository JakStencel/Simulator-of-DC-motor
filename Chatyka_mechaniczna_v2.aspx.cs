using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.DataVisualization.Charting;


public partial class Chatyka_mechaniczna_v2 : System.Web.UI.Page
{
    ModelParams modelParams;
    MathModel mathModel;
    Solver solver;
    //---
    //deklaracja obiektu datatable
    DataTable table1;
    DataView dView1;

    //-------------------------------------------------
    protected void Page_Load(object sender, EventArgs e)
    {
        Chart1.Visible = false;

        labErrorMessage.Visible = false;
        labErrorMessage_Voltage.Visible = false;
        labErrorMessage_Tm.Visible = false;

        //--------------------------------------------
        txtTmin.BackColor = System.Drawing.Color.White;
        txtTmax.BackColor = System.Drawing.Color.White;
        txtUt_m.BackColor = System.Drawing.Color.White;

        //tabWyniki.BackColor = System.Drawing.Color.White;
    }
    static double delta = 0.002;
    static int size;
    static double Ia;
    static double If;

    static int Tmin;
    static int Tmax;
    static double U_mnoznik = 0.0;

    static double Ua = 230.0; 
    static double Uf = 230.0;

    static double Ra_ext = 0.0;
    static double Rf_ext = 0.0;

    static double Ma_ext = 0.0;
    static double Mf_ext = 0.0;

    static double Jr_ext = 0.0;
    static double Dr_ext = 0.01;

    static double Text;
    static double Text_t1 = 0.0;
    static double Text_t2 = 0.0;

    static double ω;

    static bool flag = false;


    protected void btnOblicz_Click(object sender, EventArgs e)
    {
        bool bVal1 = Int32.TryParse(txtTmin.Text, out Tmin);
        bool bVal2 = Int32.TryParse(txtTmax.Text, out Tmax);
        bool bVal4 = Double.TryParse(txtUt_m.Text, out U_mnoznik);


        //Chart1.Visible = true;
        //Chart4.Visible = true;
        //---

        modelParams = new ModelParams();

        //modelParams.TimeStart = tmin;
        //modelParams.TimeStop = tmax;
        modelParams.Uarma = Ua*U_mnoznik;
        modelParams.Uflux = Uf;

        modelParams.Raext = Ra_ext;
        modelParams.Rfext = Rf_ext;
        modelParams.Maext = Ma_ext * 0.001;   //przeliczenie jednostek do µF i mH
        modelParams.Mfext = Mf_ext * 0.001;   //przeliczenie jednostek do µF i mH


        
        If = modelParams.Uflux / modelParams.Rfint;
        //Ia = (modelParams.Uarma - modelParams.Gaf * If * ω) / modelParams.Raint;
        //ω = (modelParams.Uarma - modelParams.Raint * Ia) / (modelParams.Gaf * If);

        //modelParams.Jrext = Jr_ext;
        modelParams.Drext = Dr_ext;

        //Text = modelParams.Drext * ω - modelParams.Gaf * If * Ia;

        //ustawianie parametrow momentu zewnetrznego
        modelParams.Textern = Text;
        modelParams.Textern_t1 = Text_t1;
        modelParams.Textern_t2 = Text_t2;
        //----
        flag = false;

        //size = Convert.ToInt32(Tmax / delta); //liczenie ilości próbek ; modelParams.Tstop
        //modelParams.PtsResults = size;

        size = modelParams.PtsResults;
        //------------Sprawdzenie poprawności wprowadzania danych - walidacja-------------
        if (Tmin >= Tmax || Tmin < 0 || !bVal1 || !bVal2)
        {
            validation.Visible = true;
            labErrorMessage_Tm.Visible = true;
            labErrorMessage_Tm.Text = "Wartości parametrów t<sub>min</sub> oraz t<sub>max</sub> zostały wprowadzone błędnie ";
            txtTmin.BackColor = System.Drawing.Color.Red;
            txtTmax.BackColor = System.Drawing.Color.Red;
            flag = true;
        }

        /* Sprawdzenie poprawności napięć*/

        if (!bVal4 || Ua < 0)
        {
            validation.Visible = true;
            labErrorMessage_Voltage.Visible = true;
            labErrorMessage_Voltage.Text = "Błędnie wprowadzona wartość napięcia twornika";
            txtUt_m.BackColor = System.Drawing.Color.Red;
            flag = true;
        }

        /*pętla*/

        if (flag == true)
        {
            return;
        }
        else
        {
            labErrorMessage.Visible = true;
            labErrorMessage.Text = "Dane zostały wprowadzone poprawnie";
            Chart1.Visible = true;
        }

        this.mathModel = new MathModel(modelParams, modelParams.TimeStart, modelParams.InitCondit);
        this.solver = new Solver(modelParams, mathModel);
        //---
        solver.SolverStart(modelParams);
        double[,] wyniki = solver.Results;

        //-- pierwsza tabela danych do wykresu 1

        table1 = new DataTable();
        //--
        DataColumn column1;
        DataRow row1;
        //--
        column1 = new DataColumn();
        column1.DataType = Type.GetType("System.Double");
        column1.ColumnName = "Torque";
        table1.Columns.Add(column1);

        column1 = new DataColumn();
        column1.DataType = Type.GetType("System.Double");
        column1.ColumnName = "ω";
        table1.Columns.Add(column1);

        column1 = new DataColumn();
        column1.DataType = Type.GetType("System.Double");
        column1.ColumnName = "ω przy Uan";
        table1.Columns.Add(column1);

        //----------------
        //int size_tmin = Convert.ToInt32(Tmin / delta);
        //labErrorMessage.Text = "jest to ilosc " + (int)size;

        double[,] array;

        for (int i = Tmin; i <= Tmax; i++)
        {
            array = new double[Tmax+1, 3];
            array[i, 0] = i;
            array[i, 1] = ((modelParams.Uarma / modelParams.Gaf * If) - (modelParams.Raint / Math.Pow(modelParams.Gaf*If,2))*i)*10;
            array[i, 2] = ((Ua / modelParams.Gaf * If) - (modelParams.Raint / Math.Pow(modelParams.Gaf * If, 2)) * i) * 10;
            row1 = table1.NewRow();
            row1["Torque"] = array[i, 0];
            row1["ω"] = array[i, 1];
            row1["ω przy Uan"] = array[i, 2];



            table1.Rows.Add(row1);
        }
        //--
        dView1 = new DataView(table1);
        //--
        Chart1.Series.Clear();
        Chart1.ChartAreas.Add("Wykres01");
        //--
        Chart1.DataBindTable(dView1, "Torque");
        Chart1.Width = 900;
        Chart1.Height = 750;
        Chart1.Series["ω"].ChartType = SeriesChartType.Line;
        Chart1.Series["ω"].BorderWidth = 3;//grubosc wykresu
        Chart1.Series["ω przy Uan"].ChartType = SeriesChartType.Line;
        Chart1.Series["ω przy Uan"].BorderWidth = 3;//grubosc wykresu


        //if (chkIcs.Checked)
        //{
        //    Chart1.Visible = true;
        //    Chart1.Series["Ics"].ChartType = SeriesChartType.Line;
        //    Chart1.Series["Ics"].BorderWidth = 3;//grubosc wykresu
        //}
        //Chart1.ChartAreas[0].AxisX.LineWidth = 2;
        Chart1.ChartAreas[0].AxisX.Minimum = 0;
        //Chart1.ChartAreas[0].AxisX.Maximum = (double)table1.Rows[size]["Torque"];
        //Chart1.ChartAreas[0].AxisY.Minimum = 0.0;
        Chart1.ChartAreas[0].AxisY.ArrowStyle = AxisArrowStyle.Lines;//strzałki wykresu
        //Chart1.ChartAreas[0].AxisX.ArrowStyle = AxisArrowStyle.Lines;
        Chart1.ChartAreas[0].AxisX.LabelStyle.Format = "{#0.###}";
        Chart1.ChartAreas[0].AxisX.Title = "Text [Nm]";
        Chart1.ChartAreas[0].AxisY.Title = "ω [rad/s]";
        Chart1.ChartAreas[0].AxisX.TitleFont = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold);
        Chart1.ChartAreas[0].AxisY.TitleFont = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold);
    }

}



