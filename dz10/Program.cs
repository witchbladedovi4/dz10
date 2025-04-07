namespace dz10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Money m1 = new(10, 50);
            Money m2 = new(5, 75);

            while (true)
            {
                Console.WriteLine("\nМеню операций с деньгами:");
                Console.WriteLine("1. Сложение денежных сумм");
                Console.WriteLine("2. Вычитание денежных сумм");
                Console.WriteLine("3. Деление суммы на целое число");
                Console.WriteLine("4.Умножение суммы на целое число");
                Console.WriteLine("5. Увеличение суммы на 1 копейку (++)");
                Console.WriteLine("6. Уменьшение суммы на 1 копейку (--)");
                Console.WriteLine("7. Сравнение сумм (<, >, ==, !=)");
                Console.WriteLine("8. Выход");
                Console.Write("Выберите операцию: ");

                try
                {
                    int choice = int.Parse(Console.ReadLine());

                    if (choice == 8) break;

                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine($"{m1} + {m2} = {m1 + m2}");
                            break;
                        case 2:
                            Console.WriteLine($"{m1} - {m2} = {m1 - m2}");
                            break;
                        case 3:
                            Console.Write("Введите делитель: ");
                            int divisor = int.Parse(Console.ReadLine());
                            Console.WriteLine($"{m1} / {divisor} = {m1 / divisor}");
                            break;
                        case 4:
                            Console.Write("Введите множитель: ");
                            int multiplier = int.Parse(Console.ReadLine());
                            Console.WriteLine($"{m1} * {multiplier} = {m1 * multiplier}");
                            break;
                        case 5:
                            Console.WriteLine($"m1++: {m1++}");
                            Console.WriteLine($"++m1: {++m1}");
                            break;
                        case 6:
                            Console.WriteLine($"m1--: {m1--}");
                            Console.WriteLine($"--m1: {--m1}");
                            break;
                        case 7:
                            Console.WriteLine($"{m1} > {m2}: {m1 > m2}");
                            Console.WriteLine($"{m1} < {m2}: {m1 < m2}");
                            Console.WriteLine($"{m1} == {m2}: {m1 == m2}");
                            Console.WriteLine($"{m1} != {m2}: {m1 != m2}");
                            break;
                        default:
                            Console.WriteLine("Неверный выбор операции");
                            break;
                    }
                }
                catch (BankruptException ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                }
            }
        }
    }
}
