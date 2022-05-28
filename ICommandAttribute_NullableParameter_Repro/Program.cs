// See https://aka.ms/new-console-template for more information

using ICommandAttribute_NullableParameter_Repro;

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