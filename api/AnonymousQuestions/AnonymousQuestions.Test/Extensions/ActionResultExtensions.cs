using Microsoft.AspNetCore.Mvc;

namespace AnonymousQuestions.Test.Extensions
{
    public static class ActionResultExtensions
    {
        public static TResult Cast<TActionResult, TResult>(this IActionResult actionResult) where TActionResult : ObjectResult where TResult : class
        {
            var convertedActionResult = actionResult as TActionResult;
            return convertedActionResult.Value as TResult;
        }
    }
}
