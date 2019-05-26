using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.ComponentModel;
using System.Globalization;

namespace WpfApp1.ViewModel
{
    public class CalculatorViewModel : INotifyPropertyChanged
    {
        private String inputTextBox;
        public event PropertyChangedEventHandler PropertyChanged;
        char decimalSeparator;

        CalculatorModel calculatorModel;
        private string lastParamString;

        protected void OnPropertyChanged(string input)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(input));
            }
        }

        public String InputTextBox
        {
            get
            {
                return inputTextBox;
            }

            set
            {
                inputTextBox = value;
                OnPropertyChanged("InputTextBox");
            }
        }

        public CalculatorViewModel()
        {
            inputTextBox = "0";
            decimalSeparator = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0];
            calculatorModel = new CalculatorModel();
        }

        private CommandHandler buttonClickCommand;
        public CommandHandler ButtonClickCommand
        {
            get
            {
                return buttonClickCommand ?? (buttonClickCommand = new CommandHandler(param => ButtonClickAction(param), true));
            }
        }

        public void ButtonClickAction(object parameter)
        {
            String paramString = parameter.ToString();
            
            if(paramString == "backspace")
            {
                if (lastParamString == "+"
                    || lastParamString == "-" 
                    || lastParamString == "*" 
                    || lastParamString == "/"
                    || lastParamString == "=")
                {
                    calculatorModel.Reset();
                    InputTextBox = "0";
                }

                if (inputTextBox != "")
                    InputTextBox = inputTextBox.Remove(inputTextBox.Length - 1);

                if (inputTextBox == "")
                {
                    InputTextBox = "0";
                }
            }
            else if(paramString == "0"
                || paramString == "1"
                || paramString == "2"
                || paramString == "3"
                || paramString == "4"
                || paramString == "5"
                || paramString == "6"
                || paramString == "7"
                || paramString == "8"
                || paramString == "9"
                || paramString == ".")
            {
                if(lastParamString == "=")
                {
                    calculatorModel.Reset();
                    inputTextBox = "";
                }

                AddCharToInput(paramString[0]);

            }
            else if(paramString == "clear")
            {
                InputTextBox = "0";
                calculatorModel.Reset();
            }
            else if(paramString == "+"
                || paramString == "-"
                || paramString == "*"
                || paramString == "/"
                || paramString == "=")
            {
                double inputValue = 0;
                if (InputTextBox != "")
                {
                    inputValue = Double.Parse(InputTextBox);
                }

                calculatorModel.InputNumber(inputValue);
                calculatorModel.InputOperator(StringToOperator(paramString));

                InputTextBox = calculatorModel.GetCurrentResult().ToString();

                if (paramString != "=")
                {
                    inputTextBox = "";
                }
            }

            lastParamString = paramString;
        }

        private void AddCharToInput(char ch)
        {
            if (inputTextBox.Length > 13)
                return;

            if(InputTextBox == "0")
            {
                if (ch != '.')
                {
                    InputTextBox = "";
                    InputTextBox += ch;
                }
                else
                {
                    InputTextBox += decimalSeparator;
                }
            }
            else if (ch == '.')
            {
                if(inputTextBox.IndexOf(decimalSeparator) == -1)
                {
                    InputTextBox += decimalSeparator;
                }
            }
            else
            {
                InputTextBox += ch;
            }
        }
        private CalculatorModel.Operator StringToOperator(String input)
        {
            if (input == "=")
            {
                return CalculatorModel.Operator.OPERATOR_EQUALS;
            }
            else if (input == "+")
            {
                return CalculatorModel.Operator.OPERATOR_PLUS;
            }
            else if (input == "-")
            {
                return CalculatorModel.Operator.OPERATOR_MINUS;

            }
            else if (input == "*")
            {
                return CalculatorModel.Operator.OPERATOR_MULTIPLY;
            }
            else if (input == "/")
            {
                return CalculatorModel.Operator.OPERATOR_DIVISION;
            }
            else
                return CalculatorModel.Operator.OPERATOR_NOT_DEFINED;
        }
    }

   

    public class CommandHandler : ICommand
    {
        private Action<object> action;
        private bool canExecute;
        public CommandHandler(Action<object> action, bool canExecute)
        {
            this.action = action;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return canExecute;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            action(parameter);
        }
    }
}
