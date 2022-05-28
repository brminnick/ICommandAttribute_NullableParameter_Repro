namespace ICommandAttribute_NullableParameter_Repro;

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

