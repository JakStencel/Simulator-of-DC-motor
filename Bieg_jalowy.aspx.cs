using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.DataVisualization.Charting;

public partial class Bieg_jalowy : System.Web.UI.Page
{
    ModelParams modelParams;
    MathModel mathModel;
    Solver solver;
    //---
    //deklaracja obiektu datatable
    DataTable table1;

    DataView dView1;

    protected void Page_Load(object sender, EventArgs e)
    {
        Chart1.Visible = false;

        labErrorMessage.Visible = false;
        labErrorMessage_ω.Visible = false;
        labErrorMessage_Indf.Visible = false;

        txtω.BackColor = System.Drawing.Color.White;
        txtMf_ext.BackColor = System.Drawing.Color.White;
        //tabWyniki.BackColor = System.Drawing.Color.White;
    }


    static double delta = 0.002;
    static int size;
    static double Ia;
    static double If;

    static double tmin = 0.0;
    static double tmax = 4.0;

    static double Ua; //
    static double Uf;

    static double Ra_ext = 0.0;
    static double Rf_ext = 0.0;

    static double Ma_ext = 0.0;
    static double Mf_ext = 0.0;
    static double ω;


    static double Jr_ext = 0.07;
    static double Dr_ext = 0.01;

    static double Text = 0.0;
    static double Text_t1 = 0.0;
    static double Text_t2 = 0.0;

    static bool flag = false;
    double[,] aray1;
    //double[,] aray2;



