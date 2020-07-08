using static System.Console;
using System;

namespace SocialApp
{
    class Program
    {
        static void Main()
        {
            try
            {               
                WriteLine("Insert friend name: ");
                var input = ReadLine();
                while (string.IsNullOrEmpty(input) || int.TryParse(input, out _))
                {
                    WriteLine("Please insert a name containing only letter: ");
                    input = ReadLine();
                }
                WriteLine();

                FriendsFinder obj = new FriendsFinder(input);

                obj.FriendsFinderMethod();
               
            }
            catch (Exception e)
            {
                WriteLine(e.Message);
            }
          
        }
    }
}