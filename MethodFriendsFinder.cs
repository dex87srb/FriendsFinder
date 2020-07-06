using System.Collections.Generic;
using static System.Console;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace SocialApp
{
    class MethodFriendsFinder
    {
        static void Main()
        {
            try
            {
                string path = Path.GetFullPath(@"E:\dokumenti\Web programiranje kursevi i ostalo\C#\Projekti u toku\FriendsFinder\JSON database\dataFriends.json");

                WriteLine("Insert friend name: ");
                var input = ReadLine();
                while (string.IsNullOrEmpty(input) || int.TryParse(input, out _))
                {
                    WriteLine("Please insert a name containing only letter: ");
                    input = ReadLine();
                }
                WriteLine();

                using StreamReader sr = new StreamReader(path);
                string data = sr.ReadToEnd();

                dynamic array = JsonConvert.DeserializeObject(data);

                Dictionary<int, string> idsValuesPair = new Dictionary<int, string>();

                foreach (var item in array)
                {
                    JValue id = new JValue(item.id);
                    int idCast = (int)id;

                    JValue first = new JValue(item.firstName);
                    string firstCast = (string)first;

                    idsValuesPair.Add(idCast, firstCast);

                }

                WriteLine("Friends names are: ");

                foreach (var pairCollection in idsValuesPair)
                {
                    if (pairCollection.Value == input)
                    {
                        foreach (var parseJSON in array)
                        {
                            JArray friends = new JArray(parseJSON.friends);

                            for (int i = 0; i < friends.Count; i++)
                            {
                                if (pairCollection.Key == (int)friends[i])
                                {
                                    JValue firstN = new JValue(parseJSON.firstName);
                                    string firstCast = (string)firstN;
                                    WriteLine(firstCast);
                                }
                            }

                        }
                    }
                }
            }
            catch (Exception e)
            {
                WriteLine(e.Message);
            }
          
        }
    }
}