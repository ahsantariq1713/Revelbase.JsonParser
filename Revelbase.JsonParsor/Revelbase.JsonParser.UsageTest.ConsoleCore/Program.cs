﻿
using Revelbase.JsonParser.Core;
using System;
using System.Linq;

namespace Revelbase.JsonParser.UsageTest.ConsoleCore
{
    class Program
    {
        static void Main(string[] args)
        {
        Start:
            Job();

            Console.WriteLine("Press Y to restart or any other key to abort");
            if (Console.ReadKey().Key == ConsoleKey.Y)
            {
                goto Start;
            }
        }

        static void Job()
        {
            Console.Clear();
            Console.WriteLine("Json Parser Usage Test!");
            Console.WriteLine("Please paste file path here");
            var path = Console.ReadLine();
            try
            {
                var parser = JParser.New(path);
                var choices = parser.GetChoices();

                long sr = 0;
                var startTime = DateTime.Now;
                foreach (var choice in choices)
                {
                    if (choice.Weighting == "-1")
                    {
                        Console.WriteLine(
                       $"Record # {++sr} ---------------------------------------------------------------------\n" +
                       $"{nameof(Choice.ID)}:{choice.ID}\n" +
                       $"{nameof(Choice.Weighting)}:{choice.Weighting}\n" +
                       $"{nameof(Choice.Groups)}:{choice.Groups}\n" +
                       $"{nameof(Choice.EventName)}:{choice.EventName}\n" +
                       $"{nameof(Choice.ChoiceName)}:{choice.ChoiceName}\n" +
                       $"{nameof(Choice.OutcomeName)}:{choice.OutcomeName}\n" +
                       $"{nameof(Choice.OutcomeNextGroup)}:{choice.OutcomeNextGroup}\n" +
                       $"{nameof(Choice.OutcomeAddCards)}:{choice.OutcomeAddCards}\n" +
                       $"{nameof(Choice.ChoiceName1)}:{choice.ChoiceName1}\n" +
                       $"{nameof(Choice.OutcomeName1)}:{choice.OutcomeName1}\n" +
                       $"{nameof(Choice.OutcomeNextGroup1)}:{choice.OutcomeNextGroup1}\n" +
                       $"{nameof(Choice.OutcomeAddCards1)}:{choice.OutcomeAddCards1}\n"
                       );
                        Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++");
                        foreach (var c in choices.Where(a=> {
                            try
                            {
                                return a.OutcomeAddCards.Contains(choice.ID) || a.OutcomeAddCards1.Contains(choice.ID);
                            }
                            catch (Exception)
                            {

                                return false;
                            }
                        }))
                        {
                                Console.WriteLine(
                         $"{nameof(Choice.ID)}:{c.ID}\n" +
                         $"{nameof(Choice.Weighting)}:{c.Weighting}\n" +
                         $"{nameof(Choice.Groups)}:{c.Groups}\n" +
                         $"{nameof(Choice.EventName)}:{c.EventName}\n" +
                         $"{nameof(Choice.ChoiceName)}:{c.ChoiceName}\n" +
                         $"{nameof(Choice.OutcomeName)}:{c.OutcomeName}\n" +
                         $"{nameof(Choice.OutcomeNextGroup)}:{c.OutcomeNextGroup}\n" +
                         $"{nameof(Choice.OutcomeAddCards)}:{c.OutcomeAddCards}\n" +
                         $"{nameof(Choice.ChoiceName1)}:{c.ChoiceName1}\n" +
                         $"{nameof(Choice.OutcomeName1)}:{c.OutcomeName1}\n" +
                         $"{nameof(Choice.OutcomeNextGroup1)}:{c.OutcomeNextGroup1}\n" +
                         $"{nameof(Choice.OutcomeAddCards1)}:{c.OutcomeAddCards1}\n"
                         );
                            }

                        }
                }
                    var endTime = DateTime.Now;
                    var span = endTime - startTime;

                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.White;

                    Console.WriteLine($"{sr} records found");
                    Console.WriteLine("{0:N1} seconds taken to deserialize json data", span.TotalSeconds);

                    Console.ResetColor();
                }
            catch (Exception ex)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(ex.Message);
                Console.ResetColor();

            }
        }
    }
}
