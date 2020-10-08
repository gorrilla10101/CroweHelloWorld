using System;

namespace HelloWorldLibrary
{
    public class HelloWorldWriterConsole : HelloWorldWriterBase
    {
        public HelloWorldWriterConsole(HelloWorldWriterOptions options) : base(options)
        {
        }

        public override void Write()
        {
            Console.WriteLine(Options.Text);
        }
    }
}