// See https://aka.ms/new-console-template for more information

Console.WriteLine("Enter your age:");
var age = Console.ReadLine();
Console.WriteLine("Enter insurance type: LIFE/HEALTH");
var insuranceType = Console.ReadLine()!.ToUpper();
switch (insuranceType){
    case "LIFE":{
        break;
    }
    case "HEALTH":{
        break;
    }
    default:
        Console.WriteLine("Invalid insurance type");
        break;
}
