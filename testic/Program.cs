class Program
{
    static void Main()
    {
        while (true)
        {
            TypingTest typingTest = new TypingTest();
            typingTest.RunTest();

            Console.Write("Ехало еще раз? (д/н): ");
            if (Console.ReadLine().ToLower() != "д")
                break;
        }
    }
}