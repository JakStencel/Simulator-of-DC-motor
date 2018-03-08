using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.DataVisualization.Charting;

public partial class Rozruch : System.Web.UI.Page
{
    ModelParams modelParams;
    MathModel mathModel;
    Solver solver;
    //---
    //deklaracja obiektu datatable
    DataTable table1;
    DataTable table2;
    //--------------
    DataView dView1;
    DataView dView2;

    protected void Page_Load(object sender, EventArgs e)
    {
        Chart1.Visible = false;
        Chart2.Visible = false;

        labErrorMessage.Visible = false;
        labErrorMessage_Voltage.Visible = false;
        labErrorMessage_time.Visible = false;
        labErrorMessage_Reza.Visible = false;
        labErrorMessage_Rezf.Visible = false;
        labErrorMessage_Inda.Visible = false;
        labErrorMessage_Indf.Visible = false;
        labErrorMessage_Jr.Visible = false;
        labErrorMessage_Dr.Visible = false;
        labErrorMessage_Text.Visible = false;
        //--------------------------------------------
        txtTmin.BackColor = System.Drawing.Color.White;
        txtTmax.BackColor = System.Drawing.Color.White;
        txtUa.BackColor = System.Drawing.Color.White;
        txtUf.BackColor = System.Drawing.Color.White;
        txtRa_ext.BackColor = System.Drawing.Color.White;
        txtRf_ext.BackColor = System.Drawing.Color.White;
        txtMa_ext.BackColor = System.Drawing.Color.White;
        txtMf_ext.BackColor = System.Drawing.Color.White;
        txtJr_ext.BackColor = System.Drawing.Color.White;
        txtDr_ext.BackColor = System.Drawing.Color.White;
        txtText.BackColor = System.Drawing.Color.White;
        txtText_t1.BackColor = System.Drawing.Color.White;
        txtText_t2.BackColor = System.Drawing.Color.White;
        //tabWyniki.BackColor = System.Drawing.Color.White;
    }
    static double delta = 0.002;
    static int size;
    static double Ia;
    static double If;

    static double tmin = 0.0;
    static double tmax = 0.0;

    static double Ua = 0.0; //
    static double Uf = 0.0;

    static double Ra_ext = 0.0;
    static double Rf_ext = 0.0;

    static double Ma_ext = 0.0;
    static double Mf_ext = 0.0;

    static double Jr_ext = 0.0;
    static double Dr_ext = 0.0;

    static double Text = 0.0;
    static double Text_t1 = 0.0;
    static double Text_t2 = 0.0;


    static bool flag = false;