    protected void btnOblicz_Click(object sender, EventArgs e)
    {
        //bool bVal1 = Double.TryParse(txtUfmin.Text, out tmin);
        //bool bVal2 = Double.TryParse(txtUfmax.Text, out tmax);
        bool bVal1 = Double.TryParse(txtMf_ext.Text, out Mf_ext);
        bool bVal2 = Double.TryParse(txtω.Text, out ω);

        modelParams = new ModelParams();

        //modelParams.TimeStart = tmin;
        modelParams.TimeStop = tmax;

        modelParams.Uarma = Ua;
        modelParams.Uflux = Uf;

        modelParams.Raext = Ra_ext;
        modelParams.Rfext = Rf_ext;
        modelParams.Maext = Ma_ext * 0.001;        //przeliczenie jednostek do µF i mH
        modelParams.Mfext = Mf_ext * 0.001;        //przeliczenie jednostek do µF i mH

        modelParams.Jrext = Jr_ext;
        modelParams.Drext = Dr_ext;



        //ustawianie parametrow momentu zewnetrznego
        modelParams.Textern = Text;
        modelParams.Textern_t1 = Text_t1;
        modelParams.Textern_t2 = Text_t2;
        modelParams.InitCondit[2] = ω;
        flag = false;

        //modelParams.Textern = Text;

        //size = Convert.ToInt32(tmax / delta); //liczenie ilości próbek

        modelParams.PtsResults = size;

        if (!bVal1 || Mf_ext < 0)
        {
            validation.Visible = true;
            labErrorMessage_Indf.Visible = true;
            labErrorMessage_Indf.Text = "Błędnie wprowadzona wartość indukcyjności obwodu wzbudzenia";
            txtMf_ext.BackColor = System.Drawing.Color.Red;
            flag = true;
        }
        if (ω <= 0 || !bVal2)
        {
            validation.Visible = true;
            labErrorMessage_ω.Visible = true;
            labErrorMessage_ω.Text = "Błędne wartości prędkości kątowej wału silnika";
            txtω.BackColor = System.Drawing.Color.Red;
            flag = true;
        }
        /*pętla*/
        if (flag == true)
        {
            return;
        }
        else
        {
            validation.Visible = true;
            labErrorMessage.Visible = true;
            labErrorMessage.Text = "Wprowadzono dane poprawnie";
            Chart1.Visible = true;
            validation.Visible = true;
        }
        //--- tablica napięć i prądów do wykresu
        aray1 = new double[17, 3];
        //aray2 = new double[17, 2];
        aray1[0, 0] = 20;
        aray1[1, 0] = 30;
        aray1[2, 0] = 50;
        aray1[3, 0] = 80;
        aray1[4, 0] = 100;
        aray1[5, 0] = 120;
        aray1[6, 0] = 140;
        aray1[7, 0] = 160;
        aray1[8, 0] = 180;
        aray1[9, 0] = 210;
        aray1[10, 0] = 220;
        aray1[11, 0] = 230;
        aray1[12, 0] = 240;
        aray1[13, 0] = 260;
        aray1[14, 0] = 280;
        aray1[15, 0] = 350;
        aray1[16, 0] = 380;

        //aray1[0, 1] = -0.0018*20*20 +1.4616*20 - 2.5091;
        //aray1[1, 1] = -0.0018*30*30 +1.4616*30 - 2.5091;
        //aray1[2, 1] = -0.0018*50*50 +1.4616*50 - 2.5091;
        //aray1[3, 1] = -0.0018*80*80 +1.4616*80 - 2.5091;
        //aray1[4, 1] = -0.0018*100*100 +1.4616*100 - 2.5091;
        //aray1[5, 1] = -0.0018*120*120 +1.4616*120 - 2.5091;
        //aray1[6, 1] = -0.0018*140*140 +1.4616*140 - 2.5091;
        //aray1[7, 1] = -0.0018*160*160 +1.4616*160 - 2.5091;
        //aray1[8, 1] = -0.0018*180*180 +1.4616*180 - 2.5091;
        //aray1[9, 1] = -0.0018*210*210 +1.4616*210 - 2.5091;
        //aray1[10, 1] = -0.0018*220*220 +1.4616*220 - 2.5091;
        //aray1[11, 1] = -0.0018*230*230 +1.4616*230 - 2.5091;
        //aray1[12, 1] = -0.0018*240*240 +1.4616*240 - 2.5091;
        //aray1[13, 1] = -0.0018*260*260 +1.4616*260 - 2.5091;
        //aray1[14, 1] = -0.0018*280*280 +1.4616*280 - 2.5091;
        //aray1[15, 1] = -0.0018*350*350 +1.4616*350 - 2.5091;
        //aray1[16, 1] = -0.0018*380*380 +1.4616*380 - 2.5091;

        //aray1[0, 2] = -0.0014 * 20 * 20 + 1.3296 * 20 - 7.4899;
        //aray1[1, 2] = -0.0014 * 30 * 30 + 1.3296 * 30 - 7.4899;
        //aray1[2, 2] = -0.0014 * 50 * 50 + 1.3296 * 50 - 7.4899;
        //aray1[3, 2] = -0.0014 * 80 * 80 + 1.3296 * 80 - 7.4899;
        //aray1[4, 2] = -0.0014 * 100 * 100 + 1.3296 * 100 - 7.4899;
        //aray1[5, 2] = -0.0014 * 120 * 120 + 1.3296 * 120 - 7.4899;
        //aray1[6, 2] = -0.0014 * 140 * 140 + 1.3296 * 140 - 7.4899;
        //aray1[7, 2] = -0.0014 * 160 * 160 + 1.3296 * 160 - 7.4899;
        //aray1[8, 2] = -0.0014 * 180 * 180 + 1.3296 * 180 - 7.4899;
        //aray1[9, 2] = -0.0014 * 210 * 210 + 1.3296 * 210 - 7.4899;
        //aray1[10, 2] = -0.0014 * 220 * 220 + 1.3296 * 220 - 7.4899;
        //aray1[11, 2] = -0.0014 * 230 * 230 + 1.3296 * 230 - 7.4899;
        //aray1[12, 2] = -0.0014 * 240 * 240 + 1.3296 * 240 - 7.4899;
        //aray1[13, 2] = -0.0014 * 260 * 260 + 1.3296 * 260 - 7.4899;
        //aray1[14, 2] = -0.0014 * 280 * 280 + 1.3296 * 280 - 7.4899;
        //aray1[15, 2] = -0.0014 * 350 * 350 + 1.3296 * 350 - 7.4899;
        //aray1[16, 2] = -0.0014 * 380 * 380 + 1.3296 * 380 - 7.4899;



        for (int i = 0; i < 17; i++)
        {
            aray1[i, 1] = -0.0018 * Math.Pow(aray1[i, 0], 2) + 1.4516 * aray1[i, 0] - 2.5091;
            aray1[i, 2] = -0.0014 * Math.Pow(aray1[i, 0], 2) + 1.3296 * aray1[i, 0] - 7.4899;
        }



        this.mathModel = new MathModel(modelParams, modelParams.TimeStart, modelParams.InitCondit);
        this.solver = new Solver(modelParams, mathModel);
        //---
        solver.SolverStart(modelParams);
        double[,] wyniki = solver.Results;
        //-- pierwsza tabela danych do wykresu 1
        table1 = new DataTable();

        DataColumn column1;
        DataRow row1;
        //--
        column1 = new DataColumn();
        column1.DataType = Type.GetType("System.Double");
        column1.ColumnName = "If";
        table1.Columns.Add(column1);
        //=--
        column1 = new DataColumn();
        column1.DataType = Type.GetType("System.Double");
        column1.ColumnName = "Eao ↗";
        table1.Columns.Add(column1);
        //=--
        column1 = new DataColumn();
        column1.DataType = Type.GetType("System.Double");
        column1.ColumnName = "Eao ↘";
        table1.Columns.Add(column1);
        //=--
        //----------------
        //int size_tmin = Convert.ToInt32(tmin / delta);
        //labErrorMessage.Text = "jest to ilosc " + (int)size;
        for (int i = 0; i <= 16; i++)
        {
            row1 = table1.NewRow();
            row1["If"] = aray1[i, 0];
            row1["Eao ↗"] = aray1[i, 2]; //
            row1["Eao ↘"] = aray1[i, 1]; //
            //row1["Ics"] = wyniki[i, 3]; //

            table1.Rows.Add(row1);          
        }

        dView1 = new DataView(table1);
        //--
        Chart1.Series.Clear();
        Chart1.ChartAreas.Add("Wykres01");
        //--
        Chart1.DataBindTable(dView1, "If");
        Chart1.Width = 900;
        Chart1.Height = 750;
        //Chart3.Series["Voltage"].ChartType = SeriesChartType.Line;
        Chart1.Series["Eao ↗"].ChartType = SeriesChartType.Spline;
        Chart1.Series["Eao ↗"].BorderWidth = 3;//grubosc wykresu

        Chart1.Series["Eao ↘"].ChartType = SeriesChartType.Spline;
        Chart1.Series["Eao ↘"].BorderWidth = 3;//grubosc wykresu
        Chart1.ChartAreas["ChartArea1"].AxisY2.Enabled = AxisEnabled.True;
        Chart1.Series["Eao ↘"].YAxisType = AxisType.Secondary;

        //if (chkIcs.Checked)
        //{
        //    Chart1.Visible = true;
        //    Chart1.Series["Ics"].ChartType = SeriesChartType.Line;
        //    Chart1.Series["Ics"].BorderWidth = 3;//grubosc wykresu
        //}
        //Chart1.ChartAreas[0].AxisX.LineWidth = 2;
        Chart1.ChartAreas[0].AxisX.Minimum = tmin;
        //Chart1.ChartAreas[0].AxisX.Maximum = (double)table1.Rows[size]["If"];
        //Chart1.ChartAreas[0].AxisY.Minimum = 0.0;
        Chart1.ChartAreas[0].AxisY.ArrowStyle = AxisArrowStyle.Lines;//strzałki wykresu
        //Chart1.ChartAreas[0].AxisX.ArrowStyle = AxisArrowStyle.Lines;
        Chart1.ChartAreas[0].AxisY2.ArrowStyle = AxisArrowStyle.Lines;
        //Chart1.ChartAreas[0].AxisY2.Minimum = 0.0;
        //Chart1.ChartAreas[0].AxisY2.Maximum = 2.4;
        Chart1.ChartAreas[0].AxisX.LabelStyle.Format = "{#0.###}";
        Chart1.ChartAreas[0].AxisX.Title = "If [mA]";
        Chart1.ChartAreas[0].AxisY.Title = "Eao  [V]";
        Chart1.ChartAreas[0].AxisY2.Title = "Eao  [V]";
        Chart1.ChartAreas[0].AxisX.TitleFont = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold);
        Chart1.ChartAreas[0].AxisY.TitleFont = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold);
        Chart1.ChartAreas[0].AxisY2.TitleFont = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold);

    }
}