// See https://aka.ms/new-console-template for more information

using ICommandAttribute_NullableParameter_Repro;

var stringList = new List<string> { "Hello", "World" };

var viewModel = new ViewModel();
viewModel.M1Command.Execute((DateTime.UtcNow, "Hello World", true, stringList)); // No null values
viewModel.M1Command.Execute((null, "Hello World", true, stringList)); // Pass `null` into Nullable struct
viewModel.M1Command.Execute((DateTime.UtcNow, null, true, stringList)); // Pass `null` into Nullable string
viewModel.M1Command.Execute((DateTime.UtcNow, "Hello World", null, stringList));  // Pass `null` into Nullable ValueType
viewModel.M1Command.Execute((DateTime.UtcNow, "Hello World", true, null)); // Pass `null` into Nullable object

await viewModel.M2Command.ExecuteAsync((DateTime.UtcNow, "Hello World", true, stringList)); // No null values
await viewModel.M2Command.ExecuteAsync((null, "Hello World", true, stringList)); // Pass `null` into Nullable struct
await viewModel.M2Command.ExecuteAsync((DateTime.UtcNow, null, true, stringList)); // Pass `null` into Nullable string
await viewModel.M2Command.ExecuteAsync((DateTime.UtcNow, "Hello World", null, stringList)); // Pass `null` into Nullable ValueType
await viewModel.M2Command.ExecuteAsync((DateTime.UtcNow, "Hello World", true, null)); // Pass `null` into Nullable object