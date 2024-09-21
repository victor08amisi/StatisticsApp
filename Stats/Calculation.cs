namespace Lab1;
using System.Collections.Generic;
using System.Linq;
using System;

public class Calculation
{
    
    //Method to get the max value

    public double MaxNum(List<string> userInputs)
    {
        var maxValue = double.MinValue;

        foreach (var item in userInputs)
        {
            var currentItem = double.TryParse(item, out var number);
            if (number > maxValue)
            {
                maxValue = number;
            }
            
        }
        return maxValue;
    }
    
    public  double MinNum(List<string> userInputs)
    {
        var minValue = double.MaxValue;

        foreach (var item in userInputs)
        {
            var currentItem = double.TryParse(item, out var number);
            if (number < minValue)
            {
                minValue = number;
            }
            
        }
        return minValue;
    }
    
    public  double TotalNum(List<string> userInputs)
    {
        var totalValue = 0.0;

        foreach (var item in userInputs)
        {
            var currentItem = double.TryParse(item, out var number);
            totalValue += number;

        }
        return totalValue;
    }
    
    public  double AvgNum(List<string> userInputs, double validcount)
    {
        var avgValue = 0.0;

        foreach (var item in userInputs)
        {
            var currentItem = double.TryParse(item, out var number);
            avgValue += number;

        }

        return avgValue / validcount;
    }
 
    
    /*
     *This function will check if a user entered
     * a non Numeric number and will return true or false
     * if there's even 1 non alpha numeric number
     */
    public bool IsValidNum(string userInput)
    {
        return double.TryParse(userInput, out _);
    }
    /*
     *This function will check if the user entered
     * entered two or more numbers
     * It will return true or false based on that
     */
    public double MoreThanTwo(List<string> userInputs)
    {
        var cnt = 0.0;
        foreach (var userItem in userInputs)
        {
            double parsedValue;
            if (double.TryParse(userItem, out parsedValue))
            {
                cnt++;
            }
        }
        return cnt ;
    }

}