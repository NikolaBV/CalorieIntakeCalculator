using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CalorieIntakeCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void ButtonCalculate_Click(object sender, RoutedEventArgs e)
        {
            /*
             To do:
            1. Validate user input in textboxes and combobox //DONE
            2. Add try catch blocks in case of an exception //DONE
            3. Add a weight gain section with more textblocks like the maintaining and loosing one //DONE
            4. Add clear button functionality //DONE
            5. Improve design //DONE
            6. Make textboxse for results non-changable by the user //DONE
            7. Try to round the numbers in the result texboxes (maybe with Math.Floor())
             */
            double bmr;
            try
            {
                if (string.IsNullOrEmpty(txtBoxAge.Text) || string.IsNullOrEmpty(txtboxHeightInCm.Text) || string.IsNullOrEmpty(txtboxWeightInKg.Text))
                {
                    MessageBox.Show("Please enter required information!");
                }
                else
                {
                    if (rbMale.IsChecked == true)
                    {
                        bmr = 65.5 + (13.75 * Double.Parse(txtboxWeightInKg.Text) + (5.003 * Double.Parse(txtboxHeightInCm.Text) - (6.75 * Double.Parse(txtBoxAge.Text))));
                        switch (cbActivity.SelectedIndex)
                        {
                            case 0:
                                bmr = bmr * 1.375;
                                break;
                            case 1:
                                bmr = bmr * 1.55;
                                break;
                            case 2:
                                bmr = bmr * 1.725;
                                break;
                            case 3:
                                bmr = bmr * 1.9;
                                break;
                        }
                        FillTextBoxesForMaintainingAndLosingWeight(bmr);
                        FillTextBoxesForWaightGain(bmr);
                    }
                    else if (rbFemale.IsChecked == true)
                    {
                        bmr = 655.1 + (9.563 * Double.Parse(txtboxWeightInKg.Text) + (1.850 * Double.Parse(txtboxHeightInCm.Text) - (4.676 * Double.Parse(txtBoxAge.Text))));
                        switch (cbActivity.SelectedIndex)
                        {
                            case 0:
                                bmr = bmr * 1.375;
                                break;
                            case 1:
                                bmr = bmr * 1.55;
                                break;
                            case 2:
                                bmr = bmr * 1.725;
                                break;
                            case 3:
                                bmr = bmr * 1.9;
                                break;
                        }
                        FillTextBoxesForMaintainingAndLosingWeight(bmr);
                        FillTextBoxesForWaightGain(bmr);
                    }
                    else
                    {
                        MessageBox.Show("Incorrect input");
                    }
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Incorrect format! Check your info again.");
            }
        }
        private void FillTextBoxesForMaintainingAndLosingWeight(double bmr)
        {
            tbMaintainWeight.Text = Math.Floor(bmr).ToString();
            tbMildWeightLoss.Text = (Math.Floor(bmr * 0.88).ToString());
            tbWeightLoss.Text = (Math.Floor(bmr * 0.75).ToString());
            tbExtremeWeightLoss.Text = (Math.Floor(bmr * 0.50).ToString());
        }
        private void FillTextBoxesForWaightGain(double bmr)
        {
            tbMildWeightGain.Text = (Math.Floor(bmr * 1.12).ToString());
            tbWeightGain.Text = (Math.Floor(bmr * 1.25).ToString());
            tbFastWeightGain.Text = (Math.Floor(bmr * 1.50).ToString());
        }
        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBoxAge.Text) || !string.IsNullOrEmpty(txtboxHeightInCm.Text) || !string.IsNullOrEmpty(txtboxWeightInKg.Text) || !string.IsNullOrEmpty(tbMaintainWeight.Text) || !string.IsNullOrEmpty(tbMaintainWeight.Text) || !string.IsNullOrEmpty(tbMildWeightLoss.Text) || !string.IsNullOrEmpty(tbWeightLoss.Text) || !string.IsNullOrEmpty(tbExtremeWeightLoss.Text) || rbFemale.IsChecked == true || rbMale.IsChecked == true || !string.IsNullOrEmpty(tbMildWeightGain.Text) || !string.IsNullOrEmpty(tbWeightGain.Text) || !string.IsNullOrEmpty(tbFastWeightGain.Text) || !string.IsNullOrEmpty(cbActivity.Text))
            {
                txtBoxAge.Clear();
                txtboxHeightInCm.Clear();
                txtboxWeightInKg.Clear();
                tbMaintainWeight.Clear();
                tbMildWeightLoss.Clear();
                tbWeightLoss.Clear();
                tbExtremeWeightLoss.Clear();
                tbMildWeightGain.Clear();
                tbWeightGain.Clear();
                tbFastWeightGain.Clear();
                rbFemale.IsChecked = false;
                rbMale.IsChecked = false;
                cbActivity.SelectedIndex = -1;

            }
        }
    }
}
