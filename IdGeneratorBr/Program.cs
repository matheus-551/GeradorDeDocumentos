
using IdGeneratorBr.Services;
using TextCopy;

GeneratorService generator = new GeneratorService();

bool start = true;

Console.WriteLine("Gerador de documentos BR");

while (start)
{
    Console.WriteLine("1 - Gerar CPF");

    string? decision = Console.ReadLine();
    Console.WriteLine(" ");

    while (decision == null || decision != "1")
    {
        Console.WriteLine("Insira um valor válido.");

        Console.WriteLine("1 - Gerar CPF");

        decision = Console.ReadLine();
        Console.WriteLine(" ");
    }

    if (decision == "1")
    {
        var cpf = generator.GenerateCpf();
        Console.WriteLine($"{cpf}");
        ClipboardService.SetText(cpf);
        Console.WriteLine("CPF copiado para area de transferência.");
    }

    Console.WriteLine("Deseja gerar um novo documento?");
    decision = Console.ReadLine();

    if (decision == "1")
    {
        start = true;
    }
    else
    {
        start = false;
    }
}