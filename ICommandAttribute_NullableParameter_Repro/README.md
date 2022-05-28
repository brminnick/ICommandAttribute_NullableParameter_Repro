# ICommandAttribute_NullableParameter_Repro

In CommunityToolkit.Mvvm, when a tuple containing nullable reference types is used as a parameter for a method containing the attribute `[ICommand]`, the created `IAsyncRelayCommand` removes the nullability from each object.

```cs
[ICommand]
void M1((string? text, bool isBusy)
{
}
```

generates

```cs
public IRelayCommand<string text, bool isBusy> { get; }
// Should be `IRelayCommand<string? text, bool isBusy>`
```

## Reproduction Steps

1. Download/clone the following repo: https://github.com/brminnick/ICommandAttribute_NullableParameter_Repro
2. In Visual Studio, open `ICommandAttribute_NullableParameter_Repro.sln`
3. In Visual Studio, Build/Run the solution

## Reproduction Sample

The following code is also available in the following repo: https://github.com/brminnick/ICommandAttribute_NullableParameter_Repro

### ViewModel

```cs
partial class ViewModel
{
    /*
     *  // Auto-Generates The Following Code with the following bugs:
     *   `string message` should be `string? messge`
     *   `System.Collections.Generic.List<string> stringList` should be `System.Collections.Generic.List<string>? stringList`
     *  
     *  partial class ViewModel
        {
            /// <summary>The backing field for <see cref="M1Command"/>.</summary>
            [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ICommandGenerator", "8.0.0.0")]
            private global::CommunityToolkit.Mvvm.Input.RelayCommand<(global::System.DateTime? date, string message, bool? shouldPrint, global::System.Collections.Generic.List<string> stringList)>? m1Command;
            /// <summary>Gets an <see cref="global::CommunityToolkit.Mvvm.Input.IRelayCommand{T}"/> instance wrapping <see cref="M1"/>.</summary>
            [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ICommandGenerator", "8.0.0.0")]
            [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
            public global::CommunityToolkit.Mvvm.Input.IRelayCommand<(global::System.DateTime? date, string message, bool? shouldPrint, global::System.Collections.Generic.List<string> stringList)> M1Command => m1Command ??= new global::CommunityToolkit.Mvvm.Input.RelayCommand<(global::System.DateTime? date, string message, bool? shouldPrint, global::System.Collections.Generic.List<string> stringList)>(new global::System.Action<(global::System.DateTime? date, string message, bool? shouldPrint, global::System.Collections.Generic.List<string> stringList)>(M1));
        }
     */

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


    /*
    *  // Auto-Generates The Following Code with the following bugs:
    *   `string message` should be `string? messge`
    *   `System.Collections.Generic.List<string> stringList` should be `System.Collections.Generic.List<string>? stringList`
    *  
    *  partial class ViewModel
    {
        /// <summary>The backing field for <see cref="M2Command"/>.</summary>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ICommandGenerator", "8.0.0.0")]
        private global::CommunityToolkit.Mvvm.Input.AsyncRelayCommand<(global::System.DateTime? date, string message, bool? shouldPrint, global::System.Collections.Generic.List<string> stringList)>? m2Command;
        /// <summary>Gets an <see cref="global::CommunityToolkit.Mvvm.Input.IAsyncRelayCommand{T}"/> instance wrapping <see cref="M2"/>.</summary>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ICommandGenerator", "8.0.0.0")]
        [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public global::CommunityToolkit.Mvvm.Input.IAsyncRelayCommand<(global::System.DateTime? date, string message, bool? shouldPrint, global::System.Collections.Generic.List<string> stringList)> M2Command => m2Command ??= new global::CommunityToolkit.Mvvm.Input.AsyncRelayCommand<(global::System.DateTime? date, string message, bool? shouldPrint, global::System.Collections.Generic.List<string> stringList)>(new global::System.Func<(global::System.DateTime? date, string message, bool? shouldPrint, global::System.Collections.Generic.List<string> stringList), global::System.Threading.Tasks.Task>(M2));
    }
    */

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
```

```cs
class View
{
    public View()
    {
        var stringList = new List<string> { "Hello", "World" };

        var viewModel = new ViewModel();

        // No warning/error
        viewModel.M1Command.Execute((DateTime.UtcNow, "Hello World", true, stringList)); // No null values

        // No warning/error
        viewModel.M1Command.Execute((null, "Hello World", true, stringList)); // Pass `null` into Nullable struct

        // Yes Nullable Warning/Error
        viewModel.M1Command.Execute((DateTime.UtcNow, null, true, stringList)); // Pass `null` into Nullable string

        // No warning/error
        viewModel.M1Command.Execute((DateTime.UtcNow, "Hello World", null, stringList));  // Pass `null` into Nullable ValueType

        // Yes Nullable Warning/Error
        viewModel.M1Command.Execute((DateTime.UtcNow, "Hello World", true, null)); // Pass `null` into Nullable object


        // No warning/error
        await viewModel.M2Command.ExecuteAsync((DateTime.UtcNow, "Hello World", true, stringList)); // No null values

        // No warning/error
        await viewModel.M2Command.ExecuteAsync((null, "Hello World", true, stringList)); // Pass `null` into Nullable struct

        // Yes Nullable Warning/Error
        await viewModel.M2Command.ExecuteAsync((DateTime.UtcNow, null, true, stringList)); // Pass `null` into Nullable string

        // No warning/error
        await viewModel.M2Command.ExecuteAsync((DateTime.UtcNow, "Hello World", null, stringList)); // Pass `null` into Nullable ValueType

        // Yes Nullable Warning/Error
        await viewModel.M2Command.ExecuteAsync((DateTime.UtcNow, "Hello World", true, null)); // Pass `null` into Nullable object
    }
}
```