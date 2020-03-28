using System;
using System.Threading.Tasks;
using Amazon.Lambda.Core;
using Amazon.Lambda.RuntimeSupport;
using Amazon.Lambda.Serialization.Json;
using System.Text;
using System.Net.Http;

namespace TestLambda
{
    public class Functions
    {
        /// <summary>
        /// The main entry point for the custom runtime.
        /// </summary>
        /// <param name="args"></param>
        private static async Task Main(string[] args)
        {
            Func<string, ILambdaContext, Task<string>> func = FunctionHandler;
            using var handlerWrapper = HandlerWrapper.GetHandlerWrapper(func, new JsonSerializer());
            using var bootstrap = new LambdaBootstrap(handlerWrapper);
            await bootstrap.RunAsync();
        }

        /// <summary>
        /// A simple function that takes a string, does a ToUpper of the input
        /// and appends some random info from https://openlibrary.org
        /// </summary>
        /// <param name="input"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public static async Task<string> FunctionHandler(string input, ILambdaContext context)
        {
            var sb = new StringBuilder(input?.ToUpperInvariant());
            sb.Append("   ");

            var client = new HttpClient();
            var result = await client.GetAsync("https://openlibrary.org/api/books?bibkeys=OLID:OL13998706M");
            sb.Append(await result.Content.ReadAsStringAsync());

            return sb.ToString();
        }
    }
}
