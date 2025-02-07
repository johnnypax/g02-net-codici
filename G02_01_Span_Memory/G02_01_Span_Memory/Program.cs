//char[] caratteri = { 'H', 'e', 'l', 'l', 'o', ' ', 'W', 'o', 'r', 'l', 'd' };
//Span<char> spanCaratteri = caratteri.AsSpan(6,5);
//Console.WriteLine(spanCaratteri.ToString());

using System.Diagnostics;

int counter = 10_000_000;

#region Variabile standard
var sw_uno = Stopwatch.StartNew();
for(int i=0; i< counter; i++)
{
    char[] caratteri = { 'H', 'e', 'l', 'l', 'o', ' ', 'W', 'o', 'r', 'l', 'd' };
    _ = caratteri[2];
}
sw_uno.Stop();
Console.WriteLine($"Tempo della variabile standard: {sw_uno.ElapsedMilliseconds}");
#endregion

#region Variabile Span
char[] caratteriDue = { 'H', 'e', 'l', 'l', 'o', ' ', 'W', 'o', 'r', 'l', 'd' };

var sw_due = Stopwatch.StartNew();
for (int i = 0; i < counter; i++)
{
    Span<char> spanCaratteri = caratteriDue.AsSpan();
    _ = spanCaratteri[2];
}
sw_due.Stop();
Console.WriteLine($"Tempo della variabile Span: {sw_due.ElapsedMilliseconds}");
#endregion

#region Variabile Memory
var sw_tre = Stopwatch.StartNew();
for (int i = 0; i < counter; i++)
{
    Memory<char> memoryCaratteri = caratteriDue.AsMemory();
    _ = memoryCaratteri.Span[2];
}
sw_tre.Stop();
Console.WriteLine($"Tempo della variabile Memory: {sw_tre.ElapsedMilliseconds}");
#endregion