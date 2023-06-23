using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CalculatorController : MonoBehaviour
{
    public TextMeshProUGUI displayText;
    private string currentNumber;
    private float result;
    private string currentOperation;
    private bool decimalPressed;

    private void Start()
    {
        ClearCalculation();
    }

    public void EnterDigit(string value)
    {
        if (value == "+" || value == "-" || value == "*" || value == "/")
        {
            SetOperation(value);
        }
        else if (value == "=")
        {
            CalculateResult();
        }
        else if (value == "C")
        {
            ClearCalculation();
        }
        else if (value == ".")
        {
            AddDecimal();
        }
        else
        {
            AddDigit(value);
        }
    }

    private void AddDigit(string digit)
    {
        currentNumber += digit;
        UpdateDisplay();
    }

    private void AddDecimal()
    {
        if (!decimalPressed)
        {
            currentNumber += ".";
            decimalPressed = true;
            UpdateDisplay();
        }
    }

    private void SetOperation(string operation)
    {
        currentOperation = operation;
        float.TryParse(currentNumber, out result);
        currentNumber = "";
        decimalPressed = false;
    }

    private void CalculateResult()
    {
        float operand;
        float.TryParse(currentNumber, out operand);

        switch (currentOperation)
        {
            case "+":
                result += operand;
                break;
            case "-":
                result -= operand;
                break;
            case "*":
                result *= operand;
                break;
            case "/":
                result /= operand;
                break;
        }

        currentNumber = result.ToString();
        currentOperation = "";
        decimalPressed = false;
        UpdateDisplay();
    }

    private void ClearCalculation()
    {
        currentNumber = "";
        result = 0;
        currentOperation = "";
        decimalPressed = false;
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        displayText.text = currentNumber;
    }
}
