public static class EmployerExample
{
    public static void Do()
    {
        /*
         * Here is one scheme how to keep nulls out of service and controller layers.
         * This required a bit type checking and casting but that's a lot secure
         * manner of writing code that trying to handle all the null-cases.
         */

        var employerService = new EmployerService();
        var allEmployers = employerService.GetAllEmployers();


        // Btw. one way to get gone employers
        var goners = allEmployers.OfType<NotAnEmployerAnyMore>().ToList();


        /* 
         * Just for an example you can write something like this.
         * 
         * In UI layer you might create an grid and in "end" cell
         * test if employer is NotAnEmployerAnyMore and write end
         * time only in that case. And if you were to use TypeScript
         * it would be really easy: 
         * 
         * interface Employer { type: 'current', id: string, name: string, begin: date }
         * interface GoneEmployer extends Employer { type: 'gone', end: date }
         * 
         * <td>{employer.type === 'gone' && employer.end}</td>
         */
        foreach (var employer in allEmployers)
        {
            string s = $"{employer.Name} ({employer.Begin} - ";
            if (employer is NotAnEmployerAnyMore gone)
            {
                s += $"{gone.End}";
            }
            s += ")";
            Console.WriteLine(s);
        }
    }
}
