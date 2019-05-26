using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    class CalculatorModel
    {
        public enum Operator
        {
            OPERATOR_PLUS,
            OPERATOR_MINUS,
            OPERATOR_MULTIPLY,
            OPERATOR_DIVISION,
            OPERATOR_EQUALS,
            OPERATOR_NOT_DEFINED
        };

        private double firstValue;
        private double secondValue;

        private bool isJustFirstValue;
        private bool isFirstAndSecondValue;

        private Operator currentOperator;

        public CalculatorModel()
        {
            Reset();
        }

        public void InputNumber(double number)
        {
            if (!isJustFirstValue && !isFirstAndSecondValue)
            {
                firstValue = number;
                isJustFirstValue = true;
            }
            else if(isJustFirstValue && !isFirstAndSecondValue)
            {
                secondValue = number;
                isFirstAndSecondValue = true;
            }
            else
            { 
                secondValue = number;
            }
        }

        public void InputOperator(Operator oper)
        {
            if (currentOperator != Operator.OPERATOR_NOT_DEFINED)
            {
                ExecuteOperator(currentOperator);
            }
            if (oper != Operator.OPERATOR_EQUALS)
            {
                currentOperator = oper;
            }
        }

        private void ExecuteOperator(Operator oper)
        {
            if (oper == Operator.OPERATOR_PLUS)
            {
                firstValue += secondValue;
            }
            else if (oper == Operator.OPERATOR_MINUS)
            {
                firstValue -= secondValue;
            }
            else if (oper == Operator.OPERATOR_MULTIPLY)
            {
                firstValue *= secondValue;
            }
            else if (oper == Operator.OPERATOR_DIVISION)
            {
                firstValue /= secondValue;
            }
        }

        public double GetCurrentResult()
        {
            return firstValue;
        }

        public void Reset()
        {
            firstValue = 0;
            secondValue = 0;
            isJustFirstValue = false;
            isFirstAndSecondValue = false;
            currentOperator = Operator.OPERATOR_NOT_DEFINED;
        }
    }
}
