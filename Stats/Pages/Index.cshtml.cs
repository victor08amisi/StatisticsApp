using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Lab1;
namespace Stats.Pages;


public class IndexModel : PageModel

{
    [BindProperty]
    public string? First { get; set; }
    [BindProperty]
    public string? Second { get; set; }
    [BindProperty]
    public string? Third { get; set; }
    [BindProperty]
    public string? Fourth { get; set; }
    //Error codes properties
    [BindProperty]
    public string? FirstAlert { get; set; }
    
    [BindProperty]
    public string? SecondAlert { get; set; }
    
    [BindProperty]
    public string? ThirdAlert { get; set; }
    
    [BindProperty]
    public string? FourthAlert { get; set; }
    
    [BindProperty] 
    public string? BottomAlert { get; set; }
    
    [BindProperty] 
    public string? ResultAlert { get; set; }
    
    [BindProperty] 
    public string? Max { get; set; }
    
    [BindProperty] 
    public string? Min { get; set; }
    
    [BindProperty] 
    public string? Total { get; set; }

    [BindProperty] 
    public string? Avg { get; set; }
    


    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }
    private Calculation _calc = new Calculation(); 
    
    public void OnGet()
    {
        FirstAlert = "";
        SecondAlert = "";
        ThirdAlert = "";
        FourthAlert = "";
        BottomAlert = "";
        ResultAlert = "";
    }

    public void OnPost()
    {
        var userInputData = new List<string>() { First, Second, Third, Fourth };
        var filteredResults = new List<double>();
        var allValidNumber = true;
        var moreThanTwoNum = 0.0;
        
        //********************
        //Check if we found any non numeric numbers
        //********************
        if (_calc.IsValidNum(First) == false && !string.IsNullOrEmpty(First))
        {
            FirstAlert = "Must enter a numeric number";
            allValidNumber = false;
        }
        //********************
        if (_calc.IsValidNum(Second) == false && !string.IsNullOrEmpty(Second))
        {
            SecondAlert = "Must enter a numeric number";
            allValidNumber = false;
        }
        //********************
        if (_calc.IsValidNum(Third) == false && !string.IsNullOrEmpty(Third))
        {         
            ThirdAlert = "Must enter a numeric number";
            allValidNumber = false;
        }
        //********************
        if (_calc.IsValidNum(Fourth) == false && !string.IsNullOrEmpty(Fourth))
        {         
            FourthAlert = "Must enter a numeric number";
            allValidNumber = false;
        }
        
        //********************
        //Count the valid numbers that we have
        moreThanTwoNum = _calc.MoreThanTwo(userInputData);
        if (moreThanTwoNum < 2)
        {
            BottomAlert = "You must enter at least 2 numbers, No statistics were calculated!";
        }
        if (moreThanTwoNum >= 2 && allValidNumber)
        {
            Max = $"{_calc.MaxNum(userInputData)}";
            Min = $"{_calc.MinNum(userInputData)}";
            Total = $"{_calc.TotalNum(userInputData):F2}";
            Avg = $"{_calc.AvgNum(userInputData, moreThanTwoNum):F2}";
            ResultAlert = $" You entered {moreThanTwoNum} numbers. The following are their statistics" +"\n"+
                          $"Maximum: {Max} | Minimum: {Min} | Total: {Total} | Average: {Avg} |";
        }
    }
}