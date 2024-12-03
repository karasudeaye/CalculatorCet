using Microsoft.Maui.Controls;

namespace CalculatorCet
{
    public partial class MainPage : ContentPage
    {



        public MainPage()
        {
            InitializeComponent();
        }


        double FirstNumber;
        double Memory = 0;
        bool isFirstNumberAfterOperator = true;
        bool hasDecimal = false;
        Operator PreviousOperator = Operator.None;
        bool isOperatorJustPressed = false;


        private void SubtractButton_Clicked(object sender, EventArgs e)
        {
            DoCalculation();
            PreviousOperator = Operator.Subtract;

        }

        private void MultiplyButton_Clicked(object sender, EventArgs e)
        {
            DoCalculation();
            PreviousOperator = Operator.Multiply;
        }

        private void DivideButton_Clicked(object sender, EventArgs e)
        {
            DoCalculation();
            PreviousOperator = Operator.Divide;

        }

        private void AddButton_Clicked(object sender, EventArgs e)
        {

            DoCalculation();
            PreviousOperator = Operator.Add;

        }
        private void HandleOperatorChange(Operator newOperator)
        {
            if (isOperatorJustPressed)
            {
                PreviousOperator = newOperator; 
                return;
            }

            DoCalculation();
            PreviousOperator = newOperator;
            isOperatorJustPressed = true;
        }
        void DoCalculation()
        {

            switch (PreviousOperator)
            {
                case Operator.None:
                    FirstNumber = Double.Parse(Display.Text);
                    break;
                case Operator.Add:
                    FirstNumber = FirstNumber + Double.Parse(Display.Text);
                    break;
                case Operator.Subtract:
                    FirstNumber = FirstNumber - Double.Parse(Display.Text);

                    break;
                case Operator.Multiply:
                    FirstNumber = FirstNumber * Double.Parse(Display.Text);

                    break;
                case Operator.Divide:
                    FirstNumber = FirstNumber / Double.Parse(Display.Text);

                    break;

            }
            isFirstNumberAfterOperator = true;
            Display.Text = FirstNumber.ToString();
        }

        private void Digit_Clicked(object sender, EventArgs e)
        {
            Button digitButton = sender as Button;
            if (isFirstNumberAfterOperator || isOperatorJustPressed)
            {
                Display.Text = digitButton.Text;
                isFirstNumberAfterOperator = false;
                isOperatorJustPressed = false;
            }
            else
            {
                Display.Text += digitButton.Text;
            }

        }

        private void EqualButton_Clicked(object sender, EventArgs e)
        {
            DoCalculation();
            PreviousOperator = Operator.None;

        }
        private void DeleteButton_Clicked(object sender, EventArgs e)
        {
            if (Display.Text.Length > 1)
            {
                Display.Text = Display.Text.Substring(0, Display.Text.Length - 1);
            }
            else
            {
                Display.Text = "0";
                isFirstNumberAfterOperator = true;
            }
        }

        private void CommaButton_Clicked(object sender, EventArgs e)
        {
            if (!Display.Text.Contains(","))
            {
                if (isFirstNumberAfterOperator || string.IsNullOrEmpty(Display.Text))
                {
                    Display.Text = "0,";
                }
                else
                {
                    Display.Text += ",";
                }
                isOperatorJustPressed = false;
            }
        }

        private void MemoryStoreButton_Clicked(object sender, EventArgs e)
        {
            double currentValue;
            if (double.TryParse(Display.Text, out currentValue))
            {
                Memory = currentValue;
            }
        }
        private void MemoryRecallButton_Clicked(object sender, EventArgs e)
        {
            Display.Text = Memory.ToString();
            isFirstNumberAfterOperator = true;
        }
        private void CEButton_Clicked(object sender, EventArgs e)
        {
            Display.Text = "0";
            isFirstNumberAfterOperator = true;
        }

        private void CButton_Clicked(object sender, EventArgs e)
        {
            Display.Text = "0";
            FirstNumber = 0;
            PreviousOperator = Operator.None;
            isFirstNumberAfterOperator = true;
            hasDecimal = false;
        }
    }

}