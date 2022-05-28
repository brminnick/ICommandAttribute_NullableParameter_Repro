namespace ICommandAttribute_NullableParameter_Repro;

partial class ViewModel
{
    [CommunityToolkit.Mvvm.Input.ICommand]
    void M1((DateTime? date, string? message, bool? shouldPrint, List<string>? stringList) parameter)
    {
        var (date, message, shouldPrint, stringList) = parameter;

        if (shouldPrint is not false)
        {
            Console.WriteLine(message + date.ToString());

            if (stringList is not null)
            {
                foreach (var text in stringList)
                    Console.WriteLine(text);
            }
        }
    }

    [CommunityToolkit.Mvvm.Input.ICommand]
    Task M2((DateTime? date, string? message, bool? shouldPrint, List<string>? stringList) parameter)
    {
        var (date, message, shouldPrint, stringList) = parameter;

        if (shouldPrint is not false)
        {
            Console.WriteLine(message + date.ToString());

            if (stringList is not null)
            {
                foreach (var text in stringList)
                    Console.WriteLine(text);
            }
        }

        return Task.CompletedTask;
    }
}

