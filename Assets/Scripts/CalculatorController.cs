using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CalculatorController : MonoBehaviour
{
    public TextMeshProUGUI resultText;
    private float firstOperand;
    private float secondOperand;
    private string arithmeticOperation;

    private void Start()
    {
        firstOperand = 0;
        secondOperand = 0;
        arithmeticOperation = "";
    }

    public void EnterDigit(int number)
    {
        if (arithmeticOperation == "")
        {
           
            firstOperand = firstOperand * 10 + number;
            resultText.text = firstOperand.ToString();
        }
        else
        {
            secondOperand = secondOperand * 10 + number;
            resultText.text = secondOperand.ToString();

        }
    }

    public void EnterOperation(string op)
    {
        if (secondOperand != 0)
        {
            CalculateResult();
        }

        arithmeticOperation = op;
        resultText.text += " " + arithmeticOperation + " ";
    }

    public void CalculateResult()
    {
        float result = 0;
        switch (arithmeticOperation)
        {
            case "+":
                result = firstOperand + secondOperand;
                
                break;
            case "-":
                result = firstOperand - secondOperand;
                break;
            case "*":
                result = firstOperand * secondOperand;
                break;
            case "/":
                if (secondOperand != 0)
                {
                    result = firstOperand / secondOperand;
                }
                else
                {
                    Debug.Log("Cannot divide by zero!");
                }
                break;
        }

        firstOperand = result;
        secondOperand = 0;
        arithmeticOperation = "";
        resultText.text = result.ToString();
    }

    public void Clear()
    {
        firstOperand = 0;
        secondOperand = 0;
        arithmeticOperation = "";
        resultText.text = "0";
    }
}
