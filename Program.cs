namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            QueueOperation.QueueProcessing();
        }
    }

    class QueueOperation
    {
        struct QueueTicket
        {
            public int iD = 1;
            //Unsused for now
            public string window;

            public QueueTicket(int id)
            {
                this.iD = id;
                this.window = string.Empty;
            }
        }
        public static void QueueProcessing()
        {
            int ticketCounter = 0;
            Queue<int> queue = new();
            List<string> waiting = new();
        
            Console.Clear();
            while (true)
            {
                Console.Clear();
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("Press Enter to get a ticket");

                Console.SetCursorPosition(Console.WindowWidth / 2, 1);
                Console.WriteLine("Waiting list:");
                for (int i = 0; i < waiting.Count && ticketCounter <= 30; i++)
                {
                    Console.SetCursorPosition(Console.WindowWidth / 2, 1 + i + 1);
                    Console.WriteLine(waiting[i]);
                }

                var keyInfo = Console.ReadKey(true);
                if (keyInfo.Key == ConsoleKey.Enter)
                {
                    if (ticketCounter == 30)
                    {
                        Console.Clear();
                        Console.WriteLine("Queue is full. Please wait for the next available ticket.");
                        Thread.Sleep(3000);
                        continue;
                    }
                    else
                    {
                    Console.SetCursorPosition(0, 2);
                    ticketCounter = (ticketCounter % 30) + 1;
                    QueueTicket ticket = new(ticketCounter);
                    waiting.Add(ticket.iD.ToString());
                    queue.Enqueue(ticket.iD);
                    Console.WriteLine("Your queue ticket number: " + ticket.iD);
                    Thread.Sleep(3000);
                    }
                }
                else
                {
                    switch (keyInfo.Key)
                    {
                        case ConsoleKey.D1:
                            if (queue.Count > 0)
                            {
                                var ticket = queue.Dequeue();
                                waiting.Remove(ticket.ToString());
                                Console.Clear();
                                Console.WriteLine("Ticket number " + ticket + " is served at window A");
                                Thread.Sleep(3000);
                            }
                            break;
                        case ConsoleKey.D2:
                            if (queue.Count > 0)
                            {
                                var ticket = queue.Dequeue();
                                waiting.Remove(ticket.ToString());
                                Console.Clear();
                                Console.WriteLine("Ticket number " + ticket + " is served at window B");
                                Thread.Sleep(3000);
                            }
                            break;
                        case ConsoleKey.D3:
                            if (queue.Count > 0)
                            {
                                var ticket = queue.Dequeue();
                                waiting.Remove(ticket.ToString());
                                Console.Clear();
                                Console.WriteLine("Ticket number " + ticket + " is served at window C");
                                Thread.Sleep(3000);
                            }
                            break;
                        case ConsoleKey.D4:
                            if (queue.Count > 0)
                            {
                                var ticket = queue.Dequeue();
                                waiting.Remove(ticket.ToString());
                                Console.Clear();
                                Console.WriteLine("Ticket number " + ticket + " is served at window D");
                                Thread.Sleep(3000);
                            }
                            break;
                        case ConsoleKey.D5:
                            if (queue.Count > 0)
                            {
                                var ticket = queue.Dequeue();
                                waiting.Remove(ticket.ToString());
                                Console.Clear();
                                Console.WriteLine("Ticket number " + ticket + " is served at window E");
                                Thread.Sleep(3000);
                            }
                            break;
                    }
                }
            }
        }
    }
}