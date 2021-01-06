using System;
using System.Reflection;
using Stl.CommandR.Configuration;

namespace Stl.CommandR.Internal
{
    public static class Errors
    {
        public static Exception CommandHandlerRegistryMustBeRegisteredAsInstance()
            => new InvalidOperationException("ICommandHandlerRegistry should be registered as instance.");
        public static Exception CommandHandlerRegistryInstanceIsNotRegistered()
            => new InvalidOperationException("ICommandHandlerRegistry instance is not registered.");
        public static Exception CommandResultTypeMismatch(Type expectedType, Type actualType)
            => new ArgumentException($"Command result type mismatch: expected '{expectedType}', got '{actualType}'");

        public static Exception CommandContextWasActivatedEarlier()
            => new InvalidOperationException("This CommandContext was already activated earlier.");
        public static Exception NoCurrentCommandContext()
            => new InvalidOperationException("CommandContext.Current is null - no command is running.");

        public static Exception NoHandlerFound(ICommand command)
            => new InvalidOperationException($"No handler is found for command {command}.");
        public static Exception NoFinalHandlerFound(ICommand command)
            => new InvalidOperationException($"No final handler is found for command {command}.");

        public static Exception InvalidCommandHandlerMethod(MethodInfo handlerMethod)
            => new InvalidOperationException($"Invalid command handler method: {handlerMethod}.");
        public static Exception CommandHandlerMethodMustReturnTask(MethodInfo handlerMethod)
            => new InvalidOperationException($"Command handler method must return Task or Task<T>: {handlerMethod}.");
        public static Exception WrongCommandHandlerMethodArgumentCount(MethodInfo handlerMethod)
            => new InvalidOperationException($"Command handler method must have at least 2 arguments: command and CancellationToken.");
        public static Exception WrongCommandHandlerMethodArguments(MethodInfo handlerMethod)
            => new InvalidOperationException($"Wrong command handler method arguments: {handlerMethod}.");

    }
}
