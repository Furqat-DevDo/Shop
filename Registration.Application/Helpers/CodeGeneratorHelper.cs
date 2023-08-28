
namespace Registration.Application.Helpers;

public static class CodeGeneratorHelper
{
    public static int GeneratedCode()
    => new Random().Next(1000, 9999);
}
