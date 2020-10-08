using Xunit;
using HelloWorldLibrary;
using System;
using System.IO;

namespace HelloWorldTest
{
    public class HelloWorldConsoleWriterTest
    {
        [Fact]
        public void HelloWorldWriterWritesToConsole()
        {
            using (var writer = new StringWriter())
            {
                var options = new HelloWorldWriterOptions { Text = "Hello World" };
                var helloWorldWriter = new HelloWorldWriterConsole(options);
                Console.SetOut(writer);
                helloWorldWriter.Write();
                Assert.Equal($"Hello World{Environment.NewLine}", writer.GetStringBuilder().ToString());
            }

        }
    }
}
