using System.Diagnostics;

namespace Calculator
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private double accumulator = 0;
        private double operand = 0;
        private string operation = "";
        private string totalVal = "";
        private bool Isnegative = false;


        private void NumberButton(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string val = totalVal + button.Text;
            totalVal = val;

            if (Isnegative == false)
            {
                operand = Convert.ToDouble(totalVal);
            }
            else
            {
                operand = -Convert.ToDouble(totalVal);
            }

            EntryCalculations.Text = EntryCalculations.Text + button.Text;
            
            EntryResult.Text = Convert.ToString(operand);
        }


        private void OperatorButton(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            

            if (operation != "")
            {
                string text = button.Text;
                MultibleOperators(text);
            }
            else
            {
                accumulator = operand;
                operand = 0;
                operation = button.Text;
                totalVal = "";
            }

            
            Isnegative = false;
            EntryCalculations.Text = EntryCalculations.Text + $" {operation} ";
            EntryResult.Text = Convert.ToString(operand);
        }

        private void MultibleOperators(string text)
        {
            switch (operation)
            {
                case "+":
                    accumulator += operand;
                    break;
                case "-":
                    accumulator -= operand;
                    break;
                case "*":
                    accumulator *= operand;
                    break;
                case "/":
                    if (operand == 0) // Hantera division med noll
                    {
                        DisplayAlert("Fel!", "Division med noll är ej tillåtet.", "OK");
                        Clear();
                        return;
                    }
                    accumulator /= operand;
                    break;
            }
            operand = 0;
            operation = text;
        }


        private void EqualButton(object sender, EventArgs e)
        {
            Calculate();

            EntryResult.Text = accumulator.ToString();
            EntryCalculations.Text = accumulator.ToString();

            operation = "";
            operand = 0;
        }


        private void Calculate()
        {
            switch (operation)
            {
                case "+":
                    accumulator += operand;
                    break;
                case "-":
                    accumulator -= operand;
                    break;
                case "*":
                    accumulator *= operand;
                    break;
                case "/":
                    if (operand == 0) // Hantera division med noll
                    {
                        DisplayAlert("Fel!", "Division med noll är ej tillåtet.", "OK");
                        Clear();
                        return;
                    }
                    accumulator /= operand;
                    break;
            }

            operand = 0;
        }
        private void NegativeValue(object sender, EventArgs e)
        {
            double posval = 0;
            if (Isnegative == false)
            {
                posval = operand;
                operand = -operand;
                Isnegative = true;
            }
            else
            {
                operand = Math.Abs(operand);
                Isnegative = false;
            }
            EntryResult.Text = operand.ToString();
        }
        private void PressedOnButton(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.BackgroundColor = Colors.DimGray;
        }
        private void ReleaseButton(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.BackgroundColor = Colors.LightGray;
        }
        private void ClearButton(object sender, EventArgs e)
        {
            Clear();
        }

        private void Clear()
        {
            accumulator = 0;
            operand = 0;
            operation = "";
            EntryCalculations.Text = "";
            EntryResult.Text = "0";
            totalVal = "";
        }

        private void StoreInMemoryButton(object sender, EventArgs e)
        {
            EntryCalculations.Text = "Kommande funktion";
        }

        private void CatchFromMemoryButton(object sender, EventArgs e)
        {
            EntryCalculations.Text = "Kommande funktion";
        }

    }
}
