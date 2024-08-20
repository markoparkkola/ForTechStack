using System.Diagnostics;
using ForTechStack.ResultType;

namespace ForTechStack;

internal static class OptionTypeExamples
{
    public static void Do()
    {
        /*
         * Examples how to use Option type to do away nulls altogether. This
         * prevents any possible null reference exception from occuring, and
         * especially if compiler is set to distinquish between nullable and
         * non-nullable types (i.e. compiler understands ? after type declaration).
         * 
         * Unfortunately this isn't very usable with Entity Framework. I managed
         * to write ValueConverter class and register it with EF so that it
         * knows how to handle Option<T> type properties in entity classes,
         * but it handles everything in-memory if you try to use those
         * in queries. In other words it reads everything from database to and
         * does filtering in-memory.
         */

        TestIfThereIsValueOrNot();
        TestActualValues();
        TryToUseNull();

        /*
         * Simple example of how to use Result and Option types together since
         * they are basically the same.
         */
        TestResultType();
    }

    private static void TestActualValues()
    {
        var someValue = Option.Create("I have a value");
        var someOther = Option.Create("Here's a value too for comparison");
        if (someOther == someValue)
        {
            Debug.Assert(false, "They should not match.");
        }
        else
        {
            Console.WriteLine("They do not match");
        }
    }

    static void TestIfThereIsValueOrNot()
    {
        var possiblyNull1 = Option.Create("I have a value");
        var possiblyNull2 = Option.None;

        if (possiblyNull1 == Option.Some)
        {
            // take value out of Option by
            var value = possiblyNull1.Value; // either this
            value = (string)possiblyNull1; // or this way

            Console.WriteLine("We have a value: " + value);
        }
        else
        {
            Debug.Assert(false, "Should not be here.");
        }

        if (possiblyNull2 == Option.None)
        {
            Console.WriteLine("No value");
        }
        else
        {
            Debug.Assert(false, "Should not be here.");
        }
    }

    static void TryToUseNull()
    {
        var possiblyNull = Option.Create("Buu!");
        try
        {
            if (possiblyNull == null!)
            {
                Debug.Assert(false, "Should not be here.");
            }
        }
        catch
        {
            Console.WriteLine("We end up here when we try to use nulls.");
        }
    }

    private static void TestResultType()
    {
        var result1 = GetSomeResults(true);
        var result2 = GetSomeResults(false);

        HandleResults(result1);
        HandleResults(result2);
    }

    static Result<string> GetSomeResults(bool shouldSucceed) =>
            shouldSucceed
                ? Result<string>.Success(DateTime.Now.ToString())
                : Result<string>.Failure("I'm doomed to fail.");

    static void HandleResults<T>(Result<T> result) // we lose type here but this is just an example
    {
        result
            .OnSuccess(x => Console.WriteLine(x))
            .OnFailure(x =>
            {
                if (x.HasErrorMessage)
                {
                    Console.WriteLine(x.ErrorMessage);
                }
            });
    }
}
