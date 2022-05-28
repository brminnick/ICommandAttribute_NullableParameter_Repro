// See https://aka.ms/new-console-template for more information

using ICommandAttribute_NullableParameter_Repro;

var stringList = new List<string> { "Hello", "World" };

var viewModel = new ViewModel();
viewModel.M1Command.Execute((DateTime.UtcNow, "Hello World", true, stringList));
viewModel.M1Command.Execute((null, "Hello World", true, stringList));
viewModel.M1Command.Execute((DateTime.UtcNow, null, true, stringList));
viewModel.M1Command.Execute((DateTime.UtcNow, "Hello World", true, stringList));
viewModel.M1Command.Execute((DateTime.UtcNow, "Hello World", true, null));

await viewModel.M2Command.ExecuteAsync((DateTime.UtcNow, "Hello World", true, stringList));
await viewModel.M2Command.ExecuteAsync((null, "Hello World", true, stringList));
await viewModel.M2Command.ExecuteAsync((DateTime.UtcNow, null, true, stringList));
await viewModel.M2Command.ExecuteAsync((DateTime.UtcNow, "Hello World", null, stringList));
await viewModel.M2Command.ExecuteAsync((DateTime.UtcNow, "Hello World", true, null));