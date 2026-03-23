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
        private string totalVal = "0";
        private string snapshot = "";

        private void NumberButton(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            string val = totalVal + button.Text;  
                totalVal = val;

                if (operand >= 0)
                {
                    operand = Convert.ToDouble(totalVal);
                }
                else
                {
                    operand = -Convert.ToDouble(totalVal);
                }
            
            EntryCalculations.Text = snapshot + operand;
            
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
            snapshot = EntryCalculations.Text + operation;
            EntryCalculations.Text = snapshot + operand;
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
            totalVal = "";
        }


        private void EqualButton(object sender, EventArgs e)
        {
            Calculate();


            operation = "";
            operand = 0;
        }


        private void Calculate()
        {
            if (accumulator == 0)
            {
                EntryResult.Text = Convert.ToString(operand);
            }
            else
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
                EntryResult.Text = Convert.ToString(accumulator);
            }
            operand = 0;
        }
        private void NegativeValue(object sender, EventArgs e)
        {
            if (operand > 0)
            {
                operand = -operand;
            }
            else
            {
                operand = Math.Abs(operand);
            }
            EntryCalculations.Text = snapshot + operand;
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
           
        }

        private void CatchFromMemoryButton(object sender, EventArgs e)
        {
            EntryCalculations.Text = "Kommande funktion";
        }

    }
}