    protected void btnOblicz_Click(object sender, EventArgs e)
    {
        
        bool bVal1 = Double.TryParse(txtTmin.Text, out tmin);
        bool bVal2 = Double.TryParse(txtTmax.Text, out tmax);
        bool bVal3 = Double.TryParse(txtUf.Text, out Uf);
        bool bVal4 = Double.TryParse(txtUa.Text, out Ua);
        bool bVal5 = Double.TryParse(txtRa_ext.Text, out Ra_ext);
        bool bVal6 = Double.TryParse(txtRf_ext.Text, out Rf_ext);
        bool bVal7 = Double.TryParse(txtMa_ext.Text, out Ma_ext);
        bool bVal8 = Double.TryParse(txtMf_ext.Text, out Mf_ext);
        bool bVal9 = Double.TryParse(txtJr_ext.Text, out Jr_ext);
        bool bVal10 = Double.TryParse(txtDr_ext.Text, out Dr_ext);
        bool bVal11 = Double.TryParse(txtText.Text, out Text);
        bool bVal12 = Double.TryParse(txtText_t1.Text, out Text_t1);
        bool bVal13 = Double.TryParse(txtText_t2.Text, out Text_t2);

       

        modelParams = new ModelParams();

        //modelParams.TimeStart = tmin;
        modelParams.TimeStop = tmax;

        modelParams.Uarma = Ua;
        modelParams.Uflux = Uf;

        modelParams.Raext = Ra_ext;
        modelParams.Rfext = Rf_ext;
        modelParams.Maext = Ma_ext * 0.001;  //przeliczenie jednostek do µF i mH
        modelParams.Mfext = Mf_ext * 0.001;  //przeliczenie jednostek do µF i mH

        modelParams.Jrext = Jr_ext;
        modelParams.Drext = Dr_ext;



        //ustawianie parametrow momentu zewnetrznego
        modelParams.Textern = Text;
        modelParams.Textern_t1 = Text_t1;
        modelParams.Textern_t2 = Text_t2;

        flag = false;

        size = Convert.ToInt32(tmax / delta); //liczenie ilości próbek

        modelParams.PtsResults = size;
        /* Walidacja textBoxów; sprawdzenie poprawności wprowadzonych danych*/
        if (tmin >= tmax || tmax > 5 || tmin < 0 || !bVal1 || !bVal2)
        {
            validation.Visible = true;
            labErrorMessage_time.Visible = true;
            labErrorMessage_time.Text = "Wartości parametrów t<sub>min</sub> oraz t<sub>max</sub> zostały wprowadzone błędnie ";
            txtTmin.BackColor = System.Drawing.Color.Red;
            txtTmax.BackColor = System.Drawing.Color.Red;
            flag = true;
        }

        /* Sprawdzenie poprawności napięć*/

        if (!bVal3 || Uf < 0)
        {
            validation.Visible = true;
            labErrorMessage_Voltage.Visible = true;
            labErrorMessage_Voltage.Text = "Błędnie wprowadzona wartość napięcia wzbudzenia";
            txtUf.BackColor = System.Drawing.Color.Red;
            flag = true;
        }
        if (!bVal4 || Ua < 0)
        {
            validation.Visible = true;
            labErrorMessage_Voltage.Visible = true;
            labErrorMessage_Voltage.Text = "Błędnie wprowadzona wartość napięcia twornika";
            txtUa.BackColor = System.Drawing.Color.Red;
            flag = true;
        }
        /* Sprawdzenie poprawności parametrów obwodu*/

        if (!bVal5 || Ra_ext < 0)
        {
            validation.Visible = true;
            labErrorMessage_Reza.Visible = true;
            labErrorMessage_Reza.Text = "Błędnie wprowadzona wartość rezystancji obwodu twornika";
            txtRa_ext.BackColor = System.Drawing.Color.Red;
            flag = true;
        }
        if (!bVal6 || Rf_ext < 0)
        {
            validation.Visible = true;
            labErrorMessage_Rezf.Visible = true;
            labErrorMessage_Rezf.Text = "Błędnie wprowadzona wartość rezystancji obwodu wzbudzenia";
            txtRf_ext.BackColor = System.Drawing.Color.Red;
            flag = true;
        }
        if (!bVal7 || Ma_ext < 0)
        {
            validation.Visible = true;
            labErrorMessage_Inda.Visible = true;
            labErrorMessage_Inda.Text = "Błędnie wprowadzona wartość indukcyjności obwodu twornika";
            txtMa_ext.BackColor = System.Drawing.Color.Red;
            flag = true;
        }
        if (!bVal8 || Mf_ext < 0)
        {
            validation.Visible = true;
            labErrorMessage_Indf.Visible = true;
            labErrorMessage_Indf.Text = "Błędnie wprowadzona wartość indukcyjności obwodu wzbudzenia";
            txtMf_ext.BackColor = System.Drawing.Color.Red;
            flag = true;
        }
        /********sprawdzenie  momentu bezwładności oraz współczynnika tłumienia********/
        if (!bVal9 || Jr_ext < 0 || Jr_ext > 1)
        {
            validation.Visible = true;
            labErrorMessage_Jr.Visible = true;
            labErrorMessage_Jr.Text = "Wprowadzono niepoprawną wartość momentu bezwładności";
            txtJr_ext.BackColor = System.Drawing.Color.Red;
            flag = true;
        }
        if (!bVal10 || Dr_ext < 0 || Dr_ext > 1)
        {
            validation.Visible = true;
            labErrorMessage_Dr.Visible = true;
            labErrorMessage_Dr.Text = "Wprowadzono niepoprawną wartość współczynnika tłumienia";
            txtDr_ext.BackColor = System.Drawing.Color.Red;
            flag = true;
        }
        /*Sprawdzenie warunku momentu*/
        if (Text_t1 > Text_t2 || Text_t2 > tmax || Text_t1 < 0 || Text_t1 < 0 || Text_t2 < 0 || !bVal12 || !bVal13 || !bVal11)
        {
            validation.Visible = true;
            labErrorMessage_Text.Visible = true;
            labErrorMessage_Text.Text = "Błędne wartości parametrów Text<sub>t1</sub>, Text<sub>t2</sub> oraz Text";
            txtText.BackColor = System.Drawing.Color.Red;
            txtText_t1.BackColor = System.Drawing.Color.Red;
            txtText_t2.BackColor = System.Drawing.Color.Red;
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
            labErrorMessage.Text = "Dane zostały wprowadzone poprawnie";
            //Chart1.Visible = true;
            //Chart2.Visible = true;
        }
        Chart1.Visible = true;
        Chart2.Visible = true;

        this.mathModel = new MathModel(modelParams, modelParams.TimeStart, modelParams.InitCondit);
        this.solver = new Solver(modelParams, mathModel);
        //---
        solver.SolverStart(modelParams);
        double[,] wyniki = solver.Results;

        //-- pierwsza tabela danych do wykresu 1
        table1 = new DataTable();
        //---
        DataColumn column1;
        DataRow row1;
        //--
        column1 = new DataColumn();
        column1.DataType = Type.GetType("System.Double");
        column1.ColumnName = "Time";
        table1.Columns.Add(column1);
        //=--
        //column = new DataColumn();
        //column.DataType = Type.GetType("System.Double");
        //column.ColumnName = "Voltage";
        //table.Columns.Add(column);
        //=--
        column1 = new DataColumn();
        column1.DataType = Type.GetType("System.Double");
        column1.ColumnName = "Ia";
        table1.Columns.Add(column1);
        //=--
        column1 = new DataColumn();
        column1.DataType = Type.GetType("System.Double");
        column1.ColumnName = "If";
        table1.Columns.Add(column1);
        //=--

        //-------tabela do drugiego wykresu

        table2 = new DataTable();

        DataColumn column2;
        DataRow row2;
        //--
        column2 = new DataColumn();
        column2.DataType = Type.GetType("System.Double");
        column2.ColumnName = "Time";
        table2.Columns.Add(column2);

        column2 = new DataColumn();
        column2.DataType = Type.GetType("System.Double");
        column2.ColumnName = "ω";
        table2.Columns.Add(column2);
        //=--
        column2 = new DataColumn();
        column2.DataType = Type.GetType("System.Double");
        column2.ColumnName = "Text";
        table2.Columns.Add(column2);
        //=--
        column2 = new DataColumn();
        column2.DataType = Type.GetType("System.Double");
        column2.ColumnName = "Telem";
        table2.Columns.Add(column2);


        //----------------
        int size_tmin = Convert.ToInt32(tmin / delta);
        //labErrorMessage.Text = "jest to ilosc " + (int)size;
        for (int i = size_tmin; i <= size; i++)
        {
            row1 = table1.NewRow();
            row1["Time"] = wyniki[i, 0];
            row1["Ia"] = wyniki[i, 1]; //
            row1["If"] = wyniki[i, 2]; //

            table1.Rows.Add(row1);

            row2 = table2.NewRow();
            row2["Time"] = wyniki[i, 0];
            row2["ω"] = wyniki[i, 3]; // 4 kat; 5 nap; 6 nap wzbudzenie; 
            row2["Text"] = wyniki[i, 7]; //
            row2["Telem"] = wyniki[i, 8]; //

            table2.Rows.Add(row2);


        }
        dView1 = new DataView(table1);
        //--

        Chart1.Series.Clear();
        Chart1.ChartAreas.Add("Wykres01");
        //--
        Chart1.DataBindTable(dView1, "Time");
        Chart1.Width = 900;
        Chart1.Height = 750;

        //Chart3.Series["Voltage"].ChartType = SeriesChartType.Line;
        
            Chart1.Series["Ia"].ChartType = SeriesChartType.Spline;
            Chart1.Series["Ia"].BorderWidth = 3;//grubosc wykresu
        


            Chart1.Series["If"].ChartType = SeriesChartType.Spline;
            Chart1.Series["If"].BorderWidth = 3;//grubosc wykresu
            Chart1.ChartAreas["ChartArea1"].AxisY2.Enabled = AxisEnabled.True;
            Chart1.Series["If"].YAxisType = AxisType.Secondary;

        //Chart1.ChartAreas[0].AxisX.LineWidth = 2;
        Chart1.ChartAreas[0].AxisX.Minimum = tmin;
        //Chart1.ChartAreas[0].AxisX.Maximum = (double)table.Rows[size]["Time"];
        //Chart1.ChartAreas[0].AxisY.Minimum = 0.0;
        Chart1.ChartAreas[0].AxisY.ArrowStyle = AxisArrowStyle.Lines;//strzałki wykresu
        //Chart1.ChartAreas[0].AxisX.ArrowStyle = AxisArrowStyle.Lines;
        Chart1.ChartAreas[0].AxisY2.ArrowStyle = AxisArrowStyle.Lines;
        Chart1.ChartAreas[0].AxisY2.Minimum = 0.0;
        Chart1.ChartAreas[0].AxisY2.Maximum = 2.4;
        Chart1.ChartAreas[0].AxisX.LabelStyle.Format = "{#0.###}";
        Chart1.ChartAreas[0].AxisX.Title = "Czas [s]";
        Chart1.ChartAreas[0].AxisY.Title = "Prąd twornika [A]";
        Chart1.ChartAreas[0].AxisY2.Title = "Prąd wzbudzenia [A]";
        Chart1.ChartAreas[0].AxisX.TitleFont = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold);
        Chart1.ChartAreas[0].AxisY.TitleFont = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold);
        Chart1.ChartAreas[0].AxisY2.TitleFont = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold); 

        //Drugi WYKRES

        dView2 = new DataView(table2);
        //--

        Chart2.Series.Clear();
        Chart2.ChartAreas.Add("Wykres04");
        //--

        Chart2.DataBindTable(dView2, "Time");
        Chart2.Width = 900;
        Chart2.Height = 750;

        


            Chart2.Series["ω"].ChartType = SeriesChartType.Line;
            Chart2.Series["ω"].BorderWidth = 3;//grubosc wykresu
            Chart2.ChartAreas["ChartArea1"].AxisY2.Enabled = AxisEnabled.True;
            Chart2.Series["ω"].YAxisType = AxisType.Secondary;



           Chart2.Series["Text"].ChartType = SeriesChartType.Line;
           Chart2.Series["Text"].BorderWidth = 3;//grubosc wykresu


            Chart2.Series["Telem"].ChartType = SeriesChartType.Line;
            Chart2.Series["Telem"].BorderWidth = 3;//grubosc wykresu
        


        //Chart1.ChartAreas[0].AxisX.LineWidth = 2;
        Chart2.ChartAreas[0].AxisX.Minimum = tmin;
        //Chart1.ChartAreas[0].AxisX.Maximum = (double)table.Rows[size]["Time"];
        //Chart1.ChartAreas[0].AxisY.Minimum = 0.0;
        Chart2.ChartAreas[0].AxisY.ArrowStyle = AxisArrowStyle.Lines;//strzałki wykresu
        Chart2.ChartAreas[0].AxisY2.ArrowStyle = AxisArrowStyle.Lines;
        //Chart4.ChartAreas[0].AxisX.ArrowStyle = AxisArrowStyle.Lines;
        //Chart4.ChartAreas[0].AxisY2.Minimum = 0.0;
        //Chart4.ChartAreas[0].AxisY2.Maximum = 110.0;
        Chart2.ChartAreas[0].AxisY2.Title = "prędkość kątowa [rad/s]";
        Chart2.ChartAreas[0].AxisX.LabelStyle.Format = "{#0.###}";
        Chart2.ChartAreas[0].AxisX.Title = "Czas [s]";
        Chart2.ChartAreas[0].AxisY.Title = "Moment [Nm]";
        Chart2.ChartAreas[0].AxisX.TitleFont = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold);
        Chart2.ChartAreas[0].AxisY.TitleFont = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold);
        Chart2.ChartAreas[0].AxisY2.TitleFont = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Bold);

    }
}