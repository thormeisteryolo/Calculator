namespace Calculator
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private void NumberButtons(object sender, EventArgs e)
        { 
           Button button = (Button)sender;

           EntryResult.Text += button.Text;
        }

        private void OperatorButtons(object sender, EventArgs e) 
        {
        Button button = ( Button )sender; 

        EntryCalculations.Text += button.Text;
        }
    }
}
