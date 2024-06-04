using System.Collections.Concurrent;

namespace ConsoleApp1;

static class DataTypesSelection
{
    public static void IntegralTypes()
    {
        Console.WriteLine("Signed integral types:");

        Console.WriteLine($"sbyte: {sbyte.MinValue} to {sbyte.MaxValue}");
        Console.WriteLine($"short: {short.MinValue} to {short.MaxValue}");
        Console.WriteLine($"int: {int.MinValue} to {int.MaxValue}");
        Console.WriteLine($"long: {long.MinValue} to {long.MaxValue}");
        
        Console.WriteLine("\nUnsigned integral types:");

        Console.WriteLine($"byte: {byte.MinValue} to {byte.MaxValue}");
        Console.WriteLine($"ushort: {ushort.MinValue} to {ushort.MaxValue}");
        Console.WriteLine($"uint: {uint.MinValue} to {uint.MaxValue}");
        Console.WriteLine($"ulong: {ulong.MinValue} to {ulong.MaxValue}");

    }

    public static void FloatingPointTypes()
    {
        Console.WriteLine("Unsigned floating point types:");

        Console.WriteLine($"float: {float.MinValue} to {float.MaxValue}");
        Console.WriteLine($"double: {double.MinValue} to {double.MaxValue}");
        Console.WriteLine($"decimal: {decimal.MinValue} to {decimal.MaxValue}");
    }

    public static void ReferenceTypes()
    {
        int[] data = new int[3];
        string shortenedString = "hello world";
        Console.WriteLine(shortenedString);

        int[] ref_A = new int[1];
        ref_A[0] = 2;
        int[] ref_B = ref_A;
        ref_B[0] = 5;

        Console.WriteLine("--Reference types--");
        Console.WriteLine($"ref_A[0]: {ref_A[0]}");
        Console.WriteLine($"ref_B[0]: {ref_B[0]}");

        
    }
}

