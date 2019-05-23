using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.ComponentModel;

namespace WpfApp1.ViewModel
{
    public class CalculatorViewModel : INotifyPropertyChanged
    {
        private String inputTextBox;
        public event PropertyChangedEventHandler PropertyChanged;

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
            previousValue = 0;
        }

        private CommandHandler buttonOneClickCommand;
        public CommandHandler ButtonOneClickCommand
        {
            get
            {
                return buttonOneClickCommand ?? (buttonOneClickCommand = new CommandHandler(() => ButtonOneClickAction(), true));
            }
        }
        
        public void ButtonOneClickAction()
        {
            AddCharToInput('1');
        }

        private CommandHandler buttonTwoClickCommand;
        public CommandHandler ButtonTwoClickCommand
        {
            get
            {
                return buttonTwoClickCommand ?? (buttonTwoClickCommand = new CommandHandler(() => ButtonTwoClickAction(), true));
            }
        }

        public void ButtonTwoClickAction()
        {
            AddCharToInput('2');
        }

        private CommandHandler buttonThreeClickCommand;
        public CommandHandler ButtonThreeClickCommand
        {
            get
            {
                return buttonThreeClickCommand ?? (buttonThreeClickCommand = new CommandHandler(() => ButtonThreeClickAction(), true));
            }
        }

        public void ButtonThreeClickAction()
        {
            AddCharToInput('3');
        }

        private CommandHandler buttonFourClickCommand;
        public CommandHandler ButtonFourClickCommand
        {
            get
            {
                return buttonFourClickCommand ?? (buttonFourClickCommand = new CommandHandler(() => ButtonFourClickAction(), true));
            }
        }

        public void ButtonFourClickAction()
        {
            AddCharToInput('4');
        }

        private CommandHandler buttonFiveClickCommand;
        public CommandHandler ButtonFiveClickCommand
        {
            get
            {
                return buttonFiveClickCommand ?? (buttonFiveClickCommand = new CommandHandler(() => ButtonFiveClickAction(), true));
            }
        }

        public void ButtonFiveClickAction()
        {
            AddCharToInput('5');
        }

        private CommandHandler buttondSixClickCommand;
        public CommandHandler ButtonSixClickCommand
        {
            get
            {
                return buttondSixClickCommand ?? (buttondSixClickCommand = new CommandHandler(() => ButtonSixClickAction(), true));
            }
        }

        public void ButtonSixClickAction()
        {
            AddCharToInput('6');
        }

        private CommandHandler buttonSevenClickCommand;
        public CommandHandler ButtonSevenClickCommand
        {
            get
            {
                return buttonSevenClickCommand ?? (buttonSevenClickCommand = new CommandHandler(() => ButtonSevenClickAction(), true));
            }
        }

        public void ButtonSevenClickAction()
        {
            AddCharToInput('7');
        }

        private CommandHandler buttonEightClickCommand;
        public CommandHandler ButtonEightClickCommand
        {
            get
            {
                return buttonEightClickCommand ?? (buttonEightClickCommand = new CommandHandler(() => ButtonEightClickAction(), true));
            }
        }

        public void ButtonEightClickAction()
        {
            AddCharToInput('8');
        }

        private CommandHandler buttonNineClickCommand;
        public CommandHandler ButtonNineClickCommand
        {
            get
            {
                return buttonNineClickCommand ?? (buttonNineClickCommand = new CommandHandler(() => ButtonNineClickAction(), true));
            }
        }

        public void ButtonNineClickAction()
        {
            AddCharToInput('9');
        }

        private CommandHandler buttonZeroClickCommand;
        public CommandHandler ButtonZeroClickCommand
        {
            get
            {
                return buttonZeroClickCommand ?? (buttonZeroClickCommand = new CommandHandler(() => ButtonZeroClickAction(), true));
            }
        }

        public void ButtonZeroClickAction()
        {
            AddCharToInput('0');
        }

        private CommandHandler buttonClearClickCommand;
        public CommandHandler ButtonClearClickCommand
        {
            get
            {
                return buttonClearClickCommand ?? (buttonClearClickCommand = new CommandHandler(() => ButtonClearClickAction(), true));
            }
        }

        public void ButtonClearClickAction()
        {
            InputTextBox = "0";
            previousValue = 0;
        }

        private CommandHandler buttonCommaClickCommand;
        public CommandHandler ButtonCommaClickCommand
        {
            get
            {
                return buttonCommaClickCommand ?? (buttonCommaClickCommand = new CommandHandler(() => ButtonCommaClickAction(), true));
            }
        }

        public void ButtonCommaClickAction()
        {
            AddCharToInput('.');
        }

        private CommandHandler buttonBackspaceClickCommand;
        public CommandHandler ButtonBackspaceClickCommand
        {
            get
            {
                return buttonBackspaceClickCommand ?? (buttonBackspaceClickCommand = new CommandHandler(() => ButtonBackspaceClickAction(), true));
            }
        }

        public void ButtonBackspaceClickAction()
        {
            InputTextBox = inputTextBox.Remove(inputTextBox.Length - 1);
            if(inputTextBox == "")
            {
                InputTextBox = "0";
            }
        }

        private CommandHandler buttonPlusClickCommand;
        public CommandHandler ButtonPlusClickCommand
        {
            get
            {
                return buttonPlusClickCommand ?? (buttonPlusClickCommand = new CommandHandler(() => ButtonPlusClickAction(), true));
            }
        }

        public void ButtonPlusClickAction()
        {
            Func<double, double, double> add = (double x, double y) => x + y;
            ButtonOperatorAction(add);
        }

        private CommandHandler buttonMinusClickCommand;
        public CommandHandler ButtonMinusClickCommand
        {
            get
            {
                return buttonMinusClickCommand ?? (buttonMinusClickCommand = new CommandHandler(() => ButtonMinusClickAction(), true));
            }
        }

        public void ButtonMinusClickAction()
        {
            Func<double, double, double> sub = (double x, double y) => x - y;
            ButtonOperatorAction(sub);
        }

        private CommandHandler buttonMultiClickCommand;
        public CommandHandler ButtonMultiClickCommand
        {
            get
            {
                return buttonMultiClickCommand ?? (buttonMultiClickCommand = new CommandHandler(() => ButtonMultiClickAction(), true));
            }
        }

        public void ButtonMultiClickAction()
        {
            Func<double, double, double> sub = (double x, double y) => x * y;
            ButtonOperatorAction(sub);
        }

        private CommandHandler buttonDivisionClickCommand;
        public CommandHandler ButtonDivisionClickCommand
        {
            get
            {
                return buttonDivisionClickCommand ?? (buttonDivisionClickCommand = new CommandHandler(() => ButtonDivisionClickAction(), true));
            }
        }

        public void ButtonDivisionClickAction()
        {
            Func<double, double, double> sub = (double x, double y) => { if (y != 0) return x / y; return 0; };
            ButtonOperatorAction(sub);
        }

        private Double previousValue;
        public void ButtonOperatorAction(Func<double, double, double> operation)
        {
            var currentValue = Double.Parse(inputTextBox);
            previousValue = operation(previousValue, currentValue);
            InputTextBox = previousValue.ToString();
            inputTextBox = "0";
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
                }
                InputTextBox += ch;
            }
            else if (ch=='.')
            {
                if(inputTextBox.IndexOf('.') == -1)
                {
                    InputTextBox += ch;
                }
            }
            else
            {
                InputTextBox += ch;
            }
        }
    }

    public class CommandHandler : ICommand
    {
        private Action action;
        private bool canExecute;
        public CommandHandler(Action action, bool canExecute)
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
            action();
        }
    }

   
}
