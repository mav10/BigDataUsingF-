//
// F# library to analyze Chicago crime data
// C# (GUI setup) file
// Dhrumil Patel
// U. of Illinois, Chicago
// CS341, Spring 2016
// Homework 6
//

using System;
using System.Windows.Forms;


namespace ChicagoCrime
{
  public partial class Form1 : Form
  {
     public Form1()
    {
      InitializeComponent();
    }

    private bool doesFileExist(string filename)
    {
      if (!System.IO.File.Exists(filename))
      {
        string msg = string.Format("Input file not found: '{0}'",
          filename);

        MessageBox.Show(msg);
        return false;
      }

      // exists!
      return true;
    }

    private void clearForm()
    {
      // 
      // if a chart is being displayed currently, remove it:
      //
      if (this.graphPanel.Controls.Count > 0)
      {
        this.graphPanel.Controls.RemoveAt(0);
        this.graphPanel.Refresh();
      }
    }

    private void cmdByYear_Click(object sender, EventArgs e)
    {
      string filename = this.txtFilename.Text;

      if (!doesFileExist(filename))
        return;

      clearForm();

      //
      // Call over to F# code to analyze data and return a 
      // chart to display:
      //
      this.Cursor = Cursors.WaitCursor;

      var chart = FSAnalysis.CrimesByYear(filename);

      this.Cursor = Cursors.Default;

      //
      // we have chart, display it:
      //
      this.graphPanel.Controls.Add(chart);
      this.graphPanel.Refresh();
    }

        private void CrimesvsArrests_Click(object sender, EventArgs e)
        {
            string filename = this.txtFilename.Text;

            if (!doesFileExist(filename))
                return;

            clearForm();

            //
            // Call over to F# code to analyze data and return a 
            // chart to display:
            //
            this.Cursor = Cursors.WaitCursor;

            var chart = FSAnalysis.ArrestByYear(filename);

            this.Cursor = Cursors.Default;

            //
            // we have chart, display it:
            //
            this.graphPanel.Controls.Add(chart);
            this.graphPanel.Refresh();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string filename = this.txtFilename.Text;

            if (!doesFileExist(filename))
                return;

            clearForm();

            //
            // Call over to F# code to analyze data and return a 
            // chart to display:
            //
            this.Cursor = Cursors.WaitCursor;
            String crimeCode = textBox1.Text;
            var chart = FSAnalysis.numCrimeByCode(filename, crimeCode);

            this.Cursor = Cursors.Default;

            //
            // we have chart, display it:
            //
            this.graphPanel.Controls.Add(chart);
            this.graphPanel.Refresh();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        { }

        private void byArea_Click(object sender, EventArgs e)
        {
            string filename = this.txtFilename.Text;

            if (!doesFileExist(filename))
                return;

            clearForm();

            //
            // Call over to F# code to analyze data and return a 
            // chart to display:
            //
            this.Cursor = Cursors.WaitCursor;
            String areaCode = textBox2.Text;
            var chart = FSAnalysis.numCrimeByArea(filename, areaCode);

            this.Cursor = Cursors.Default;

            //
            // we have chart, display it:
            //
            this.graphPanel.Controls.Add(chart);
            this.graphPanel.Refresh();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        { }

        private void chicago_Click(object sender, EventArgs e)
        {
            string filename = this.txtFilename.Text;

            if (!doesFileExist(filename))
                return;

            clearForm();

            //
            // Call over to F# code to analyze data and return a 
            // chart to display:
            //
            this.Cursor = Cursors.WaitCursor;
            String areaCode = textBox2.Text;
            var chart = FSAnalysis.CrimeByArea(filename);

            this.Cursor = Cursors.Default;

            //
            // we have chart, display it:
            //
            this.graphPanel.Controls.Add(chart);
            this.graphPanel.Refresh();
        }
    }//class
}//namespace
