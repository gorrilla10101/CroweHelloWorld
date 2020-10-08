using System;

namespace HelloWorldLibrary
{
    public abstract class HelloWorldWriterBase : IHelloWorldWriter
    {
        protected HelloWorldWriterOptions Options { get; }

        public HelloWorldWriterBase(HelloWorldWriterOptions options)
        {
            Options = options ?? throw new ArgumentNullException(nameof(options));
        }

        public abstract void Write();
    }
}