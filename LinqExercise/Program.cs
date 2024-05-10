using System;
using System.Collections.Generic;
using System.Linq;
namespace LinqExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            //You can get the trainee details from the GetTraineeDetails() method in TraineeData class
            TraineeData traineeData = new TraineeData();
            List<TraineeDetails> traineeList = traineeData.GetTraineeDetails();

            Console.WriteLine(" 1 - To Show the list of Trainee Id");
            Console.WriteLine(" 2 - To Show the first 3 Trainee Id using Take");
            Console.WriteLine(" 3 - To show the last 2 Trainee Id using Skip");
            Console.WriteLine(" 4 - To show the count of Trainee");
            Console.WriteLine(" 5 - To show the Trainee Name who are all passed out 2019 or later");
            Console.WriteLine(" 6 - To show the Trainee Id and Trainee Name by alphabetic order of the trainee name.");
            Console.WriteLine(" 7 - To show the Trainee Id, Trainee Name, Topic Name, Exercise Name and Mark who are all scores the more than or equal to 4 mark");
            Console.WriteLine(" 8 - To show the unique passed out year using distinct");
            Console.WriteLine(" 9 - To show the total marks of single user (get the Trainee Id from User), if Trainee Id does not exist, show the invalid message");
            Console.WriteLine(" 10 - To show the first Trainee Id and Trainee Name");
            Console.WriteLine(" 11 - To show the last Trainee Id and Trainee Name");
            Console.WriteLine(" 12 - To print the total score of each trainee");
            Console.WriteLine(" 13 - To show the maximum total score");
            Console.WriteLine(" 14 - To show the minimum total score");
            Console.WriteLine(" 15 - To show the average of total score");
            Console.WriteLine(" 16 - To show true or false if any one has the more than 40 score using any()");
            Console.WriteLine(" 17 - To show true of false if all of them has the more than 20 using all()");
            Console.WriteLine(" 18 - To show the Trainee Id, Trainee Name, Topic Name, Exercise Name and Mark by show the Trainee Name as descending order and then show the Mark as descending order.");

            System.Console.WriteLine("Enter the choice ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Trainee Ids:");
                    foreach (var trainee in traineeList)
                    {
                        System.Console.WriteLine(trainee.TraineeId);
                    }
                    break;
                case 2:
                    Console.WriteLine("First 3 Trainee Ids:");
                    foreach (var trainee in traineeList.Take(3))
                    {
                        System.Console.WriteLine(trainee.TraineeId);
                    }
                    break;
                case 3:
                    Console.WriteLine("Last 2 Trainee Ids:");
                    foreach (var trainee in traineeList.Skip(traineeList.Count - 2))
                    {
                        Console.WriteLine(trainee.TraineeId);
                    }
                    break;
                case 4:
                    System.Console.WriteLine($"Count of Trainees: {traineeList.Count}");
                    break;
                case 5:
                    Console.WriteLine("Trainee Names who passed out in 2019 or later:");
                    var result = traineeList.Where(Passed => Passed.YearPassedOut >= 2019);
                    foreach (var trainee in result)
                    {
                        System.Console.WriteLine(trainee.TraineeName);
                    }
                    break;
                case 6:
                    System.Console.WriteLine("Trainee Id and Name by alphabetical order of Name:");
                    foreach (var trainee in traineeList.OrderBy(Alphabetical => Alphabetical.TraineeName))
                    {
                        Console.WriteLine($"{trainee.TraineeId} - {trainee.TraineeName}");
                    }
                    break;
                case 7:
                    Console.WriteLine("Trainee Id, Trainee Name, Topic Name, Exercise Name, and Mark where Mark >= 4:");
                    foreach (var trainee in traineeList.SelectMany(traine => traine.ScoreDetails.Where(mark => mark.Mark >= 4).Select(s => new { traine.TraineeId, traine.TraineeName, s.TopicName, s.ExerciseName, s.Mark })))
                    {
                        Console.WriteLine($"{trainee.TraineeId} - {trainee.TraineeName} - {trainee.TopicName} - {trainee.ExerciseName} - {trainee.Mark}");
                    }
                    break;
                case 8:
                    //Press 8 to show the unique passed out year using distinct
                    Console.WriteLine("Unique passed out years:");
                    var result1 = traineeList.Select(t => t.YearPassedOut).Distinct();
                    foreach (var year in result1)
                    {
                        Console.WriteLine(year);
                    }
                    break;
                case 9:
                    // show the total marks of single user (get the Trainee Id from User), 
                    Console.WriteLine("Enter Trainee Id:");
                    string traineeId = Console.ReadLine();
                    var selectedTrainee = traineeList.FirstOrDefault(t => t.TraineeId == traineeId);
                    if (selectedTrainee != null)
                    {
                        int totalScore1 = selectedTrainee.ScoreDetails.Sum(s => s.Mark);
                        Console.WriteLine($"Total Score of {selectedTrainee.TraineeName}: {totalScore1}");
                    }
                    else
                    {
                        //if Trainee Id does not exist, show the invalid message
                        Console.WriteLine("Invalid Trainee Id");
                    }
                    break;
                case 10:
                    //show the first Trainee Id and Trainee Name
                    var firstTrainee = traineeList.First();
                    Console.WriteLine($"First Trainee Id: {firstTrainee.TraineeId}, Name: {firstTrainee.TraineeName}");
                    break;
                case 11:
                    //show the last Trainee Id and Trainee Name
                    var lastTrainee = traineeList.Last();
                    Console.WriteLine($"Last Trainee Id: {lastTrainee.TraineeId}, Name: {lastTrainee.TraineeName}");
                    break;
                case 12:
                    //print the total score of each trainee
                    Console.WriteLine("Total Score of each trainee:");
                    foreach (var trainee in traineeList)
                    {
                        int total = trainee.ScoreDetails.Sum(s => s.Mark);
                        Console.WriteLine($"{trainee.TraineeName}: {total}");
                    }
                    break;
                case 13:
                    // to show the maximum total score
                    int maxTotalScore = traineeList.Max(td => td.ScoreDetails.Sum(sum => sum.Mark));
                    System.Console.WriteLine(maxTotalScore);
                    break;
                case 14:
                    // to show the minimum total score
                    int minTotalScore = traineeList.Min(td => td.ScoreDetails.Sum(sum => sum.Mark));
                    System.Console.WriteLine(minTotalScore);
                    break;
                case 15:
                    //average
                    double average = traineeList.Average(td => td.ScoreDetails.Sum(sum => sum.Mark));
                    System.Console.WriteLine(average);
                    break;
                case 16:
                    //to show true or false if any one has the more than 40 score using any()
                    bool hasMoreThan40 = traineeList.Any(td => td.ScoreDetails.Sum(ts => ts.Mark) > 40);
                    Console.WriteLine($"Person who attains more than 40 : {hasMoreThan40}");
                    break;
                case 17:
                    //to show true or false if any one has the more than 40 score using any()
                    bool hasMoreThan20 = traineeList.All(td => td.ScoreDetails.Sum(ts => ts.Mark) > 20);
                    Console.WriteLine($"Person who attains more than 20 : {hasMoreThan20}");
                    break;
                case 18:
                    var descendingOrder = traineeList.SelectMany(t => t.ScoreDetails.Select(s => new { t.TraineeId, t.TraineeName, s.TopicName, s.ExerciseName, s.Mark })).OrderByDescending(t => t.TraineeName).ThenByDescending(s => s.Mark);
                    Console.WriteLine("Trainee Id, Trainee Name, Topic Name, Exercise Name, and Mark by descending order of Name and Mark:");
                    foreach (var item in descendingOrder)
                    {
                        Console.WriteLine($"{item.TraineeId,-10} - {item.TraineeName,-20} - {item.TopicName,-20} - {item.ExerciseName,-20} - {item.Mark,-10}");
                    }
                    break;
                default:
                    Console.WriteLine("Invalid choice!");
                    break;
            }
        }
    }
}

