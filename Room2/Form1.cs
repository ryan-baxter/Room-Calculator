using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Room2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Validation Checks
        private new bool Validate()
        {
            //Validation Variables
            int allowedChars;
            string lengthText = txtLength.Text;
            string widthText = txtWidth.Text;
            string heightText = txtHeight.Text;
            string measureText = cboMeasure.Text;

            //Length Check
            if (string.IsNullOrEmpty(lengthText))
            {
                MessageBox.Show("Please enter the length of the room", "Length Error");
                return false;
            }

            if (!int.TryParse(lengthText, out allowedChars))
            {
                MessageBox.Show("Please enter only numbers", "Length Error");
                return false;
            }

            //Width Check
            if (string.IsNullOrEmpty(widthText))
            {
                MessageBox.Show("Please enter the width of the room", "Width Error");
                return false;
            }

            if (!int.TryParse(widthText, out allowedChars))
            {
                MessageBox.Show("Please enter only numbers", "Width Error");
                return false;
            }

            //Height Check
            if (string.IsNullOrEmpty(heightText))
            {
                MessageBox.Show("Please enter the height of the room", "Height Error");
                return false;
            }

            if (!int.TryParse(heightText, out allowedChars))
            {
                MessageBox.Show("Please enter only numbers", "Height Error");
                return false;
            }

            //Measurement Check
            if (string.IsNullOrEmpty(measureText))
            {
                MessageBox.Show("Please enter the measurement of the room", "Measurement Error");
                return false;
            }

            if (cboMeasure.Text.Contains("Feet"))
            {
                return true;
            }
            else if (cboMeasure.Text.Contains("Yards"))
            {
                return true;
            }
            else
            {
                MessageBox.Show("Please select either Feet or Yards", "Measurement Error");
                return false;
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            //Clear Previous Calculations
            lstResults.Items.Clear();

            //Room Measurements & Area/Volume
            int length;
            int width;
            int height;
            int area;
            int volume;

            //To Calculate Paint
            int paintNeeded;
            int wallsValue;

            //Calculating The Area Of The Walls
            double wallsConverted;
            int lengthDouble;
            int widthDouble;
            int walls;

            //Room Measurement
            string measure;

            if(!Validate())
            {
                return;
            }

            //Convert Inputs
            length = Convert.ToInt32(txtLength.Text);
            width = Convert.ToInt32(txtWidth.Text);
            height = Convert.ToInt32(txtHeight.Text);
            measure = Convert.ToString(cboMeasure.SelectedItem);

            //Check Whether 'Feet' Or 'Yards' Is Entered
            string measureArea = "";
            string measureVolume = "";

            switch (measure)
            {
                case "Feet":
                    measureArea = "Square Feet";
                    measureVolume = "Cubic Feet";
                    break;
                case "Yards":
                    measureArea = "Square Yards";
                    measureVolume = "Cubic Yards";
                    break;
            }

            //Area
            area = length * width;
            lstResults.Items.Add("The area of the floor is " + area + " " + measureArea);

            //Volume
            volume = length * width * height;
            lstResults.Items.Add("The volume of the room is " + volume + " " + measureVolume);

            //Area Of Walls
            lengthDouble = length * height * 2;
            widthDouble = width * height * 2;
            walls = lengthDouble + widthDouble;
            wallsConverted = 0;

            //Convert Feet/Yards To Meters
            switch (measure)
            {
                case "Feet":
                    wallsConverted = walls / 10.764;
                    break;
                case "Yards":
                    wallsConverted = walls / 1.1960;
                    break;
            }

            lstResults.Items.Add("The total area of the walls is " + wallsConverted + " Meters Squared");

            //Calculate Paint
            paintNeeded = 0;
            wallsValue = Convert.ToInt32(wallsConverted);

            for (int i = 0; i < wallsValue;)
            {
                paintNeeded = paintNeeded + 1;
                wallsValue = wallsValue - 10;
            }

            lstResults.Items.Add("The amount of paint needed (in Liters) is " + paintNeeded + ", " + "covering 10m²  per Liter");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
